using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data;
using MySql.Data.MySqlClient;

namespace Data
{
    public class Emisor_Data
    {
        private Emisor_Data() { }

        /// <summary>
        /// Uso de singleton con el parerametro de instance para el uso de un solo objeto
        /// </summary>
        public static Emisor_Data getInstance
        {
            get
            {
                  if(_Instancia==null)
                  {
                      _Instancia = new Emisor_Data();
                  }
                  return _Instancia;
            }
        }

        #region Almacenamiento en BD


        /// <summary>
        /// Almacena un Servicio // Contiene un id de un funcionario y arraylist de los horarios
        /// </summary>
        /// <param name="pDato"></param>
        /// <returns></returns>
        public bool Almacenar_Servicio(Servicio pDato,Horario pHorario)
        {
            Conector coneccion = new Conector();
            float cost = float.Parse(pDato.getMonto);
            bool conecto = coneccion.OpenConnection();
            if (conecto)
            {
                MySqlCommand cmd = new MySqlCommand("almacenarhorarioxservicio", coneccion.connection);
                cmd.Parameters.Add(new MySqlParameter("ids", pDato.getNombre));
                cmd.Parameters.Add(new MySqlParameter("dia", pHorario.getDias));
                cmd.Parameters.Add(new MySqlParameter("h1", pHorario.getHora_Inicio.ToString()+":00"));
                cmd.Parameters.Add(new MySqlParameter("h2", pHorario.getHora_Final.ToString() + ":00"));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            conecto = coneccion.CloseConnection();
            return true;
        }

        /// <summary>
        /// Almacena un Servicio de tipo ESPECIAL, habiamos hablado que esto era algun tipo de flag en los servicios
        /// </summary>
        /// <param name="pDato"></param>
        /// <param name="pHorario"></param>
        /// <returns></returns> Si nose puede almacenar el servicio devuelve false de lo contrario True
        public bool Almacenar_Servicio_Especial(Servicio pDato, Horario pHorario)
        {
            Conector coneccion = new Conector();
            bool conecto = coneccion.OpenConnection();
            if (conecto)
            {
                MySqlCommand cmd = new MySqlCommand("horarioespecial", coneccion.connection);
                cmd.Parameters.Add(new MySqlParameter("nom", pDato.getNombre));
                cmd.Parameters.Add(new MySqlParameter("dia", pHorario.getDias));
                cmd.Parameters.Add(new MySqlParameter("h1", pHorario.getHora_Inicio.ToString() + ":00"));
                cmd.Parameters.Add(new MySqlParameter("h2", pHorario.getHora_Final.ToString() + ":00"));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            conecto = coneccion.CloseConnection();
            return true;
        }

        /// <summary>
        /// Dado un id de servicio caerle encima a sus datos con los del nuevo servicio, a excepcion del nombre del servicio
        /// Si lo atributos vienen en vacio , no hacer UPDATE DE ESE ATRIBUTO
        /// </summary>
        /// <param name="pId_Servicio_A_Modificar"></param> Este dato tiene que ser validado, si no existe el id de servicio seleccionado , RETORNA FALSE
        /// <param name="pNuevo_Servicio"></param>
        /// <param name="pNuevo_Horario"></param>
        /// <returns></returns>
        public bool Modificar_Servicio(String pId_Servicio_A_Modificar, Servicio pNuevo_Servicio, Horario pNuevo_Horario)
        {
            Conector coneccion = new Conector();
            float cost = float.Parse(pNuevo_Servicio.getMonto);
            bool res = false;
            bool conecto = coneccion.OpenConnection();
            if (conecto)
            {
                MySqlCommand cmd = new MySqlCommand("modificarservicio", coneccion.connection);
                cmd.Parameters.Add(new MySqlParameter("idhs", pId_Servicio_A_Modificar));
                cmd.Parameters.Add(new MySqlParameter("cup", pNuevo_Servicio.getCupo_Disponible));
                cmd.Parameters.Add(new MySqlParameter("cost", cost));
                cmd.Parameters.Add(new MySqlParameter("dia", pNuevo_Horario.getDias));
                cmd.Parameters.Add(new MySqlParameter("h1", pNuevo_Horario.getHora_Inicio.ToString() + ":00"));
                cmd.Parameters.Add(new MySqlParameter("h2", pNuevo_Horario.getHora_Final.ToString() + ":00"));
                cmd.Parameters.Add(new MySqlParameter("res", res));
                cmd.Parameters[6].Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                if (cmd.Parameters[6].Value.ToString() == "1")
                {
                    res = true;
                }
            }
            conecto = coneccion.CloseConnection();
            return res;
        }

        /// <summary>
        /// Dado un Id de servicio, eliminarlo de la base de datos
        /// </summary>
        /// <param name="pId_Servicio_A_Eliminar"></param> Validar que el id de servicio exista, de lo contrario devolver false
        /// <returns></returns>
        public bool Eliminar_Servicio(String pId_Servicio_A_Eliminar)
        {
            Conector coneccion = new Conector();
            bool res = false;
            bool conecto = coneccion.OpenConnection();
            if (conecto)
            {
                MySqlCommand cmd = new MySqlCommand("eliminarservicio", coneccion.connection);
                cmd.Parameters.Add(new MySqlParameter("ids", pId_Servicio_A_Eliminar));
                cmd.Parameters.Add(new MySqlParameter("res", res));
                cmd.Parameters[1].Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                if (cmd.Parameters[1].Value.ToString() == "1")
                {
                    res = true;
                }
            }
            conecto = coneccion.CloseConnection();
            return res;
        }

        /// <summary>
        /// Almacena los contratos // 
        /// ***en la base de datos se debe hacer un split de los servicios id que vienen en ej: 1,2,3 -- Devuelve false si algun id no existe
        /// ***en la base de datos de debe validar la identificacion del usuario -- devuelve false si no existe el usuario
        /// </summary>
        /// <param name="pDato"></param>
        /// <returns></returns>
        public bool Almacenar_Contrato(Contrato pDato)
        {
            Conector coneccion = new Conector();
            bool res = false;
            bool conecto = coneccion.OpenConnection();
            float costo = 0;
            int idco = 0;
            string[] idservicios = pDato.getId_Servicios.Split(',');
            int n = idservicios.Length;
            if (conecto)
            {
                MySqlCommand cmd;
                int i = 0;
                while (n > 0)
                {
                    cmd = new MySqlCommand("Costoservicio", coneccion.connection);
                    cmd.Parameters.Add(new MySqlParameter("ids", idservicios[i]));
                    cmd.Parameters.Add(new MySqlParameter("cost", costo));
                    cmd.Parameters.Add(new MySqlParameter("res", res));
                    cmd.Parameters[1].Direction = ParameterDirection.Output;
                    cmd.Parameters[2].Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    if (cmd.Parameters[2].Value.ToString() == "1")
                    {
                        res = true;
                        costo += float.Parse(cmd.Parameters[1].Value.ToString());
                    }
                    else
                    {
                        res = false;
                        break;
                    }

                    i++;
                    n--;
                }
                if (res != false)
                {
                    cmd = new MySqlCommand("NuevoContrato", coneccion.connection);
                    cmd.Parameters.Add(new MySqlParameter("niño", pDato.getNombre_Beneficiado));
                    cmd.Parameters.Add(new MySqlParameter("cost", costo));
                    cmd.Parameters.Add(new MySqlParameter("funcionarioid", pDato.getId_Funcionario));
                    cmd.Parameters.Add(new MySqlParameter("user", pDato.getId_Cliente));
                    cmd.Parameters.Add(new MySqlParameter("res", res));
                    cmd.Parameters.Add(new MySqlParameter("idc", idco));
                    cmd.Parameters[4].Direction = ParameterDirection.Output;
                    cmd.Parameters[5].Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    if (cmd.Parameters[4].Value.ToString() == "1")
                    {
                        res = true;
                        idco = int.Parse(cmd.Parameters[5].Value.ToString());
                    }
                    else
                        res = false;

                }
                if (res != false)
                {
                    i = 0;
                    n = idservicios.Length;
                    while (n > 0)
                    {
                        cmd = new MySqlCommand("enlazarcontratohorario", coneccion.connection);
                        cmd.Parameters.Add(new MySqlParameter("idc", idco));
                        cmd.Parameters.Add(new MySqlParameter("ids", idservicios[i]));
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        i++;
                        n--;
                    }
                }
            }

            Console.WriteLine(costo);
            return res;
        }

        /// <summary>
        /// Almacena contratos , con al la funcion extra de usar un horario predeterminado.
        /// </summary>
        /// <param name="pDato"></param>
        /// <param name="pHorario"></param>
        /// <returns></returns>
        public bool Almacenar_Contrato_Especial(Contrato pDato, Horario pHorario)
        {
            return false;
        }
        
        #endregion

        private static Emisor_Data _Instancia;
    }
}
