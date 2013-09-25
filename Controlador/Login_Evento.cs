using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vista;
using System.Windows.Forms;
using System.Threading;

namespace Controlador
{
    class Login_Evento
    {
        static void Main(string[] args)
        {

                Restart_Login();

        }

        public static void Restart_Login()
        {
            Login prueba = new Login();
            Manejo_Eventos mane = new Manejo_Eventos(prueba);
            mane.Iniciar();
        }

    }
}
