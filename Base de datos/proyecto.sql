USE master
go

IF exists(SELECT * FROM SysDataBases WHERE name='Proyecto_Pronosticos')
BEGIN
    DROP DATABASE Proyecto_Pronosticos
END
go

CREATE DATABASE Proyecto_Pronosticos
go
use Proyecto_Pronosticos
go

-----------------------------------------------------------------------------------------------------------
					/*/*/*/*/*/*/*/*/*/*	SERVIDOR   	*/*/*/*/*/*/*/*/*/*/
-----------------------------------------------------------------------------------------------------------
USE master
GO

CREATE LOGIN [IIS APPPOOL\DefaultAppPool] FROM WINDOWS 
GO

USE Proyecto_Pronosticos
GO

CREATE USER [IIS APPPOOL\DefaultAppPool] FOR LOGIN [IIS APPPOOL\DefaultAppPool]
GO

GRANT Execute to [IIS APPPOOL\DefaultAppPool]
go


-----------------------------------------------------------------------------------------------------------
					/*/*/*/*/*/*/*/*/*/*	 TABLAS		*/*/*/*/*/*/*/*/*/*/
-----------------------------------------------------------------------------------------------------------
create table usuarios (
	username varchar(20) not null primary key,
	password varchar(9) not null 
		check(password like '[0-9][0-9][0-9][A-Z][A-Z][A-Z][A-Z][^0-9A-Z][^0-9A-Z]'),
	nombre_completo varchar(50) not null
)
go

create table empleados (
	usuario varchar(20) primary key,
	carga_horaria int check(carga_horaria > 0),
	foreign key (usuario) references usuarios (username)
)
go

create table meteorologos (
	usuario varchar(20) primary key,
	telefono varchar(20) not null,
	correo varchar(30) not null
		check(correo like '%_@__%.__%'),
	deleted bit not null default(0),
	foreign key (usuario) references usuarios (username)
)
go

create table ciudades (
	codigo varchar(6) not null primary key
		check(codigo like '[A-Z][A-Z][A-Z][A-Z][A-Z][A-Z]'),
	nombre_ciudad varchar(30) not null,
	pais varchar(20) not null,
	deleted bit not null default(0)
)
go

create table pronosticos_tiempo (
	interno int not null primary key identity(1,1),
	usuario varchar(20) not null,
	ciudad varchar(6) not null,
	fecha date not null
		check(fecha >= getDate()) default(getdate()),
	foreign key (usuario) references usuarios (username),
	foreign key (ciudad) references ciudades (codigo),
)
go

create table pronosticos_hora (
	hora int not null
		check (hora >= 0 and hora <= 2359),
	interno int not null,
	temp_max int not null,
	temp_min int not null,
	v_viento int not null,
	tipo_cielo varchar(20) not null
		check (tipo_cielo like 'despejado' 
		    or tipo_cielo like 'parcialmente_nuboso'
		    or tipo_cielo like 'nuboso'),
	prob_lluvias int not null
		check(prob_lluvias >= 0 and prob_lluvias <= 100),
	prob_tormenta int not null,
		check(prob_tormenta >= 0 and prob_tormenta <= 100),
	primary key (interno,hora),
	foreign key (interno) references pronosticos_tiempo (interno)
)
go


-----------------------------------------------------------------------------------------------------------
				  /*/*/*/*/*/*/*/*/*/*	    ROLES		*/*/*/*/*/*/*/*/*/*/
-----------------------------------------------------------------------------------------------------------

create role rol_empleados
go
create role rol_meteorologos
go


-----------------------------------------------------------------------------------------------------------
			      /*/*/*/*/*/*/*/*/*/*	  PROCEDIMIENTOS	 */*/*/*/*/*/*/*/*/*/
-----------------------------------------------------------------------------------------------------------
/*********************************************************************************************************/
-----------------------------------------------------------------------------------------------------------
		-- CREAR USUARIO EMPLEADO --	1
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'crear_usuario_empleado')
		drop proc crear_usuario_empleado
	go
	create procedure crear_usuario_empleado 
		@username varchar(20),
		@nombre varchar(50),
		@pass varchar(9),
		@hrs int
	as
	begin
		declare @var_sentencia varchar(max)
		declare @rol varchar(50) 

		if (exists(select * from usuarios where username = @username))
			return -1
			
		begin try
			
			begin transaction
				insert usuarios(username, password, nombre_completo) values (@username, @pass, @nombre)
				insert empleados(usuario, carga_horaria) values (@username, @hrs)			
			commit transaction
		end try
		begin catch
			rollback transaction
			return @@error
		end catch
		
		if (@@ERROR = 0)
		begin
			set @var_sentencia ='create login ['+@username+'] with password = '+QUOTENAME(@pass, '''')
			exec (@var_sentencia)

			set @var_sentencia = 'create user [' + @username + '] from login [' + @username + ']'
			exec (@var_sentencia)
			
			set @rol = 'rol_empleados'
			exec sp_addrolemember @rolename=@rol, @membername=@username
			exec sp_addrolemember @rolename='db_securityAdmin', @membername=@username
			exec sp_addsrvrolemember @loginame=@username, @rolename='securityadmin'
			
			return 1
		end	  
		else
		begin
			return -2
		end
	end
	go
-----------------------------------------------------------------------------------------------------------
		-- CREAR USUARIO METEOROLOGO --		3
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'crear_usuario_meteorologo')
		drop proc crear_usuario_meteorologo
	go
	create procedure crear_usuario_meteorologo 
		@username varchar(20),
		@nombre varchar(50),
		@pass varchar(9),
		
		@telefono varchar(20),
		@correo varchar(30)
	as
	begin
		declare @var_sentencia varchar(max)
		declare @rol varchar(50)
		
		if (exists(select * from usuarios where username = @username))
			return -1
		if (exists(select * from meteorologos where usuario = @username and deleted = 1))
		begin
			update meteorologos
			set telefono = @telefono, correo = @correo, deleted = 0
			where usuario = @username
			return -2
		end
		
		begin try
			begin transaction
				insert usuarios(username, password, nombre_completo) values (@username, @pass, @nombre)
				insert meteorologos(usuario, telefono, correo) values (@username, @telefono, @correo)
			commit transaction
		end try
		begin catch
			rollback transaction
			return @@error
		end catch
		
		if (@@ERROR = 0)
		begin
			set @var_sentencia ='create login ['+@username+'] with password = '+QUOTENAME(@pass, '''')
			exec (@var_sentencia)

			set @var_sentencia = 'create user [' + @username + '] from login [' + @username + ']'
			exec (@var_sentencia)
			
			set @rol = 'rol_empleados'
			exec sp_addrolemember @rolename=@rol, @membername=@username
			exec sp_addrolemember @rolename='db_securityAdmin', @membername=@username
			exec sp_addsrvrolemember @loginame=@username, @rolename= 'dbcreator'
			  
			return 1
		end	  
		else
		begin
			return -2
		end
	end
	go
-----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------
		-- ELIMINAR USUARIO EMPLEADO --		2
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'eliminar_ususario_empleado')
		drop proc eliminar_ususario_empleado
	go
	create procedure eliminar_ususario_empleado 
		@username varchar(20)
	as
	begin
		declare @var_sentencia varchar(max)
		declare @rol varchar(50)

		if not(exists(select * from usuarios where username = @username))
			return -1
		if not(exists(select * from empleados where usuario = @username))
			return -2
		
		set @rol = 'rol_empleados'
		exec sp_droprolemember @rolename=@rol, @membername=@username 
		exec sp_droprolemember @rolename='db_securityadmin', @membername=@username
		exec sp_dropsrvrolemember @loginame=@username, @rolename='securityadmin'

		begin try
			begin transaction
				delete empleados where usuario = @username
				delete usuarios where username = @username
			commit transaction
		end try
		begin catch
			rollback transaction
			-- return @@error
			raiserror(0,16,16,@@error)
		end catch
		
		set @var_sentencia = 'drop user [' + @username + ']'
		exec (@var_sentencia)

		set @var_sentencia = 'drop login [' + @username + ']'
		exec (@var_sentencia)	

		return 1
	end
	go
-----------------------------------------------------------------------------------------------------------
		-- ELIMINAR USUARIO METEOROLOGO --		4
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'eliminar_ususario_meteorologo')
		drop proc eliminar_ususario_meteorologo
	go
	create procedure eliminar_ususario_meteorologo 
		@username varchar(20)
	as
	begin
		declare @var_sentencia varchar(max)
		declare @rol varchar(50)
		
		if not(exists(select * from usuarios where username = @username))
			return -1
		if not(exists(select * from meteorologos where usuario = @username))
			return -2
		if exists(select * from pronosticos_tiempo where usuario = @username)
		begin
			update meteorologos set deleted = 1 where usuario = @username
		end
			else
		begin
			set @rol = 'rol_meteorologos'
			exec sp_droprolemember @rolename=@rol, @membername=@username 
			exec sp_droprolemember @rolename='db_securityadmin', @membername=@username
			exec sp_dropsrvrolemember @loginame=@username, @rolename= 'dbcreator'

			begin try
				begin transaction
					delete meteorologos where usuario = @username
					delete usuarios where username = @username
				commit transaction
			end try
			begin catch
				rollback transaction
				-- return @@error
				raiserror(0,16,16,@@error)
			end catch	
			
			set @var_sentencia = 'drop user [' + @username + ']'
			exec (@var_sentencia)

			set @var_sentencia = 'drop login [' + @username + ']'
			exec (@var_sentencia)
			
			return 1
		end
	end
	go
-----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------
		-- MODIFICAR USUARIO EMPLEADO --		5
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'modificar_ususario_empleado')
		drop proc modificar_ususario_empleado
	go
	create procedure modificar_ususario_empleado 
		@username varchar(20),
		@nombre varchar(50),
		@pass varchar(9),
		
		@hrs int
	as
	begin
		if not(exists(select * from usuarios where username = @username))
			return -1
		if not(exists(select * from empleados where usuario = @username))
			return -2

		begin try
			begin transaction
				update usuarios set nombre_completo=@nombre, password = @pass where username = @username
				update empleados set carga_horaria = @hrs where usuario = @username
			commit transaction
			return 1		
		end try
		begin catch
			rollback transaction
			return @@error
		end catch	
	end
	go
-----------------------------------------------------------------------------------------------------------
		-- MODIFICAR USUARIO METEOROLOGO --		6
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'modificar_ususario_meteorologo')
		drop proc modificar_ususario_meteorologo
	go
	create procedure modificar_ususario_meteorologo 
		@username varchar(20),
		@nombre varchar(50),
		@pass varchar(9),
		
		@telefono varchar(20),
		@correo varchar(30)
	as
	begin
		if not(exists(select * from usuarios where username = @username))
			return -1
		if not(exists(select * from meteorologos where usuario = @username))
			return -2

		begin try
			begin transaction
				update usuarios set nombre_completo=@nombre, password = @pass where username = @username
				update meteorologos set telefono = @telefono, correo = @correo where usuario = @username
			return 1
			commit transaction
		end try
		begin catch
			rollback transaction
			return @@error
		end catch	
	end
	go
-----------------------------------------------------------------------------------------------------------
/*********************************************************************************************************/
-----------------------------------------------------------------------------------------------------------
									 /*	     CIUDADES	    */
-----------------------------------------------------------------------------------------------------------
		-- CREAR CIUDAD --		7
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'crear_ciudad')
		drop proc crear_ciudad
	go
	create proc crear_ciudad
		@codigo varchar(6), 
		@nombre_ciudad varchar(30),
		@pais varchar(20) 
	as	
	begin
		if (exists(select * from ciudades where codigo = @codigo and deleted = 1))
		begin
			update ciudades
			set nombre_ciudad = @nombre_ciudad, pais = @pais, deleted = 0
			where codigo = @codigo
			return 1
		end
		if (exists(select * from ciudades where codigo = @codigo and deleted = 0))
			return -1

		insert ciudades(codigo, nombre_ciudad, pais) values (@codigo, @nombre_ciudad, @pais)
	end
	go
-----------------------------------------------------------------------------------------------------------
		-- MODIFICAR CIUDAD --		8
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'modificar_ciudad')
		drop proc modificar_ciudad
	go
	create proc modificar_ciudad
		@codigo varchar(6), 
		@nombre_ciudad varchar(30),
		@pais varchar(20) 
	as
	begin
		if (not exists(select * from ciudades where codigo = @codigo and deleted = 0))
			return -1
		else
		begin
			update ciudades Set nombre_ciudad=@nombre_ciudad, pais = @pais where codigo = @codigo
			return 1
		end
	end
	go
-----------------------------------------------------------------------------------------------------------
		-- ELIMINAR CIUDAD --		9
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'eliminar_ciudad')
		drop proc eliminar_ciudad
	go
	create proc eliminar_ciudad
		@codigo varchar(6) 
	as
	begin
		if (not exists(select * from ciudades where codigo = @codigo))
		begin	
			return -1
		end

		if (exists(Select * From pronosticos_tiempo where ciudad = @codigo))
		Begin
			update ciudades Set deleted = 1 where codigo = @codigo
		end
		else
		begin
			Delete From ciudades where codigo = @codigo
			return 1
		end
	end
	go
-----------------------------------------------------------------------------------------------------------
/*********************************************************************************************************/
-----------------------------------------------------------------------------------------------------------
								 /*	     PRONOSTICO	TIEMPO     */
-----------------------------------------------------------------------------------------------------------
		-- CREAR PRONOSTICO TIEMPO --		10
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'crear_pronostico_tiempo')
		drop proc crear_pronostico_tiempo
	go
	create proc crear_pronostico_tiempo  
		@fecha date,
		@ciudad varchar(6), 
		@usuario varchar(20)
	as
	begin
		if (not exists (select * from usuarios where username = @usuario))
			return -1
		if (not exists (select * from ciudades where codigo = @ciudad))
			return -2
				
		begin try	
			insert into pronosticos_tiempo (fecha, usuario, ciudad)
				values (@fecha, @usuario, @ciudad)		
			return 1
		end try
		begin catch
			return @@error
		end catch
	end
	go		
-----------------------------------------------------------------------------------------------------------
		-- CREAR PRONOSTICO HORA --		11
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'crear_pronostico_hora')
		drop proc crear_pronostico_hora
	go
	create proc crear_pronostico_hora  
		@hora int,
		@temp_max int,
		@temp_min int,
		@v_viento int,
		@tipo_cielo varchar(20),
		@prob_lluvias int,
		@prob_tormenta int
	as
	begin
		begin try	
			insert into pronosticos_hora (hora, temp_max, temp_min, v_viento, tipo_cielo, prob_lluvias, prob_tormenta)
				values (@hora, @temp_max, @temp_min, @v_viento, @tipo_cielo, @prob_lluvias, @prob_tormenta)		
			return 1
		end try
		begin catch
			return @@error
		end catch
	end
	go
-----------------------------------------------------------------------------------------------------------
/*********************************************************************************************************/
-----------------------------------------------------------------------------------------------------------
								 /*			LISTADOS	    */
-----------------------------------------------------------------------------------------------------------
		-- CIUDADES PARA DESPLEGABLE --			12
-----------------------------------------------------------------------------------------------------------	
	if exists (select * from sysobjects where name = 'listar_ciudades')
		drop proc listar_ciudades
	go
	create proc listar_ciudades
	as
	begin
		select * from ciudades where deleted = 0
	end
	go

-----------------------------------------------------------------------------------------------------------
		-- PRONOSTICOS DE AÑO ACTUAL --			13
-----------------------------------------------------------------------------------------------------------	
	if exists (select * from sysobjects where name = 'listar_pronosticos_anio')
		drop proc listar_pronosticos_anio
	go
	create proc listar_pronosticos_anio
	as
	begin
		select * 
		from pronosticos_tiempo
		where YEAR(fecha) = YEAR(GETDATE())
	end
	go

-----------------------------------------------------------------------------------------------------------
		-- PRONOSTICOS TODOS POR FECHA --			14
-----------------------------------------------------------------------------------------------------------	
	if exists (select * from sysobjects where name = 'listar_pronosticos_fecha')
		drop proc listar_pronosticos_fecha
	go
	create proc listar_pronosticos_fecha
		@fecha date
	as
	begin
		select * from pronosticos_tiempo where fecha = @fecha
	end
	go

-----------------------------------------------------------------------------------------------------------
		-- PRONOSTICOS HORA DE CADA P.TIEMPO --			15
-----------------------------------------------------------------------------------------------------------	
	if exists (select * from sysobjects where name = 'listar_pronosticos_hora')
		drop proc listar_pronosticos_hora
	go
	create proc listar_pronosticos_hora
		@interno int
	as
	begin
		select * from pronosticos_hora where interno = @interno
	end
	go

-----------------------------------------------------------------------------------------------------------
		-- CIUDADES SIN PRONOSTICOS --			16
-----------------------------------------------------------------------------------------------------------	

	if exists (select * from sysobjects where name = 'listar_ciudades_sin')
		drop proc listar_ciudades_sin
	go
	create proc listar_ciudades_sin
	as
	begin
		select * from ciudades c 
		where deleted = 0 
		and c.codigo not in (select ciudad from pronosticos_tiempo)
	end
	go
-----------------------------------------------------------------------------------------------------------
		-- METEOROLOGO SIN PRONOSTICO POR AÑO --		17
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'listar_meteorologos_sin')
		drop proc listar_meteorologos_sin
	go
	create proc listar_meteorologos_sin
	as
	begin
		select * from meteorologos m
		inner join usuarios u on u.username = m.usuario
		where m.usuario not in (select usuario from pronosticos_tiempo)
		and deleted = 0
	end
	go

-----------------------------------------------------------------------------------------------------------
/*********************************************************************************************************/
-----------------------------------------------------------------------------------------------------------
							   /*			BUSQUEDAS 		   */
-----------------------------------------------------------------------------------------------------------
	-- LOGUEO EMPLEADO --			18
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'logueo_empleado')
		drop proc logueo_empleado
	go
	create proc logueo_empleado
		@user varchar(20),
		@pass varchar(9)
	as
	begin
		select * from usuarios u
		inner join empleados e on e.usuario = u.username
		where u.username = @user and u.password = @pass
	end
	go
-----------------------------------------------------------------------------------------------------------
	-- LOGUEO METEOROLOGO --		19
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'logueo_meteorologo')
		drop proc logueo_meteorologo
	go
	create proc logueo_meteorologo
		@user varchar(20),
		@pass varchar(9)
	as
	begin
		select * from usuarios u
		inner join meteorologos m on m.usuario = u.username
		where u.username = @user and u.password = @pass
	end
	go

-----------------------------------------------------------------------------------------------------------
	-- BUSCAR USUARIO METEOROLOGO ACTIVO --			20
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'buscar_meteorologo_activo')
		drop proc buscar_meteorologo_activo
	go
	create proc buscar_meteorologo_activo
		@user varchar(20)
	as
	begin
		select * from usuarios u
		inner join meteorologos m on m.usuario = u.username
		where u.username = @user and m.deleted = 0
	end
	go
	
-----------------------------------------------------------------------------------------------------------
	-- BUSCAR USUARIO METEOROLOGO --		21
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'buscar_meteorologo')
		drop proc buscar_meteorologo
	go
	create proc buscar_meteorologo
		@user varchar(20)
	as
	begin
		select * from usuarios u
		join meteorologos m on m.usuario = u.username
		where u.username = @user
	end
	go

-----------------------------------------------------------------------------------------------------------
	-- BUSCAR USUARIO EMPLEADO --		22
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'buscar_empleado')
		drop proc buscar_empleado
	go
	create proc buscar_empleado
		@user varchar(20)
	as
	begin
		select * from usuarios u
		join empleados e on e.usuario = u.username
		where u.username = @user
	end
	go
	
-----------------------------------------------------------------------------------------------------------
	-- BUSCAR CIUDAD ACTIVA --			23
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'buscar_ciudad_activa')
		drop proc buscar_ciudad_activa
	go
	create proc buscar_ciudad_activa
		@code varchar(6)
	as
	begin
		select * from ciudades where codigo = @code and deleted = 0
	end
	go
	
-----------------------------------------------------------------------------------------------------------
	-- BUSCAR CIUDAD --		24
-----------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where name = 'buscar_ciudad')
		drop proc buscar_ciudad
	go
	create proc buscar_ciudad
		@code varchar(6)
	as
	begin
		select * from ciudades where codigo = @code
	end
	go
-----------------------------------------------------------------------------------------------------------	
/*********************************************************************************************************/
-----------------------------------------------------------------------------------------------------------
								 /*			PERMISOS	     */
-----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------
		-- EMPLEADOS
-----------------------------------------------------------------------------------------------------------

grant execute on crear_usuario_empleado to rol_empleados
go
grant execute on crear_usuario_meteorologo to rol_empleados
go
grant execute on eliminar_ususario_empleado to rol_empleados
go
grant execute on eliminar_ususario_meteorologo to rol_empleados
go
grant execute on modificar_ususario_empleado to rol_empleados
go
grant execute on modificar_ususario_meteorologo to rol_empleados
go

grant execute on buscar_ciudad to rol_empleados
go
grant execute on buscar_ciudad_activa to rol_meteorologos
go
grant execute on crear_ciudad to rol_empleados
go
grant execute on modificar_ciudad to rol_empleados
go
grant execute on eliminar_ciudad to rol_empleados
go

grant execute on buscar_meteorologo_activo to rol_empleados
go
grant execute on buscar_meteorologo to rol_empleados
go
grant execute on buscar_empleado to rol_empleados
go

grant execute on listar_pronosticos_anio to rol_empleados
go
grant execute on listar_pronosticos_hora to rol_empleados
go
grant execute on listar_pronosticos_fecha to rol_empleados
go
grant execute on listar_ciudades to rol_empleados
go
grant execute on listar_ciudades_sin to rol_empleados
go
grant execute on listar_meteorologos_sin to rol_empleados
go

-----------------------------------------------------------------------------------------------------------
		-- METEOROLOGOS
-----------------------------------------------------------------------------------------------------------

grant execute on crear_pronostico_tiempo to rol_meteorologos
go
grant execute on crear_pronostico_hora to rol_meteorologos
go
grant execute on modificar_ususario_meteorologo to rol_meteorologos
go

grant execute on buscar_ciudad_activa to rol_meteorologos
go
grant execute on buscar_ciudad to rol_meteorologos
go

grant execute on listar_ciudades to rol_empleados
go
grant execute on listar_pronosticos_hora to rol_meteorologos
go

-----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------
					/*/*/*/*/*/*/*/*/*/*	 DATOS		*/*/*/*/*/*/*/*/*/*/
-----------------------------------------------------------------------------------------------------------
--insert usuarios (username,password,nombre_completo)
--	values ('Esteban89', '123este**', 'Esteban Piccardo'),
--		   ('Analia123', '123anal**', 'Analia Rodriguez'),
--		   ('Carlos29',  '129carl**', 'Carlos Techera'),
--		   ('Laura36663','123laur**', 'Larua Setevelatan'),
--		   ('Admin',     '000admi**', 'Administrador')
--go

--insert empleados (usuario,carga_horaria)
--	values ('Esteban89', 44),
--	       ('Analia123', 24),
--	       ('Admin',	 16)
--go

--insert meteorologos (usuario,telefono,correo)
--	values ('Carlos29',   '098790944', 'carlosfernandez@gmail.com'),
--		   ('Laura36663', '094143488', 'laura36@gmail.com'),
--		   ('Admin',	  '099099099', 'admin-sistema@gmail.com')
--go

exec crear_usuario_empleado 'Esteban89', 'Esteban Piccardo', '123este**', 44
exec crear_usuario_empleado 'Analia123', 'Analia Rodriguez', '123anal**', 24
exec crear_usuario_empleado 'Admin',	 'Administrador',	 '000admi**', 16
exec crear_usuario_empleado 'Usuario2',	 'Usuario2',		 '000admi**', 16

exec crear_usuario_meteorologo 'Carlos29',   'Carlos Techera',    '129carl**', '098790944', 'carlosfernandez@gmail.com'
exec crear_usuario_meteorologo 'Laura36663', 'Larua Setevelatan', '123laur**', '094143488', 'laura36@gmail.com'
exec crear_usuario_meteorologo 'Usuario1',   'Usuario1',		  '000admi**', '094143100', 'usuario1@gmail.com'


--exec eliminar_ususario_empleado 'Esteban89'
--exec eliminar_ususario_empleado 'Analia123'
--exec eliminar_ususario_empleado 'Admin'
--exec eliminar_ususario_empleado 'Usuario2'

--exec eliminar_ususario_meteorologo 'Carlos29'
--exec eliminar_ususario_meteorologo 'Laura36663'
--exec eliminar_ususario_meteorologo 'Usuario1'


insert ciudades (codigo,nombre_ciudad,pais)
	values ('URUMVD', 'Montevideo', 'Uruguay'),
		   ('URUCAN', 'Canelones', 'Uruguay'),
		   ('URULPS', 'Las Piedras', 'Uruguay'),
		   ('URUPAN', 'Pando', 'Uruguay'),
		   ('URUSAN', 'San Ramon', 'Uruguay'),
		   ('URUPIR', 'Piriapoilis', 'Uruguay'),
		   ('URUMDO', 'Maldonado', 'Uruguay'),
		   ('URUPDE', 'Punta del Este', 'Uruguay'),
		   ('URURCA', 'Rocha', 'Uruguay'),
		   ('URULPM', 'La Paloma', 'Uruguay'),
		   ('ARGBAS', 'Bs As', 'Argentina'),
		   ('BRSSAP', 'Sao Pablo', 'Brasil')   
go

insert pronosticos_tiempo (fecha,usuario,ciudad)
	values ('20220310 06:00:00','Carlos29','URUMVD'),
		   ('20220310 06:15:00','Carlos29','URUCAN'),
		   ('20220310 07:30:00','Carlos29','URUCAN'),
		   ('20220310 08:00:00','Laura36663','URUPDE'),
		   ('20220310 09:15:00','Laura36663','URUPDE'),
		   ('20220310 15:30:00','Carlos29','URUMVD'),
		   ('20220310 18:00:00','Carlos29','URUPIR'),
		   ('20220310 18:15:00','Carlos29','URUMVD'),
		   ('20220310 18:30:00','Carlos29','URUMVD'),
		   ('20220310 20:00:00','Laura36663','URUMVD'),
		   ('20220310 20:15:00','Laura36663','URUPIR'),
		   ('20220310 23:30:00','Laura36663','URUMVD'),
		   ('20220311 06:00:00','Carlos29','URUMVD'),
		   ('20220311 06:15:00','Carlos29','URUSAN'),
		   ('20220311 07:30:00','Carlos29','URUSAN'),
		   ('20220311 08:00:00','Carlos29','URUSAN'),
		   ('20220311 09:15:00','Carlos29','URUMVD'),
		   ('20220311 15:30:00','Carlos29','URUMVD'),
		   ('20220312 18:00:00','Carlos29','URUMVD'),
		   ('20220312 18:15:00','Carlos29','BRSSAP'),
		   ('20220312 18:30:00','Laura36663','URUMVD'),
		   ('20220313 20:00:00','Laura36663','ARGBAS'),
		   ('20220313 20:15:00','Laura36663','URUMVD'),
		   ('20220313 23:30:00','Laura36663','URUMVD')
go

insert pronosticos_hora (interno,hora,temp_max,temp_min,v_viento,tipo_cielo,prob_lluvias,prob_tormenta)
	values  (1,600,24,18,45,'despejado',60,20),
			(2,615,24,18,45,'despejado',60,20),
			(3,730,24,18,45,'despejado',60,20),
			(4,800,24,18,45,'despejado',60,20),
			(5,915,24,18,45,'despejado',60,20),
			(6,1530,24,18,45,'despejado',60,20),
			(7,1800,24,18,45,'despejado',60,20),
			(8,1815,24,18,45,'parcialmente_nuboso',60,20),
			(9,1830,24,18,45,'parcialmente_nuboso',60,20),
			(10,2000,24,18,45,'parcialmente_nuboso',60,20),
			(11,2015,24,18,45,'parcialmente_nuboso',60,20),
			(12,2330,24,18,45,'parcialmente_nuboso',60,20),
			(13,600,24,18,45,'despejado',60,20),
			(14,615,24,18,45,'despejado',60,20),
			(15,730,24,18,45,'despejado',60,20),
			(16,800,24,18,45,'despejado',60,20),
			(17,915,24,18,45,'despejado',60,20),
			(18,1530,24,18,45,'nuboso',60,20),
			(19,1800,24,18,45,'nuboso',60,20),
			(20,1815,24,18,45,'despejado',60,20),
			(21,1830,24,18,45,'nuboso',60,20),
			(22,2000,24,18,45,'nuboso',60,20),
			(23,2015,24,18,45,'nuboso',60,20),
			(24,2330,24,18,45,'nuboso',60,20)		
go