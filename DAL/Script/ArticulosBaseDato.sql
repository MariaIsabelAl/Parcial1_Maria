Create database ArticulosMariaDb

use ArticulosMariaDb

create table Articulos
(
	ProductoId int primary key identity,
	Descripcion varchar(30),
	Existencia int,
	Costo int,
	ValorInventario int
)