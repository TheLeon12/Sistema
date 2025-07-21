Create database DB_SISTEMA_VENTAS
GO

USE DB_SISTEMA_VENTAS
go

create table ROL(
IdRol int primary key identity,
Descripcion varchar(50),
FechaRegistro datetime default getdate()
)
go

create table PERMISO(
IdPermiso int primary key identity,
IdRol int References ROL(IdRol),
NombreMenu varchar(100),
FechaRegistro datetime default getdate()
)
go

create table PROVEEDOR(
IdProveedor int primary key identity,
Documento varchar(50),
RazonSocial varchar(50),
Correo varchar(50),
Telefono varchar(50),
Estado bit,
FechaRegistro datetime default getdate()
)
GO

create table CLIENTE(
IdCliente int primary key identity,
Documento varchar(50),
NombreCompleto varchar(50),
Correo varchar(50),
Telefono varchar(50),
Estado bit,
FechaRegistro datetime default getdate()
)
GO

create table USUARIO(
IdUsuario int primary key identity,
Documento varchar(50),
NombreCompleto varchar(50),
Correo varchar(50),
Clave varchar(50),
IdRol int References ROL(IdRol),
Estado bit,
FechaRegistro datetime default getdate()
)
GO

create table CATEGORIA(
IdCategoria int primary key identity,
Descripcion varchar(100),
Estado bit,
FechaRegistro datetime default getdate()
)
GO

create table PRODUCTO(
IdProducto int primary key identity,
Codigo varchar(50),
Nombre varchar(50),
Descripcion varchar(50),
IdCategoria int references CATEGORIA(IdCategoria),
Stock int not null default 0,
PrecioCompra decimal(10,2) default 0,
PrecioVenta decimal(10,2) default 0,
Estado bit,
FechaRegistro datetime default getdate()
)
GO

create table COMPRA(
IdCompra int primary key identity,
IdUsuario int references USUARIO(IdUsuario),
IdProveedor int references PROVEEDOR(IdProveedor),
TipoDocumento varchar(50),
NumeroDocumento varchar(50),
MontoTotal decimal(10,2),
FechaRegistro datetime default getdate()
)
GO


create table DETALLE_COMPRA(
IdDetalleCompra int primary key identity,
IdCompra int references COMPRA(IdCompra),
IdProducto int references PRODUCTO(IdProducto),
PrecioCompra decimal(10,2) default 0,
PrecioVenta decimal(10,2) default 0,
Cantidad int,
MontoTotal decimal(10,2),
FechaRegistro datetime default getdate()
)
GO

create table VENTA(
IdVenta int primary key identity,
IdUsuario int references USUARIO(IdUsuario),
TipoDocumento varchar(50),
NumeroDocumento varchar(50),
DocumentoCliente varchar(50),
NombreCliente varchar(100),
MontoPago decimal(10,2),
MontoCambio decimal(10,2),
MontoTotal decimal(10,2),
FechaRegistro datetime default getdate()
)
GO

create table DETALLE_VENTA(
IdDetalleVenta int primary key identity,
IdVenta int references VENTA(IdVenta),
IdProducto int references PRODUCTO(IdProducto),
PrecioVenta decimal(10,2),
Cantidad int,
Subtotal decimal(10,2),
FechaRegistro datetime default getdate()
)
GO

create table NEGOCIO(
IdNegocio int primary key,
Nombre varchar(60),
RUC varchar(60),
Direccion varchar(60),
Logo varbinary(max) null
)
go

 
 /*-------PROCEDIMIENTO PARA USUARIOS-------*/
--Registrar un usuario
create PROC SP_REGISTRAUSUARIO(
@Documento varchar(50),
@NombreCompleto varchar(100),
@Correo varchar(100),
@Clave varchar(100),
@IdRol int,
@Estado bit,
@IdUsuarioResultado int output,
@Mensaje varchar(500) output
)
as 
begin 
	set @IdUsuarioResultado = 0
	set @Mensaje = ''

	if not exists (select * from USUARIO WHERE Documento = @Documento)
	begin
	insert into USUARIO(Documento,NombreCompleto,Correo,Clave,IdRol,Estado) values 
	(@Documento,@NombreCompleto,@Correo,@Clave,@IdRol,@Estado)

	set @IdUsuarioResultado = SCOPE_IDENTITY()
	end 
	else 
		set @Mensaje = 'No se puede repetir el documento para más de un usuario'
end
go

-- Editar un usuario
create PROC SP_EDITARUSUARIO(
@IdUsuario int,
@Documento varchar(50),
@NombreCompleto varchar(100),
@Correo varchar(100),
@Clave varchar(100),
@IdRol int,
@Estado bit,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as 
begin 
	set @Respuesta = 0
	set @Mensaje = ''

	if not exists (select * from USUARIO WHERE Documento = @Documento and IdUsuario != @IdUsuario)
	begin
	update USUARIO set 
	Documento = @Documento,
	NombreCompleto = @NombreCompleto,
	Correo = @Correo,
	Clave = @Clave,
	IdRol = @IdRol,
	Estado = @Estado
	where IdUsuario = @IdUsuario
	
	set @Respuesta = 1
	end 
	else 
		set @Mensaje = 'No se puede repetir el documento para más de un usuario'
end
go

--Eliminar el usuario
create PROC SP_ELIMINARUSUARIO(
@IdUsuario int,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as 
begin 
	set @Respuesta = 0
	set @Mensaje = ''
	declare @pasoreglas bit = 1

	IF EXISTS (select * from COMPRA c
	inner join USUARIO u on u.IdUsuario = c.IdUsuario
	where u.IdUsuario = @IdUsuario
	)
	begin 
		set @pasoreglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar porque el usuario esta relacionado a una compra\n'
	end 

	
	IF EXISTS (select * from VENTA v
	inner join USUARIO u on u.IdUsuario = v.IdUsuario
	where u.IdUsuario = @IdUsuario
	)
	begin 
		set @pasoreglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar porque el usuario esta relacionado a una Venta\n'
	end 

	if (@pasoreglas = 1)
	begin 
		delete from USUARIO where IdUsuario = @IdUsuario
		set @Respuesta = 1 
	end 
end

--Pruebas realizadas
declare @Respuesta int 
declare @Mensaje varchar(500)

exec SP_ELIMINARUSUARIO 4, @Respuesta output, @Mensaje output

select @Respuesta
select @Mensaje

select * from USUARIO

declare @Respuesta int 
declare @Mensaje varchar(500)

exec SP_REGISTRAUSUARIO '1234', 'Pruebas3', 'teste@gmail.com', '456',2,1, @Respuesta output, @Mensaje output

select @Respuesta
select @Mensaje

 /*-------PROCEDIMIENTO PARA CATEGORIA-------*/

 --Procedimiento para guardar categoria
 create proc SP_RegistrarCategoria(
 @Descripcion varchar(50),
 @Estado bit,
 @Resultado int output,
 @Mensaje varchar(500) output
 )as 
 begin 
	set @Resultado = 0
		if not exists (select * from CATEGORIA WHERE Descripcion = @Descripcion)
		begin
			insert into CATEGORIA(Descripcion, Estado) values (@Descripcion, @Estado)
			set @Resultado = SCOPE_IDENTITY()
		end 
		else 
			set @Mensaje = 'No se puede repetir la Descripcion de una categoria'
 end 
 go

 --Proceso para modificar una categoria 
 create procedure SP_EditarCategoria(
 @IdCategoria int, 
 @Descripcion varchar(50),
 @Estado bit,
 @Resultado bit output,
  @Mensaje varchar(500) output
 ) as
 begin
	set @Resultado = 1
		if not exists (select * from CATEGORIA where Descripcion = @Descripcion and IdCategoria != @IdCategoria)
			update CATEGORIA set 
			Descripcion = @Descripcion,
			Estado = @Estado
			where IdCategoria = @IdCategoria
			else 
			begin
				set @Resultado = 0
				set @Mensaje = 'No se puede repetir la Descripcion de una categoria'
			end
 end
 go

 --Procedimiento para eliminar una categoria
  create procedure SP_EliminarCategoria(
 @IdCategoria int, 
 @Resultado bit output,
  @Mensaje varchar(500) output
 ) as
 begin
	set @Resultado = 1
		if not exists (
		select * from CATEGORIA c
		inner join PRODUCTO p on p.IdCategoria = c.IdCategoria
		where c.IdCategoria = @IdCategoria
		) begin
			delete top(1) from CATEGORIA where IdCategoria = @IdCategoria
			end 
			else 
			begin
				set @Resultado = 0
				set @Mensaje = 'La cateoria se encuentra relacionada a un producto'
			end
 end


 /*-------PROCEDIMIENTO PARA CLIENTES-------*/
 
 --Registrar un cliente
 create proc SP_RegistrarCliente(
 @Documento varchar(50),
 @NombreCompleto varchar(50),
 @Correo varchar(50),
 @Telefono varchar(50),
 @Estado bit, 
 @Resultado int output,
 @Mensaje varchar(500) output
 )as 
 begin
	set @Resultado = 0
	Declare @IDPERSONA INT 
	IF NOT EXISTS (Select * from CLIENTE WHERE Documento = @Documento)
	begin 
		insert into CLIENTE (Documento,NombreCompleto,Correo,Telefono,Estado) values
		(@Documento,@NombreCompleto,@Correo,@Telefono,@Estado)

		set @Resultado = SCOPE_IDENTITY()
	end
	ELSE 
		set @Mensaje = 'El Numero de Documento ya existe'
 end 
 go

 /* ---------- PROCEDIMIENTOS PARA PRODUCTO -----------------*/

create PROC sp_RegistrarProducto(
@Codigo varchar(20),
@Nombre varchar(30),
@Descripcion varchar(30),
@IdCategoria int,
@Estado bit,
@Resultado int output,
@Mensaje varchar(500) output
)as
begin
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM producto WHERE Codigo = @Codigo)
	begin
		insert into producto(Codigo,Nombre,Descripcion,IdCategoria,Estado) values (@Codigo,@Nombre,@Descripcion,@IdCategoria,@Estado)
		set @Resultado = SCOPE_IDENTITY()
	end
	ELSE
	 SET @Mensaje = 'Ya existe un producto con el mismo codigo' 
	
end

GO

create procedure sp_ModificarProducto(
@IdProducto int,
@Codigo varchar(20),
@Nombre varchar(30),
@Descripcion varchar(30),
@IdCategoria int,
@Estado bit,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE codigo = @Codigo and IdProducto != @IdProducto)
		
		update PRODUCTO set
		codigo = @Codigo,
		Nombre = @Nombre,
		Descripcion = @Descripcion,
		IdCategoria = @IdCategoria,
		Estado = @Estado
		where IdProducto = @IdProducto
	ELSE
	begin
		SET @Resultado = 0
		SET @Mensaje = 'Ya existe un producto con el mismo codigo' 
	end
end

go


create PROC SP_EliminarProducto(
@IdProducto int,
@Respuesta bit output,
@Mensaje varchar(500) output
)
as
begin
	set @Respuesta = 0
	set @Mensaje = ''
	declare @pasoreglas bit = 1

	IF EXISTS (SELECT * FROM DETALLE_COMPRA dc 
	INNER JOIN PRODUCTO p ON p.IdProducto = dc.IdProducto
	WHERE p.IdProducto = @IdProducto
	)
	BEGIN
		set @pasoreglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar porque se encuentra relacionado a una COMPRA\n' 
	END

	IF EXISTS (SELECT * FROM DETALLE_VENTA dv
	INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto
	WHERE p.IdProducto = @IdProducto
	)
	BEGIN
		set @pasoreglas = 0
		set @Respuesta = 0
		set @Mensaje = @Mensaje + 'No se puede eliminar porque se encuentra relacionado a una VENTA\n' 
	END

	if(@pasoreglas = 1)
	begin
		delete from PRODUCTO where IdProducto = @IdProducto
		set @Respuesta = 1 
	end

end
go



 --Editar un cliente 
 create proc SP_ModificarCliente(
 @IdCliente int,
 @Documento varchar(50),
 @NombreCompleto varchar(50),
 @Correo varchar(50),
 @Telefono varchar(50),
 @Estado bit,
 @Resultado int output,
 @Mensaje varchar(500) output
 )as
 begin
	set @Resultado = 1 
	declare @IDPERSONA INT 
	IF NOT EXISTS (select * from CLIENTE where Documento = @Documento and IdCliente != @IdCliente)
	begin
		update CLIENTE set 
		Documento = @Documento,
		NombreCompleto = @NombreCompleto,
		Correo = @Correo,
		Telefono = @Telefono,
		Estado = @Estado
		where IdCliente = @IdCliente
	end 
	else 
	begin
		set @Resultado = 0
		set @Mensaje = 'El numero de documento ya existe'
	end 
 end 

 select * from cliente

  /*-------PROCEDIMIENTO PARA CLIENTES-------*/
  -- Registrar un Proveedor
GO
CREATE PROCEDURE SP_RegistrarProveedor(
  @Documento VARCHAR(50),
  @RazonSocial VARCHAR(50),
  @Correo VARCHAR(50),
  @Telefono VARCHAR(50),
  @Estado BIT,
  @Resultado INT OUTPUT,
  @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
  SET @Resultado = 0
  IF NOT EXISTS (SELECT * FROM PROVEEDOR WHERE Documento = @Documento)
  BEGIN
    INSERT INTO PROVEEDOR (Documento, RazonSocial, Correo, Telefono, Estado)
    VALUES (@Documento, @RazonSocial, @Correo, @Telefono, @Estado)

    SET @Resultado = SCOPE_IDENTITY()
  END
  ELSE
  BEGIN
    SET @Mensaje = 'El número de documento ya existe'
  END
END
GO

-- Modificar un Proveedor
GO
CREATE PROCEDURE SP_ModificarProveedor(
  @IdProveedor INT,
  @Documento VARCHAR(50),
  @RazonSocial VARCHAR(50),
  @Correo VARCHAR(50),
  @Telefono VARCHAR(50),
  @Estado BIT,
  @Resultado BIT OUTPUT,
  @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
  SET @Resultado = 1
  IF NOT EXISTS (SELECT * FROM PROVEEDOR WHERE Documento = @Documento AND IdProveedor != @IdProveedor)
  BEGIN
    UPDATE PROVEEDOR
    SET Documento = @Documento,
        RazonSocial = @RazonSocial,
        Correo = @Correo,
        Telefono = @Telefono,
        Estado = @Estado
    WHERE IdProveedor = @IdProveedor
  END
  ELSE
  BEGIN
    SET @Resultado = 0
    SET @Mensaje = 'El número de documento ya existe'
  END
END
GO

-- Eliminar un Proveedor
GO
CREATE PROCEDURE SP_EliminarProveedor(
  @IdProveedor INT,
  @Resultado BIT OUTPUT,
  @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
  SET @Resultado = 1
  IF NOT EXISTS (
    SELECT * FROM PROVEEDOR p
    INNER JOIN COMPRA c ON p.IdProveedor = c.IdProveedor
    WHERE p.IdProveedor = @IdProveedor
  )
  BEGIN
    DELETE FROM PROVEEDOR WHERE IdProveedor = @IdProveedor
  END
  ELSE
  BEGIN
    SET @Resultado = 0
    SET @Mensaje = 'El proveedor se encuentra relacionado a una compra'
  END
END
GO


/* Proceso para registrar una compra */
CREATE TYPE [dbo].[EDetalle_Compra] as table(
[IdProducto] int null,
[PrecioCompra] decimal(18,2)null,
[PrecioVenta] decimal(18,2)null,
[Cantidad] int null,
[MontoTotal] decimal(18,2)null
)
go

CREATE PROCEDURE SP_RegistrarCompra	(
@IdUsuario int,
@IdProveedor int,
@TipoDocumento varchar(500),
@NumeroDocumento varchar(500),
@MontoTotal decimal(18,2),
@DetalleCompra [EDetalle_Compra] READONLY,
@Resultado bit output,
@Mensaje varchar(500) output
)as 
begin
	begin try
		declare @idcompra int = 0 
		set @Resultado = 1
		set @Mensaje = ''

		begin transaction registro
		insert into COMPRA(IdUsuario, IdProveedor, TipoDocumento, NumeroDocumento, MontoTotal)
		values(@IdUsuario, @IdProveedor, @TipoDocumento, @NumeroDocumento, @MontoTotal)


			set @idcompra = SCOPE_IDENTITY()

			insert into DETALLE_COMPRA(IdCompra,IdProducto,PrecioCompra,PrecioVenta,Cantidad,MontoTotal)
			Select @idcompra,IdProducto,PrecioCompra,PrecioVenta,Cantidad,MontoTotal from @DetalleCompra

			update p set p.Stock = p.Stock + dc.Cantidad,
			p.PrecioCompra = dc.PrecioCompra,
			p.PrecioVenta = dc.PrecioVenta
			from PRODUCTO p
			inner join @DetalleCompra dc on dc.IdProducto = p.IdProducto

		COMMIT transaction registro
	end try
	begin catch
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()
		rollback transaction registro
	end catch
end 


/* Crear tipo de tabla solo si no existe */
IF TYPE_ID(N'dbo.EDetalle_Venta') IS NULL
BEGIN
    CREATE TYPE [dbo].[EDetalle_Venta] AS TABLE (
        [IdProducto] INT NULL,
        [PrecioVenta] DECIMAL(18,2) NULL,
        [Cantidad] INT NULL,
        [SubTotal] DECIMAL(18,2) NULL
    );
END
GO

/* Crear procedimiento */
CREATE PROCEDURE dbo.SP_RegistrarVenta(
    @IdUsuario INT,
    @TipoDocumento VARCHAR(500),
    @numeroDocumento VARCHAR(500),
    @DocumentoCliente VARCHAR(500),
    @NombreCliente VARCHAR(500),
    @MontoPago DECIMAL(18,2),
    @MontoCambio DECIMAL(18,2),
    @MontoTotal DECIMAL(18,2),
    @DetalleVenta [dbo].[EDetalle_Venta] READONLY,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    BEGIN TRY
        SET XACT_ABORT ON; -- Opcional pero recomendable

        DECLARE @idventa INT = 0;
        SET @Resultado = 1;
        SET @Mensaje = '';

        BEGIN TRANSACTION registro;

        INSERT INTO VENTA (IdUsuario, TipoDocumento, NumeroDocumento, DocumentoCliente, NombreCliente, MontoPago, MontoCambio, MontoTotal)
        VALUES (@IdUsuario, @TipoDocumento, @numeroDocumento, @DocumentoCliente, @NombreCliente, @MontoPago, @MontoCambio, @MontoTotal);

        SET @idventa = SCOPE_IDENTITY();

        INSERT INTO DETALLE_VENTA (IdVenta, IdProducto, PrecioVenta, Cantidad, Subtotal)
        SELECT @idventa, IdProducto, PrecioVenta, Cantidad, SubTotal
        FROM @DetalleVenta;

        COMMIT TRANSACTION registro;
    END TRY
    BEGIN CATCH
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
        ROLLBACK TRANSACTION registro;
    END CATCH
END;
GO


-- Recréalo correctamente
CREATE PROC SP_ReporteCompras(
    @fechainicio DATE,
    @fechafin DATE,
    @idproveedor INT
)
AS
BEGIN
    SELECT 
        CONVERT(CHAR(10), c.FechaRegistro, 103) AS [FechaRegistro],
        c.TipoDocumento,
        c.NumeroDocumento,
        c.MontoTotal,
        u.NombreCompleto AS [UsuarioRegistro],
        pr.Documento AS [DocumentoProveedor],
        pr.RazonSocial,
        p.Codigo AS [CodigoProducto],
        p.Nombre AS [NombreProducto],
        ca.Descripcion AS [Categoria],
        dc.PrecioCompra,
        dc.PrecioVenta,
        dc.Cantidad,
        dc.MontoTotal AS [Subtotal]
    FROM COMPRA c
    INNER JOIN USUARIO u ON u.IdUsuario = c.IdUsuario
    INNER JOIN PROVEEDOR pr ON pr.IdProveedor = c.IdProveedor
    INNER JOIN DETALLE_COMPRA dc ON dc.IdCompra = c.IdCompra
    INNER JOIN PRODUCTO p ON p.IdProducto = dc.IdProducto
    INNER JOIN CATEGORIA ca ON ca.IdCategoria = p.IdCategoria
    WHERE 
        CAST(c.FechaRegistro AS DATE) BETWEEN @fechainicio AND @fechafin
        AND (@idproveedor = 0 OR pr.IdProveedor = @idproveedor)
END
GO



CREATE OR ALTER PROC SP_ReporteVenta (
    @fechaainicio DATE,
    @fechafin DATE
)
AS
BEGIN
    SELECT 
        CONVERT(char(10), v.FechaRegistro, 103) AS FechaRegistro,
        v.TipoDocumento,
        v.NumeroDocumento,
        v.MontoTotal,
        u.NombreCompleto AS UsuarioRegistrado,
        v.DocumentoCliente,
        v.NombreCliente AS NombreClientes,
        p.Codigo AS CodigoProducto,
        p.Nombre AS NombreProducto,
        ca.Descripcion AS Categoria,
        dv.PrecioVenta,
        dv.Cantidad,
        dv.SubTotal
    FROM VENTA v
    INNER JOIN USUARIO u ON u.IdUsuario = v.IdUsuario
    INNER JOIN DETALLE_VENTA dv ON dv.IdVenta = v.IdVenta
    INNER JOIN PRODUCTO p ON p.IdProducto = dv.IdProducto
    INNER JOIN CATEGORIA ca ON ca.IdCategoria = p.IdCategoria
    WHERE v.FechaRegistro BETWEEN @fechaainicio AND @fechafin
END
GO
--Definiendo los roles 
insert into ROL (Descripcion)
values ('ADMINISTRADOR')
go
insert into ROL (Descripcion)
values ('EMPLEADO')
go

--creando usuarios 
insert into USUARIO(Documento, NombreCompleto, Correo, Clave, IdRol, Estado)
values ('101010', 'ADMIN', 'HOLA@gmail.com', '123', 1, 1)
select * from USUARIO;
go
insert into USUARIO(Documento, NombreCompleto, Correo, Clave, IdRol, Estado)
values ('202020', 'EMPLEADO', 'HOLA@gmail.com', '456', 2, 1)
go

--otorgandole permisos
insert into PERMISO (IdRol, NombreMenu) values 
(1,'Menuusuario'),
(1,'Menumantenedor'),
(1,'Menuventas'),
(1, 'Menuclientes'),
(1,'Menucompras'),
(1,'Menucompras'),
(1,'Menuproveedor'),
(1,'Menureporte'),
(1,'Menuacercade')
go

insert into PERMISO (IdRol, NombreMenu) values 
(2,'Menuventas'),
(2,'Menucompras'),
(2,'Menucompras'),
(2,'Menuproveedor'),
(2,'Menuacercade')
go

-- Insertar negocio
insert into NEGOCIO (IdNegocio,Nombre,RUC,Direccion) values (1,'Industrias MS', '102030','av. codigo 456')
go

