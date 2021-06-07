using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XCommerce.Base.Clases;
using XCommerce.Base.Helpers;

namespace XCommerce.Base.Formularios
{
    public partial class FormularioAbm : FormularioBase
    {
        protected long? EntidadId;
        protected TipoOperacion _operacion;
        public bool RealizoAlgunaOperacion;

        private readonly List<ControlObligatorioDto> _listaControlObligatorio;

        public FormularioAbm()
        {
            InitializeComponent();
            RealizoAlgunaOperacion = false;
            _listaControlObligatorio = new List<ControlObligatorioDto>();
        }

        public FormularioAbm(TipoOperacion operacion, long? entidadId = null)
            :this()
        {
            EntidadId = entidadId;
            _operacion = operacion;
            AsignarImagenBotones();
        }

        private void AsignarImagenBotones()
        {
            btnEjecutar.Image = _operacion == TipoOperacion.Delete
                ? Properties.Resources.Borrar
                : Properties.Resources.Guardar;
            btnLimpiar.Image = Properties.Resources.Limpiar4;
            btnSalir.Image = Properties.Resources.Salir;
        }

        public virtual void AgregarControlesObligatorios(object ctrol, string nombreControl)
        {
            _listaControlObligatorio.Add(new ControlObligatorioDto
            {
                Control = ctrol,
                NombreControl = nombreControl
            });
            AsignarErrorProvider(ctrol);
        }

        private void AsignarErrorProvider(object ctrol)
        {
            if (ctrol is TextBox)
            {
                ((TextBox) ctrol).Validated += TextBox_Validated;
            }
            else if (ctrol is RichTextBox)
            {
                ((RichTextBox) ctrol).Validated += RichTextBox_Validated;
            }
        }

        private void TextBox_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                error.SetError((TextBox)sender, string.Empty);
            }
            else
            {
                error.SetError((TextBox)sender, $"El campo es Obligatorio");
            }
        }

        private void RichTextBox_Validated (object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(((RichTextBox)sender).Text))
            {
                error.SetError((RichTextBox)sender, string.Empty);
            }
            else
            {
                error.SetError((RichTextBox)sender, "El campo es Obligaorio");
            }
        }
        //=========================== BOTONES ========================//

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (VerificarDatosSinGuardar() && _operacion != TipoOperacion.Delete)
            {
                if (Mensaje.Mostrar("Hay datos sin guardar, Desea limpiar los datos?" , Mensaje.Tipo.Pregunta) == DialogResult.Yes)
                {
                    LimpiarControles();
                }
            }
        }
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            EjecutarComando();
        }

        public virtual void Inicializador()
        {
            switch (_operacion)
            {
                    case TipoOperacion.Insert:
                        btnEjecutar.Text = "Guardar";
                    break;
                    case TipoOperacion.Update:
                        btnEjecutar.Text = "Modificar";
                        CargarDatos(EntidadId);
                    break;
                    case TipoOperacion.Delete:
                        btnEjecutar.Text = "Eliminar";
                    CargarDatos(EntidadId);
                    break;
            }
        }

        //=========================== METODOS ========================//
        public virtual void CargarDatos(long? entidadId)
        {
        }

        private void EjecutarComando()
        {
            switch (_operacion)
            {
                case TipoOperacion.Insert:
                    if (verificarDatosObligatorios())
                    {
                        EjecutarComandoInsert();
                        LimpiarControles();
                        RealizoAlgunaOperacion = true;
                    }
                    else
                    {
                        Mensaje.Mostrar("Faltan datos por cargar", Mensaje.Tipo.Informacion);
                    }
                    break;
                    case TipoOperacion.Update:
                        if (verificarDatosObligatorios())
                        {
                            EjecutarComandoUpDate();
                            RealizoAlgunaOperacion = true;
                        LimpiarControles();
                        }
                        else
                        {
                            Mensaje.Mostrar("Hay campo que no pueden estar vacios", Mensaje.Tipo.Advertencia);
                        }
                        break;
                    case TipoOperacion.Delete:
                        EjecutarComandoDelete();
                        RealizoAlgunaOperacion = true;
                    Close();
                    break;
            }
        }

        private bool verificarDatosObligatorios()
        {
            foreach (var objeto in _listaControlObligatorio)
            {
                if (objeto.Control is TextBox)
                {
                    if (string.IsNullOrEmpty(((TextBox)objeto.Control).Text))
                    {
                        return false;
                    }
                }
                else if (objeto.Control is RichTextBox)
                {
                    if (string.IsNullOrEmpty(((RichTextBox)objeto.Control).Text))
                    {
                        return false;
                    }
                }
                else if (objeto.Control is NumericUpDown)
                {
                    if (string.IsNullOrEmpty(((NumericUpDown)objeto.Control).Text))
                    {
                        return false;
                    }
                }
                else if (objeto.Control is ComboBox)
                {
                    if (((ComboBox)objeto.Control).Items.Count <= 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public virtual void EjecutarComandoDelete()
        {
        }

        public virtual void EjecutarComandoUpDate()
        {
        }

        public virtual void EjecutarComandoInsert()
        {
        }

        public virtual  void LimpiarControles()
        {
        }

        private bool VerificarDatosSinGuardar()
        {
            foreach (var Objeto in _listaControlObligatorio)
            {
                if (Objeto.Control is TextBox)
                {
                    if (!string.IsNullOrEmpty(((TextBox)Objeto.Control).Text))
                    {
                        return true;
                    }
                }
                else if (Objeto.Control is RichTextBox)
                {
                    if (!string.IsNullOrEmpty(((RichTextBox)Objeto.Control).Text))
                    {
                        return true;
                    }
                }
                else if (Objeto.Control is NumericUpDown)
                {
                    if (!string.IsNullOrEmpty(((NumericUpDown)Objeto.Control).Text))
                    {
                        return true;
                    }
                }
                else if (Objeto.Control is ComboBox)
                {
                    if (((ComboBox)Objeto.Control).Items.Count <= 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void FormularioAbm_Load(object sender, EventArgs e)
        {
            lblUsuarioLogin.Text = $@"Usuario: {Identidad.ApyNomEmpleadoLogin}";
        }
    }
}
