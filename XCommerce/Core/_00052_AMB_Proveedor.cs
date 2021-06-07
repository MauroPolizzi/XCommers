using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.CondicionIva;
using XCommerce.LogicaNegocio.Proveedor;
using XCommerce.LogicaNegocio.Proveedor.DTOs;

namespace XCommerce.Core
{
    public partial class _00052_AMB_Proveedor: FormularioAbm
    {
        private readonly ProveedorServicios _proveedorServicios;
        private readonly CondicionIvaServicio _condicionIvaServicio;
        public _00052_AMB_Proveedor()
        {
            InitializeComponent();
        }

        public _00052_AMB_Proveedor(TipoOperacion tipoOperacion, long? entidadId = null)
            :base(tipoOperacion,entidadId)
        {
            _proveedorServicios = new ProveedorServicios();
            _condicionIvaServicio = new CondicionIvaServicio();

            InitializeComponent();

            CargarComboCondicion();

            Inicializador();
        }

        //============================  ===========================//
        private void CargarComboCondicion()
        {
            cmbCondicionIva.DataSource = _condicionIvaServicio.ObtenerTodo(string.Empty);
            cmbCondicionIva.ValueMember = "Id";
            cmbCondicionIva.DisplayMember = "Descripcion";
        }

        //============================  ===========================//
        public override void Inicializador()
        {
            base.Inicializador();

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            AgregarControlesObligatorios(txtRazonSocial, "Razon Social");
            AgregarControlesObligatorios(rtbDireccion,"Direccion");
            AgregarControlesObligatorios(txtTelefono,"Telefono");

            //**************** VALIDACION
            txtRazonSocial.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoInyeccion(sender,args);
                Validar.NoSimbolos(sender,args);
            };
            txtTelefono.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender,args);
                Validar.NoInyeccion(sender,args);
                Validar.NoLetras(sender,args);
            };
            rtbDireccion.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender,args);
                Validar.NoInyeccion(sender,args);
            };
            //****************

            if (_operacion == TipoOperacion.Insert)
            {
                txtRazonSocial.Focus();
            }
        }

        //============================  ===========================//
        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                var proveedor = _proveedorServicios.ObtenerPorId(entidadId);

                txtRazonSocial.Text = proveedor.RazonSocial;
                txtTelefono.Text = proveedor.Telefono;
                txtEmail.Text = proveedor.Email;
                rtbDireccion.Text = proveedor.Direccion;

                cmbCondicionIva.Text = proveedor.CondicionIva;

                if (_operacion == TipoOperacion.Delete)
                {
                    DesactivarControles(this,false);
                }
                else
                {
                    txtRazonSocial.Focus();
                }
            }
        }

        //============================  ===========================//
        public override void EjecutarComandoInsert()
        {
            try
            {
                var proveedor = new ProveedorDto
                {
                    Direccion = rtbDireccion.Text,
                    Email = txtEmail.Text,
                    RazonSocial = txtRazonSocial.Text,
                    Telefono = txtTelefono.Text,
                    CondicionIvaId = (long)cmbCondicionIva.SelectedValue
                };

                _proveedorServicios.Insertar(proveedor);
                LimpiarControles(this);
                txtRazonSocial.Focus();
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al guardar los datos", Mensaje.Tipo.Informacion);
            }
        }

        //============================  ===========================//
        public override void EjecutarComandoUpDate()
        {
            try
            {
                var proveedorModificar = new ProveedorDto
                {
                    Id = EntidadId.Value,
                    RazonSocial = txtRazonSocial.Text,
                    Direccion = rtbDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text,
                    CondicionIvaId = (long) cmbCondicionIva.SelectedValue
                };

                _proveedorServicios.Modificar(proveedorModificar);
                Close();
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al modificar el proveedor", Mensaje.Tipo.Informacion);
            }
        }

        //============================  ===========================//
        public override void EjecutarComandoDelete()
        {
            try
            {
                _proveedorServicios.Eliminar(EntidadId);
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al eliminar el proveedor", Mensaje.Tipo.Informacion);
            }
        }

        //============================  ===========================//
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
