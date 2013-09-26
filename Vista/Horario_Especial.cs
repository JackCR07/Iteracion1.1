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
        }
    }
}
