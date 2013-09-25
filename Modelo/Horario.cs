using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Modelo
{
    public class Horario
    {
        public Horario(String pHora_Inicio, String pHora_Final, String pDias)
        {
            _Hora_Inicio = pHora_Inicio;
            _Hora_Final = pHora_Final;
            _Dias = pDias;
        }

        #region Propiedades
        public String getHora_Inicio
        {
            get { return _Hora_Inicio; }
        }
        public String getHora_Final
        {
            get { return _Hora_Final; }
        }
        public String getDias
        {
            get { return _Dias; }
        }

        #endregion

        private String _Hora_Inicio;
        private String _Hora_Final;
        private String _Dias;
    }
}
