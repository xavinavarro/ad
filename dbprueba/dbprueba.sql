create table categoria (
  id bigint auto_increment primary key,
  nombre varchar(50) not null unique
);

insert into categoria (nombre) values ('categoría 1');
insert into categoria (nombre) values ('categoría 2');
insert into categoria (nombre) values ('categoría 3');

create table articulo (
  id bigint auto_increment primary key,
  nombre varchar(50) not null unique,
  precio decimal(10,2),
  categoria bigint
);

alter table articulo add foreign key (categoria)
  references categoria (id);


insert into articulo (nombre, precio, categoria) values ('artículo 1', 1, 1);
insert into articulo (nombre, precio, categoria) values ('artículo 2', 2, 2);
insert into articulo (nombre, precio) values ('artículo 3', 3);
insert into articulo (nombre) values ('artículo 4');
