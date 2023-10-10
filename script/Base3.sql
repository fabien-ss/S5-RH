
create table coefficient
(
    id_coefficient serial
        primary key,
    valeur         integer,
    text           varchar(500)
);

create table service
(
    id_service serial
        primary key,
    nom        varchar(200) not null
);


create table poste
(
    id_poste   serial
        primary key,
    id_service integer
        references service,
    details    varchar(500) not null
);

create table annonce
(
    id_annonce serial
        primary key,
    id_service integer
        references service,
    debut      timestamp not null,
    fin        timestamp not null,
    details    varchar(500)
);

create table diplome
(
    id_diplome serial
        primary key,
    details    varchar(255) not null
);

create table experience
(
    id_experience serial
        primary key,
    details       varchar(255) not null
);


create table sexe
(
    id_sexe serial
        primary key,
    details varchar(255) not null
);


create table situation_matrimoniale
(
    id_situation_matrimoniale serial
        primary key,
    details                   varchar(255) not null
);


create table qualification
(
    id_qualification       serial
        primary key,
    id_annonce             integer
        references annonce,
    diplome                varchar(500) not null,
    experience             varchar(500) not null,
    sexe                   varchar(500) not null,
    situation_matrimoniale varchar(500) not null
);


create table question
(
    id_question serial
        primary key,
    question    varchar(255) not null,
    id_annonce  integer
        references annonce,
    point       integer
);


create table reponse
(
    id_question integer
        references question,
    id_reponse  serial
        primary key,
    reponse     varchar(255) not null,
    verite      integer      not null
);

create table candidature
(
    id_candidature   serial
        primary key,
    id_annonce       integer
        references annonce,
    nom              varchar(500) not null,
    prenom           varchar(500) not null,
    date_de_naissane timestamp    not null,
    contact          varchar(500) not null
);

create table candidat_cv
(
    id_candidat_cv            serial
        primary key,
    id_candidature            integer
        references candidature,
    id_diplome                integer
        references diplome,
    id_sexe                   integer
        references sexe,
    id_situation_matrimoniale integer
        references situation_matrimoniale,
    id_poste                  integer
        constraint fk_candidat_cv_poste
            references poste,
    id_experience             integer
        constraint fk_candidat_cv_experience
            references experience
);

create table note
(
    id_candidature serial
        primary key,
    note           double precision
);


create table mission
(
    id_mission serial
        constraint unq_mission_id_mission
            unique
        constraint fk_mission_poste
            references poste,
    nom        varchar(500),
    id_poste   integer
);


create table tache
(
    id_tache   serial
        constraint pk_tache
            primary key,
    nom        varchar,
    id_mission integer
);

create table type_avantage
(
    id_avantage serial
        constraint pk_type_avantage
            primary key,
    nom         varchar(500)
);

create table type_contrat
(
    id_type_contrat serial primary key,
    nom             varchar(500)
);

create table details_contrat
(
    id_details_contrat serial
        constraint pk_details_contrat
            primary key,
    date_debut         date,
    date_fin           date,
    id_type_contrat    integer
        constraint fk_details_contrat
            references type_contrat,
    id_salaire         bigint,
    matricule          varchar(500) default 'none'::character varying,
    constraint unq_details_contrat_id_details_contrat
        unique (id_details_contrat, id_type_contrat)
);

create table employe
(
    id_employe         serial
        constraint pk_employe
            primary key,
    id_candidature     integer
        references candidature,
    id_details_contrat integer
        constraint fk_employe_details_contrat
            references details_contrat,
    id_superieur       integer
        constraint fk_employe_employe
            references employe
);

create table avantage_employe
(
    id_employe  integer
        constraint fk_avantage_employe_employe
            references employe,
    id_avantage integer
        constraint fk_avantage_employe
            references type_avantage
);

create table salaire
(
    date_salaire timestamp,
    salaire      double precision,
    id_contrat   integer not null
        constraint fk_salaire_details_contrat
            references details_contrat
);

create table jour
(
    id_jour Serial not null
        constraint pk_jour
            primary key,
    jour    varchar
);

create table horaire
(
    id_contrat integer 
            references details_contrat(id_details_contrat),
    entree     varchar,
    sortie     varchar,
    id_jour    integer
        constraint fk_horaire_jour
            references jour
);

create view v_avantages(id_employe, id_avantage, nom) as
SELECT ae.id_employe,
       ae.id_avantage,
       ta.nom
FROM avantage_employe ae
         JOIN type_avantage ta ON ae.id_avantage = ta.id_avantage;

create view v_horaire(id_contrat, entree, sortie, id_jour, jour) as
SELECT h.id_contrat,
       h.entree,
       h.sortie,
       h.id_jour,
       j.jour
FROM horaire h
         JOIN jour j ON h.id_jour = j.id_jour;

