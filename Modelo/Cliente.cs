using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente 
    {
        public Cliente(int pIdentificacion, String pNombre, String pTelefonoUno, String pTelefonoDos)
        {
            _Identificacion = pIdentificacion;
            _Nombre = pNombre;
            _TelefonoUno = pTelefonoUno;
            _TelefonoDos = pTelefonoDos;
        }
        #region Propiedades
        public int getIdenticacion
        {
            get { return _Identificacion; }
        }

        public String getNombre
        {
            get { return _Nombre; }
        }

        public String getTelefonoUno
        {
            get { return _TelefonoUno; }
        }

        public String getTelefonoDos
        {
            get { return _TelefonoDos; }
        }
        #endregion


        #region Atributos
        private int _Identificacion;
        private String _Nombre;
        private String _TelefonoUno;
        private String _TelefonoDos;
        #endregion
    }
}
