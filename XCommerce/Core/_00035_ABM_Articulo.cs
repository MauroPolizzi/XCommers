using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using XCommerce.AccesoDatos;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Articulo;
using XCommerce.LogicaNegocio.Articulo.DTOs;
using XCommerce.LogicaNegocio.Marca;
using XCommerce.LogicaNegocio.Rubro;
using XCommerce.LogicaNegocio.Seguridad;
using XCommerce.LogicaNegocio.SubSubRubro;

namespace XCommerce.Core
{
    public partial class _00035_ABM_Articulo : FormularioAbm
    {
        private readonly ArticuloServicio _articuloServicio;
        private readonly MarcaServicio _marcaServicio;
        private readonly RubroServicio _rubroServicio;
        private readonly SubRubroServicio _subRubroServicio;
        public _00035_ABM_Articulo()
        {
            InitializeComponent();
        }

        public _00035_ABM_Articulo(TipoOperacion tipoOperacion, long? entidadId = null)
            :base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _articuloServicio = new ArticuloServicio();
            _marcaServicio = new MarcaServicio();
            _rubroServicio = new RubroServicio();
            _subRubroServicio = new SubRubroServicio();

            Inicializador();

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;
        }

        public override void Inicializador()
        {
            base.Inicializador();

            AgregarControlesObligatorios(txtCodigoBarra,"CodigoBarra");
            AgregarControlesObligatorios(txtDescripcion,"Descripcion");
            AgregarControlesObligatorios(txtAbreviatura,"Abreviatura");
            AgregarControlesObligatorios(txtDetalle,"Detalle");

            //************************ VALIDACION 
            txtCodigoBarra.KeyPress += delegate(object sender, KeyPressEventArgs args)
            {
                Validar.NoLetras(sender,args);
                Validar.NoInyeccion(sender,args);
            };
            txtDescripcion.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
            };
            txtAbreviatura.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                Validar.NoSimbolos(sender, args);
                Validar.NoInyeccion(sender, args);
                Validar.NoNumeros(sender,args);
            };
            txtCodigoBarra.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                Validar.NoLetras(sender, args);
                Validar.NoInyeccion(sender, args);
            };
            //************************

            if (_operacion == TipoOperacion.Insert)
            {
                //txtCodigo.Text = _articuloServicio.ObtenerSiguienteCodigo().ToString();
                //txtCodigo.Enabled = false;
            }

            CargarComboMarca();
            CargarComboRubro();
            CargarComboSubRubro();
            CargarComboTipoArticulo();
        }

        //========================= CARGAR DATOS ==========================//
        private void CargarComboMarca()
        {
            cmbMarca.DataSource = _marcaServicio.ObtenerTodo(Identidad.EmpresaId, string.Empty);
            cmbMarca.DisplayMember = "Descripcion";
            cmbMarca.ValueMember = "Id";
        }

        private void CargarComboRubro()
        {
            cmbRubro.DataSource = _rubroServicio.ObtenerTodo(Identidad.EmpresaId,string.Empty);
            cmbRubro.DisplayMember = "Descripcion";
            cmbRubro.ValueMember = "Id";
        }

        private void CargarComboSubRubro()
        {
            cmbSubRubro.DataSource = _subRubroServicio.ObtenerTodo( string.Empty);
            cmbSubRubro.DisplayMember = "Descripcion";
            cmbSubRubro.ValueMember = "Id";
        }

        private void CargarComboTipoArticulo()
        {
            cmbTipoArticulo.DataSource = Enum.GetValues(typeof(AccesoDatos.TipoArticulo));
        }

        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue)
            {
                var articulo = _articuloServicio.ObtenrePorId(entidadId.Value);

                txtCodigo.Text = articulo.Codigo;
                txtCodigoBarra.Text = articulo.CodigoBarra;
                txtAbreviatura.Text = articulo.Abreviatura;
                txtDescripcion.Text = articulo.Descripcion;
                cmbMarca.Text = articulo.Marca;
                cmbRubro.Text = articulo.Rubro;
                cmbSubRubro.Text = articulo.SubRubro;
                ctrolFotoArticulo.imgFoto.Image = Imagen.Convertir_Bytes_Imagen(articulo.Foto);
                if (articulo.ActivarLimiteVenta == true) chkActivarLimiteVenta.Checked = true;
                nudCantidadLimiteVenta.Value = articulo.CantidadLimiteVenta;
                cmbTipoArticulo.Text = articulo.TipoArticulo.ToString();
                nudStockMinimo.Value = articulo.StockMinimo;
                nudStockMaximo.Value = articulo.StockMaximo;
                if (articulo.DescuentaStock == true) chkDescuentaStock.Checked = true;
                if (articulo.PermiteStockNegativo == true) chkPermiteStockNegativo.Checked = true;
                if (articulo.EstaDiscontinuado == true) chkDiscontinuar.Checked = true;
                if (articulo.SePuedeFraccionar == true) chkSePuedeFraccionar.Checked = true;

                if (_operacion == TipoOperacion.Delete)
                {
                    DesactivarControles(this,false);
                }
                else
                {
                    txtCodigo.Enabled = false;
                    txtCodigoBarra.Focus();
                }
            }
        }

        //========================= EJECUTAR ===========================//

        public override void EjecutarComandoInsert()
        {
            if (VerificarDatosNulos())
            {
                try
                {
                    var artiulo = new ArticuloDto
                    {
                        Codigo = txtCodigo.Text,
                        CodigoBarra = txtCodigoBarra.Text,
                        Abreviatura = txtAbreviatura.Text,
                        Descripcion = txtDescripcion.Text,
                        MarcaId = (long) cmbMarca.SelectedValue,
                        RubroId = (long) cmbRubro.SelectedValue,
                        SubRubroId = (long) cmbSubRubro.SelectedValue,
                        Foto = Imagen.Convertir_Imagen_Bytes(ctrolFotoArticulo.imgFoto.Image),
                        ActivarLimiteVenta = chkActivarLimiteVenta.Checked,
                        CantidadLimiteVenta = nudCantidadLimiteVenta.Value,
                        PermiteStockNegativo = chkPermiteStockNegativo.Checked,
                        EstaDiscontinuado = chkDiscontinuar.Checked,
                        TipoArticulo = (TipoArticulo) cmbTipoArticulo.SelectedValue,
                        StockMinimo = nudStockMinimo.Value,
                        StockMaximo = nudStockMaximo.Value,
                        DescuentaStock = chkDescuentaStock.Checked,
                        SePuedeFraccionar = chkSePuedeFraccionar.Checked,
                        Detalle = txtDetalle.Text,
                        EmpresaId = Identidad.EmpresaId
                    };

                    _articuloServicio.Insertar(artiulo, Identidad.EmpresaId);

                    LimpiarControles(this);
                    //txtCodigo.Text = _articuloServicio.ObtenerSiguienteCodigo().ToString();
                    ctrolFotoArticulo.imgFoto.Image = Properties.Resources.ImagenFondo;
                    txtCodigoBarra.Focus();
                }
                catch
                {
                    Mensaje.Mostrar("Ocurrio un error al guardar el articulo", Mensaje.Tipo.Informacion);
                }
            }
            else
            {
            Mensaje.Mostrar("Faltan por ingresar datos necesarios", Mensaje.Tipo.Informacion);
            }
        }

        public override void EjecutarComandoUpDate()
        {
            if (VerificarDatosNulos())
            {
                try
                {
                    var artiuloModficar = new ArticuloDto
                    {
                        Id = EntidadId.Value,
                        Codigo = txtCodigo.Text,
                        CodigoBarra = txtCodigoBarra.Text,
                        Abreviatura = txtAbreviatura.Text,
                        Descripcion = txtDescripcion.Text,
                        MarcaId = (long) cmbMarca.SelectedValue,
                        RubroId = (long) cmbRubro.SelectedValue,
                        SubRubroId = (long) cmbSubRubro.SelectedValue,
                        Foto = Imagen.Convertir_Imagen_Bytes(ctrolFotoArticulo.imgFoto.Image),
                        ActivarLimiteVenta = chkActivarLimiteVenta.Checked,
                        CantidadLimiteVenta = nudCantidadLimiteVenta.Value,
                        PermiteStockNegativo = chkPermiteStockNegativo.Checked,
                        EstaDiscontinuado = chkDiscontinuar.Checked,
                        TipoArticulo = (TipoArticulo) cmbTipoArticulo.SelectedValue,
                        StockMinimo = nudStockMinimo.Value,
                        StockMaximo = nudStockMaximo.Value,
                        DescuentaStock = chkDescuentaStock.Checked,
                        SePuedeFraccionar = chkSePuedeFraccionar.Checked,
                        Detalle = txtDetalle.Text,
                        EstaEliminado = false,
                    };

                    _articuloServicio.Modificar(artiuloModficar);
                    Close();
                }
                catch
                {
                    Mensaje.Mostrar("Ocurrio un error al guardar el articulo", Mensaje.Tipo.Informacion);
                }
            }
            else
            {
                Mensaje.Mostrar("Faltan por ingresar datos necesarios", Mensaje.Tipo.Informacion);
            }
        }

        public override void EjecutarComandoDelete()
        {
            try
            {
                _articuloServicio.Eliminar(EntidadId.Value);
            }
            catch
            {
                Mensaje.Mostrar("ocurrio un error al eliminar el articulo", Mensaje.Tipo.Informacion);
            }
        }

        //======================== EVENTOS ============================//
        private void chkActivarLimiteVenta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivarLimiteVenta.Checked == true)
            {
                nudCantidadLimiteVenta.Enabled = true;
            }
            else
            {
                nudCantidadLimiteVenta.Enabled = false;
            }
        }
        
        private bool VerificarDatosNulos()
        {
            if (string.IsNullOrEmpty(txtCodigo.Text)
                || string.IsNullOrEmpty(txtCodigo.Text)
                || string.IsNullOrEmpty(txtDescripcion.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //=========================== AGREGRA ============================//
        private void btnNuevaMarca_Click(object sender, EventArgs e)
        {
            var nuevaMarca = new _00029_ABM_Marca(TipoOperacion.Insert);
            nuevaMarca.ShowDialog();
            //return nuevaMarca.RealizoAlgunaOperacion;

            CargarComboMarca();
        }

        private void btnNuevoRubro_Click(object sender, EventArgs e)
        {
            var nuevaMarca = new _00031_ABM_Rubro(TipoOperacion.Insert);
            nuevaMarca.ShowDialog();
            //return nuevaMarca.RealizoAlgunaOperacion;

            CargarComboRubro();
        }

        private void btnNuevoSubRubro_Click(object sender, EventArgs e)
        {
            var nuevaMarca = new _00033_ABM_SubRubro(TipoOperacion.Insert);
            nuevaMarca.ShowDialog();
            //return nuevaMarca.RealizoAlgunaOperacion;

            CargarComboSubRubro();
        }
    }
}
