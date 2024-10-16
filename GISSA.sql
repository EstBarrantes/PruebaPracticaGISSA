DROP DATABASE GISSA;
CREATE DATABASE GISSA;

USE GISSA ;

Drop table Test_Usuario;
CREATE TABLE Test_Usuario (
	tipo_usuario VARCHAR(50),
	tipo_identificacion VARCHAR(50) NOT NULL,
	identificacion VARCHAR(12) PRIMARY KEY  NOT NULL,
	activo VARCHAR (12) NOT NULL,
	nombre_completo VARCHAR(250) NOT NULL,
	nombre_usuario VARCHAR(100)  NOT NULL,
	clave VARCHAR(64) NOT NULL,
	correo VARCHAR(150) NOT NULL
);
Drop table Test_Usuario_Telefono;
CREATE TABLE Test_Usuario_Telefono(
	identificacion_usuario VARCHAR(12)  NOT NULL,
	tipo VARCHAR(12),
	telefono int  NOT NULL,
	PRIMARY KEY (identificacion_usuario,telefono),
	FOREIGN KEY (identificacion_usuario ) REFERENCES Test_Usuario(identificacion)
);

Drop table Test_Habilidades_Blandas_Usuario;
CREATE TABLE Test_Habilidades_Blandas_Usuario(
	id INT PRIMARY KEY IDENTITY ,
	identificacion_usuario VARCHAR(12),
	habilidades VARCHAR(120),
	FOREIGN KEY (identificacion_usuario ) REFERENCES Test_Usuario(identificacion)
);


CREATE TABLE Catalogo_Habilidades_Blandas(
	id INT PRIMARY KEY IDENTITY ,
	habilidades VARCHAR(120),
);

INSERT INTO Test_Usuario (tipo_usuario, tipo_identificacion, identificacion, activo, nombre_completo, nombre_usuario, clave, correo)
VALUES ('Admin', 'Cédula', '1234567890', 'Activo', 'Juan Pérez', 'juan.perez', 'mi_clave', 'juan.perez@example.com');

INSERT INTO Test_Usuario_Telefono (identificacion_usuario, telefono_propio, telefono2, numero_telefono2, telefono3, numero_telefono3)
VALUES ('1234567890', 88887777, 'Casa', 22223333, 'Emergencia', 99998888);

INSERT INTO Test_Habilidades_Blandas_Usuario (identificacion_usuario, habilidades)
VALUES ('1234567890', 'Comunicación Efectiva');

INSERT INTO Catalogo_Habilidades_Blandas ( habilidades)
VALUES ('hola');
INSERT INTO Catalogo_Habilidades_Blandas ( habilidades)
VALUES ('adios');


