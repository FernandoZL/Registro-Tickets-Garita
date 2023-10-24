using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

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
            string registro = $"{id}, {numeroTurno}, {fechaYHora}, {textBoxNombre.Text}, {textBoxApellido.Text}, {textBoxLicencia.Text}, {textBoxProveedor.Text}";

            // Agregar un título si el archivo no existe
            if (!File.Exists(registrosFilePath))
            {
                File.WriteAllText(registrosFilePath, "ID, Turno, Fecha y Hora, Nombre, Apellido, No. Licencia, Proveedor" + Environment.NewLine);
            }

            // Escribir la línea en el archivo de registros
            File.AppendAllText(registrosFilePath, registro + Environment.NewLine);

            // Guardar el último ID
            GuardarUltimoID();

            // Imprimir el ticket
            ImprimirTicket(id, numeroTurno, fechaYHora, textBoxNombre.Text, textBoxApellido.Text, textBoxLicencia.Text, textBoxProveedor.Text);

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


        private void ImprimirTicket(int id, int turno, DateTime fechaYHora, string nombre, string apellido, string licencia, string proveedor)
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

                    // Título "Bienvenido a Suministros y Alimentos"
                    string tituloBienvenido = "Suministros y Alimentos";
                    e.Graphics.DrawString(tituloBienvenido, titleFont, textBrush, x, y);
                    y += 30;

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

                    // string numeroID = $"Registro: {id}";
                    string titulonumeroID = "Registro:";
                    string numeroID = $" {id}";
                    e.Graphics.DrawString(titulonumeroID, titleFont, textBrush, x, y);
                    e.Graphics.DrawString(numeroID, normalFont, textBrush, x, y + titleFont.GetHeight());
                    y += 10;

                    // Línea horizontal (ajustada al ancho del papel)
                    e.Graphics.DrawLine(linePen, x, y + 40, x + lineaLongitud, y + 40);

                    // Agradecimiento y número de ID
                    string agradecimiento = "¡Gracias por visitarnos!";


                    y += 40;

                    e.Graphics.DrawString(agradecimiento, titleFont, textBrush, x, y);



                }
            };

            // Configurar la impresora (opcional)
            PrintDialog printDialog = new PrintDialog();
            printDocument.PrinterSettings = printDialog.PrinterSettings;

            // Imprimir el documento
            printDocument.Print();
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


    }
}
