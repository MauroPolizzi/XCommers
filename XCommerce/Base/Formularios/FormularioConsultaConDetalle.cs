using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using XCommerce.Base.Helpers;

namespace XCommerce.Base.Formularios
{
    public partial class FormularioConsultaConDetalle : FormularioBase
    {
        protected long? EntidadId;
        protected object ObjetoSeleccionado;

        public FormularioConsultaConDetalle()
        {
            InitializeComponent();
            AsignarImagenBotones();
            EntidadId = null;
            ObjetoSeleccionado = null;
        }
        public FormularioConsultaConDetalle(string titulo)
            :this()
        {
            lblTitulo.Text = titulo;
        }
        private void FormularioConsultaConDetalle_Load(object sender, EventArgs e)
        {
            EjecutarEventoLoad();
            lblUsuario.Text = $@"Usuario: {Identidad.ApyNomEmpleadoLogin}";
        }
        //======================== METODOS ======================//
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (VerificarSiExistenDatos())
            {
                EjecutarComandoImprimir();
            }
            else
            {
                Mensaje.Mostrar("No hay dato cargado", Mensaje.Tipo.Informacion);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarDatos(string.Empty);
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (VerificarSiExistenDatos())
            {
                if (VerificoSeSelecionoAlguno())
                {
                    if (EjecutarComanoUpDate(EntidadId))
                    {
                        ActualizarDatos(string.Empty);
                    }
                }
                else
                {
                    Mensaje.Mostrar("No se selecciono un regitro", Mensaje.Tipo.Informacion);
                }
            }
            else
            {
                Mensaje.Mostrar("No hay dato cargado", Mensaje.Tipo.Informacion);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (VerificarSiExistenDatos())
            {
                if (VerificoSeSelecionoAlguno())
                {
                    if (EjecutarComandoDelete(EntidadId))
                    {
                        ActualizarDatos(string.Empty);
                    }
                }
                else
                {
                    Mensaje.Mostrar("No selecciono ningun regitro", Mensaje.Tipo.Advertencia);
                }
            }
            else
            {
                Mensaje.Mostrar("No existe dato para borrar", Mensaje.Tipo.Stop);
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (EjecutarNuevaEntidad())
            {
                ActualizarDatos(string.Empty);
            }
        }

        //======================== METODOS ======================//
        public virtual bool VerificoSeSelecionoAlguno()
        {
            return EntidadId.HasValue;
        }

        public virtual bool EjecutarComanoUpDate(long? entidadId)
        {
            return false;
        }

        public virtual bool VerificarSiExistenDatos()
        {
            return dgvGrilla.RowCount > 0;
        }
        public virtual void EjecutarComandoImprimir()
        {
        }
        public virtual void ActualizarDatos(string empty)
        {
        }
        public virtual bool EjecutarComandoDelete(long? entidadId)
        {
            return false;
        }
        public virtual bool EjecutarNuevaEntidad()
        {
            return false;
        }
        private void AsignarImagenBotones()
        {

        }

        public virtual void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (VerificarSiExistenDatos())
            {
                EntidadId = (long) dgvGrilla["Id", e.RowIndex].Value;
                ObjetoSeleccionado = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                EntidadId = null;
                ObjetoSeleccionado = null;
            }
        }
        public virtual void EjecutarEventoLoad()
        {
            ActualizarDatos(string.Empty);
        }
    }
}
