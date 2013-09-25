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
    public partial class Eliminar_Servicio : Form
    {
        public Eliminar_Servicio()
        {
            InitializeComponent();
        }

        // Boton de Si
        private void button1_Click(object sender, EventArgs e)
        {
            Confirmar_Eliminar_Servicio();
            this.Dispose();
        }

        public void Confirmar_Eliminar_Servicio()
        {
            if (Ev_Confirma_Elminar != null)
            {
                Ev_Confirma_Elminar(null, EventArgs.Empty);
            }
        }


        //Boton de No
        private void button_No_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public event EventHandler Ev_Confirma_Elminar;
    }
}
