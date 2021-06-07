using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Articulo;
using XCommerce.LogicaNegocio.Articulo.DTOs;
using XCommerce.LogicaNegocio.Deposito;

namespace XCommerce.Core
{
    public partial class _00043_AgregarStock: FormularioAbm
    {
        private readonly DepositoServicio _depositoServicio;
        private readonly ArticuloServicio _articuloServicio;
        public _00043_AgregarStock()
        {
            InitializeComponent();
        }

        public _00043_AgregarStock(TipoOperacion tipoOperacion, long? entidadId = null)
            :base(tipoOperacion,entidadId)
        {
            InitializeComponent();
            _depositoServicio = new DepositoServicio();
            _articuloServicio = new ArticuloServicio();
            Inicializador();
        }

        public override void Inicializador()
        {
            base.Inicializador();

            CargarComboDeposito();
            
            AgregarControlesObligatorios(nudCantidad, "Cantidad");

            var articulo = _articuloServicio.ObtenrePorId(EntidadId.Value);
            lblNombreArticulo.Text = articulo.Descripcion;

            if (_operacion == TipoOperacion.Update)
            {
                cmbDeposito.Enabled = false;
                btnNuevoDeposito.Enabled = false;

                var depositoArticulo = _articuloServicio.ObtenreStockArticulo(EntidadId.Value);
                var nombreDeposito = _depositoServicio.ObtenerPorId(depositoArticulo.DepositoId);
                cmbDeposito.Text = nombreDeposito.Descripcion;
            }
        }

        private void CargarComboDeposito()
        {
            cmbDeposito.DataSource = _depositoServicio.ObtenerTodo(Identidad.EmpresaId, string.Empty);
            cmbDeposito.DisplayMember = "Descripcion";
            cmbDeposito.ValueMember = "Id";
        }

        private void btnNuevoDeposito_Click(object sender, EventArgs e)
        {
            var nuevoDeposito = new _00038_ABM_Deposito(TipoOperacion.Insert);
            nuevoDeposito.ShowDialog();
            //return nuevoDeposito.RealizoAlgunaOperacion;

            CargarComboDeposito();
        }

        public override void EjecutarComandoInsert()
        {
            try
            {
                var articulo = _articuloServicio.ObtenrePorId(EntidadId.Value);

                if (nudCantidad.Value <= articulo.StockMaximo)
                {
                    var stock = new StockDto
                    {
                        ArticuloId = EntidadId.Value,
                        DepositoId = (long) cmbDeposito.SelectedValue,
                        Cantidad = nudCantidad.Value,
                    };

                    _articuloServicio.AgregarStock(stock);
                    Close();
                }
                else
                {
                    Mensaje.Mostrar($"No puede tenes un stock mayor a {articulo.StockMaximo}",
                        Mensaje.Tipo.Informacion);
                }
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un errror al guardar", Mensaje.Tipo.Informacion);
            }
        }

        public override void EjecutarComandoUpDate()
        {
            try
            {
                var articulo = _articuloServicio.ObtenrePorId(EntidadId.Value);
                var articuloS = _articuloServicio.ObtenreStockArticulo(EntidadId.Value);

                if ((articuloS.Cantidad + nudCantidad.Value) <= articulo.StockMaximo)
                {
                    var aumentarStock = new StockDto
                    {
                        ArticuloId = EntidadId.Value,
                        DepositoId = (long) cmbDeposito.SelectedValue,
                        Cantidad = nudCantidad.Value,
                    };


                    _articuloServicio.AumentarStock(aumentarStock);
                    Close();
                }
                else
                {
                    Mensaje.Mostrar($"Puede tener un stock maximo de {articulo.StockMaximo}"
                                    + Environment.NewLine + $"Ya hay en stock {articuloS.Cantidad}",
                        Mensaje.Tipo.Informacion);
                }
            }
            catch
            {
                Mensaje.Mostrar("No se pudo incrementar el stock", Mensaje.Tipo.Informacion);
            }
        }
    }
}
