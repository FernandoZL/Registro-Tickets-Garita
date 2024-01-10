using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registro_Tickets_Garita
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FormRegistro
            FormRegistro formRegistro = new FormRegistro();

            // Ocultar el formulario actual (Menu)
            this.Hide();

            // Mostrar el formulario FormRegistro
            formRegistro.ShowDialog();

            // Mostrar nuevamente el formulario actual (Menu) al cerrar el FormRegistro
            this.Show();

        }



        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
