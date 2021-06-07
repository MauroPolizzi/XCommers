using System;
using System.Windows.Forms;
using XCommerce.Base.Helpers;
using XCommerce.Core;
using XCommerce.LogicaNegocio.Caja;
using XCommerce.LogicaNegocio.Seguridad;
using Color = System.Drawing.Color;

namespace XCommerce
{
    public partial class Principal : Form
    {
        private readonly CajaServicios _cajaServicios;
        public Principal()
        {
            InitializeComponent();

            ctrolEmpleadoLogin1.cambiarContraseñaToolStripMenuItem.Click += cambiarContraseña_Click;
            ctrolEmpleadoLogin1.cerrarSesiónToolStripMenuItem.Click += serrarSesion_Click;

            _cajaServicios = new CajaServicios();
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            imgEmpresa.Image = null;
            lblEmpresa.Text = string.Empty;

            QuitarDatosUsuarioLogin();

            IniciarDatosPantallaInicion();

            ObtenerCaja();
        }

        

        //============================ METODOS LOAD ========================//
        private void IniciarDatosPantallaInicion()
        {
            if (Identidad.UsuarioLoginId != 0)
            {
                var fElegirEmpresa = new _00010_EmpresaParaTrabajar(Identidad.EmpleadoLoginId);
                fElegirEmpresa.ShowDialog();

                AsignarDatosUsuarioYEmpresa(); //carga datos del empleado
                ObtenerCaja();
            }
            else
            {
                AsignarDatosUsuario(); // cara datos del administrador
                ObtenerCaja();
            }
        }

        private void AsignarDatosUsuarioYEmpresa()
        {
            ctrolEmpleadoLogin1.imgFoto.Image = Identidad.Foto;
            ctrolEmpleadoLogin1.lblEmpleadoLogin.Text = Identidad.ApyNomEmpleadoLogin;
            imgEmpresa.Image = Identidad.LogoEmpresa;
            lblEmpresa.Text = Identidad.Empresa;
        }

        private void QuitarDatosUsuarioLogin()
        {
            ctrolEmpleadoLogin1.imgFoto.Image = null;
            ctrolEmpleadoLogin1.lblEmpleadoLogin.Text = string.Empty;
        }

        private void AsignarDatosUsuario()
        {
            ctrolEmpleadoLogin1.imgFoto.Image = Identidad.Foto;
            ctrolEmpleadoLogin1.lblEmpleadoLogin.Text = Identidad.ApyNomEmpleadoLogin;
        }

        private void ObtenerCaja()
        {
            var cajaEmpresa = _cajaServicios.ObtenerCajaEmpresa(Identidad.EmpresaId);

            if (cajaEmpresa.Id == 0)
            {
                btnCaja.Text = "Abrir Caja";
                btnCaja.BackColor = Color.DarkGreen;
            }
            else
            {
                if (cajaEmpresa.UsuarioCierre != null)
                {
                    btnCaja.Text = "Abrir Caja";
                    btnCaja.BackColor = Color.DarkGreen;
                }
                else
                {
                    btnCaja.Text = "Cerrar Caja";
                    btnCaja.BackColor = Color.DarkRed;
                }
            }
        }

        //=============================== BOTONES CTROL ===============================//
        private void serrarSesion_Click(object sender, EventArgs e)
        {
            QuitarDatosUsuarioLogin();
            imgEmpresa.Image = null;
            lblEmpresa.Text = string.Empty;

            var login = new _00000_Login();
            login.ShowDialog();

            if (login.PuedeAccederAlSistema)
            {
                IniciarDatosPantallaInicion();
            }
            else
            {
                Application.Exit();
            }
        }

        private void cambiarContraseña_Click(object sender, EventArgs e)
        {
            var fCambiarContraseña = new _00025_CambiarPassword();
            fCambiarContraseña.ShowDialog();
        }
        //=============================== EMPLEADO ===============================//
        private void consultaDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var consultaEmpleado = new _00001_Empleado();
            consultaEmpleado.ShowDialog();
        }

        private void nuevoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fnuevoEmpleado = new _00002_ABM_Empleado(TipoOperacion.Insert);
            fnuevoEmpleado.ShowDialog();
        }

        //=============================== CONDICION IVA ===============================//
        private void consultaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var fCondicionIva = new _00004_CondicionDeIva();
            fCondicionIva.ShowDialog();
        }

        private void nuevaCondicionIvaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fnuevaCondicionIva = new _00005_ABM_CondicionDeIva(TipoOperacion.Insert);
            fnuevaCondicionIva.ShowDialog();
        }

        //=============================== EMPRESA ===============================//
        private void consultaEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fconsultaEmpresa = new _00006_Empresa();
            fconsultaEmpresa.ShowDialog();
        }

        private void nuevaEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fnuevaEmpresa = new _00007_ABM_Empresa(TipoOperacion.Insert);
            fnuevaEmpresa.ShowDialog();
        }
        
        //=============================== MARCA ===============================//
        private void consultaDeMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var consultaMarca = new _00028_Marca();
            consultaMarca.ShowDialog();
        }

        private void nuevaMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fnuevaMarca = new _00029_ABM_Marca(TipoOperacion.Insert);
            fnuevaMarca.ShowDialog();
        }

        //=============================== USUARIO ===============================//
        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fUsuario = new _00003_Usuario();
            fUsuario.ShowDialog();
        }

        //=============================== RUBRO ===============================//
        private void consultaDeRubroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fRubro = new _00030_Rubro();
            fRubro.ShowDialog();
        }

        private void nuevoRubroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNueoRubro = new _00031_ABM_Rubro(TipoOperacion.Insert);
            fNueoRubro.ShowDialog();
        }

        //=============================== SUB RUBRO ===============================//
        private void consultaDeSubRubroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fSubRubro = new _00032_SubRubro();
            fSubRubro.ShowDialog();
        }

        private void nuevoSubRubroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fnuevoSubRubro = new _00033_ABM_SubRubro(TipoOperacion.Insert);
            fnuevoSubRubro.ShowDialog();
        }

        //=============================== TIPO COMPROBANTE ===============================//
        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var consultaTipoComprobante = new _00026_TipoComprobante();
            consultaTipoComprobante.ShowDialog();
        }

        private void nuevoTipoDeComprobanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fnuevoComprobante = new _00027_ABM_TipoComprobante(TipoOperacion.Insert);
            fnuevoComprobante.ShowDialog();
        }

        //=============================== DEPOSITO ===============================//
        private void consultaDepositoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaDeposito = new _00037_Deposito();
            fConsultaDeposito.ShowDialog();
        }

        private void nuevoDepositoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevoDeposito = new _00038_ABM_Deposito(TipoOperacion.Insert);
            fNuevoDeposito.ShowDialog();
        }
        //=============================== ARTICULO ===============================//
        private void consultaDeArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultArticulo = new _00034_Articulo();
            fConsultArticulo.ShowDialog();
        }

        private void nuevoArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fnuevoArticulo = new _00035_ABM_Articulo(TipoOperacion.Insert);
            fnuevoArticulo.ShowDialog();
        }
        //=============================== CLIENTE ===============================//
        private void consultaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var fconsultaCliente = new _00041_Cliente();
            fconsultaCliente.ShowDialog();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fnuevoCliente = new _00042_ABM_Cliente(TipoOperacion.Insert);
            fnuevoCliente.ShowDialog();
        }

        //=============================== PERFIL ===============================//
        private void consultaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var consultaPerfil = new _00019_Perfil();
            consultaPerfil.ShowDialog();
        }

        private void nuevoPerfilToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var nueoPerfil = new _00020_ABM_Perfil(TipoOperacion.Insert);
            nueoPerfil.ShowDialog();
        }

        //=============================== SALA ===============================//
        private void consultaDeSalasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaSala = new _00011_Sala();
            fConsultaSala.ShowDialog();
        }

        private void nuevaSalaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fNuevaSala = new _00012_ABM_Sala(TipoOperacion.Insert);
            fNuevaSala.ShowDialog();
        }

        //=============================== MESA ===============================//
        private void copnsultaDeMesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaMesa = new _00013_Mesa();
            fConsultaMesa.ShowDialog();
        }

        private void nuevaMesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevaMesa = new _00014_ABM_Mesa(TipoOperacion.Insert);
            fNuevaMesa.ShowDialog();
        }

        //=============================== LISTA DE PRECIO ===============================//
        private void consultaListaPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fListaPrecio = new _00039_ListaPrecio();
            fListaPrecio.ShowDialog();
        }

        private void nuevaListaPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fnuevaLista = new _00040_ABM_ListaPrecio(TipoOperacion.Insert);
            fnuevaLista.ShowDialog();
        }

        //=============================== FORMULARIOS ===============================//
        private void formulariosVentanasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fFormularios = new _00018_Formulario();
            fFormularios.ShowDialog();
        }

        //================================= KIOSCO ===============================//
        private void btnKiosco_Click(object sender, EventArgs e)
        {
            var cajaEmpresa = _cajaServicios.ObtenerCajaEmpresa(Identidad.EmpresaId);

            if (cajaEmpresa.UsuarioApertura == 0
                || cajaEmpresa.MontoCierre != null)
            {
                Mensaje.Mostrar("Debe abrir caja antes de hacer una venta", Mensaje.Tipo.Informacion);
            }
            else
            {
                var kiosco = new _00045_Kiosco();
                kiosco.ShowDialog();
            }
        }

        private void btnVentaSalon_Click(object sender, EventArgs e)
        {
            var salon = new _00015_VentaSalon();
            salon.ShowDialog();
        }

        //============================= CAJA =============================//
        private void btnCaja_Click(object sender, EventArgs e)
        {
            var cajaEmpresa = _cajaServicios.ObtenerCajaEmpresa(Identidad.EmpresaId);

            if(cajaEmpresa.UsuarioApertura == 0
                || cajaEmpresa.MontoCierre != null)
            {
                var caja = new _00059_AbrirCaja();
                caja.ShowDialog();

                var verCajaAbierta = _cajaServicios.ObtenerCajaEmpresa(Identidad.EmpresaId);

                if (verCajaAbierta.UsuarioApertura != 0 && verCajaAbierta.FechaCierre == null)
                {
                    btnCaja.BackColor = Color.DarkRed;
                    btnCaja.Text = "Cerrar Caja";
                }
            }
            else
            {
                var caja = new _00060_CerrarCaja();
                caja.ShowDialog();

                var verCajaAbierta = _cajaServicios.ObtenerCajaEmpresa(Identidad.EmpresaId);
                if (verCajaAbierta.UsuarioCierre != null)
                {
                    btnCaja.BackColor = Color.DarkGreen;
                    btnCaja.Text = "Abrir Caja";
                }
                

            }
        }
        private void cajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var consultaCaja = new _00061_ConsultarCaja();
            consultaCaja.ShowDialog();
        }
        //============================= PROVEEDORES ========================//
        private void consultaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var fProveedor = new _00051_Proveedor();
            fProveedor.ShowDialog();
        }

        private void nuevoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fnuevoProveedor = new _00052_AMB_Proveedor(TipoOperacion.Insert);
            fnuevoProveedor.ShowDialog();
        }

        //============================ TARJETAS =======================//
        private void consultaToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            var fTarjeta = new _00053_Tarjeta();
            fTarjeta.ShowDialog();
        }

        private void nuevaTarjetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tarjetaNueva = new _00054_ABM_Tarjeta(TipoOperacion.Insert);
            tarjetaNueva.ShowDialog();
        }

        //============================ BANCO =======================//
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nuevoBanco = new _00058_ABM_Banco(TipoOperacion.Insert);
            nuevoBanco.ShowDialog();
        }

        private void consultaBancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var consultaBanco = new _00057_Banco();
            consultaBanco.ShowDialog();
        }

        //============================ FACTURAS =======================//
        private void kioscoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var comprobanteFactura = new _00063_Comprobantes(Identidad.EmpresaId, 1);
            comprobanteFactura.ShowDialog();
        }
    }
}
