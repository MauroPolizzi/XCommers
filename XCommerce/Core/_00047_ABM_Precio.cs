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
using XCommerce.LogicaNegocio.ListaPrecio;
using XCommerce.LogicaNegocio.Precio;
using XCommerce.LogicaNegocio.Precio.DTOs;

namespace XCommerce.Core
{
    public partial class _00047_ABM_Precio: FormularioAbm
    {
        private readonly ArticuloServicio _articuloServicio;

        private readonly PrecioServicio _precioServicio;
        private readonly ListaPrecioServicio _listaPrecio;
        public _00047_ABM_Precio()
        {
            InitializeComponent();
        }

        public _00047_ABM_Precio(TipoOperacion tipoOperacion, long? entidadId = null)
            :base(tipoOperacion,entidadId)
        {
            InitializeComponent();

            _articuloServicio = new ArticuloServicio();

            _precioServicio = new PrecioServicio();
            _listaPrecio = new ListaPrecioServicio();

            

            Inicializador();
        }

        public override void Inicializador()
        {
            base.Inicializador();

            AgregarControlesObligatorios(nudRentabilidad,"Rentabilidad");

            CargarComboListaPrecio();

            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            if (_operacion == TipoOperacion.Insert)
            {
                txtArticulo.Enabled = false;

                var articulo = _articuloServicio.ObtenrePorId(EntidadId.Value);
                txtArticulo.Text = articulo.Descripcion;
            }
        }

        //======================= COMBO LISTA =====================//
        private void CargarComboListaPrecio()
        {
            cmbListaPrecio.DataSource = _listaPrecio.ObtenerTodo(Identidad.EmpresaId, string.Empty);
            cmbListaPrecio.ValueMember = "Id";
            cmbListaPrecio.DisplayMember = "Descripcion";
        }

        //======================== DATOS ===========================//
        public override void CargarDatos(long? entidadId)
        {
            var precioArticulo = _precioServicio.ObtenerPorId(entidadId.Value);

            txtArticulo.Text = precioArticulo.NombreArticulo;
            nudPrecioCosto.Value = precioArticulo.PrecioCosto;
            nudPrecioPublico.Value = precioArticulo.PreioPublico;
            nudRentabilidad.Value = precioArticulo.Rentabilidad;

            if (_operacion == TipoOperacion.Delete)
            {
                DesactivarControles(this,false);
            }
            else
            {
                txtArticulo.Enabled = false;
            }
        }

        //========================= BOTON LISTA ======================//
        private void btnNuevaLista_Click(object sender, EventArgs e)
        {
            var flista = new _00040_ABM_ListaPrecio(TipoOperacion.Insert);
            flista.ShowDialog();
            CargarComboListaPrecio();
        }

        //========================= COMANDOS =========================//
        public override void EjecutarComandoInsert()
        {
            try
            {
                var Precio = new PrecioDto
                {
                    ArticuloId = EntidadId.Value,
                    EmpresaId = Identidad.EmpresaId,
                    FechaActualizacion = DateTime.Now,
                    PrecioCosto = nudPrecioCosto.Value,
                    //PreioPublico = nudPrecioPublico.Value,
                    PreioPublico = nudPrecioCosto.Value + (nudPrecioCosto.Value * (nudRentabilidad.Value / 100)),
                    Rentabilidad = nudRentabilidad.Value,
                    ListaPrecioId = (long)cmbListaPrecio.SelectedValue,
                };

                _precioServicio.Insertar(Precio);
                Close();
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al guardar el precio", Mensaje.Tipo.Informacion);
            }
        }

        public override void EjecutarComandoUpDate()
        {
            try
            {
                var Precio = new PrecioDto
                {
                    Id = EntidadId.Value,
                    //ArticuloId = EntidadId.Value,
                    EmpresaId = Identidad.EmpresaId,
                    FechaActualizacion = DateTime.Now,
                    PrecioCosto = nudPrecioCosto.Value,
                    //PreioPublico = nudPrecioPublico.Value,
                    PreioPublico = nudPrecioCosto.Value + (nudPrecioCosto.Value * (nudRentabilidad.Value / 100)),
                    Rentabilidad = nudRentabilidad.Value,
                    ListaPrecioId = (long)cmbListaPrecio.SelectedValue,
                };

                _precioServicio.Modificar(Precio);
                Close();
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al guardar el precio", Mensaje.Tipo.Informacion);
            }
        }

        public override void EjecutarComandoDelete()
        {
            try
            {
                _precioServicio.Eliminar(EntidadId.Value);
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al eliminar", Mensaje.Tipo.Informacion);
            }
        }
    }
}
