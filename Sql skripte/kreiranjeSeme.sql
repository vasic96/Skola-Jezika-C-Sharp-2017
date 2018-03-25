--Kreiranje baze

--create database SJWPF
--use SJWPF


--Kreiranje tabela
create table korisnik(
id int primary key,
ime varchar(30),
prezime varchar(30),
jmbg varchar(30),
sts bit,
kime varchar(30),
lozinka varchar(30),
uloga bit,
)


create table jezik(
id int primary key,
nazivJezika varchar(30),
oznaka varchar(30),
sts bit,
)

create table kurs
(
id int primary key,
jezikid int,
tipid int,
cena float,
datpoc date,
datkraj date,
sts bit,
)


create table nastavnik
(
 id int primary key,
ime varchar(30),
prezime varchar(30),
jmbg varchar(30),
sts bit,
plata float,
email varchar(30),
adresa varchar(30),
brTelefona varchar(30),


)


create table tipkursa
(
id int,
nivo varchar(30),
oznaka varchar(30),
sts bit,
)


create table skola

(
naziv varchar(30),
adresa varchar(30),
web varchar(30),
email varchar(30),
ziro varchar(30),
mb varchar(30),
pib varchar(30),

)

create table ucenik

(
id int primary key,
ime varchar(30),
prezime varchar(30),
jmbg varchar(30),
sts bit,
email varchar(30),
adresa varchar(30),
brTelefona varchar(30),


)

create table uplata
(
	uid int,
	kid int,
	datum date,
	sts bit,
)


create table nastavnikkurs
(
kid int,
nid int,
)


create table ucenikkurs
(
kid int,
uid int,
)








--brisanje baze
--use master
--drop database SJWPF




