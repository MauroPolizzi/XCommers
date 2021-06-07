using System;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Seguridad;
using XCommerce.LogicaNegocio.Usuario;

namespace XCommerce.Core
{
    public partial class _00025_CambiarPassword : FormularioBase
    {
        private readonly UsuarioServicio _usuarioServicio;
        
        public _00025_CambiarPassword()
            :this(new UsuarioServicio())
        {
            InitializeComponent();
        }

        public _00025_CambiarPassword(UsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;

            lblUsuarioLogin.Text = Identidad.ApyNomEmpleadoLogin;
        }

        //============================= BOTONES ==============================//
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                if (verificarCamposVacios())
                {
                    if (VerificarNuevasPassword())
                    {
                        _usuarioServicio.CambiarPassword(Identidad.UsuarioLoginId, txtPasswordActual.Text,
                            txtNuevaPassword.Text);

                        Mensaje.Mostrar("Contraseña modificada correctamente", Mensaje.Tipo.Informacion);
                        Close();
                    }
                    else
                    {
                        Mensaje.Mostrar("Las contraseñas no coiciden", Mensaje.Tipo.Informacion);
                        txtRepetirPassword.Clear();
                        txtRepetirPassword.Focus();
                    }
                }
                else
                {
                    Mensaje.Mostrar("Faltan campos por cargar", Mensaje.Tipo.Stop);
                }
            }
            catch
            {
                Mensaje.Mostrar("Ocurrio un error al guardar la contraseña nueva", Mensaje.Tipo.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //========================== METODOS =============================//
        private bool verificarCamposVacios()
        {
            if (string.IsNullOrEmpty(txtPasswordActual.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(txtNuevaPassword.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(txtPasswordActual.Text))
            {
                return false;
            }

            return true;
        }

        private bool VerificarNuevasPassword()
        {
            var passwordNueva = txtNuevaPassword.Text;
            var passwordRepetida = txtRepetirPassword.Text;

            if (passwordNueva == passwordRepetida)
            {
                return true;
            }
            return false;
        }
    }
}
