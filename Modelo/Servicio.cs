using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Modelo
{
    public class Servicio
    {
        public Servicio(String pNombre, String pDescripcion, String pMonto, String  pId_Encargado,String pCupo_Disponible)
        {
            _Nombre = pNombre;
            _Descripcion = pDescripcion;
            _Monto = pMonto;
            _Id_Encargado = pId_Encargado;
            _Cupo_Disponible = pCupo_Disponible;
        }

        #region Propiedades

        public String getNombre
        {
            get { return _Nombre; }
        }

        public String getDescripcion
        {
            get { return _Descripcion; }
        }

        public String getMonto
        {
            get { return _Monto; }
        }

        public String getId_Encargado
        {
            get { return _Id_Encargado; }
        }

        public String getCupo_Disponible
        {
            get { return _Cupo_Disponible; }
        }

        #endregion


        private String _Nombre;
        private String _Descripcion;
        private String _Monto;
        private String _Id_Encargado;
        private String _Cupo_Disponible;
    }
}
