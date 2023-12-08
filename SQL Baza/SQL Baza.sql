use master;

drop database if exists vehiclecatalog;
go

create database vehiclecatalog;
go
use vehiclecatalog;

create table VehicleMake(
		ID int not null primary key identity,
		carname varchar(50) not null,
		abrv varchar(50)


);

create table VehicleModel(
		ID int not null primary key identity,
		VehicleMake int,
		carname varchar(50) not null,
		abrv varchar(50)


);

alter table VehicleModel add foreign key (VehicleMake) references VehicleMake(ID);

insert into VehicleMake(carname,abrv)
values('Toyota','Tyt'),('Mazda','Mzd');

select * from VehicleMake;

insert into VehicleModel(VehicleMake,carname,abrv)
values(1,'Toyota','Tyt');

select * from VehicleModel;