using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Menu_Principal : Form
    {
        #region Constructor
        public Menu_Principal(bool pEs_Root,String[] pEncargados,String[] pTipo_Servicios)
        {
            InitializeComponent();
            box_Agre_Encargado.Items.AddRange(pEncargados);
            box_Mod_Encargado.Items.AddRange(pEncargados);
            box_Agre_NombreServicio.Items.AddRange(pTipo_Servicios);

            Agre_Combo_HoraInicio.Items.AddRange(_Horas_Default);
            Agre_Combo_HoraFinal.Items.AddRange(_Horas_Default);
            Agre_Combo_Dias.Items.AddRange(_Dias_Default);
            

            Mod_Combo_HoraInicio.Items.AddRange(_Horas_Default);
            Mod_Combo_HoraFinal.Items.AddRange(_Horas_Default);
            Mod_Combo_Dias.Items.AddRange(_Dias_Default);

            // DEFAULT VALUES
            box_Agre_Encargado.SelectedIndex = 0;
            box_Mod_Encargado.SelectedIndex = 0;
            box_Agre_NombreServicio.SelectedIndex = 0;

            Agre_Combo_HoraInicio.SelectedIndex = 0;
            Agre_Combo_HoraFinal.SelectedIndex = 1;
            Agre_Combo_Dias.SelectedIndex = 0;

            Mod_Combo_HoraInicio.SelectedIndex = 0;
            Mod_Combo_HoraFinal.SelectedIndex = 1;
            Mod_Combo_Dias.SelectedIndex = 0;


            if (!pEs_Root)
            { 
                tab_Agregar.Dispose();
                tab_Modificar.Dispose();
                tab_Eliminar.Dispose();
            }

            _Tipo_Servicios = pTipo_Servicios;
            _Encargados = pEncargados;
        }
        #endregion
        //==================== Boton de Mostrar lista de Servicios
        private void button6_Click(object sender, EventArgs e)
        {
            Lista_Servicios();
        }


        public void Lista_Servicios()
        {
            if (Abrir_Lista_Servicios != null)
            {
                if (check_Especiales.Checked)
                {
                    Abrir_Lista_Servicios(true, EventArgs.Empty);
                }
                else
                {
                    Abrir_Lista_Servicios(false, EventArgs.Empty);

                }
            }
        }
        //=======================================================

        //================= Boton de Generar Contrato y evento
        private void button2_Click(object sender, EventArgs e)
        {
            _Nombre_Cliente = txt_Cliente.Text;
            _Nombre_Beneficiado = txt_Beneficiado.Text;
            _Seleccion_Servicio = txt_Servicios.Text;
            Generar_Contrato();
        }

        public void Generar_Contrato()
        {
            if (Abrir_Generar_Contrato != null)
            {
                Abrir_Generar_Contrato(this, EventArgs.Empty);
            }
        }


        //====================================================

        //======================= Boton para volver a login
        private void button1_Click_1(object sender, EventArgs e)
        {
            Abrir_Login();
        }

        public void Abrir_Login()
        {
            if (Volver_Login != null)
            {
                Volver_Login(null, EventArgs.Empty);
            }
        }
        //=================================================

        //============================ Bonton Agregar nuevo servicio
        private void button4_Click(object sender, EventArgs e)
        {
            _Seleccion_Servicio = (String)box_Agre_NombreServicio.SelectedItem;
            _Encargado = (String)box_Agre_Encargado.SelectedItem;
            _Dias = (String)Agre_Combo_Dias.SelectedItem;
            _Hora_Inicio = (String)Agre_Combo_HoraInicio.SelectedItem;
            _Costo = nume_Agre_Costo.Text;
            _Hora_Final = (String)Agre_Combo_HoraFinal.SelectedItem;
            _Cupo_Disponible = nume_Agre_CupoDisponible.Text;
            if(txt_Agre_Descripcion.Text==null)
            {
                _Descripcion = "No hay despcripcion del servicio";
            }
            else
            {
                _Descripcion = txt_Agre_Descripcion.Text;
            }
            Guardar_Servicio();
        }

        public void Guardar_Servicio()
        {
            if (Almacenar_Servicio != null)
            {
                Almacenar_Servicio(this, EventArgs.Empty);
            }
        }
        //======================================================


        //============================== Boton Modificar un Servicio

        private void button7_Click(object sender, EventArgs e)
        {
            int Temp;
            if (int.TryParse(txt_Mod_NumeroServicio.Text, out Temp))
            {
                _Id_Servicio = txt_Mod_NumeroServicio.Text;
                _Encargado = (String)box_Mod_Encargado.SelectedItem;
                _Dias = (String)Mod_Combo_Dias.SelectedItem;
                _Hora_Inicio = (String)Mod_Combo_HoraInicio.SelectedItem;
                _Costo = nume_Mod_Costo.Text;
                _Hora_Final = (String)Mod_Combo_HoraFinal.SelectedItem; ;
                _Cupo_Disponible = nume_Mod_CupoDisponible.Text;
                if (txt_Mod_Descripcion.Text == null)
                {
                    _Descripcion = "No hay despcripcion del servicio";
                }
                else
                {
                    _Descripcion = txt_Mod_Descripcion.Text;
                }
                Modificar_Servicio();
            }
            else
            {
                _Ventana_Error = new Errorcs();
                Thread Hilo_Error = new Thread(Iniciar_Ventana_Error);
                Hilo_Error.Start();
            }
        }

        public void Modificar_Servicio()
        {
            if (Modificar_Servi != null)
            {
                Modificar_Servi(this, EventArgs.Empty);
            }
        }
        //=========================================================

        //====================================== Boton de Eliminar Servicio

        private void button3_Click(object sender, EventArgs e)
        {

            int Temp;
            if (int.TryParse(txt_Eli_NumeroServicio.Text, out Temp))
            {
                _Id_Servicio = txt_Eli_NumeroServicio.Text;
                _Ventana_Confirmacion = new Eliminar_Servicio();
                _Ventana_Confirmacion.Ev_Confirma_Elminar += Eliminar_Servicio;
                Thread Hilo_Confirmacion = new Thread(Iniciar_Ventana);
                Hilo_Confirmacion.Start();
            }
            else
            {
                _Ventana_Error = new Errorcs();
                Thread Hilo_Error = new Thread(Iniciar_Ventana_Error);
                Hilo_Error.Start();
            }
        }


        public void Iniciar_Ventana()
        {
            Application.Run(_Ventana_Confirmacion);
        }
        public void Eliminar_Servicio(Object Sender,EventArgs e)
        {
            if (Ev_Eliminar_Servicio != null)
            {
                Ev_Eliminar_Servicio(_Id_Servicio, EventArgs.Empty);
            }
        }

        //================================================================


        //============================================= Boton Servicio Especial

        private void button5_Click(object sender, EventArgs e)
        {
            _Ventana_Especial = new Horario_Especial(_Horas_Default, _Dias_Default, _Encargados, _Tipo_Servicios);
            _Ventana_Especial.Ev_Horario_Especial += Agregar_Nuevo_Servicio_Especial;
            Thread Hilo_Especial = new Thread(Iniciar_Ventana_Especial);
            Hilo_Especial.Start();
        }

        private void Iniciar_Ventana_Especial()
        {
            Application.Run(_Ventana_Especial);
        }

        public void Agregar_Nuevo_Servicio_Especial(Object Sender,EventArgs e)
        {
            if (Ev_Agregar_Servicio_Especial != null)
            {
               Ev_Agregar_Servicio_Especial(Sender, EventArgs.Empty);
            }
        }



        //=========================================================

        private void Iniciar_Ventana_Error()
        {
            Application.Run(_Ventana_Error);
        }

        #region Propiedades de Text Box

        public String Get_Cliente
        {
            get { return _Nombre_Cliente; }
        }

        public String Get_Beneficiado
        {
            get { return _Nombre_Beneficiado; }
        }

        public String Get_Seleccion_Servicio
        {
            get { return _Seleccion_Servicio; }
        }
        #endregion

        #region Propiedades de Manejo de Servicios
        public String Get_Encargado
        {
            get { return _Encargado; }
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
        public String Get_Costo
        {
            get { return _Costo; }
        }

        public String Get_Descripcion
        {
            get { return _Descripcion; }
        }
        public String Get_Id_Servicio
        {
            get { return _Id_Servicio; }
        }

        public String Get_Cupo_Disponible
        {
            get { return _Cupo_Disponible; }
        }

        #endregion

        #region Atributos

        private Eliminar_Servicio _Ventana_Confirmacion;
        private Horario_Especial _Ventana_Especial;
        private Errorcs _Ventana_Error;
        

        private String _Nombre_Cliente;
        private String _Nombre_Beneficiado;
        private String _Seleccion_Servicio;
        private String _Encargado;
        private String _Dias;
        private String _Hora_Inicio;
        private String _Costo;
        private String _Descripcion;
        private String _Hora_Final;
        private String _Id_Servicio;
        private String _Cupo_Disponible;

        public event EventHandler Abrir_Generar_Contrato;
        public event EventHandler Abrir_Lista_Servicios;
        public event EventHandler Volver_Login;
        public event EventHandler Almacenar_Servicio;
        public event EventHandler Modificar_Servi;
        public event EventHandler Ev_Eliminar_Servicio;
        public event EventHandler Ev_Agregar_Servicio_Especial;

        private String[] _Horas_Default = new String[] { "7:00", "8:00", "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
        private String[] _Dias_Default = new String[] {"L","K","M","J","V","L-K","L-M","L-J","L-V","K-M","K-J","K-V","M-J","M-V","J-V" };
        private String[] _Tipo_Servicios;
        private String[] _Encargados;



        #endregion


        #region Auto Generado
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Principal_Load(object sender, EventArgs e)
        {

        }
        #endregion














        }
}
