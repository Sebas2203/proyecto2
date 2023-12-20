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
	@telefono INT = 0
AS 
BEGIN
	INSERT INTO usuarios (nombre, correo, telefono) VALUES (@nombre, @correo, @telefono)
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