using System;
using System.Windows.Forms;
using XCommerce.Base.Clases;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Seguridad;
using XCommerce.LogicaNegocio.Usuario;

namespace XCommerce.Core
{
    public partial class _00000_Login : Form
    {
        private int CantidadDeIntentosFallidos;

        private readonly SeguridadServicio _seguridadServicio;
        private readonly UsuarioServicio _usuarioServicio;

        public bool PuedeAccederAlSistema { get; private set; }

        public _00000_Login()
            : this(new SeguridadServicio(), new UsuarioServicio())
        {
            InitializeComponent();
            CantidadDeIntentosFallidos = 1;
            PuedeAccederAlSistema = false;
        }

        public _00000_Login(SeguridadServicio seguridadServicio, UsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
            _seguridadServicio = seguridadServicio;
        }

        private void btnIngresar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (VerificarDatosObligatorios(txtUsuario.Text, txtPassword.Text))
                {
                    if (txtUsuario.Text == "admin")
                    {
                        var usuarioAdmin =
                            _seguridadServicio.VerificarAccesoAlSistema(txtUsuario.Text, txtPassword.Text);

                        if (usuarioAdmin != null)
                        {
                            if (!usuarioAdmin.Bloqueado)
                            {
                                PuedeAccederAlSistema = true;
                                
                                Identidad.UsuarioLogin = usuarioAdmin.NombreUsuario;
                                Identidad.UsuarioLoginId = usuarioAdmin.UsuarioId ?? 0;
                                Identidad.ApellidoEmpleado = usuarioAdmin.Apellido;
                                Identidad.NombreEmpleado = usuarioAdmin.Nombre;
                                Identidad.EmpleadoLoginId = usuarioAdmin.EmpleadoId;
                                Identidad.Foto = usuarioAdmin.Foto;

                                Close();
                            }
                            else
                            {
                                Mensaje.Mostrar("El usuario esta bloqueado, por favor comuniquese con el administrador",
                                    Mensaje.Tipo.Advertencia);
                                txtUsuario.Clear();
                                txtPassword.Clear();
                                txtUsuario.Focus();
                            }
                        }
                        else
                        {
                            if (CantidadDeIntentosFallidos == ConstanteSeguridad.CantidadIngresosFallidos)
                            {
                                _usuarioServicio.CambiarEstado(txtUsuario.Text);
                                Mensaje.Mostrar(
                                    "El usuario fue bloqueado por seguridad, comunicarse con el administrador",
                                    Mensaje.Tipo.Informacion);
                            }
                            else
                            {
                                Mensaje.Mostrar("EL usuario o la contraseña son incorrectos", Mensaje.Tipo.Error);
                                txtPassword.Clear();
                                txtUsuario.Focus();
                                CantidadDeIntentosFallidos++;
                            }
                        }
                    }
                    else
                    {
                        var passwordEncriptada = Encriptar.EncriptarCadena(txtPassword.Text);

                        var usuarioLogin =
                            _seguridadServicio.VerificarAccesoAlSistema(txtUsuario.Text, passwordEncriptada);

                        if (usuarioLogin != null)
                        {
                            if (!usuarioLogin.Bloqueado)
                            {
                                PuedeAccederAlSistema = true;

                                Identidad.UsuarioLogin = usuarioLogin.NombreUsuario;
                                Identidad.UsuarioLoginId = usuarioLogin.UsuarioId ?? 0;
                                Identidad.ApellidoEmpleado = usuarioLogin.Apellido;
                                Identidad.NombreEmpleado = usuarioLogin.Nombre;
                                Identidad.EmpleadoLoginId = usuarioLogin.EmpleadoId;
                                Identidad.Foto = usuarioLogin.Foto;

                                Close();
                            }
                            else
                            {
                                Mensaje.Mostrar("El usuario esta bloqueado, por favor comuniquese con el administrador",
                                    Mensaje.Tipo.Advertencia);
                                txtUsuario.Clear();
                                txtPassword.Clear();
                                txtUsuario.Focus();
                            }
                        }
                        else
                        {
                            if (CantidadDeIntentosFallidos == ConstanteSeguridad.CantidadIngresosFallidos)
                            {
                                _usuarioServicio.CambiarEstado(txtUsuario.Text);
                                Mensaje.Mostrar(
                                    "El usuario fue bloqueado por seguridad, comunicarse con el administrador",
                                    Mensaje.Tipo.Informacion);
                            }
                            else
                            {
                                Mensaje.Mostrar("EL usuario o la contraseña son incorrectos", Mensaje.Tipo.Error);
                                txtPassword.Clear();
                                txtUsuario.Focus();
                                CantidadDeIntentosFallidos++;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Mensaje.Mostrar(exception, Mensaje.Tipo.Error);
                Close();
            }
        }

        private bool VerificarDatosObligatorios(string usuario, string password)
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                Mensaje.Mostrar("Faltan datos por ingresar", Mensaje.Tipo.Stop);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
