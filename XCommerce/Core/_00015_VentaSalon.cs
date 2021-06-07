using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XCommerce.Base.Formularios;
using XCommerce.Base.Helpers;
using XCommerce.Core.Controles;
using XCommerce.LogicaNegocio.Mesa;
using XCommerce.LogicaNegocio.Sala;
using XCommerce.LogicaNegocio.Sala.DTOs;
using Color = System.Drawing.Color;

namespace XCommerce.Core
{
    public partial class _00015_VentaSalon : FormularioBase
    {
        private readonly SalaServicio _salaServicio;
        private readonly MesaServicio _mesaServicio;
        public _00015_VentaSalon()
            :this(new MesaServicio(), new SalaServicio())
        {
            InitializeComponent();
            Inicializador();
        }

        public _00015_VentaSalon(MesaServicio mesaServicio, SalaServicio salaServicio)
        {
            _mesaServicio = mesaServicio;
            _salaServicio = salaServicio;
        }

        //=========================== INICIALIZADOR ======================//
        private void Inicializador()
        {
            lblUsuarioLogin.Text += Identidad.ApyNomEmpleadoLogin;

            var salasCreadas = _salaServicio.ObtenerTodo(Identidad.EmpresaId, string.Empty);
            CrearSalas(salasCreadas);
        }

        //======================== CREAR SALAS ===========================//
        private void CrearSalas(IEnumerable<SalaDto> salasCreadas)
        {
            var contenedorSalas = new TabControl();

            var contador = 0;

            foreach (var sala in salasCreadas.ToList())
            {
                var mesas = _mesaServicio.ObtenerPorSala(sala.Id);

                var flowContenedor = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    Location = new System.Drawing.Point(3, 3),
                    Name = $"{contador}FlowSala",
                    Size = new System.Drawing.Size(848, 351),
                    TabIndex = 0,
                    BackColor = Color.DarkGray,
                };

                foreach (var mesa in mesas)
                {
                    var controlMesa = new ctrolMesa
                    {
                        MesaId = mesa.Id,
                        Numero = mesa.Codigo,
                        Estado = mesa.EstadoMesa,
                        //MontoConsumido = mesa.Monto
                    };

                    flowContenedor.Controls.Add(controlMesa);
                }

                var paginaSala = new TabPage
                {
                    Location = new System.Drawing.Point(4, 22),
                    Name = $"{contador}{sala.Descripcion}",
                    Padding = new Padding(3),
                    Size = new System.Drawing.Size(854, 357),
                    TabIndex = contador,
                    Text = sala.Descripcion,
                    UseVisualStyleBackColor = true
                };
                paginaSala.Controls.Add(flowContenedor);

                contenedorSalas.Controls.Add(paginaSala);
                contador++;
            }

            contenedorSalas.Dock = DockStyle.Fill;
            contenedorSalas.Location = new System.Drawing.Point(0, 66);
            contenedorSalas.Name = "tabVentaSalon";
            contenedorSalas.SelectedIndex = 0;
            contenedorSalas.Size = new System.Drawing.Size(862, 383);
            contenedorSalas.TabIndex = 9;
            contenedorSalas.Padding = new Point(20, 15);

            this.Controls.Add(contenedorSalas);
            this.Controls.SetChildIndex(contenedorSalas, 0);
            contenedorSalas.ResumeLayout(false);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtMesa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int) Keys.Enter)
            {
                var salasCreadas = _salaServicio.ObtenerTodo(Identidad.EmpresaId, txtMesa.Text);
                CrearSalas(salasCreadas);
            }
        }
    }
}
