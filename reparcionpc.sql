-- creacion de la base de datos 
CREATE DATABASE reparacionPc
GO

USE reparacionPc
GO

--creacion de tablas
--tabla usuarios 
CREATE TABLE usuarios
(
	id INT IDENTITY(1,1),
	nombre VARCHAR(50) NOT NULL,
	correo VARCHAR(50) NOT NULL,
	clave VARCHAR(50) NOT NULL,
	telefono INT DEFAULT 0

	CONSTRAINT pk_idUsuarios PRIMARY KEY (id)
)
GO

--tabla tecnicos 
CREATE TABLE tecnicos
(
	id INT IDENTITY(1,1),
	nombre VARCHAR(50) NOT NULL,
	especialidad VARCHAR(50) NOT NULL

	CONSTRAINT pk_idTecnicos PRIMARY KEY (id)
)
GO

--tabla equipos 
CREATE TABLE equipos
(
	id INT IDENTITY(1,1),
	idUsuarios INT,
	tipoEquipo VARCHAR(100) NOT NULL,
	modelo VARCHAR(50) NOT NULL

	CONSTRAINT pk_idEquipos PRIMARY KEY (id),
	CONSTRAINT FK_idUsuarios FOREIGN KEY (idUsuarios) REFERENCES usuarios(id)
)
GO

--tabla reparaciones 
CREATE TABLE reparaciones
(
	id INT IDENTITY(1,1),
	idEquipo INT,
	fechaSolicitud DATETIME CONSTRAINT fs_fechaSolicitud DEFAULT GETDATE(),
	estado VARCHAR(50) NOT NULL

	CONSTRAINT pk_reparaciones PRIMARY KEY (id),
	CONSTRAINT fk_idEquipo FOREIGN KEY (idEquipo) REFERENCES equipos(id)
)
GO

--tabla asignaciones 
CREATE TABLE asignaciones 
(
	id INT IDENTITY(1,1),
	idReparacionesAsignaciones INT,
	idTecnicos INT,
	fechaAsignacion DATETIME CONSTRAINT fa_fechaAsignacion DEFAULT GETDATE()

	CONSTRAINT pk_asignaciones PRIMARY KEY (id),
	CONSTRAINT fk_idReparacionesAsignaciones FOREIGN KEY(idReparacionesAsignaciones) REFERENCES reparaciones(id),
	CONSTRAINT fk_idTecnicos FOREIGN KEY(idTecnicos) REFERENCES tecnicos(id)
)
GO

--tabla detalles de reparacion 
CREATE TABLE detallesReparacion
(
	id INT IDENTITY(1,1),
	idReparaciones INT,
	descripcion VARCHAR(100) NOT NULL,
	fechaInicio DATETIME CONSTRAINT fi_fechaInicio DEFAULT GETDATE(),
	fechaFin DATETIME CONSTRAINT ff_fechaFinal DEFAULT GETDATE()

	CONSTRAINT pk_idDetallesReparaciones PRIMARY KEY (id),
	CONSTRAINT fk_idReparaciones FOREIGN KEY(idReparaciones) REFERENCES reparaciones(id)
)
GO

----------mantenimiento de tablas----------

--agregar usuarios 
CREATE PROCEDURE agregarUsuario
	@nombre VARCHAR(50),
	@correo VARCHAR(50),
	@clave VARCHAR(50),
	@telefono INT = 0
AS 
BEGIN
	INSERT INTO usuarios (nombre, correo, clave, telefono) VALUES (@nombre, @correo, @clave, @telefono)
END;
GO

--consultar usuarios 
CREATE PROCEDURE consultarUsuario
	@id INT
AS
BEGIN
	SELECT*FROM usuarios WHERE id = @id
END
GO

--modificar usuarios
CREATE PROCEDURE modificarUsuarios
	@id INT,
	@nombre VARCHAR(50),
	@correo VARCHAR(50),
	@telefono INT = 0
AS
BEGIN
	UPDATE usuarios 
	SET nombre = @nombre,
		correo = @correo, 
		telefono = @telefono 
		WHERE id = @id
END
GO

--borrar usuarios 
CREATE PROCEDURE borrarUsuario
	@id INT
AS
BEGIN
	DELETE usuarios WHERE id = @id
END
GO

-------------------

--agregar tecnico
CREATE PROCEDURE agregarTecnico
	@nombre VARCHAR(50),
	@especialidad Varchar(50)
AS
BEGIN
	INSERT INTO tecnicos(nombre, especialidad) VALUES (@nombre, @especialidad)
END
GO

--consultar tecnico
CREATE PROCEDURE consultarTecnico
	@id INT
AS
BEGIN
	SELECT*FROM tecnicos WHERE id = @id
END
GO

--modificar tecnico
CREATE PROCEDURE modificarTecnico
	@id INT,
	@nombre VARCHAR(50),
	@especialidad VARCHAR(50)
AS
BEGIN
	UPDATE tecnicos
	SET nombre = @nombre,
		especialidad = @especialidad
		WHERE id = @id
END
GO

--borrar tecnico
CREATE PROCEDURE borrarTecnico
	@id INT
AS 
BEGIN
	DELETE tecnicos WHERE id = @id
END
GO


-------------------

--agregar equipo 
CREATE PROCEDURE agregarEquipo
	@idUsuario INT,
	@tipoEquipo VARCHAR(50),
	@modelo Varchar(50)
AS
BEGIN
	INSERT INTO equipos (idUsuarios,tipoEquipo, modelo) VALUES (@idUsuario, @tipoEquipo, @modelo)
END
GO

--consultar equipo
CREATE PROCEDURE consultarEquipo
	@id INT
AS
BEGIN
	SELECT*FROM equipos WHERE id = @id
END
GO

--modificar equipo
CREATE PROCEDURE modificarEquipo
	@id INT,
	@idUsuario INT,
	@tipoEquipo VARCHAR(50),
	@modelo VARCHAR(50)
AS
BEGIN
	UPDATE equipos 
	SET tipoEquipo = @tipoEquipo,
		idUsuarios = @idUsuario,
		modelo = @modelo
		WHERE id = @id
END
GO

--borrar equipo
CREATE PROCEDURE borrarEquipo
	@id INT
AS 
BEGIN
	DELETE equipos WHERE id = @id
END
GO

----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------

--procesos almacenados de las ultimas 3 tablas

--APREGAR REPARACION
CREATE PROCEDURE agregarReparacion
	@idEquipo INT,
	@fechaSolicitud DATETIME,
	@estado VARCHAR(50)

AS
BEGIN
	INSERT INTO reparaciones(idEquipo,fechaSolicitud, estado) VALUES (@idEquipo, @fechaSolicitud, @estado)
END
GO

--MODIFICAR REPARACION
CREATE PROCEDURE modificarReparacion
	@id INT,
	@idEquipo INT,
	@fechaSolicitud DATETIME,
	@estado VARCHAR(50)
AS
BEGIN
	UPDATE reparaciones
	SET idEquipo = @idEquipo,
		fechaSolicitud = @fechaSolicitud,
		estado = @estado
		WHERE id = @id
END
GO
----------------------------------------------------------------------------------------

--AGREGAR ASIGNACIONES
CREATE PROCEDURE agregarAsignaciones
	@idReparacion INT,
	@fechaAsignacion DATETIME,
	@idTecnico INT

AS
BEGIN
	INSERT INTO asignaciones(idReparacionesAsignaciones,fechaAsignacion, idTecnicos) VALUES (@idReparacion, @fechaAsignacion, @idTecnico);
END
GO

--MODIFICAR ASIGNACIONES
CREATE PROCEDURE modificarAsignaciones
	@id INT,
	@idReparacion INT,
	@fechaAsignacion DATETIME,
	@idTecnico INT

AS
BEGIN
	UPDATE asignaciones
	SET idReparacionesAsignaciones = @idReparacion,
		fechaAsignacion = @fechaAsignacion,
		idTecnicos = @idTecnico
		WHERE id = @id
END
GO
----------------------------------------------------------------------------------------

--AGREGAR DETALLES REPARACION
CREATE PROCEDURE agregarDetallesReparacion
	@idReparacion INT,
	@fechaInicio DATETIME,
	@fechaFin DATETIME,
	@descripcion VARCHAR(50)

AS
BEGIN
	INSERT INTO detallesReparacion (idReparaciones,fechaInicio, fechaFin, descripcion) VALUES (@idReparacion, @fechaInicio, @fechaFin, @descripcion);
END
GO

--MODIFICAR DETALLES REPARACION
CREATE PROCEDURE modificarDetallesReparacion
	@id INT,
	@idReparacion INT,
	@fechaInicio DATETIME,
	@fechaFin DATETIME,
	@descripcion VARCHAR(50)
AS
BEGIN
	UPDATE detallesReparacion
	SET idReparaciones = @idReparacion,
		fechaInicio = @fechaInicio,
		fechaFin = @fechaFin,
		descripcion = @descripcion
		WHERE id = @id
END
GO

----------------------------------------------------------------------------------------

--LOGIN--
CREATE PROCEDURE validar
	@correo VARCHAR(50),
	@clave VARCHAR(50)
AS
BEGIN
	SELECT nombre, correo FROM usuarios WHERE clave = @clave AND correo = @correo
END
GO
----------------------------------------------------------------------------------------
--Nombre Usuario. Estado de Reparacion, Tecnico, Detalle
Select U.nombre, R.estado, T.nombre, D.descripcion
FROM usuarios U
Inner Join equipos E ON U.id = E.id
Inner Join reparaciones R ON R.id = E.id
inner Join asignaciones A ON R.id = A.id
inner Join tecnicos T ON T.id = A.id
inner Join detallesReparacion D ON D.id= R.id
GO

CREATE PROCEDURE ConsultarUsuariosConDetallesReparacion
AS
BEGIN
    SELECT U.nombre AS 'Nombre Usuario', R.estado AS 'Estado de Reparacion', T.nombre AS 'Tecnico', D.descripcion AS 'Detalle'
    FROM usuarios U
    INNER JOIN equipos E ON U.id = E.idUsuarios
    INNER JOIN reparaciones R ON R.idEquipo = E.id
    INNER JOIN asignaciones A ON R.id = A.idReparacionesAsignaciones
    INNER JOIN tecnicos T ON T.id = A.idTecnicos
    INNER JOIN detallesReparacion D ON D.idReparaciones = R.id;
END
GO
----------------------------------------------------------------------------------------

exec agregarUsuario 'Sebatian','sebas@gmail.com','sebas','123'
exec agregarUsuario 'Karla','karla@gmail.com','karla','321'