using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Base.Helpers;
using XCommerce.Core;
using XCommerce.Core.PrimerAcceso;

namespace XCommerce
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //var splashScreen = new SplashScreen();
            //splashScreen.ShowDialog();

            //if (!splashScreen.EsPrimerAcceso)
            //{
            //    var formularioPrimerAcceso = new FormularioPrimerAcceso(TipoOperacion.Insert);
            //    formularioPrimerAcceso.ShowDialog();
            //}

            //var login = new _00000_Login();
            //login.ShowDialog();

            //if (login.PuedeAccederAlSistema)
            //{
            //    Application.Run(new Principal());
            //}
            //else
            //{
            //    Application.Exit();
            //}

            var principal = new _00045_Kiosco();
            principal.ShowDialog();

            //Application.Run(new _00003_Usuario());

        }
    }
}
