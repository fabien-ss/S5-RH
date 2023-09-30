create database rh;
\c rh;

create table service(
id_service serial primary key,
nom varchar(200) not null
);

create table poste(
id_poste serial primary key,
id_service int references service(id_service),
details varchar(500) not null
);

create table annonce(
id_annonce serial primary key,
id_service int references service(id_service),
debut timestamp,
fin timestamp,
details varchar(500)
);

create table diplome(
id_diplome serial primary key,
details varchar(255)
);

create table experience(
id_experience serial primary key,
details varchar(255)
);

create table sexe(
id_sexe serial primary key,
details varchar(255)
);

create table situation_matrimoniale(
id_situation_matrimoniale serial primary key,
details varchar(255)
);

create table qualification(
id_qualification serial primary key,
id_annonce int references annonce(id_annonce),
dimplome varchar(500), --- id = coefficient
experience varchar(500), --- id = coefficient
sexe varchar(500), -- id = coefficient
situation_matrimoniale varchar(500)-- id = coefficient
);

create table question(
id_question serial primary key,
question varchar(255)
);

create table reponse(
id_reponse serial primary key,
reponse varchar(255),
verite int -- 0 si faux 1 si vrai
);
