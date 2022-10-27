--CREATE TABLE  producto (Id INT IDENTITY(1,1) PRIMARY KEY , Producto VARCHAR(100), Cantidad INT, ValorUnitario INT, ValorTotal INT) 

--CREATE TABLE cliente (Id INT IDENTITY(1,1) PRIMARY KEY ,Cedula INT, Nombre VARCHAR(100), Apellido VARCHAR(100), Telefono INT)

--UPDATE producto SET Producto='MANZANA',Cantidad=7,ValorUnitario=3900,ValorTotal=4000 WHERE Id=3
select * from cliente where id = 4

--INSERT INTO producto (Producto,Cantidad,ValorUnitario,ValorTotal) VALUES ('MANZANA',20,700,710),
--('ARANDANO AZUL',20,700,710)

--TRUNCATE TABLE producto
--select * from producto
--select * from ventas
--select * from cliente

/*CREATE TABLE ventas
(Id INT IDENTITY(1,1) PRIMARY KEY,
IdProducto INT NOT NULL,
IdCliente INT NOT NULL,
Cantidad INT,
ValorUnitario INT,
ValorTotal INT,
CONSTRAINT Idprod FOREIGN KEY(IdProducto)
REFERENCES producto (Id), 
CONSTRAINT Idcli FOREIGN KEY(IdCliente)
REFERENCES cliente (Id)) */