create database biblioteca;
use biblioteca;


create table Carrera(
	codigoCarrera varchar(36) not null primary key,
	nombre varchar(100) not null
);

create table Usuario(
	codigoUsuario varchar(36) not null primary key,
	nombre varchar(50) not null,
	apellidos varchar(50) not null,
	direccion varchar(120) not null,
	telefono varchar(10) not null,
	dni char(8) not null unique,
	codigoInterno varchar(25) not null unique,
	sexo bit not null,
	codigoCarrera varchar(36) not null foreign key references Carrera(codigoCarrera) on delete cascade on update cascade,
	rol varchar(50) not null,
	contrasena varchar(500) not null
);

create table Autor (
	codigoAutor varchar(36) not null primary key,
	nombre varchar(60) not null,
	apellidos varchar(100) not null
);

create table Categoria (
	codigoCategoria varchar(36) not null primary key,
	nombre varchar(100) not null
);

create table Libro (
	codigoLibro varchar(36) not null primary key,	
	titulo varchar(100) not null,
	fechaLanzamiento date not null,
	idioma varchar(100) not null,
	paginas int not null,
	descripcion text not null,
	stock int not null
);

create table LibroAutor (
	codigoLibroAutor varchar(36) not null primary key,
	codigoAutor varchar(36) not null foreign key references Autor(codigoAutor) on delete cascade on update cascade,
	codigoLibro varchar(36) not null foreign key references Libro(codigoLibro) on delete cascade on update cascade
);

create table LibroCategoria(
	codigoLibroCategoria varchar(36) not null primary key,
	codigoCategoria varchar(36) not null foreign key references Categoria(codigoCategoria) on delete cascade on update cascade,
	codigoLibro varchar(36) not null foreign key references Libro(codigoLibro) on delete cascade on update cascade
);

create table Prestamo(
	codigoPrestamo varchar(36) not null primary key,
	fechaPrestamo date not null,
	fechaDevolucion date not null,
	codigoUsuario varchar(36) not null foreign key references Usuario(codigoUsuario)on delete cascade on update cascade,
	codigoLibro varchar(36) not null foreign key references Libro(codigoLibro)on delete cascade on update cascade,
	estado varchar(50) not null
);

create table Devolucion (
	codigoDevolucion varchar(36) not null primary key,
	fechaConsignada date not null,
	fechaDevolucion date not null,
	codigoPrestamo varchar(36) not null,
	codigoUsuario varchar(36) not null foreign key references Usuario(codigoUsuario)on delete cascade on update cascade,
	codigoLibro varchar(36) not null foreign key references Libro(codigoLibro)on delete cascade on update cascade
);
