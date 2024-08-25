CREATE DATABASE OrganizeMySelf;

USE OrganizeMySelf
CREATE TABLE Type(
	id int not null primary key Identity(1,1),
	type varchar(25) not null
);
USE OrganizeMySelf
CREATE TABLE Storage(
	id int not null primary key Identity(1,1),
	date date not null,
	id_type int not null,
	inside int not null,
	cash decimal not null,
	constraint TypeConstraint FOREIGN KEY (id_type) references Type(id)
);