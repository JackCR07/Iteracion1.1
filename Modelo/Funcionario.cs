using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Funcionario 
    {
        public Funcionario(String pNombre, int pIdentificacion, String pConstrasenia, String pTipo)
        {
            _Nombre = pNombre;
            _Identificacion = pIdentificacion;
            _Contrasenia = pConstrasenia;
            _Tipo = pTipo;
        }


        #region Propiedades
        public String getNombre
        {
            get { return _Nombre; }
        }

        public int getIdentificacion
        {
            get { return _Identificacion; }
        }

        public String getContrasenia
        {
            get { return _Contrasenia; }
        }

        public String getTipo
        {
            get { return _Tipo; }
        }

        #endregion

        private String _Nombre;
        private int _Identificacion;
        private String _Contrasenia;      //ESTO HAY QUE CIFRARLO
        private String _Tipo;
    }
}
