using System;
using System.Linq;
using System.Windows.Forms;
using XCommerce.Base.Helpers;
using XCommerce.LogicaNegocio.Articulo;
using XCommerce.LogicaNegocio.Articulo.DTOs;
using XCommerce.LogicaNegocio.Rubro;

namespace XCommerce.Core.Controles.FormulariosVarios
{
    public partial class FControlArticulos : Form
    {
        private int _index;
        private readonly ArticuloServicio _articuloServicio;
        private readonly RubroServicio _rubroServicio;

        public delegate void AgregarArticulo(ArticuloDto articulo);
        public event AgregarArticulo AgregarArticuloParaLaVenta;

        public FControlArticulos()
            : this(new ArticuloServicio(), new RubroServicio())
        {
            InitializeComponent();
            _index = 0;
        }

        public FControlArticulos(ArticuloServicio articuloServicio, RubroServicio rubroServicio)
        {
            _articuloServicio = articuloServicio;
            _rubroServicio = rubroServicio;
        }

        protected virtual void OnAgregarArticuloParaLaVenta(ArticuloDto articulo)
        {
            AgregarArticuloParaLaVenta?.Invoke(articulo);
        }

        //private void FControlArticulos_Load(object sender, System.EventArgs e)
        //{
        //    var rubros = _rubroServicio.Obtener(Identidad.EmpresaId, string.Empty);

        //    foreach (var rubro in rubros)
        //    {
        //        flpRubros.Controls.Add(CrearBoton(_index, rubro.Id, rubro.Descripcion));
        //        _index++;
        //    }

        //    if (rubros != null && rubros.Any())
        //    {
        //        var primerRubro = rubros.First();
        //        ObtenerArticulos(primerRubro.Id);
        //    }
        //}

        //private void ObtenerArticulos(long rubroId)
        //{
        //    var articulos = _articuloServicio.ObtenerPorRubro(Identidad.EmpresaId, rubroId);
        //    var indexArticulo = 0;
        //    flpArticulos.Controls.Clear();

        //    foreach (var articulo in articulos)
        //    {
        //        var nuevoControlArticulo = CrearControlArticulo(indexArticulo, articulo);
        //        flpArticulos.Controls.Add(nuevoControlArticulo);
        //        indexArticulo++;
        //    }
        //}

        //private RubroButton CrearBoton(int index, long rubroId, string descripcion)
        //{
        //    var btnRubro = new RubroButton
        //    {
        //        RubroId = rubroId,
        //        BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (64)))), ((int) (((byte) (64)))),
        //            ((int) (((byte) (64))))),
        //        FlatStyle = System.Windows.Forms.FlatStyle.Flat,
        //        Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold,
        //            System.Drawing.GraphicsUnit.Point, ((byte) (0))),
        //        ForeColor = System.Drawing.Color.WhiteSmoke,
        //        Location = new System.Drawing.Point(3, 3),
        //        Name = $"btn{descripcion}",
        //        Size = new System.Drawing.Size(flpRubros.Width-30, 60),
        //        TabIndex = index,
        //        Text = descripcion,
        //        UseVisualStyleBackColor = false,
        //    };

        //    btnRubro.Click += btnRubro_Click;
        //    return btnRubro;
        //}

        //private void btnRubro_Click(object sender, EventArgs e)
        //{
        //    if (sender is RubroButton)
        //    {
        //        var boton = (RubroButton) sender;
        //        ObtenerArticulos(boton.RubroId);
        //    }
        //}

        //private ctrolArticulo CrearControlArticulo(int index, ArticuloDto articuloDto)
        //{
        //    var ctrolArticulo = new ctrolArticulo
        //    {
        //        Id = articuloDto.Id,
        //        Nombre = articuloDto.Descripcion,
        //        Descripcion = articuloDto.Descripcion,
        //        Foto = articuloDto.Foto,
        //        Codigo = articuloDto.Codigo,
        //        PrecioUnitario = 10,
        //        Cantidad = 1,
                
        //        BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
        //        Location = new System.Drawing.Point(3, 3),
        //        MaximumSize = new System.Drawing.Size(149, 88),
        //        MinimumSize = new System.Drawing.Size(149, 88),
        //        Name = $"ctrol{articuloDto.Id}",
        //        Size = new System.Drawing.Size(149, 88),
        //        TabIndex = index
        //    };

        //    ctrolArticulo.AgregarArticuloParalaVenta += AgregarArticuloParaVenta;

        //    return ctrolArticulo;
        //}

        private void AgregarArticuloParaVenta(ArticuloDto articuloDto)
        {
            OnAgregarArticuloParaLaVenta(articuloDto);
        }
    }
}
