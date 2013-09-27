using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Data
{
    public class Receptor_Data
    {
         private Receptor_Data() { }

        /// <summary>
        /// Implementacion del patron singleton para la llamada al receptor
        /// </summary>
        public static Receptor_Data getInstance
        {
            get
            {
                  if(_Instancia==null)
                  {
                      _Instancia = new Receptor_Data();
                  }
                  return _Instancia;
            }
        }

        /// <summary>
        /// Manda los datos a la bd, para saber si el usuario existe
        /// </summary>
        /// <param name="pUsuario"></param>
        /// <param name="pContrasenia"></param>
        /// <returns></returns>
        /// devuelve el tipo de usuarios si existe, en caso que no encuentre el usuario devolvera "NULL"
        public String Es_Usuario(String pUsuario, String pContrasenia)
        {
            Conector coneccion = new Conector();
            String tipousuario = "";
            bool conecto = coneccion.OpenConnection();
            if (conecto)
            {
                bool res = false;
                MySqlCommand cmd = new MySqlCommand("ValidarUsuario", coneccion.connection);
                cmd.Parameters.Add(new MySqlParameter("nom", pUsuario));
                cmd.Parameters.Add(new MySqlParameter("pass", pContrasenia));
                cmd.Parameters.Add(new MySqlParameter("res", res));
                cmd.Parameters.Add(new MySqlParameter("tipou", tipousuario));
                cmd.Parameters[2].Direction = ParameterDirection.Output;
                cmd.Parameters[3].Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                if (cmd.Parameters[2].Value.ToString() == "1")
                {
                    tipousuario = cmd.Parameters[3].Value.ToString();
                }
            }
            conecto = coneccion.CloseConnection();
            return tipousuario; 
            
        }

        /// <summary>
        /// Devuelve en un String, todos los servicios numerados con su nombre,dia,hora y encargado
        /// EJ: 1. Natacion L-M 13:00-!4:00 Carlos_Montana
        ///     2. Basket ....
        /// </summary>
        /// <returns></returns>
        /// RETORNA un  STRING CON su RESPECTIVO ID, para hacer el calculo de costo,,, separa con enter por cada columna
        public String getLista_Servicios()
        {
            Conector coneccion = new Conector();
            String servicios = "";
            bool conecto = coneccion.OpenConnection();
            if (conecto)
            {
                MySqlCommand cmd = new MySqlCommand("listaservicios", coneccion.connection);
                cmd.Parameters.Add(new MySqlParameter("lista", servicios));
                cmd.Parameters[0].Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                servicios = cmd.Parameters[0].Value.ToString();
            }
            conecto = coneccion.CloseConnection();
            return servicios;
        }

        /// <summary>
        /// Retorna en el mismo formato de getLista_Servicios, con la restriccion que no devuelve los servicios que estan marcados como especiales
        /// </summary>
        /// <returns></returns>
        public String getLista_Servicios_Sin_Especiales()
        {
            Conector coneccion = new Conector();
            String servicios = "";
            bool conecto = coneccion.OpenConnection();
            if (conecto)
            {
                MySqlCommand cmd = new MySqlCommand("listaserviciosespeciales", coneccion.connection);
                cmd.Parameters.Add(new MySqlParameter("lista", servicios));
                cmd.Parameters[0].Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                servicios = cmd.Parameters[0].Value.ToString();
            }
            conecto = coneccion.CloseConnection();
            return servicios;
        }


        /// <summary>
        /// Devuevle una lista de todos los nombres de los funcionario de tipo maestro en un array de String[]
        /// </summary>
        /// <returns></returns>
        public String[] getLista_Funcionarios_Maestros()
        {
            Conector coneccion = new Conector();
            String[] funcionarios=null;
            bool conecto = coneccion.OpenConnection();
            if (conecto)
            {
                MySqlCommand cmd = new MySqlCommand("listaroot", coneccion.connection);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader dr=cmd.ExecuteReader();
                funcionarios = new string[(dr.FieldCount+1)];
                int i = 0;
                while (dr.Read())
                {
                    funcionarios[i] = dr[0].ToString();
                    i++;
                }
                dr.Close();
            }
            conecto = coneccion.CloseConnection();
            return funcionarios;
        }

        /// <summary>
        /// Retorna todos los nombres de los tipos de servicios en un String[]
        /// </summary>
        /// <returns></returns>
        public String[] getLista_Tipo_Servicios()
        {
            Conector coneccion = new Conector();
            String servicios = null;
            bool conecto = coneccion.OpenConnection();
            if (conecto)
            {
                MySqlCommand cmd = new MySqlCommand("listaservicioshe", coneccion.connection);
                cmd.Parameters.Add(new MySqlParameter("serv", servicios));
                cmd.Parameters[0].Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                servicios = cmd.Parameters[0].Value.ToString();
            }
            conecto = coneccion.CloseConnection();
            return servicios.ToString().Split(',');
        }


        private static Receptor_Data _Instancia;
    }
}
