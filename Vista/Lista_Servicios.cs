using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Vista
{
    public partial class Lista_Servicios : Form
    {
        public Lista_Servicios(String pLista_Servicios)
        {
            InitializeComponent();
            txt_servicios.AppendText(pLista_Servicios);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
