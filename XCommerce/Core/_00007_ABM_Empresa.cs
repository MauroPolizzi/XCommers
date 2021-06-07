using System;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.CondicionIva;
using XCommerce.LogicaNegocio.Empresa;
using XCommerce.LogicaNegocio.Empresa.DTOs;
using XCommerce.LogicaNegocio.Seguridad;

namespace XCommerce.Core
{
    public partial class _00007_ABM_Empresa : FormularioAbm
    {
        private readonly EmpresaServicio _empresaServicio;
        private readonly CondicionIvaServicio _condicionIvaServicio;

        //=============================== CONSTRUCTOR ===============================//
        public _00007_ABM_Empresa()
        {
            InitializeComponent();
        }

        public _00007_ABM_Empresa(TipoOperacion operacion, long? entidadId = null)
            :base(operacion, entidadId)
        {
            InitializeComponent();

            _empresaServicio = new EmpresaServicio();
            _condicionIvaServicio = new CondicionIvaServicio();

            Inicializador();
        }

        public override void Inicializador()
        {
            base.Inicializador();

            PoblarComboCondicionIva();

            AgregarControlesObligatorios(txtRazonSocial,"Razon Social");
            AgregarControlesObligatorios(txtCuit,"Cuit");
            AgregarControlesObligatorios(txtTelefono,"Telefono");
            AgregarControlesObligatorios(rtbDomicilio,"Domicilio");

            //************ verificaciones *************

            txtRazonSocial.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
            };
            txtCuit.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoLetras(sender, args);
                Validar.NoInyeccion(sender, args);
            };
            txtTelefono.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoLetras(sender, args);
                Validar.NoInyeccion(sender, args);
                Validar.NoSimbolos(sender, args);
            };
            rtbDomicilio.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoInyeccion(sender, args);
                Validar.NoSimbolos(sender, args);
            };

            if (_operacion == TipoOperacion.Insert)
            {
                nudSucursal.Value = _empresaServicio.ObtenerSiguienteSucursal();
                nudSucursal.Enabled = false;
            }

        }

        private void PoblarComboCondicionIva()
        {
            cmbCondicionIva.DataSource = _condicionIvaServicio.ObtenerTodo(string.Empty);
            cmbCondicionIva.DisplayMember = "Descripcion";
            cmbCondicionIva.ValueMember = "Id";
        }

        //=============================== DATOS ===============================//

        public override void CargarDatos(long? entidadId)
        {
            base.CargarDatos(entidadId);

            if (entidadId.HasValue)
            {
                var empresa = _empresaServicio.ObtenerPorId(entidadId.Value);

                nudSucursal.Value = empresa.Sucursal;
                txtRazonSocial.Text = empresa.RazonSocial;
                txtNombreFantasia.Text = empresa.NombreFantasia;
                txtCuit.Text = empresa.Cuit;
                rtbDomicilio.Text = empresa.Domicilio;
                txtTelefono.Text = empresa.Telefono;
                txtEMail.Text = empresa.Email;
                ctrolFoto1.imgFoto.Image = Imagen.Convertir_Bytes_Imagen(empresa.Logo);
                cmbCondicionIva.Text = empresa.CondicionIva;

                if (_operacion == TipoOperacion.Delete)
                {
                    DesactivarControles(this,false);
                    ctrolFoto1.btnObtenerImagen.Enabled = false;
                    cmbCondicionIva.Enabled = false;
                }
                else
                {
                    nudSucursal.Enabled = false;
                    txtRazonSocial.Focus();
                }
            }
            else
            {
                Mensaje.Mostrar("No se pudieron cargar los datos de la empresa", Mensaje.Tipo.Informacion);
            }
        }

        //=============================== COMANDOS ===============================//
        public override void EjecutarComandoInsert()
        {
            if (VerificarDtosNulos())
            {
                try
                {
                    var nuevoEmpresa = new EmpresaDto
                    {
                        Sucursal = (int) nudSucursal.Value,
                        RazonSocial = txtRazonSocial.Text,
                        NombreFantasia = txtNombreFantasia.Text,
                        Cuit = txtCuit.Text,
                        Domicilio = rtbDomicilio.Text,
                        Telefono = txtTelefono.Text,
                        Email = txtEMail.Text,
                        CondicionIva = cmbCondicionIva.Text,
                        CondicionIvaId = (long) cmbCondicionIva.SelectedValue,
                        Logo = Imagen.Convertir_Imagen_Bytes(ctrolFoto1.imgFoto.Image)
                    };

                    _empresaServicio.Insertar(nuevoEmpresa);
                    LimpiarControles(this);
                    ctrolFoto1.imgFoto.Image = Properties.Resources.ImagenFondo;
                    txtRazonSocial.Focus();
                }
                catch
                {
                    Mensaje.Mostrar("No se pudo guardar la empresa", Mensaje.Tipo.Stop);
                }
            }
            else
            {
                Mensaje.Mostrar("Faltan datos necesarios por ingresar", Mensaje.Tipo.Informacion);
            }
        }

        public override void EjecutarComandoUpDate()
        {
            if (VerificarDtosNulos())
            {
                try
                {
                    var modificarEmpresa = new EmpresaDto
                    {
                        Id = EntidadId.Value,
                        Sucursal = (int) nudSucursal.Value,
                        RazonSocial = txtRazonSocial.Text,
                        NombreFantasia = txtNombreFantasia.Text,
                        Cuit = txtCuit.Text,
                        Domicilio = rtbDomicilio.Text,
                        Telefono = txtTelefono.Text,
                        Email = txtEMail.Text,
                        CondicionIva = cmbCondicionIva.Text,
                        CondicionIvaId = (long) cmbCondicionIva.SelectedValue,
                        Logo = Imagen.Convertir_Imagen_Bytes(ctrolFoto1.imgFoto.Image)
                    };

                    _empresaServicio.Modificar(modificarEmpresa);
                    Close();
                }
                catch
                {
                    Mensaje.Mostrar("No se pudo modificar la empresa", Mensaje.Tipo.Informacion);
                }
            }
            else
            {
                Mensaje.Mostrar("Faltan datos necesarios por ingresar", Mensaje.Tipo.Informacion);
            }
        }

        public override void EjecutarComandoDelete()
        {
            try
            {
                _empresaServicio.Eliminar(EntidadId.Value);
            }
            catch
            {
                Mensaje.Mostrar("No se pudo eliminar la empresa", Mensaje.Tipo.Informacion);
            }
        }

        //=============================== SALA ===============================//
        public override void LimpiarControles()
        {
            base.LimpiarControles(this);
        }

        //=============================== BONOT NUEVA CONDICION ===============================//
        private void btnNuevaCondicionIva_Click(object sender, EventArgs e)
        {
            var fnuevaCondicion = new _00005_ABM_CondicionDeIva(TipoOperacion.Insert);
            fnuevaCondicion.ShowDialog();
            if (fnuevaCondicion.RealizoAlgunaOperacion)
            {
                PoblarComboCondicionIva();
            }
        }

        private bool VerificarDtosNulos()
        {
            if (string.IsNullOrEmpty(txtRazonSocial.Text)
                || string.IsNullOrEmpty(txtCuit.Text)
                || string.IsNullOrEmpty(txtTelefono.Text)
                || string.IsNullOrEmpty(rtbDomicilio.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
