create table genres (
	id int identity(1,1) primary key,
	genre_name nvarchar(30) not null unique check(len(genre_name) > 0)
);

create table actors (
	id int identity(1,1) primary key,
	actor_name nvarchar(30) not null check(len(actor_name) > 0),
	actor_surname nvarchar(30) not null check(len(actor_surname) > 0)
);

create table movies (
	id int identity(1,1) primary key,
	movie_name nvarchar(30) not null check(len(movie_name) > 0),
	movie_description nvarchar(100) not null check(len(movie_description) > 0),
	release_date date not null check(release_date < getdate()),
	rating float default 0,

	check (rating >= 0 and rating <= 5)
);

create table movie_genres (
	id int identity(1,1) primary key,
	id_movie int not null,
	id_genre int not null,
	foreign key (id_movie) references movies (id) on delete cascade,
	foreign key (id_genre) references genres (id) on delete cascade
);

create table movie_actors (
	id int identity(1,1) primary key,
	id_movie int not null,
	id_actor int not null,
	foreign key (id_movie) references movies (id) on delete cascade,
	foreign key (id_actor) references actors (id) on delete cascade
);

create table users (
	id int identity(1,1) primary key,
	username nvarchar(30) not null unique check(len(username) > 0),
	password nvarchar(50) not null check(len(password) > 8), 
	first_name nvarchar(30) not null check(len(first_name) > 0),
	last_name nvarchar(30) not null check(len(last_name) > 0),
	date_of_birth date not null check(date_of_birth < getdate()),
	email nvarchar(320) not null check(email like '%@%.%'),
	country nvarchar(50) not null check(len(country) > 0),
);

create table list (
	id int identity(1,1) primary key,
	id_user int not null,
	id_movie int not null,
	foreign key (id_user) references users (id) on delete cascade,
	foreign key (id_movie) references movies (id) on delete cascade
);