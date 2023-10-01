create database rh;
\c rh;

drop table if exists service;
create table service(
id_service serial primary key,
nom varchar(200) not null
);

drop table if exists poste;
create table poste(
id_poste serial primary key,
id_service int references service(id_service),
details varchar(500) not null
);

drop table if exists annonce;
create table annonce(
id_annonce serial primary key,
id_service int references service(id_service),
debut timestamp not null,
fin timestamp not null,
details varchar(500)
);

drop table if exists diplome;
create table diplome(
id_diplome serial primary key,
details varchar(255) not null
);

drop table if exists experience;
create table experience(
id_experience serial primary key,
details varchar(255) not null
);

drop table if exists sexe;
create table sexe(
id_sexe serial primary key,
details varchar(255) not null
);

drop table if exists situation_matrimoniale;
create table situation_matrimoniale(
id_situation_matrimoniale serial primary key,
details varchar(255) not null
);

drop table if exists qualification;
create table qualification(
id_qualification serial primary key,
id_annonce int references annonce(id_annonce),
dimplome varchar(500) not null, --- id = coefficient
experience varchar(500) not null, --- id = coefficient
sexe varchar(500) not null, -- id = coefficient
situation_matrimoniale varchar(500) not null-- id = coefficient
);

drop table if exists question;
create table question(
id_question serial primary key,
question varchar(255) not null,
id_annonce int references annonce(id_annonce) 
);

drop table if exists reponse;
create table reponse(
id_question int references question(id_question), 
id_reponse serial primary key,
reponse varchar(255) not null,
verite int not null -- 0 si faux 1 si vrai
);

drop table if exists candidature;
create table candidature(
id_candidature serial primary key,
id_annonce int references annonce(id_annonce),
nom varchar(500) not null,
prenom varchar(500) not null,
date_de_naissane timestamp not null,
contact varchar(500) not null
);

drop table if exists candidat_cv;
create table candidat_cv(
id_candidat_cv serial primary key,
id_candidature int references candidature(id_candidature),
id_diplome int references diplome(id_diplome),
id_sexe int references sexe(id_sexe),
id_situation_matrimoniale int references situation_matrimoniale(id_situation_matrimoniale)
);

drop table if exists note;
create table note(
id_candidature serial primary key,
note float
);