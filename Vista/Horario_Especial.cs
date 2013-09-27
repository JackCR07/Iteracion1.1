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
    public partial class Horario_Especial : Form
    {
        public Horario_Especial(String[] pHoras,String[] pDias,String[] pFuncionarios,String[] pTipo_Serivicios)
        {
            InitializeComponent();
            combo_Dias.Items.AddRange(pDias);
            combo_HoraInicio.Items.AddRange(pHoras);
            combo_HoraFinal.Items.AddRange(pHoras);
            combo_Funcionario.Items.AddRange(pFuncionarios);
            combo_Tipo_Servicio.Items.AddRange(pTipo_Serivicios);

            // Default Value
            combo_Dias.SelectedIndex = 0;
            combo_HoraInicio.SelectedIndex = 0;
            combo_HoraFinal.SelectedIndex = 1;
            combo_Funcionario.SelectedIndex = 0;
            combo_Tipo_Servicio.SelectedIndex = 0;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _Dias = (String)combo_Dias.SelectedItem;
            _Hora_Inicio = (String)combo_HoraInicio.SelectedItem;
            _Hora_Final = (String)combo_HoraFinal.SelectedItem;
            _Tipo_Servicio = (String)combo_Tipo_Servicio.SelectedItem;
            _Funcionario = (String)combo_Funcionario.SelectedItem;
            
            Agregar_Servicio();
            this.Dispose();
        }

        public void Agregar_Servicio()
        {
            if (Ev_Horario_Especial != null)
            {
                Ev_Horario_Especial(this, EventArgs.Empty);
            }
        }


        #region Propiedades

        public String Get_Funcionario
        {
            get { return _Funcionario; }
        }
        public String Get_Dias
        {
            get { return _Dias; }
        }
        public String Get_Hora_Inicio
        {
            get { return _Hora_Inicio; }
        }
        public String Get_Hora_Final
        {
            get { return _Hora_Final; }
        }

        public String Get_Tipo_Servicio
        {
            get { return _Tipo_Servicio; }
        }
        #endregion

        private String _Dias;
        private String _Hora_Inicio;
        private String _Hora_Final;
        private String _Funcionario;
        private String _Tipo_Servicio;

        public event EventHandler Ev_Horario_Especial;
    }
}
