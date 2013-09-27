using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Vista
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Usuario = txt_Usuario.Text;
            _Contrasenia = txt_Contrasenia.Text;
            Cambios_Login();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public String getUsuario
        {
            get { return _Usuario; }
        }
        public String getContrasenia
        {
            get { return _Contrasenia; }
        }

        public void Cambios_Login()
        {
            if (Cambio_De_Datos != null)
            {
                Cambio_De_Datos(this, EventArgs.Empty);
            }
        }

        public event EventHandler Cambio_De_Datos;
        private String _Usuario;
        private String _Contrasenia;

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
