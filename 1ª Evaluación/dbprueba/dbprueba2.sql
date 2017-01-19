create table cliente (
    id bigint AUTO_INCREMENT PRIMARY KEY,
    nombre varchar(50) not null UNIQUE
);
create table pedido (
    id bigint AUTO_INCREMENT PRIMARY KEY,
    cliente bigint not null,
    fecha datetime not null,
    importe decimal(10,2)
);
create table pedidolinea (
    id bigint AUTO_INCREMENT PRIMARY KEY,
    pedido bigint not null,
    articulo bigint not null,
    precio decimal(10,2),
    unidades decimal(10,2),
    importe decimal(10,2)
);

alter table articulo add FOREIGN key (categoria) REFERENCES categoria (id);
ALTER TABLE pedido add FOREIGN KEY (cliente) REFERENCES cliente (id);
alter table pedidolinea add FOREIGN key (pedido) REFERENCES pedido (id) on delete cascade;
alter TABLE pedidolinea add FOREIGN KEY (articulo) REFERENCES articulo (id);
