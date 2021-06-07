using System;
using XCommerce.Base.Helpers;

namespace XCommerce.Base.Formularios
{
    public partial class FormularioConsulta : FormularioBase
    {
        protected long? _entidadId;
        protected object _objetoSleccionado;

        public FormularioConsulta()
        {
            InitializeComponent();
            _entidadId = null;
            _objetoSleccionado = null;
        }
        public FormularioConsulta(string titulo)
            : this ()
        {
            lblTitulo.Text = titulo;
        }

        private void FormularioConsulta_Load(object sender, System.EventArgs e)
        {
            CargarEventoLoad();
            lblUsuario.Text = $@"Usuario: {Identidad.ApyNomEmpleadoLogin}";
        }

        private void CargarEventoLoad()
        {
            ACtualizarDatos(string.Empty);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            EjecutarImprimir();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ACtualizarDatos(string.Empty);
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (EjecutarNuevaEntidad())
            {
                ACtualizarDatos(string.Empty);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (VerificarSiHayDatosCargados())
            {
                if (VerificarSiSeleccionoObjeto())
                {
                    if (EjecutarEliminarEntidad(_entidadId))
                    {
                        ACtualizarDatos(string.Empty);
                    }
                }
                else
                {
                    Mensaje.Mostrar("No se selecciono ningun registro", Mensaje.Tipo.Stop);
                }
            }
            else
            {
                Mensaje.Mostrar("No hay datos cargados", Mensaje.Tipo.Stop);
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (VerificarSiHayDatosCargados())
            {
                if (VerificarSiSeleccionoObjeto())
                {
                    if (EjecutarModificarEntidad(_entidadId))
                    {
                        ACtualizarDatos(string.Empty);
                    }
                }
                else
                {
                    Mensaje.Mostrar("No se selecciono ningun registro", Mensaje.Tipo.Stop);
                }
            }
            else
            {
                Mensaje.Mostrar("No hay datos cargados", Mensaje.Tipo.Stop);
            }
        }

        //========================== METODOS ======================//
        public virtual void dgvGrilla_RowEnter(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _entidadId = (long)dgvGrilla["Id", e.RowIndex].Value;
                _objetoSleccionado = dgvGrilla.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                _entidadId = null;
                _objetoSleccionado = null;
            }
        }

        public virtual void ACtualizarDatos(string empty)
        {
        }
        public virtual void EjecutarImprimir()
        {
        }
        public virtual bool EjecutarNuevaEntidad()
        {
            return false;
        }
        public virtual bool EjecutarEliminarEntidad(long? _entidadId)
        {
            return false;
        }
        public virtual bool EjecutarModificarEntidad(long? _entidadId)
        {
            return false;
        }

        public bool VerificarSiSeleccionoObjeto()
        {
            return _entidadId.HasValue;
        }

        public bool VerificarSiHayDatosCargados()
        {
            return dgvGrilla.RowCount > 0;
        }
    }
}
