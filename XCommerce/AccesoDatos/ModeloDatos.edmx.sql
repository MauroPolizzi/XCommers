
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/10/2018 18:32:58
-- Generated from EDMX file: C:\Users\augusto\Documents\Loboratorio\2do Cuatrimestre\Final2-Laboratorio\XCommerce\AccesoDatos\ModeloDatos.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Final2-Laboratorio];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EmpleadoUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_EmpleadoUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_CondicionIvaEmpresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empresas] DROP CONSTRAINT [FK_CondicionIvaEmpresa];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpleadoEmpresa_Empleado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmpleadoEmpresa] DROP CONSTRAINT [FK_EmpleadoEmpresa_Empleado];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpleadoEmpresa_Empresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmpleadoEmpresa] DROP CONSTRAINT [FK_EmpleadoEmpresa_Empresa];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaSala]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Salas] DROP CONSTRAINT [FK_EmpresaSala];
GO
IF OBJECT_ID(N'[dbo].[FK_SalaMesa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mesas] DROP CONSTRAINT [FK_SalaMesa];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioPerfil_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioPerfil] DROP CONSTRAINT [FK_UsuarioPerfil_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioPerfil_Perfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioPerfil] DROP CONSTRAINT [FK_UsuarioPerfil_Perfil];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilFormulario_Perfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerfilFormulario] DROP CONSTRAINT [FK_PerfilFormulario_Perfil];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilFormulario_Formulario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerfilFormulario] DROP CONSTRAINT [FK_PerfilFormulario_Formulario];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaPerfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Perfiles] DROP CONSTRAINT [FK_EmpresaPerfil];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaComprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes] DROP CONSTRAINT [FK_EmpresaComprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioComprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes] DROP CONSTRAINT [FK_UsuarioComprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteComprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes] DROP CONSTRAINT [FK_ClienteComprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpleadoComprobante_Salon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_Salon] DROP CONSTRAINT [FK_EmpleadoComprobante_Salon];
GO
IF OBJECT_ID(N'[dbo].[FK_MesaComprobante_Salon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_Salon] DROP CONSTRAINT [FK_MesaComprobante_Salon];
GO
IF OBJECT_ID(N'[dbo].[FK_ComprobanteDetalleComprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleComprobantes] DROP CONSTRAINT [FK_ComprobanteDetalleComprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticuloDetalleComprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleComprobantes] DROP CONSTRAINT [FK_ArticuloDetalleComprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpleadoDelivery]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_Delivery] DROP CONSTRAINT [FK_EmpleadoDelivery];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioCaja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cajas] DROP CONSTRAINT [FK_UsuarioCaja];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioCajaCierre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cajas] DROP CONSTRAINT [FK_UsuarioCajaCierre];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaCaja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cajas] DROP CONSTRAINT [FK_EmpresaCaja];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoComprobanteComprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes] DROP CONSTRAINT [FK_TipoComprobanteComprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_CajaDetalleCaja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCajas] DROP CONSTRAINT [FK_CajaDetalleCaja];
GO
IF OBJECT_ID(N'[dbo].[FK_ComprobanteMovimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movimientos] DROP CONSTRAINT [FK_ComprobanteMovimiento];
GO
IF OBJECT_ID(N'[dbo].[FK_CajaMovimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movimientos] DROP CONSTRAINT [FK_CajaMovimiento];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioMovimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Movimientos] DROP CONSTRAINT [FK_UsuarioMovimiento];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaConfiguracion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Configuraciones] DROP CONSTRAINT [FK_EmpresaConfiguracion];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoComprobanteConfiguracion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Configuraciones] DROP CONSTRAINT [FK_TipoComprobanteConfiguracion];
GO
IF OBJECT_ID(N'[dbo].[FK_MarcaArticulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articulos] DROP CONSTRAINT [FK_MarcaArticulo];
GO
IF OBJECT_ID(N'[dbo].[FK_RubroSubRubro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubRubros] DROP CONSTRAINT [FK_RubroSubRubro];
GO
IF OBJECT_ID(N'[dbo].[FK_SubRubroArticulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articulos] DROP CONSTRAINT [FK_SubRubroArticulo];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaTipoComprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TipoComprobantes] DROP CONSTRAINT [FK_EmpresaTipoComprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaRubro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rubros] DROP CONSTRAINT [FK_EmpresaRubro];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaMarca]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Marcas] DROP CONSTRAINT [FK_EmpresaMarca];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticuloIngrediente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ingredientes] DROP CONSTRAINT [FK_ArticuloIngrediente];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticuloIngrediente1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ingredientes] DROP CONSTRAINT [FK_ArticuloIngrediente1];
GO
IF OBJECT_ID(N'[dbo].[FK_TarjetaPlanTarjeta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlanTarjetas] DROP CONSTRAINT [FK_TarjetaPlanTarjeta];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanTarjetaFormaPagoTarjeta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormaPagos_FormaPagoTarjeta] DROP CONSTRAINT [FK_PlanTarjetaFormaPagoTarjeta];
GO
IF OBJECT_ID(N'[dbo].[FK_BancoFormaPagoCheque]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormaPagos_FormaPagoCheque] DROP CONSTRAINT [FK_BancoFormaPagoCheque];
GO
IF OBJECT_ID(N'[dbo].[FK_ComprobanteFormaPago]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormaPagos] DROP CONSTRAINT [FK_ComprobanteFormaPago];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteFormaPagoCuentaCorriente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormaPagos_FormaPagoCuentaCorriente] DROP CONSTRAINT [FK_ClienteFormaPagoCuentaCorriente];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaPrecio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Precios] DROP CONSTRAINT [FK_EmpresaPrecio];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticuloPrecio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Precios] DROP CONSTRAINT [FK_ArticuloPrecio];
GO
IF OBJECT_ID(N'[dbo].[FK_ListaPrecioPrecio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Precios] DROP CONSTRAINT [FK_ListaPrecioPrecio];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaDeposito]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Depositos] DROP CONSTRAINT [FK_EmpresaDeposito];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteCuentaCorriente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CuentaCorrientes] DROP CONSTRAINT [FK_ClienteCuentaCorriente];
GO
IF OBJECT_ID(N'[dbo].[FK_DepositoStock]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stocks] DROP CONSTRAINT [FK_DepositoStock];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticuloStock]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stocks] DROP CONSTRAINT [FK_ArticuloStock];
GO
IF OBJECT_ID(N'[dbo].[FK_StockBajaArticulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BajasArticulos] DROP CONSTRAINT [FK_StockBajaArticulo];
GO
IF OBJECT_ID(N'[dbo].[FK_ListaPrecioConfiguracion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Configuraciones] DROP CONSTRAINT [FK_ListaPrecioConfiguracion];
GO
IF OBJECT_ID(N'[dbo].[FK_DepositoConfiguracion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Configuraciones] DROP CONSTRAINT [FK_DepositoConfiguracion];
GO
IF OBJECT_ID(N'[dbo].[FK_CondicionIvaProveedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proveedores] DROP CONSTRAINT [FK_CondicionIvaProveedor];
GO
IF OBJECT_ID(N'[dbo].[FK_ProveedorCuentaCorrienteProveedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CuentaCorrienteProveedores] DROP CONSTRAINT [FK_ProveedorCuentaCorrienteProveedor];
GO
IF OBJECT_ID(N'[dbo].[FK_ProveedorCompra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_Compra] DROP CONSTRAINT [FK_ProveedorCompra];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaListaPrecio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ListaPrecios] DROP CONSTRAINT [FK_EmpresaListaPrecio];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaArticulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articulos] DROP CONSTRAINT [FK_EmpresaArticulo];
GO
IF OBJECT_ID(N'[dbo].[FK_Empleado_inherits_Persona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas_Empleado] DROP CONSTRAINT [FK_Empleado_inherits_Persona];
GO
IF OBJECT_ID(N'[dbo].[FK_Cliente_inherits_Persona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personas_Cliente] DROP CONSTRAINT [FK_Cliente_inherits_Persona];
GO
IF OBJECT_ID(N'[dbo].[FK_Salon_inherits_Comprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_Salon] DROP CONSTRAINT [FK_Salon_inherits_Comprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_Delivery_inherits_Comprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_Delivery] DROP CONSTRAINT [FK_Delivery_inherits_Comprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_FormaPagoTarjeta_inherits_FormaPago]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormaPagos_FormaPagoTarjeta] DROP CONSTRAINT [FK_FormaPagoTarjeta_inherits_FormaPago];
GO
IF OBJECT_ID(N'[dbo].[FK_FormaPagoCheque_inherits_FormaPago]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormaPagos_FormaPagoCheque] DROP CONSTRAINT [FK_FormaPagoCheque_inherits_FormaPago];
GO
IF OBJECT_ID(N'[dbo].[FK_FormaPagoCuentaCorriente_inherits_FormaPago]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormaPagos_FormaPagoCuentaCorriente] DROP CONSTRAINT [FK_FormaPagoCuentaCorriente_inherits_FormaPago];
GO
IF OBJECT_ID(N'[dbo].[FK_Compra_inherits_Comprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_Compra] DROP CONSTRAINT [FK_Compra_inherits_Comprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_Factura_inherits_Comprobante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comprobantes_Factura] DROP CONSTRAINT [FK_Factura_inherits_Comprobante];
GO
IF OBJECT_ID(N'[dbo].[FK_FormaPagoEfectivo_inherits_FormaPago]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormaPagos_FormaPagoEfectivo] DROP CONSTRAINT [FK_FormaPagoEfectivo_inherits_FormaPago];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Personas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personas];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO
IF OBJECT_ID(N'[dbo].[Empresas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empresas];
GO
IF OBJECT_ID(N'[dbo].[CondicionIvas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CondicionIvas];
GO
IF OBJECT_ID(N'[dbo].[Salas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Salas];
GO
IF OBJECT_ID(N'[dbo].[Mesas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mesas];
GO
IF OBJECT_ID(N'[dbo].[Perfiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perfiles];
GO
IF OBJECT_ID(N'[dbo].[Formularios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Formularios];
GO
IF OBJECT_ID(N'[dbo].[Comprobantes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comprobantes];
GO
IF OBJECT_ID(N'[dbo].[DetalleComprobantes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleComprobantes];
GO
IF OBJECT_ID(N'[dbo].[Articulos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Articulos];
GO
IF OBJECT_ID(N'[dbo].[Cajas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cajas];
GO
IF OBJECT_ID(N'[dbo].[TipoComprobantes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoComprobantes];
GO
IF OBJECT_ID(N'[dbo].[DetalleCajas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleCajas];
GO
IF OBJECT_ID(N'[dbo].[Movimientos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movimientos];
GO
IF OBJECT_ID(N'[dbo].[Configuraciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Configuraciones];
GO
IF OBJECT_ID(N'[dbo].[Marcas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Marcas];
GO
IF OBJECT_ID(N'[dbo].[Rubros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rubros];
GO
IF OBJECT_ID(N'[dbo].[SubRubros]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubRubros];
GO
IF OBJECT_ID(N'[dbo].[Ingredientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ingredientes];
GO
IF OBJECT_ID(N'[dbo].[FormaPagos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormaPagos];
GO
IF OBJECT_ID(N'[dbo].[Tarjetas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tarjetas];
GO
IF OBJECT_ID(N'[dbo].[PlanTarjetas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlanTarjetas];
GO
IF OBJECT_ID(N'[dbo].[Bancos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bancos];
GO
IF OBJECT_ID(N'[dbo].[Precios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Precios];
GO
IF OBJECT_ID(N'[dbo].[ListaPrecios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ListaPrecios];
GO
IF OBJECT_ID(N'[dbo].[Depositos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Depositos];
GO
IF OBJECT_ID(N'[dbo].[CuentaCorrientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CuentaCorrientes];
GO
IF OBJECT_ID(N'[dbo].[Stocks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stocks];
GO
IF OBJECT_ID(N'[dbo].[BajasArticulos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BajasArticulos];
GO
IF OBJECT_ID(N'[dbo].[Proveedores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedores];
GO
IF OBJECT_ID(N'[dbo].[CuentaCorrienteProveedores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CuentaCorrienteProveedores];
GO
IF OBJECT_ID(N'[dbo].[Personas_Empleado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personas_Empleado];
GO
IF OBJECT_ID(N'[dbo].[Personas_Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personas_Cliente];
GO
IF OBJECT_ID(N'[dbo].[Comprobantes_Salon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comprobantes_Salon];
GO
IF OBJECT_ID(N'[dbo].[Comprobantes_Delivery]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comprobantes_Delivery];
GO
IF OBJECT_ID(N'[dbo].[FormaPagos_FormaPagoTarjeta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormaPagos_FormaPagoTarjeta];
GO
IF OBJECT_ID(N'[dbo].[FormaPagos_FormaPagoCheque]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormaPagos_FormaPagoCheque];
GO
IF OBJECT_ID(N'[dbo].[FormaPagos_FormaPagoCuentaCorriente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormaPagos_FormaPagoCuentaCorriente];
GO
IF OBJECT_ID(N'[dbo].[Comprobantes_Compra]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comprobantes_Compra];
GO
IF OBJECT_ID(N'[dbo].[Comprobantes_Factura]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comprobantes_Factura];
GO
IF OBJECT_ID(N'[dbo].[FormaPagos_FormaPagoEfectivo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormaPagos_FormaPagoEfectivo];
GO
IF OBJECT_ID(N'[dbo].[EmpleadoEmpresa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmpleadoEmpresa];
GO
IF OBJECT_ID(N'[dbo].[UsuarioPerfil]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioPerfil];
GO
IF OBJECT_ID(N'[dbo].[PerfilFormulario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PerfilFormulario];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Personas'
CREATE TABLE [dbo].[Personas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Apellido] nvarchar(250)  NOT NULL,
    [Nombre] nvarchar(250)  NOT NULL,
    [Dni] nvarchar(8)  NOT NULL,
    [Domicilio] nvarchar(400)  NOT NULL,
    [Telefono] nvarchar(25)  NOT NULL,
    [Email] nvarchar(250)  NOT NULL,
    [Celular] nvarchar(25)  NOT NULL,
    [FechaNacimiento] datetime  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [EmpleadoId] bigint  NOT NULL,
    [Nombre] nvarchar(250)  NOT NULL,
    [Password] nvarchar(400)  NOT NULL,
    [EstaBloqueado] bit  NOT NULL
);
GO

-- Creating table 'Empresas'
CREATE TABLE [dbo].[Empresas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [CondicionIvaId] bigint  NOT NULL,
    [RazonSocial] nvarchar(250)  NOT NULL,
    [NombreFantasia] nvarchar(250)  NOT NULL,
    [Cuit] nvarchar(13)  NOT NULL,
    [Domicilio] nvarchar(400)  NOT NULL,
    [Telefono] nvarchar(25)  NOT NULL,
    [Mail] nvarchar(250)  NOT NULL,
    [Sucursal] int  NOT NULL,
    [Logo] varbinary(max)  NOT NULL
);
GO

-- Creating table 'CondicionIvas'
CREATE TABLE [dbo].[CondicionIvas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Codigo] int  NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminada] bit  NOT NULL
);
GO

-- Creating table 'Salas'
CREATE TABLE [dbo].[Salas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [EmpresaId] bigint  NOT NULL,
    [Codigo] int  NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminada] bit  NOT NULL
);
GO

-- Creating table 'Mesas'
CREATE TABLE [dbo].[Mesas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [SalaId] bigint  NOT NULL,
    [Codigo] int  NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstadoMesa] int  NOT NULL
);
GO

-- Creating table 'Perfiles'
CREATE TABLE [dbo].[Perfiles] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EmpresaId] bigint  NOT NULL
);
GO

-- Creating table 'Formularios'
CREATE TABLE [dbo].[Formularios] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(5)  NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [DescripcionCompleta] nvarchar(255)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Comprobantes'
CREATE TABLE [dbo].[Comprobantes] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Numero] bigint  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [SubTotal] decimal(18,2)  NOT NULL,
    [Descuento] decimal(18,2)  NOT NULL,
    [Total] decimal(18,2)  NOT NULL,
    [EmpresaId] bigint  NOT NULL,
    [UsuarioId] bigint  NOT NULL,
    [ClienteId] bigint  NOT NULL,
    [TipoComprobanteId] bigint  NOT NULL
);
GO

-- Creating table 'DetalleComprobantes'
CREATE TABLE [dbo].[DetalleComprobantes] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ComprobanteId] bigint  NOT NULL,
    [Codigo] nvarchar(50)  NOT NULL,
    [Descripcion] nvarchar(400)  NOT NULL,
    [PrecioUnitario] decimal(18,2)  NOT NULL,
    [Cantidad] decimal(18,2)  NOT NULL,
    [SubTotal] decimal(18,2)  NOT NULL,
    [ArticuloId] bigint  NOT NULL
);
GO

-- Creating table 'Articulos'
CREATE TABLE [dbo].[Articulos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [CodigoBarra] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [EstaEliminado] bit  NOT NULL,
    [Abreviatura] nvarchar(max)  NOT NULL,
    [MarcaId] bigint  NOT NULL,
    [SubRubroId] bigint  NOT NULL,
    [Foto] varbinary(max)  NOT NULL,
    [ActivarLimiteVenta] bit  NOT NULL,
    [CantidadLimiteVenta] decimal(18,2)  NOT NULL,
    [PermiteStockNegativo] bit  NOT NULL,
    [EstaDiscontinuado] bit  NOT NULL,
    [TipoArticulo] int  NOT NULL,
    [StockMaximo] decimal(18,2)  NOT NULL,
    [StockMinimo] decimal(18,2)  NOT NULL,
    [DescuentaStock] bit  NOT NULL,
    [SePuedeFraccionar] bit  NOT NULL,
    [Detalle] nvarchar(max)  NOT NULL,
    [EmpresaId] bigint  NOT NULL
);
GO

-- Creating table 'Cajas'
CREATE TABLE [dbo].[Cajas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [UsuarioAperturaId] bigint  NOT NULL,
    [UsuarioCierreId] bigint  NULL,
    [MontoApertura] decimal(18,2)  NOT NULL,
    [MontoCierre] decimal(18,2)  NULL,
    [FechaApertura] datetime  NOT NULL,
    [FechaCierre] datetime  NULL,
    [MontoSistema] decimal(18,2)  NULL,
    [Diferencia] decimal(18,2)  NULL,
    [EmpresaId] bigint  NOT NULL
);
GO

-- Creating table 'TipoComprobantes'
CREATE TABLE [dbo].[TipoComprobantes] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Codigo] int  NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminado] bit  NOT NULL,
    [EmpresaId] bigint  NOT NULL,
    [Letra] nvarchar(5)  NOT NULL
);
GO

-- Creating table 'DetalleCajas'
CREATE TABLE [dbo].[DetalleCajas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [CajaId] bigint  NOT NULL,
    [Monto] decimal(18,2)  NOT NULL,
    [TipoPago] int  NOT NULL
);
GO

-- Creating table 'Movimientos'
CREATE TABLE [dbo].[Movimientos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ComprobanteId] bigint  NOT NULL,
    [TipoMovimiento] int  NOT NULL,
    [CajaId] bigint  NOT NULL,
    [UsuarioId] bigint  NOT NULL,
    [Monto] decimal(18,2)  NOT NULL,
    [Fecha] datetime  NOT NULL
);
GO

-- Creating table 'Configuraciones'
CREATE TABLE [dbo].[Configuraciones] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [EmpresaId] bigint  NOT NULL,
    [TipoComprobantePorDefectoId] bigint  NOT NULL,
    [ListaPrecioPorDefectoId] bigint  NOT NULL,
    [DepositoPorDefectoId] bigint  NOT NULL,
    [PuestoDeCajaSeparado] bit  NOT NULL,
    [SeCobraCubiertos] bit  NOT NULL,
    [MontoPorCubierto] decimal(18,2)  NOT NULL,
    [GrabarProductoEnTodosDepositos] bit  NOT NULL
);
GO

-- Creating table 'Marcas'
CREATE TABLE [dbo].[Marcas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Codigo] int  NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminada] bit  NOT NULL,
    [EmpresaId] bigint  NOT NULL
);
GO

-- Creating table 'Rubros'
CREATE TABLE [dbo].[Rubros] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Codigo] int  NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminado] bit  NOT NULL,
    [EmpresaId] bigint  NOT NULL
);
GO

-- Creating table 'SubRubros'
CREATE TABLE [dbo].[SubRubros] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [RubroId] bigint  NOT NULL,
    [Codigo] int  NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Ingredientes'
CREATE TABLE [dbo].[Ingredientes] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ArticuloPadreId] bigint  NOT NULL,
    [ArticuloHijoId] bigint  NOT NULL,
    [Cantidad] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'FormaPagos'
CREATE TABLE [dbo].[FormaPagos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ComprobanteId] bigint  NOT NULL,
    [TipoFormaPago] int  NOT NULL,
    [Monto] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'Tarjetas'
CREATE TABLE [dbo].[Tarjetas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Codigo] int  NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminada] bit  NOT NULL
);
GO

-- Creating table 'PlanTarjetas'
CREATE TABLE [dbo].[PlanTarjetas] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [TarjetaId] bigint  NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [Alicuota] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'Bancos'
CREATE TABLE [dbo].[Bancos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Codigo] int  NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'Precios'
CREATE TABLE [dbo].[Precios] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [FechaActualizacion] datetime  NOT NULL,
    [PrecioCosto] decimal(18,2)  NOT NULL,
    [PrecioPublico] decimal(18,2)  NOT NULL,
    [Rentabilidad] decimal(18,2)  NOT NULL,
    [EmpresaId] bigint  NOT NULL,
    [ArticuloId] bigint  NOT NULL,
    [ListaPrecioId] bigint  NOT NULL
);
GO

-- Creating table 'ListaPrecios'
CREATE TABLE [dbo].[ListaPrecios] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Codigo] int  NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EmpresaId] bigint  NOT NULL,
    [EstaEliminada] bit  NOT NULL
);
GO

-- Creating table 'Depositos'
CREATE TABLE [dbo].[Depositos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [EmpresaId] bigint  NOT NULL,
    [Codigo] int  NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [EstaEliminado] bit  NOT NULL
);
GO

-- Creating table 'CuentaCorrientes'
CREATE TABLE [dbo].[CuentaCorrientes] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ClienteId] bigint  NOT NULL,
    [Descripcion] nvarchar(400)  NOT NULL,
    [Monto] decimal(18,2)  NOT NULL,
    [TipoMovimiento] int  NOT NULL,
    [Fecha] datetime  NOT NULL
);
GO

-- Creating table 'Stocks'
CREATE TABLE [dbo].[Stocks] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [DepositoId] bigint  NOT NULL,
    [ArticuloId] bigint  NOT NULL,
    [Cantidad] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'BajasArticulos'
CREATE TABLE [dbo].[BajasArticulos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [StockId] bigint  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Cantidad] decimal(18,2)  NOT NULL,
    [Observacion] nvarchar(400)  NOT NULL
);
GO

-- Creating table 'Proveedores'
CREATE TABLE [dbo].[Proveedores] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [RazonSocial] nvarchar(max)  NOT NULL,
    [Domicilio] nvarchar(max)  NOT NULL,
    [Telefono] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [CondicionIvaId] bigint  NOT NULL
);
GO

-- Creating table 'CuentaCorrienteProveedores'
CREATE TABLE [dbo].[CuentaCorrienteProveedores] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ProveedorId] bigint  NOT NULL,
    [TipoMovimiento] int  NOT NULL,
    [Monto] decimal(18,2)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Descripcion] nvarchar(400)  NOT NULL
);
GO

-- Creating table 'Personas_Empleado'
CREATE TABLE [dbo].[Personas_Empleado] (
    [Legajo] int  NOT NULL,
    [FechaIngreso] datetime  NOT NULL,
    [Foto] varbinary(max)  NOT NULL,
    [EstaEliminado] bit  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'Personas_Cliente'
CREATE TABLE [dbo].[Personas_Cliente] (
    [MontoMaximoCompra] decimal(18,2)  NOT NULL,
    [TieneCuentaCorriente] bit  NOT NULL,
    [EstaBloqueado] bit  NOT NULL,
    [EstaEliminado] bit  NOT NULL,
    [Visible] bit  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'Comprobantes_Salon'
CREATE TABLE [dbo].[Comprobantes_Salon] (
    [Estado] int  NOT NULL,
    [Comensales] int  NOT NULL,
    [EmpleadoId] bigint  NULL,
    [MesaId] bigint  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'Comprobantes_Delivery'
CREATE TABLE [dbo].[Comprobantes_Delivery] (
    [Estado] int  NOT NULL,
    [CostoEnvio] decimal(18,2)  NOT NULL,
    [EmpleadoId] bigint  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'FormaPagos_FormaPagoTarjeta'
CREATE TABLE [dbo].[FormaPagos_FormaPagoTarjeta] (
    [PlanTarjetaId] bigint  NOT NULL,
    [Cupon] nvarchar(50)  NOT NULL,
    [Numero] nvarchar(50)  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'FormaPagos_FormaPagoCheque'
CREATE TABLE [dbo].[FormaPagos_FormaPagoCheque] (
    [BancoId] bigint  NOT NULL,
    [Numero] nvarchar(50)  NOT NULL,
    [EnteEmisor] nvarchar(250)  NOT NULL,
    [FechaEmision] datetime  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'FormaPagos_FormaPagoCuentaCorriente'
CREATE TABLE [dbo].[FormaPagos_FormaPagoCuentaCorriente] (
    [ClienteId] bigint  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'Comprobantes_Compra'
CREATE TABLE [dbo].[Comprobantes_Compra] (
    [ProveedorId] bigint  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'Comprobantes_Factura'
CREATE TABLE [dbo].[Comprobantes_Factura] (
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'FormaPagos_FormaPagoEfectivo'
CREATE TABLE [dbo].[FormaPagos_FormaPagoEfectivo] (
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'EmpleadoEmpresa'
CREATE TABLE [dbo].[EmpleadoEmpresa] (
    [Empleados_Id] bigint  NOT NULL,
    [Empresas_Id] bigint  NOT NULL
);
GO

-- Creating table 'UsuarioPerfil'
CREATE TABLE [dbo].[UsuarioPerfil] (
    [Usuarios_Id] bigint  NOT NULL,
    [Perfiles_Id] bigint  NOT NULL
);
GO

-- Creating table 'PerfilFormulario'
CREATE TABLE [dbo].[PerfilFormulario] (
    [Perfiles_Id] bigint  NOT NULL,
    [Formularios_Id] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [PK_Personas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Empresas'
ALTER TABLE [dbo].[Empresas]
ADD CONSTRAINT [PK_Empresas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CondicionIvas'
ALTER TABLE [dbo].[CondicionIvas]
ADD CONSTRAINT [PK_CondicionIvas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Salas'
ALTER TABLE [dbo].[Salas]
ADD CONSTRAINT [PK_Salas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Mesas'
ALTER TABLE [dbo].[Mesas]
ADD CONSTRAINT [PK_Mesas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [PK_Perfiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Formularios'
ALTER TABLE [dbo].[Formularios]
ADD CONSTRAINT [PK_Formularios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comprobantes'
ALTER TABLE [dbo].[Comprobantes]
ADD CONSTRAINT [PK_Comprobantes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetalleComprobantes'
ALTER TABLE [dbo].[DetalleComprobantes]
ADD CONSTRAINT [PK_DetalleComprobantes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [PK_Articulos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cajas'
ALTER TABLE [dbo].[Cajas]
ADD CONSTRAINT [PK_Cajas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TipoComprobantes'
ALTER TABLE [dbo].[TipoComprobantes]
ADD CONSTRAINT [PK_TipoComprobantes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetalleCajas'
ALTER TABLE [dbo].[DetalleCajas]
ADD CONSTRAINT [PK_DetalleCajas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Movimientos'
ALTER TABLE [dbo].[Movimientos]
ADD CONSTRAINT [PK_Movimientos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Configuraciones'
ALTER TABLE [dbo].[Configuraciones]
ADD CONSTRAINT [PK_Configuraciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Marcas'
ALTER TABLE [dbo].[Marcas]
ADD CONSTRAINT [PK_Marcas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rubros'
ALTER TABLE [dbo].[Rubros]
ADD CONSTRAINT [PK_Rubros]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubRubros'
ALTER TABLE [dbo].[SubRubros]
ADD CONSTRAINT [PK_SubRubros]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ingredientes'
ALTER TABLE [dbo].[Ingredientes]
ADD CONSTRAINT [PK_Ingredientes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FormaPagos'
ALTER TABLE [dbo].[FormaPagos]
ADD CONSTRAINT [PK_FormaPagos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tarjetas'
ALTER TABLE [dbo].[Tarjetas]
ADD CONSTRAINT [PK_Tarjetas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlanTarjetas'
ALTER TABLE [dbo].[PlanTarjetas]
ADD CONSTRAINT [PK_PlanTarjetas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bancos'
ALTER TABLE [dbo].[Bancos]
ADD CONSTRAINT [PK_Bancos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Precios'
ALTER TABLE [dbo].[Precios]
ADD CONSTRAINT [PK_Precios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ListaPrecios'
ALTER TABLE [dbo].[ListaPrecios]
ADD CONSTRAINT [PK_ListaPrecios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Depositos'
ALTER TABLE [dbo].[Depositos]
ADD CONSTRAINT [PK_Depositos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CuentaCorrientes'
ALTER TABLE [dbo].[CuentaCorrientes]
ADD CONSTRAINT [PK_CuentaCorrientes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Stocks'
ALTER TABLE [dbo].[Stocks]
ADD CONSTRAINT [PK_Stocks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BajasArticulos'
ALTER TABLE [dbo].[BajasArticulos]
ADD CONSTRAINT [PK_BajasArticulos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Proveedores'
ALTER TABLE [dbo].[Proveedores]
ADD CONSTRAINT [PK_Proveedores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CuentaCorrienteProveedores'
ALTER TABLE [dbo].[CuentaCorrienteProveedores]
ADD CONSTRAINT [PK_CuentaCorrienteProveedores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Personas_Empleado'
ALTER TABLE [dbo].[Personas_Empleado]
ADD CONSTRAINT [PK_Personas_Empleado]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Personas_Cliente'
ALTER TABLE [dbo].[Personas_Cliente]
ADD CONSTRAINT [PK_Personas_Cliente]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comprobantes_Salon'
ALTER TABLE [dbo].[Comprobantes_Salon]
ADD CONSTRAINT [PK_Comprobantes_Salon]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comprobantes_Delivery'
ALTER TABLE [dbo].[Comprobantes_Delivery]
ADD CONSTRAINT [PK_Comprobantes_Delivery]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FormaPagos_FormaPagoTarjeta'
ALTER TABLE [dbo].[FormaPagos_FormaPagoTarjeta]
ADD CONSTRAINT [PK_FormaPagos_FormaPagoTarjeta]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FormaPagos_FormaPagoCheque'
ALTER TABLE [dbo].[FormaPagos_FormaPagoCheque]
ADD CONSTRAINT [PK_FormaPagos_FormaPagoCheque]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FormaPagos_FormaPagoCuentaCorriente'
ALTER TABLE [dbo].[FormaPagos_FormaPagoCuentaCorriente]
ADD CONSTRAINT [PK_FormaPagos_FormaPagoCuentaCorriente]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comprobantes_Compra'
ALTER TABLE [dbo].[Comprobantes_Compra]
ADD CONSTRAINT [PK_Comprobantes_Compra]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comprobantes_Factura'
ALTER TABLE [dbo].[Comprobantes_Factura]
ADD CONSTRAINT [PK_Comprobantes_Factura]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FormaPagos_FormaPagoEfectivo'
ALTER TABLE [dbo].[FormaPagos_FormaPagoEfectivo]
ADD CONSTRAINT [PK_FormaPagos_FormaPagoEfectivo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Empleados_Id], [Empresas_Id] in table 'EmpleadoEmpresa'
ALTER TABLE [dbo].[EmpleadoEmpresa]
ADD CONSTRAINT [PK_EmpleadoEmpresa]
    PRIMARY KEY CLUSTERED ([Empleados_Id], [Empresas_Id] ASC);
GO

-- Creating primary key on [Usuarios_Id], [Perfiles_Id] in table 'UsuarioPerfil'
ALTER TABLE [dbo].[UsuarioPerfil]
ADD CONSTRAINT [PK_UsuarioPerfil]
    PRIMARY KEY CLUSTERED ([Usuarios_Id], [Perfiles_Id] ASC);
GO

-- Creating primary key on [Perfiles_Id], [Formularios_Id] in table 'PerfilFormulario'
ALTER TABLE [dbo].[PerfilFormulario]
ADD CONSTRAINT [PK_PerfilFormulario]
    PRIMARY KEY CLUSTERED ([Perfiles_Id], [Formularios_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmpleadoId] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_EmpleadoUsuario]
    FOREIGN KEY ([EmpleadoId])
    REFERENCES [dbo].[Personas_Empleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadoUsuario'
CREATE INDEX [IX_FK_EmpleadoUsuario]
ON [dbo].[Usuarios]
    ([EmpleadoId]);
GO

-- Creating foreign key on [CondicionIvaId] in table 'Empresas'
ALTER TABLE [dbo].[Empresas]
ADD CONSTRAINT [FK_CondicionIvaEmpresa]
    FOREIGN KEY ([CondicionIvaId])
    REFERENCES [dbo].[CondicionIvas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CondicionIvaEmpresa'
CREATE INDEX [IX_FK_CondicionIvaEmpresa]
ON [dbo].[Empresas]
    ([CondicionIvaId]);
GO

-- Creating foreign key on [Empleados_Id] in table 'EmpleadoEmpresa'
ALTER TABLE [dbo].[EmpleadoEmpresa]
ADD CONSTRAINT [FK_EmpleadoEmpresa_Empleado]
    FOREIGN KEY ([Empleados_Id])
    REFERENCES [dbo].[Personas_Empleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Empresas_Id] in table 'EmpleadoEmpresa'
ALTER TABLE [dbo].[EmpleadoEmpresa]
ADD CONSTRAINT [FK_EmpleadoEmpresa_Empresa]
    FOREIGN KEY ([Empresas_Id])
    REFERENCES [dbo].[Empresas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadoEmpresa_Empresa'
CREATE INDEX [IX_FK_EmpleadoEmpresa_Empresa]
ON [dbo].[EmpleadoEmpresa]
    ([Empresas_Id]);
GO

-- Creating foreign key on [EmpresaId] in table 'Salas'
ALTER TABLE [dbo].[Salas]
ADD CONSTRAINT [FK_EmpresaSala]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaSala'
CREATE INDEX [IX_FK_EmpresaSala]
ON [dbo].[Salas]
    ([EmpresaId]);
GO

-- Creating foreign key on [SalaId] in table 'Mesas'
ALTER TABLE [dbo].[Mesas]
ADD CONSTRAINT [FK_SalaMesa]
    FOREIGN KEY ([SalaId])
    REFERENCES [dbo].[Salas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalaMesa'
CREATE INDEX [IX_FK_SalaMesa]
ON [dbo].[Mesas]
    ([SalaId]);
GO

-- Creating foreign key on [Usuarios_Id] in table 'UsuarioPerfil'
ALTER TABLE [dbo].[UsuarioPerfil]
ADD CONSTRAINT [FK_UsuarioPerfil_Usuario]
    FOREIGN KEY ([Usuarios_Id])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Perfiles_Id] in table 'UsuarioPerfil'
ALTER TABLE [dbo].[UsuarioPerfil]
ADD CONSTRAINT [FK_UsuarioPerfil_Perfil]
    FOREIGN KEY ([Perfiles_Id])
    REFERENCES [dbo].[Perfiles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioPerfil_Perfil'
CREATE INDEX [IX_FK_UsuarioPerfil_Perfil]
ON [dbo].[UsuarioPerfil]
    ([Perfiles_Id]);
GO

-- Creating foreign key on [Perfiles_Id] in table 'PerfilFormulario'
ALTER TABLE [dbo].[PerfilFormulario]
ADD CONSTRAINT [FK_PerfilFormulario_Perfil]
    FOREIGN KEY ([Perfiles_Id])
    REFERENCES [dbo].[Perfiles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Formularios_Id] in table 'PerfilFormulario'
ALTER TABLE [dbo].[PerfilFormulario]
ADD CONSTRAINT [FK_PerfilFormulario_Formulario]
    FOREIGN KEY ([Formularios_Id])
    REFERENCES [dbo].[Formularios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerfilFormulario_Formulario'
CREATE INDEX [IX_FK_PerfilFormulario_Formulario]
ON [dbo].[PerfilFormulario]
    ([Formularios_Id]);
GO

-- Creating foreign key on [EmpresaId] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [FK_EmpresaPerfil]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaPerfil'
CREATE INDEX [IX_FK_EmpresaPerfil]
ON [dbo].[Perfiles]
    ([EmpresaId]);
GO

-- Creating foreign key on [EmpresaId] in table 'Comprobantes'
ALTER TABLE [dbo].[Comprobantes]
ADD CONSTRAINT [FK_EmpresaComprobante]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaComprobante'
CREATE INDEX [IX_FK_EmpresaComprobante]
ON [dbo].[Comprobantes]
    ([EmpresaId]);
GO

-- Creating foreign key on [UsuarioId] in table 'Comprobantes'
ALTER TABLE [dbo].[Comprobantes]
ADD CONSTRAINT [FK_UsuarioComprobante]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioComprobante'
CREATE INDEX [IX_FK_UsuarioComprobante]
ON [dbo].[Comprobantes]
    ([UsuarioId]);
GO

-- Creating foreign key on [ClienteId] in table 'Comprobantes'
ALTER TABLE [dbo].[Comprobantes]
ADD CONSTRAINT [FK_ClienteComprobante]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Personas_Cliente]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteComprobante'
CREATE INDEX [IX_FK_ClienteComprobante]
ON [dbo].[Comprobantes]
    ([ClienteId]);
GO

-- Creating foreign key on [EmpleadoId] in table 'Comprobantes_Salon'
ALTER TABLE [dbo].[Comprobantes_Salon]
ADD CONSTRAINT [FK_EmpleadoComprobante_Salon]
    FOREIGN KEY ([EmpleadoId])
    REFERENCES [dbo].[Personas_Empleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadoComprobante_Salon'
CREATE INDEX [IX_FK_EmpleadoComprobante_Salon]
ON [dbo].[Comprobantes_Salon]
    ([EmpleadoId]);
GO

-- Creating foreign key on [MesaId] in table 'Comprobantes_Salon'
ALTER TABLE [dbo].[Comprobantes_Salon]
ADD CONSTRAINT [FK_MesaComprobante_Salon]
    FOREIGN KEY ([MesaId])
    REFERENCES [dbo].[Mesas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MesaComprobante_Salon'
CREATE INDEX [IX_FK_MesaComprobante_Salon]
ON [dbo].[Comprobantes_Salon]
    ([MesaId]);
GO

-- Creating foreign key on [ComprobanteId] in table 'DetalleComprobantes'
ALTER TABLE [dbo].[DetalleComprobantes]
ADD CONSTRAINT [FK_ComprobanteDetalleComprobante]
    FOREIGN KEY ([ComprobanteId])
    REFERENCES [dbo].[Comprobantes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComprobanteDetalleComprobante'
CREATE INDEX [IX_FK_ComprobanteDetalleComprobante]
ON [dbo].[DetalleComprobantes]
    ([ComprobanteId]);
GO

-- Creating foreign key on [ArticuloId] in table 'DetalleComprobantes'
ALTER TABLE [dbo].[DetalleComprobantes]
ADD CONSTRAINT [FK_ArticuloDetalleComprobante]
    FOREIGN KEY ([ArticuloId])
    REFERENCES [dbo].[Articulos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticuloDetalleComprobante'
CREATE INDEX [IX_FK_ArticuloDetalleComprobante]
ON [dbo].[DetalleComprobantes]
    ([ArticuloId]);
GO

-- Creating foreign key on [EmpleadoId] in table 'Comprobantes_Delivery'
ALTER TABLE [dbo].[Comprobantes_Delivery]
ADD CONSTRAINT [FK_EmpleadoDelivery]
    FOREIGN KEY ([EmpleadoId])
    REFERENCES [dbo].[Personas_Empleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadoDelivery'
CREATE INDEX [IX_FK_EmpleadoDelivery]
ON [dbo].[Comprobantes_Delivery]
    ([EmpleadoId]);
GO

-- Creating foreign key on [UsuarioAperturaId] in table 'Cajas'
ALTER TABLE [dbo].[Cajas]
ADD CONSTRAINT [FK_UsuarioCaja]
    FOREIGN KEY ([UsuarioAperturaId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioCaja'
CREATE INDEX [IX_FK_UsuarioCaja]
ON [dbo].[Cajas]
    ([UsuarioAperturaId]);
GO

-- Creating foreign key on [UsuarioCierreId] in table 'Cajas'
ALTER TABLE [dbo].[Cajas]
ADD CONSTRAINT [FK_UsuarioCajaCierre]
    FOREIGN KEY ([UsuarioCierreId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioCajaCierre'
CREATE INDEX [IX_FK_UsuarioCajaCierre]
ON [dbo].[Cajas]
    ([UsuarioCierreId]);
GO

-- Creating foreign key on [EmpresaId] in table 'Cajas'
ALTER TABLE [dbo].[Cajas]
ADD CONSTRAINT [FK_EmpresaCaja]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaCaja'
CREATE INDEX [IX_FK_EmpresaCaja]
ON [dbo].[Cajas]
    ([EmpresaId]);
GO

-- Creating foreign key on [TipoComprobanteId] in table 'Comprobantes'
ALTER TABLE [dbo].[Comprobantes]
ADD CONSTRAINT [FK_TipoComprobanteComprobante]
    FOREIGN KEY ([TipoComprobanteId])
    REFERENCES [dbo].[TipoComprobantes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoComprobanteComprobante'
CREATE INDEX [IX_FK_TipoComprobanteComprobante]
ON [dbo].[Comprobantes]
    ([TipoComprobanteId]);
GO

-- Creating foreign key on [CajaId] in table 'DetalleCajas'
ALTER TABLE [dbo].[DetalleCajas]
ADD CONSTRAINT [FK_CajaDetalleCaja]
    FOREIGN KEY ([CajaId])
    REFERENCES [dbo].[Cajas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CajaDetalleCaja'
CREATE INDEX [IX_FK_CajaDetalleCaja]
ON [dbo].[DetalleCajas]
    ([CajaId]);
GO

-- Creating foreign key on [ComprobanteId] in table 'Movimientos'
ALTER TABLE [dbo].[Movimientos]
ADD CONSTRAINT [FK_ComprobanteMovimiento]
    FOREIGN KEY ([ComprobanteId])
    REFERENCES [dbo].[Comprobantes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComprobanteMovimiento'
CREATE INDEX [IX_FK_ComprobanteMovimiento]
ON [dbo].[Movimientos]
    ([ComprobanteId]);
GO

-- Creating foreign key on [CajaId] in table 'Movimientos'
ALTER TABLE [dbo].[Movimientos]
ADD CONSTRAINT [FK_CajaMovimiento]
    FOREIGN KEY ([CajaId])
    REFERENCES [dbo].[Cajas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CajaMovimiento'
CREATE INDEX [IX_FK_CajaMovimiento]
ON [dbo].[Movimientos]
    ([CajaId]);
GO

-- Creating foreign key on [UsuarioId] in table 'Movimientos'
ALTER TABLE [dbo].[Movimientos]
ADD CONSTRAINT [FK_UsuarioMovimiento]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioMovimiento'
CREATE INDEX [IX_FK_UsuarioMovimiento]
ON [dbo].[Movimientos]
    ([UsuarioId]);
GO

-- Creating foreign key on [EmpresaId] in table 'Configuraciones'
ALTER TABLE [dbo].[Configuraciones]
ADD CONSTRAINT [FK_EmpresaConfiguracion]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaConfiguracion'
CREATE INDEX [IX_FK_EmpresaConfiguracion]
ON [dbo].[Configuraciones]
    ([EmpresaId]);
GO

-- Creating foreign key on [TipoComprobantePorDefectoId] in table 'Configuraciones'
ALTER TABLE [dbo].[Configuraciones]
ADD CONSTRAINT [FK_TipoComprobanteConfiguracion]
    FOREIGN KEY ([TipoComprobantePorDefectoId])
    REFERENCES [dbo].[TipoComprobantes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoComprobanteConfiguracion'
CREATE INDEX [IX_FK_TipoComprobanteConfiguracion]
ON [dbo].[Configuraciones]
    ([TipoComprobantePorDefectoId]);
GO

-- Creating foreign key on [MarcaId] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [FK_MarcaArticulo]
    FOREIGN KEY ([MarcaId])
    REFERENCES [dbo].[Marcas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MarcaArticulo'
CREATE INDEX [IX_FK_MarcaArticulo]
ON [dbo].[Articulos]
    ([MarcaId]);
GO

-- Creating foreign key on [RubroId] in table 'SubRubros'
ALTER TABLE [dbo].[SubRubros]
ADD CONSTRAINT [FK_RubroSubRubro]
    FOREIGN KEY ([RubroId])
    REFERENCES [dbo].[Rubros]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RubroSubRubro'
CREATE INDEX [IX_FK_RubroSubRubro]
ON [dbo].[SubRubros]
    ([RubroId]);
GO

-- Creating foreign key on [SubRubroId] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [FK_SubRubroArticulo]
    FOREIGN KEY ([SubRubroId])
    REFERENCES [dbo].[SubRubros]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubRubroArticulo'
CREATE INDEX [IX_FK_SubRubroArticulo]
ON [dbo].[Articulos]
    ([SubRubroId]);
GO

-- Creating foreign key on [EmpresaId] in table 'TipoComprobantes'
ALTER TABLE [dbo].[TipoComprobantes]
ADD CONSTRAINT [FK_EmpresaTipoComprobante]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaTipoComprobante'
CREATE INDEX [IX_FK_EmpresaTipoComprobante]
ON [dbo].[TipoComprobantes]
    ([EmpresaId]);
GO

-- Creating foreign key on [EmpresaId] in table 'Rubros'
ALTER TABLE [dbo].[Rubros]
ADD CONSTRAINT [FK_EmpresaRubro]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaRubro'
CREATE INDEX [IX_FK_EmpresaRubro]
ON [dbo].[Rubros]
    ([EmpresaId]);
GO

-- Creating foreign key on [EmpresaId] in table 'Marcas'
ALTER TABLE [dbo].[Marcas]
ADD CONSTRAINT [FK_EmpresaMarca]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaMarca'
CREATE INDEX [IX_FK_EmpresaMarca]
ON [dbo].[Marcas]
    ([EmpresaId]);
GO

-- Creating foreign key on [ArticuloPadreId] in table 'Ingredientes'
ALTER TABLE [dbo].[Ingredientes]
ADD CONSTRAINT [FK_ArticuloIngrediente]
    FOREIGN KEY ([ArticuloPadreId])
    REFERENCES [dbo].[Articulos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticuloIngrediente'
CREATE INDEX [IX_FK_ArticuloIngrediente]
ON [dbo].[Ingredientes]
    ([ArticuloPadreId]);
GO

-- Creating foreign key on [ArticuloHijoId] in table 'Ingredientes'
ALTER TABLE [dbo].[Ingredientes]
ADD CONSTRAINT [FK_ArticuloIngrediente1]
    FOREIGN KEY ([ArticuloHijoId])
    REFERENCES [dbo].[Articulos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticuloIngrediente1'
CREATE INDEX [IX_FK_ArticuloIngrediente1]
ON [dbo].[Ingredientes]
    ([ArticuloHijoId]);
GO

-- Creating foreign key on [TarjetaId] in table 'PlanTarjetas'
ALTER TABLE [dbo].[PlanTarjetas]
ADD CONSTRAINT [FK_TarjetaPlanTarjeta]
    FOREIGN KEY ([TarjetaId])
    REFERENCES [dbo].[Tarjetas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TarjetaPlanTarjeta'
CREATE INDEX [IX_FK_TarjetaPlanTarjeta]
ON [dbo].[PlanTarjetas]
    ([TarjetaId]);
GO

-- Creating foreign key on [PlanTarjetaId] in table 'FormaPagos_FormaPagoTarjeta'
ALTER TABLE [dbo].[FormaPagos_FormaPagoTarjeta]
ADD CONSTRAINT [FK_PlanTarjetaFormaPagoTarjeta]
    FOREIGN KEY ([PlanTarjetaId])
    REFERENCES [dbo].[PlanTarjetas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanTarjetaFormaPagoTarjeta'
CREATE INDEX [IX_FK_PlanTarjetaFormaPagoTarjeta]
ON [dbo].[FormaPagos_FormaPagoTarjeta]
    ([PlanTarjetaId]);
GO

-- Creating foreign key on [BancoId] in table 'FormaPagos_FormaPagoCheque'
ALTER TABLE [dbo].[FormaPagos_FormaPagoCheque]
ADD CONSTRAINT [FK_BancoFormaPagoCheque]
    FOREIGN KEY ([BancoId])
    REFERENCES [dbo].[Bancos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BancoFormaPagoCheque'
CREATE INDEX [IX_FK_BancoFormaPagoCheque]
ON [dbo].[FormaPagos_FormaPagoCheque]
    ([BancoId]);
GO

-- Creating foreign key on [ComprobanteId] in table 'FormaPagos'
ALTER TABLE [dbo].[FormaPagos]
ADD CONSTRAINT [FK_ComprobanteFormaPago]
    FOREIGN KEY ([ComprobanteId])
    REFERENCES [dbo].[Comprobantes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComprobanteFormaPago'
CREATE INDEX [IX_FK_ComprobanteFormaPago]
ON [dbo].[FormaPagos]
    ([ComprobanteId]);
GO

-- Creating foreign key on [ClienteId] in table 'FormaPagos_FormaPagoCuentaCorriente'
ALTER TABLE [dbo].[FormaPagos_FormaPagoCuentaCorriente]
ADD CONSTRAINT [FK_ClienteFormaPagoCuentaCorriente]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Personas_Cliente]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteFormaPagoCuentaCorriente'
CREATE INDEX [IX_FK_ClienteFormaPagoCuentaCorriente]
ON [dbo].[FormaPagos_FormaPagoCuentaCorriente]
    ([ClienteId]);
GO

-- Creating foreign key on [EmpresaId] in table 'Precios'
ALTER TABLE [dbo].[Precios]
ADD CONSTRAINT [FK_EmpresaPrecio]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaPrecio'
CREATE INDEX [IX_FK_EmpresaPrecio]
ON [dbo].[Precios]
    ([EmpresaId]);
GO

-- Creating foreign key on [ArticuloId] in table 'Precios'
ALTER TABLE [dbo].[Precios]
ADD CONSTRAINT [FK_ArticuloPrecio]
    FOREIGN KEY ([ArticuloId])
    REFERENCES [dbo].[Articulos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticuloPrecio'
CREATE INDEX [IX_FK_ArticuloPrecio]
ON [dbo].[Precios]
    ([ArticuloId]);
GO

-- Creating foreign key on [ListaPrecioId] in table 'Precios'
ALTER TABLE [dbo].[Precios]
ADD CONSTRAINT [FK_ListaPrecioPrecio]
    FOREIGN KEY ([ListaPrecioId])
    REFERENCES [dbo].[ListaPrecios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ListaPrecioPrecio'
CREATE INDEX [IX_FK_ListaPrecioPrecio]
ON [dbo].[Precios]
    ([ListaPrecioId]);
GO

-- Creating foreign key on [EmpresaId] in table 'Depositos'
ALTER TABLE [dbo].[Depositos]
ADD CONSTRAINT [FK_EmpresaDeposito]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaDeposito'
CREATE INDEX [IX_FK_EmpresaDeposito]
ON [dbo].[Depositos]
    ([EmpresaId]);
GO

-- Creating foreign key on [ClienteId] in table 'CuentaCorrientes'
ALTER TABLE [dbo].[CuentaCorrientes]
ADD CONSTRAINT [FK_ClienteCuentaCorriente]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Personas_Cliente]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteCuentaCorriente'
CREATE INDEX [IX_FK_ClienteCuentaCorriente]
ON [dbo].[CuentaCorrientes]
    ([ClienteId]);
GO

-- Creating foreign key on [DepositoId] in table 'Stocks'
ALTER TABLE [dbo].[Stocks]
ADD CONSTRAINT [FK_DepositoStock]
    FOREIGN KEY ([DepositoId])
    REFERENCES [dbo].[Depositos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepositoStock'
CREATE INDEX [IX_FK_DepositoStock]
ON [dbo].[Stocks]
    ([DepositoId]);
GO

-- Creating foreign key on [ArticuloId] in table 'Stocks'
ALTER TABLE [dbo].[Stocks]
ADD CONSTRAINT [FK_ArticuloStock]
    FOREIGN KEY ([ArticuloId])
    REFERENCES [dbo].[Articulos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticuloStock'
CREATE INDEX [IX_FK_ArticuloStock]
ON [dbo].[Stocks]
    ([ArticuloId]);
GO

-- Creating foreign key on [StockId] in table 'BajasArticulos'
ALTER TABLE [dbo].[BajasArticulos]
ADD CONSTRAINT [FK_StockBajaArticulo]
    FOREIGN KEY ([StockId])
    REFERENCES [dbo].[Stocks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StockBajaArticulo'
CREATE INDEX [IX_FK_StockBajaArticulo]
ON [dbo].[BajasArticulos]
    ([StockId]);
GO

-- Creating foreign key on [ListaPrecioPorDefectoId] in table 'Configuraciones'
ALTER TABLE [dbo].[Configuraciones]
ADD CONSTRAINT [FK_ListaPrecioConfiguracion]
    FOREIGN KEY ([ListaPrecioPorDefectoId])
    REFERENCES [dbo].[ListaPrecios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ListaPrecioConfiguracion'
CREATE INDEX [IX_FK_ListaPrecioConfiguracion]
ON [dbo].[Configuraciones]
    ([ListaPrecioPorDefectoId]);
GO

-- Creating foreign key on [DepositoPorDefectoId] in table 'Configuraciones'
ALTER TABLE [dbo].[Configuraciones]
ADD CONSTRAINT [FK_DepositoConfiguracion]
    FOREIGN KEY ([DepositoPorDefectoId])
    REFERENCES [dbo].[Depositos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepositoConfiguracion'
CREATE INDEX [IX_FK_DepositoConfiguracion]
ON [dbo].[Configuraciones]
    ([DepositoPorDefectoId]);
GO

-- Creating foreign key on [CondicionIvaId] in table 'Proveedores'
ALTER TABLE [dbo].[Proveedores]
ADD CONSTRAINT [FK_CondicionIvaProveedor]
    FOREIGN KEY ([CondicionIvaId])
    REFERENCES [dbo].[CondicionIvas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CondicionIvaProveedor'
CREATE INDEX [IX_FK_CondicionIvaProveedor]
ON [dbo].[Proveedores]
    ([CondicionIvaId]);
GO

-- Creating foreign key on [ProveedorId] in table 'CuentaCorrienteProveedores'
ALTER TABLE [dbo].[CuentaCorrienteProveedores]
ADD CONSTRAINT [FK_ProveedorCuentaCorrienteProveedor]
    FOREIGN KEY ([ProveedorId])
    REFERENCES [dbo].[Proveedores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProveedorCuentaCorrienteProveedor'
CREATE INDEX [IX_FK_ProveedorCuentaCorrienteProveedor]
ON [dbo].[CuentaCorrienteProveedores]
    ([ProveedorId]);
GO

-- Creating foreign key on [ProveedorId] in table 'Comprobantes_Compra'
ALTER TABLE [dbo].[Comprobantes_Compra]
ADD CONSTRAINT [FK_ProveedorCompra]
    FOREIGN KEY ([ProveedorId])
    REFERENCES [dbo].[Proveedores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProveedorCompra'
CREATE INDEX [IX_FK_ProveedorCompra]
ON [dbo].[Comprobantes_Compra]
    ([ProveedorId]);
GO

-- Creating foreign key on [EmpresaId] in table 'ListaPrecios'
ALTER TABLE [dbo].[ListaPrecios]
ADD CONSTRAINT [FK_EmpresaListaPrecio]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaListaPrecio'
CREATE INDEX [IX_FK_EmpresaListaPrecio]
ON [dbo].[ListaPrecios]
    ([EmpresaId]);
GO

-- Creating foreign key on [EmpresaId] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [FK_EmpresaArticulo]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empresas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaArticulo'
CREATE INDEX [IX_FK_EmpresaArticulo]
ON [dbo].[Articulos]
    ([EmpresaId]);
GO

-- Creating foreign key on [Id] in table 'Personas_Empleado'
ALTER TABLE [dbo].[Personas_Empleado]
ADD CONSTRAINT [FK_Empleado_inherits_Persona]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Personas]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Personas_Cliente'
ALTER TABLE [dbo].[Personas_Cliente]
ADD CONSTRAINT [FK_Cliente_inherits_Persona]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Personas]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Comprobantes_Salon'
ALTER TABLE [dbo].[Comprobantes_Salon]
ADD CONSTRAINT [FK_Salon_inherits_Comprobante]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Comprobantes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Comprobantes_Delivery'
ALTER TABLE [dbo].[Comprobantes_Delivery]
ADD CONSTRAINT [FK_Delivery_inherits_Comprobante]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Comprobantes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'FormaPagos_FormaPagoTarjeta'
ALTER TABLE [dbo].[FormaPagos_FormaPagoTarjeta]
ADD CONSTRAINT [FK_FormaPagoTarjeta_inherits_FormaPago]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[FormaPagos]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'FormaPagos_FormaPagoCheque'
ALTER TABLE [dbo].[FormaPagos_FormaPagoCheque]
ADD CONSTRAINT [FK_FormaPagoCheque_inherits_FormaPago]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[FormaPagos]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'FormaPagos_FormaPagoCuentaCorriente'
ALTER TABLE [dbo].[FormaPagos_FormaPagoCuentaCorriente]
ADD CONSTRAINT [FK_FormaPagoCuentaCorriente_inherits_FormaPago]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[FormaPagos]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Comprobantes_Compra'
ALTER TABLE [dbo].[Comprobantes_Compra]
ADD CONSTRAINT [FK_Compra_inherits_Comprobante]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Comprobantes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Comprobantes_Factura'
ALTER TABLE [dbo].[Comprobantes_Factura]
ADD CONSTRAINT [FK_Factura_inherits_Comprobante]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Comprobantes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'FormaPagos_FormaPagoEfectivo'
ALTER TABLE [dbo].[FormaPagos_FormaPagoEfectivo]
ADD CONSTRAINT [FK_FormaPagoEfectivo_inherits_FormaPago]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[FormaPagos]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------