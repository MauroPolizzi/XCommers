using System;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.LogicaNegocio.PrimerIngresoSistema;

namespace XCommerce.Core.PrimerAcceso
{
    public partial class SplashScreen : Form
    {
        // Atributos / Variables
        private readonly ServicioInicio _servicioInicio;
        private readonly Timer tmr;
        private int segundos = 0;

        // Propiedades
        public bool EsPrimerAcceso { get; set; }

        public SplashScreen()
        {
            InitializeComponent();
            tmr = new Timer();
            _servicioInicio = new ServicioInicio();
        }
        private void tmr_Tick(object sender, EventArgs e)
        {
            //EsPrimerAcceso = _servicioInicio.VerificarSiEsPrimerAcceso();

            //after 3 sec stop the timer
            if (segundos > 4)
            {
                tmr.Stop();
                Close();
            }
            else
            {
                segundos += 1;
                progressBar1.Value += 20;
            }
        }

        private void SplashScreen_Load_1(object sender, EventArgs e)
        {
            //using (var context = new ModeloDatosContainer())
            //{
            //    if (!context.Database.Exists())
            //    {
            //        context.Database.CreateIfNotExists();
            //    }
            //}

            // establecer el intervalo de tiempo 3 seg
            tmr.Interval = 1000;
            // inicia el temporizador
            tmr.Start();
            
            tmr.Tick += tmr_Tick;
        }
    }
}
