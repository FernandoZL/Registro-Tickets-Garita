using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GmailMessage = Google.Apis.Gmail.v1.Data.Message;


namespace Registro_Tickets_Garita
{
    public partial class FormRegistro : Form
    {
        private int idIncremental = 1; // Variable para el ID incremental
        private int numeroTurno = 1; // Variable para el número de turno
        private DateTime ultimoInicioDelDia = DateTime.Now.Date; // Variable para el último inicio del día
        private string registrosFilePath; // Ruta del archivo de registros

        public FormRegistro()
        {
            InitializeComponent();
            // Establecer la ruta del archivo de registros
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string registrosFolder = Path.Combine(baseDirectory, "Registros");
            if (!Directory.Exists(registrosFolder))
            {
                Directory.CreateDirectory(registrosFolder);
            }
            registrosFilePath = Path.Combine(registrosFolder, "registros.csv");

            // Cargar el último ID desde un archivo (si existe)
            CargarUltimoID();
            // Verificar si se inicia un nuevo día
            if (DateTime.Now.Date != ultimoInicioDelDia)
            {
                numeroTurno = 1;
                ultimoInicioDelDia = DateTime.Now.Date;
            }
        }

        private List<Registro> registros = new List<Registro>();

        private void btnRegistrar_Click(object sender, EventArgs e)
        {


            // Incrementar el ID
            int id = idIncremental++;

            // Capturar la fecha y hora actual
            DateTime fechaYHora = DateTime.Now;

            // Crear una línea de registro
            string registro = $"{id}, {numeroTurno}, {fechaYHora}, {textBoxNombre.Text}, {textBoxApellido.Text}, {textBoxLicencia.Text}, {textBoxProveedor.Text},{textBoxPlacas.Text}";

            // Agregar un título si el archivo no existe
            if (!File.Exists(registrosFilePath))
            {
                File.WriteAllText(registrosFilePath, "ID, Turno, Fecha y Hora, Nombre, Apellido, No. Licencia, Proveedor, Placas" + Environment.NewLine);
            }

            // Escribir la línea en el archivo de registros
            File.AppendAllText(registrosFilePath, registro + Environment.NewLine);

            // Guardar el último ID
            GuardarUltimoID();

            // Imprimir el ticket
            ImprimirTicket(id, numeroTurno, fechaYHora, textBoxNombre.Text, textBoxApellido.Text, textBoxLicencia.Text, textBoxProveedor.Text, textBoxPlacas.Text);

            // Enviar un correo electrónico con los datos
            EnviarCorreoElectronico(id, numeroTurno, fechaYHora, textBoxNombre.Text, textBoxApellido.Text, textBoxLicencia.Text, textBoxProveedor.Text, textBoxPlacas.Text);

            // Mostrar un mensaje de éxito o hacer otras acciones necesarias
            MessageBox.Show("Registro completado.Turno: " + numeroTurno);

            // Incrementar el número de turno
            numeroTurno++;

            // Reiniciar los campos de entrada si es necesario
            LimpiarCampos();

        }

        private void CargarUltimoID()
        {
            string idFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ultimo_id.txt");

            if (File.Exists(idFilePath) && int.TryParse(File.ReadAllText(idFilePath), out int id))
            {
                idIncremental = id;
            }
        }

        private void GuardarUltimoID()
        {
            string idFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ultimo_id.txt");
            File.WriteAllText(idFilePath, idIncremental.ToString());
        }

        private void LimpiarCampos()
        {
            // Lógica para limpiar los campos de entrada después de registrar
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxLicencia.Clear();
            textBoxProveedor.Clear();
            textBoxPlacas.Clear();
        }

        private void ImprimirTicket(int id, int turno, DateTime fechaYHora, string nombre, string apellido, string licencia, string proveedor, string placas)
        {
            // Crear un documento para imprimir
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) =>
            {
                using (System.Drawing.Font titleFont = new System.Drawing.Font("Arial", 14, FontStyle.Bold))
                using (System.Drawing.Font normalFont = new System.Drawing.Font("Arial", 12))
                using (Pen linePen = new Pen(Color.Black, 2)) // Pincel para la línea
                using (SolidBrush textBrush = new SolidBrush(Color.Black)) // Pincel para el texto
                {
                    int x = 10; // Margen izquierdo
                    int y = 10; // Margen superior


                    // Obtener la ruta de la imagen en la carpeta Debug
                    string rutaImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SysAmall.jpg"); // Reemplaza con el nombre y extensión de tu imagen

                    // Agregar la imagen centrada
                    Image imagen = Image.FromFile(rutaImagen);
                    int imagenAncho = 172; // Ancho deseado de la imagen
                    int imagenAltura = 74; // Altura deseada de la imagen
                    int centrarX = (e.PageBounds.Width - imagenAncho) / 2; // Calcular la posición X para centrar la imagen
                    e.Graphics.DrawImage(imagen, centrarX, y, imagenAncho, imagenAltura); // Ajusta la posición y el tamaño de la imagen centrada
                    y += imagenAltura + 20; // Ajusta el espacio después de la imagen

                    // Título "Descarga de proveedores!" centrado
                    string tituloBienvenido = "" +
                    "¡Descarga de proveedores!";
                    SizeF tituloSize = e.Graphics.MeasureString(tituloBienvenido, titleFont);
                    int centrarXTitulo = (e.PageBounds.Width - (int)tituloSize.Width) / 2; // Calcular la posición X para centrar el título
                    e.Graphics.DrawString(tituloBienvenido, titleFont, textBrush, centrarXTitulo, y);
                    y += (int)tituloSize.Height + 30; // Ajusta el espacio después del título



                    // Título "Turno" en negrita
                    string tituloTurno = "Turno";
                    string valorTurno = turno.ToString();
                    e.Graphics.DrawString(tituloTurno, titleFont, textBrush, x, y);
                    e.Graphics.DrawString(valorTurno, titleFont, textBrush, x + 100, y); // Ajusta la posición del turno
                    y += 40;

                    // Línea horizontal (ajustada al ancho del papel)
                    int lineaLongitud = 250; // Ancho de la línea
                    e.Graphics.DrawLine(linePen, x, y, x + lineaLongitud, y);
                    y += 20;

                    // Otros detalles (ajustados al ancho del papel)
                    string tituloFecha = "Fecha y Hora:";
                    string valorFecha = fechaYHora.ToString();
                    e.Graphics.DrawString(tituloFecha, titleFont, textBrush, x, y);
                    e.Graphics.DrawString(valorFecha, normalFont, textBrush, x, y + titleFont.GetHeight());
                    y += 40;

                    string tituloNombre = "Nombre:";
                    string valorNombre = nombre;
                    e.Graphics.DrawString(tituloNombre, titleFont, textBrush, x, y);
                    e.Graphics.DrawString(valorNombre, normalFont, textBrush, x, y + titleFont.GetHeight());
                    y += 40;

                    string tituloApellido = "Apellido:";
                    string valorApellido = apellido;
                    e.Graphics.DrawString(tituloApellido, titleFont, textBrush, x, y);
                    e.Graphics.DrawString(valorApellido, normalFont, textBrush, x, y + titleFont.GetHeight());
                    y += 40;

                    // ... continúa con otros detalles

                    string tituloLicencia = "No. Licencia:";
                    string valorLicencia = licencia;
                    e.Graphics.DrawString(tituloLicencia, titleFont, textBrush, x, y);
                    e.Graphics.DrawString(valorLicencia, normalFont, textBrush, x, y + titleFont.GetHeight());
                    y += 40;

                    string tituloProveedor = "Proveedor:";
                    string valorProveedor = proveedor;
                    e.Graphics.DrawString(tituloProveedor, titleFont, textBrush, x, y);
                    e.Graphics.DrawString(valorProveedor, normalFont, textBrush, x, y + titleFont.GetHeight());
                    y += 40;

                    string tituloPlacas = "Placas:";
                    string valorPlacas = placas;
                    e.Graphics.DrawString(tituloPlacas, titleFont, textBrush, x, y);
                    e.Graphics.DrawString(valorPlacas, normalFont, textBrush, x, y + titleFont.GetHeight());
                    y += 40;

                    // string numeroID = $"Registro: {id}";
                    string titulonumeroID = "Registro:";
                    string numeroID = $" {id}";
                    e.Graphics.DrawString(titulonumeroID, titleFont, textBrush, x, y);
                    e.Graphics.DrawString(numeroID, normalFont, textBrush, x, y + titleFont.GetHeight());
                    y += 50;

                    // Línea horizontal (ajustada al ancho del papel)
                    e.Graphics.DrawLine(linePen, x, y + 40, x + lineaLongitud, y + 40);

                    // Agradecimiento centrado
                    string agradecimiento = "¡Gracias por visitarnos!";
                    SizeF agradecimientoSize = e.Graphics.MeasureString(agradecimiento, titleFont);
                    int centrarXAgradecimiento = (e.PageBounds.Width - (int)agradecimientoSize.Width) / 2; // Calcular la posición X para centrar el agradecimiento
                    e.Graphics.DrawString(agradecimiento, titleFont, textBrush, centrarXAgradecimiento, y);
                    y += (int)agradecimientoSize.Height + 40; // Ajusta el espacio después del agradecimiento

                    // Despedida centrada
                    string despedida = "¡Hasta luego!";
                    SizeF despedidaSize = e.Graphics.MeasureString(despedida, titleFont);
                    int centrarXDespedida = (e.PageBounds.Width - (int)despedidaSize.Width) / 2; // Calcular la posición X para centrar la despedida
                    e.Graphics.DrawString(despedida, titleFont, textBrush, centrarXDespedida, y);
                    y += (int)despedidaSize.Height + 20; // Ajusta el espacio después de la despedida



                }
            };

            // Configurar la impresora (opcional)
            PrintDialog printDialog = new PrintDialog();
            printDocument.PrinterSettings = printDialog.PrinterSettings;

            // Imprimir el documento
            printDocument.Print();
            // Después de imprimir el ticket, enviar un correo electrónico

        }

        private void EnviarCorreoElectronico(int id, int turno, DateTime fechaYHora, string nombre, string apellido, string licencia, string proveedor, string placas)
        {
            UserCredential credential;

            string credencialesJsonPath = "credentials.json"; // Reemplaza con la ruta a tu archivo JSON de credenciales

            using (var stream = new FileStream(credencialesJsonPath, FileMode.Open, FileAccess.Read))
            {
                string[] scopes = { GmailService.Scope.GmailSend };

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets
,
                    scopes,
                    "fernando.zuniga@foodservice.com.gt", // Cambia "usuario@gmail.com" por tu dirección de correo
                    CancellationToken.None,
                    new FileDataStore(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tokens"))
                ).Result;
            }

            var gmailService = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Reg_Entrada"
            });

            var mensaje = new AE.Net.Mail.MailMessage
            {
                Subject = $"Nuevo registro: {proveedor} - Ingreso: {fechaYHora}",
                Body = $"Hola Equipo de Supply gusto en saludarles,\n\n" +
        $"Se ha registrado un nuevo turno con ID {id}. Comparto los detalles:  \n\n" +
        $"Turno: {turno}\n" +
        $"Fecha y Hora: {fechaYHora}\n" +
        $"Nombre: {nombre}\n" +
        $"Apellido: {apellido}\n" +
        $"No. Licencia: {licencia}\n" +
        $"Proveedor: {proveedor}\n\n" +
        $"Placas: {placas}\n\n" +
        "Saludos cordiales.\n\n" +
        "Mejora Continua Procesos RPA | Supply Chain\n\n" +
        "D: 12 av 1-93 zona 2 de Mixco Colonia Alvarado, Guatemala\n" +
        "W: www.foodservice.com.gt\n\n" +
        "Nota: Este es un correo automatico, por favor no respondas a esta direccion de correo electronico.\n\n"
            };

            var mimeMessage = new MimeKit.MimeMessage();
            mimeMessage.From.Add(new MimeKit.MailboxAddress("NUEVO INGRESO - GARITA", "fernando.zuniga@foodservice.com.gt"));

            // Cadena de destinatarios separados por comas
            string destinatarios = "mejoracontinua.rpa@foodservice.com.gt,procesos@foodservice.com.gt,bodegacd@foodservice.com.gt,brayan.morales@foodservice.com.gt,dania.reyes@foodservice.com.gt,kely.felipe@foodservice.com.gt";

            // Divide la cadena de destinatarios por comas
            string[] direcciones = destinatarios.Split(',');

            // Crea una lista para almacenar las direcciones de correo electrónico
            List<MimeKit.MailboxAddress> listaDestinatarios = new List<MimeKit.MailboxAddress>();

            // Recorre las direcciones y crea objetos MimeKit.MailboxAddress
            foreach (string direccion in direcciones)
            {
                listaDestinatarios.Add(new MimeKit.MailboxAddress(direccion.Trim(), direccion.Trim()));
            }

            // Agrega la lista de destinatarios al campo "Para" del mensaje
            mimeMessage.To.AddRange(listaDestinatarios);

            mimeMessage.Subject = mensaje.Subject;
            mimeMessage.Body = new MimeKit.TextPart("plain")
            {
                Text = mensaje.Body
            };


            var gmailMessage = new GmailMessage
            {
                Raw = Base64UrlEncode(mimeMessage.ToString())
            };


            var request = gmailService.Users.Messages.Send(gmailMessage, "me"); // "me" se refiere al usuario autenticado

            try
            {
                request.Execute();
                Console.WriteLine("Correo electrónico enviado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo electrónico: " + ex.Message);
            }
        }

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(inputBytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .TrimEnd('=');
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            // Código que deseas ejecutar cuando cambia el texto en el control textBoxNombre.
        }

        private void textBoxApellido_TextChanged(object sender, EventArgs e)
        {
            // Código que deseas ejecutar cuando cambia el texto en el control textBoxApellido.
        }

        private void textBoxLicencia_TextChanged(object sender, EventArgs e)
        {
            // Código que deseas ejecutar cuando cambia el texto en el control textBoxLicencia.
        }
        private void textBoxProveedor_TextChanged(object sender, EventArgs e)
        {
            // Código que deseas ejecutar cuando cambia el texto en el control textBoxProveedor.
        }

        private void textBoxPlacas_TextChanged(object sender, EventArgs e)
        {
            // Código que deseas ejecutar cuando cambia el texto en el control textBoxPlacas.
        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {

        }
    }
}
