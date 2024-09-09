USE OrganizeMySelf
CREATE TABLE Type(
	id int not null primary key auto_increment,
	type varchar(25) not null
);
USE OrganizeMySelf
CREATE TABLE Storage(
	id int not null primary key auto_increment,
	date date not null,
	id_type int not null,
	inside int not null,
	cash float not null,
	descrizione varchar(255),
	constraint TypeConstraint FOREIGN KEY (id_type) references Type(id)
);
