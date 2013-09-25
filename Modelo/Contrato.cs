using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Modelo
{
    public class Contrato
    {
        public Contrato(String pId_Servicios, String pId_Funcionarios, String pId_Cliente, String pNombre_Beneficiado)
        {
            _Id_Servicios = pId_Servicios;
            _Id_Funcionario = pId_Funcionarios;
            _Id_Cliente = pId_Cliente;
            _Nombre_Beneficiado = pNombre_Beneficiado;
        }

        #region Propiedades

        public String getId_Servicios
        {
            get { return _Id_Servicios; }
        }

        public String getId_Funcionario
        {
            get { return _Id_Funcionario; }
        }

        public String getId_Cliente
        {
            get { return _Id_Cliente; }
        }

        public String getNombre_Beneficiado
        {
            get { return _Nombre_Beneficiado; }
        }


        #endregion

        #region Atributos
        private String _Id_Servicios;    // hay que hacer un split  : 1,2,3
        private String _Id_Funcionario;
        private String _Id_Cliente;
        private String _Nombre_Beneficiado;
        #endregion
    }
}
