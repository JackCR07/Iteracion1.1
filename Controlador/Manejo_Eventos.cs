using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vista;
using Data;
using Modelo;
using System.Windows.Forms;
using System.Threading;

namespace Controlador
{
    class Manejo_Eventos
    {
        public Manejo_Eventos(Login pLogin_View)
        {
            _Login_View = pLogin_View;
        }

        /// <summary>
        /// Empieza a traerse los datos del login con el observer
        /// </summary>
        internal void Iniciar()
        {
            _Login_View.Cambio_De_Datos += Validar_Usuario;
            Application.EnableVisualStyles();
            Application.Run(_Login_View);
        }

        private void Validar_Usuario(Object sender, EventArgs e)
        {
            String pUsuario =  ((Login)sender).getUsuario;
            String pContrasenia = ((Login)sender).getContrasenia;
            Console.WriteLine("NOMBRE " + pUsuario );
            Console.WriteLine("Constra " + pContrasenia );
            
            switch (Receptor_Data.getInstance.Es_Usuario(pUsuario, pContrasenia))
            {
                case "ROOT":
                    _Funcionario_Actual = pUsuario;
                    _Login_View.Hide();
                    _Hilo_Menu_Principal = new Thread(Correr_Menu);
                    _Hilo_Menu_Principal.Start(true);
                    _Abrir_Login = false;
                    Esconder_Login();
                    break;
                case "USUARIO":
                    _Funcionario_Actual = pUsuario;
                    _Login_View.Hide();
                    _Hilo_Menu_Principal = new Thread(Correr_Menu);
                    _Hilo_Menu_Principal.Start(false);
                     _Abrir_Login = false;
                    Esconder_Login();
                    break;
                case "NULL":
                    Console.WriteLine("EL USUARIO NO EXISTE");
                    break;
                default:
                    Console.WriteLine("ESTE USUARIO NO PUEDE USAR LA APP");
                    break;

            }

        }
        #region Eventos del Menu Principal

        private void Correr_Menu(Object pEs_Root)
        {
            _Menu_Princiapal = new Menu_Principal((bool)pEs_Root,Receptor_Data.getInstance.getLista_Funcionarios_Maestros());
            _Menu_Princiapal.Abrir_Lista_Servicios += Abrir_Lista_Servicios;
            _Menu_Princiapal.Abrir_Generar_Contrato += Generar_Contrato;
            _Menu_Princiapal.Volver_Login += Volver_Ventana_Login;
            _Menu_Princiapal.Almacenar_Servicio += Almacenar_Servicio;
            _Menu_Princiapal.Modificar_Servi += Modificar_Servicio;
            _Menu_Princiapal.Ev_Eliminar_Servicio += Eliminar_Servicio;
            Application.Run(_Menu_Princiapal);
        }

        private void Abrir_Lista_Servicios(Object sender, EventArgs e)
        {
            Thread Hilo_Ventana = new Thread(Ventana_Servicios);
            Hilo_Ventana.Start(Receptor_Data.getInstance.getLista_Servicios());
        }
        private void Generar_Contrato(Object sender, EventArgs e)
        {
            Menu_Principal _Temp = (Menu_Principal) sender;
            Contrato _Nuevo_Contrato = new Contrato(_Temp.Get_Seleccion_Servicio,_Funcionario_Actual,_Temp.Get_Cliente,_Temp.Get_Beneficiado);
            if(Emisor_Data.getInstance.Almacenar_Contrato(_Nuevo_Contrato))
            {
                Thread Hilo_Generar_Contrato = new Thread(Ventana_Exito);
                Hilo_Generar_Contrato.Start();
            }
            else
            {
                Thread Hilo_Generar_Contrato = new Thread(Ventana_Denegada);
                Hilo_Generar_Contrato.Start();
            }

        }
        //================================== Regresar a la ventana de login
        private void Volver_Ventana_Login(Object sender, EventArgs e)
        {

            _Menu_Princiapal.Dispose();
            _Abrir_Login = true;
            _Hilo_Menu_Principal.Abort();

        }
        public void Esconder_Login()
        { while(!_Abrir_Login) {}
            _Login_View.Show();
        }

        private void Almacenar_Servicio(Object sender, EventArgs e)
        {
            Menu_Principal _Valores = (Menu_Principal)sender;
            Servicio _Nuevo_Servicio = new Servicio(_Valores.Get_Seleccion_Servicio, _Valores.Get_Descripcion, _Valores.Get_Costo, _Valores.Get_Encargado,_Valores.Get_Cupo_Disponible);
            Horario _Nuevo_Horario = new Horario(_Valores.Get_Hora_Inicio, _Valores.Get_Hora_Final, _Valores.Get_Dias);
            if (Emisor_Data.getInstance.Almacenar_Servicio(_Nuevo_Servicio,_Nuevo_Horario))
            {
                Thread Hilo_Generar_Contrato = new Thread(Ventana_Exito);
                Hilo_Generar_Contrato.Start();
            }
            else
            {
                Thread Hilo_Generar_Contrato = new Thread(Ventana_Denegada);
                Hilo_Generar_Contrato.Start();
            }
        }

        private void Modificar_Servicio(Object sender, EventArgs e)
        {
            Menu_Principal _Valores = (Menu_Principal)sender;
            Servicio _Mod_Servicio = new Servicio("", _Valores.Get_Descripcion, _Valores.Get_Costo, _Valores.Get_Encargado,_Valores.Get_Cupo_Disponible);
            Horario _Mod_Horario = new Horario(_Valores.Get_Hora_Inicio, _Valores.Get_Hora_Final, _Valores.Get_Dias);
            if (Emisor_Data.getInstance.Modificar_Servicio(_Valores.Get_Id_Servicio,_Mod_Servicio, _Mod_Horario))
            {
                Thread Hilo_Generar_Contrato = new Thread(Ventana_Exito);
                Hilo_Generar_Contrato.Start();
            }
            else
            {
                Thread Hilo_Generar_Contrato = new Thread(Ventana_Denegada);
                Hilo_Generar_Contrato.Start();
            }
        }

        private void Eliminar_Servicio(Object sender, EventArgs e)
        {
            if (Emisor_Data.getInstance.Eliminar_Servicio((string)sender))
            {
                Thread Hilo_Generar_Contrato = new Thread(Ventana_Exito);
                Hilo_Generar_Contrato.Start();
            }
            else
            {
                Thread Hilo_Generar_Contrato = new Thread(Ventana_Denegada);
                Hilo_Generar_Contrato.Start();
            }
        }
        // =================================================================

        #region Llamados a Ventanas
        // Imprime los servicios actuales con su respectivo id
        private void Ventana_Servicios(Object pLista_Servicios)
        {
            Lista_Servicios _Servicios = new Lista_Servicios((String)pLista_Servicios);
            Application.Run(_Servicios);
        }

        // Ventana de transaccion exitosa
        private void Ventana_Exito(Object pLista_Servicios)
        {
            Accion_Exitosa _Exito = new Accion_Exitosa();
            Application.Run(_Exito);
        }

        //Venta de transaccion erronea
        private void Ventana_Denegada(Object pLista_Servicios)
        {
            Accion_Denegada _Denegada = new Accion_Denegada();
            Application.Run(_Denegada);
        }


        #endregion

        #endregion

        private Login _Login_View;
        private Menu_Principal _Menu_Princiapal;
        private Thread _Hilo_Menu_Principal;
        private String _Funcionario_Actual;
        private bool _Abrir_Login;
        
    }
}
