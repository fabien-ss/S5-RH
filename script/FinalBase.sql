CREATE SCHEMA IF NOT EXISTS "public";

CREATE SEQUENCE "public".annonce_id_annonce_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".candidat_cv_id_candidat_cv_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".candidature_id_candidature_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".coefficient_id_coefficient_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".details_contrat_id_details_contrat_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".diplome_id_diplome_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".employe_id_employe_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".experience_id_experience_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".jour_id_jour_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".mission_id_mission_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".note_id_candidature_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".poste_id_poste_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".qualification_id_qualification_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".question_id_question_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".reponse_id_reponse_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".service_id_service_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".sexe_id_sexe_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".situation_matrimoniale_id_situation_matrimoniale_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".tache_id_tache_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".type_avantage_id_avantage_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE "public".type_contrat_id_type_contrat_seq START WITH 1 INCREMENT BY 1;

CREATE  TABLE "public".coefficient (
       id_coefficient       serial primary key  ,
       valeur               integer    ,
       text                 varchar(500)    

);

CREATE  TABLE "public".diplome (
       id_diplome           serial primary key  ,
       details              varchar(255)  NOT NULL  
);

CREATE  TABLE "public".experience (
          id_experience        serial primary key  ,
          details              varchar(255)  NOT NULL  
);

CREATE  TABLE "public".jour (
        id_jour              serial primary key  ,
        jour                 varchar    
);

CREATE  TABLE "public".note (
        id_candidature       serial  primary key  ,
        note                 double precision    
);

CREATE  TABLE "public".service (
       id_service           serial primary key  ,
       nom                  varchar(200)  NOT NULL 
);

CREATE  TABLE "public".sexe (
        id_sexe              serial primary key ,
        details              varchar(255)  NOT NULL  
);

CREATE  TABLE "public".situation_matrimoniale (
          id_situation_matrimoniale serial primary key  ,
          details              varchar(255)  NOT NULL  
);

CREATE  TABLE "public".tache (
         id_tache             serial primary key ,
         nom                  varchar    ,
         id_mission           integer   
);

CREATE  TABLE "public".type_avantage (
         id_avantage          serial primary key ,
         nom                  varchar(500)   
);

CREATE  TABLE "public".type_contrat (
        id_type_contrat      serial primary key  ,
        nom                  varchar(500)   
);

CREATE  TABLE "public".type_salaire (
        id_type_salaire      serial primary key ,
        nom                  varchar(500)   
);

CREATE  TABLE "public".annonce (
       id_annonce           serial primary key  ,
       id_service           integer    ,
       debut                timestamp  NOT NULL  ,
       fin                  timestamp  NOT NULL  ,
       details              varchar(500)
);

CREATE  TABLE "public".candidature (
       id_candidature       serial primary key  ,
       id_annonce           integer    ,
       nom                  varchar(500)  NOT NULL  ,
       prenom               varchar(500)  NOT NULL  ,
       date_de_naissane     timestamp  NOT NULL  ,
       contact              varchar(500)  NOT NULL  ,
       etat int default 0
);

CREATE  TABLE "public".employe (
       id_employe           serial primary key  ,
       id_candidature       integer    ,
       id_superieur         integer   
);

CREATE  TABLE "public".poste (
         id_poste             serial primary key  ,
         id_service           integer    ,
         details              varchar(500)  NOT NULL  
);

CREATE  TABLE "public".qualification (
         id_qualification     serial primary key  ,
         id_annonce           integer    ,
         diplome              varchar(500)  NOT NULL  ,
         experience           varchar(500)  NOT NULL  ,
         sexe                 varchar(500)  NOT NULL  ,
         situation_matrimoniale varchar(500)  NOT NULL 
);

CREATE  TABLE "public".question (
        id_question          serial primary key  ,
        question             varchar(255)  NOT NULL  ,
        id_annonce           integer    ,
        point                integer   
);

CREATE  TABLE "public".reponse (
       id_question          integer    ,
       id_reponse           serial primary key  ,
       reponse              varchar(255)  NOT NULL  ,
       verite               integer  NOT NULL 
);

CREATE  TABLE "public".avantage_employe (
        id_employe           integer    ,
        id_avantage          integer    ,
        id                   serial  
);

CREATE  TABLE "public".candidat_cv (
       id_candidat_cv       serial primary key  ,
       id_candidature       integer    ,
       id_diplome           integer    ,
       id_sexe              integer    ,
       id_situation_matrimoniale integer    ,
       id_poste             integer    ,
       id_experience        integer   
);

CREATE  TABLE "public".details_contrat (
       id_details_contrat   serial primary key  ,
       date_debut           date    ,
       date_fin             date    ,
       id_type_contrat      integer    ,
       matricule            varchar(500) DEFAULT 'none'::character varying   ,
       id_employe           integer   
);

CREATE  TABLE "public".horaire (
    id serial primary key ,
       id_contrat           integer    ,
       entree               varchar    ,
       sortie               varchar    ,
       id_jour              integer
);

CREATE  TABLE "public".mission (
       id_mission           serial primary key  ,
       nom                  varchar(500)    ,
       id_poste             integer    
);

CREATE  TABLE "public".salaire (
       date_salaire         timestamp    ,
       salaire              double precision    ,
       id_contrat           integer  NOT NULL  ,
       id_type_salaire      integer
);

ALTER TABLE "public".annonce ADD CONSTRAINT annonce_id_service_fkey FOREIGN KEY ( id_service ) REFERENCES "public".service( id_service );

ALTER TABLE "public".avantage_employe ADD CONSTRAINT fk_avantage_employe_employe FOREIGN KEY ( id_employe ) REFERENCES "public".employe( id_employe );

ALTER TABLE "public".avantage_employe ADD CONSTRAINT fk_avantage_employe FOREIGN KEY ( id_avantage ) REFERENCES "public".type_avantage( id_avantage );

ALTER TABLE "public".candidat_cv ADD CONSTRAINT candidat_cv_id_candidature_fkey FOREIGN KEY ( id_candidature ) REFERENCES "public".candidature( id_candidature );

ALTER TABLE "public".candidat_cv ADD CONSTRAINT candidat_cv_id_diplome_fkey FOREIGN KEY ( id_diplome ) REFERENCES "public".diplome( id_diplome );

ALTER TABLE "public".candidat_cv ADD CONSTRAINT fk_candidat_cv_experience FOREIGN KEY ( id_experience ) REFERENCES "public".experience( id_experience );

ALTER TABLE "public".candidat_cv ADD CONSTRAINT fk_candidat_cv_poste FOREIGN KEY ( id_poste ) REFERENCES "public".poste( id_poste );

ALTER TABLE "public".candidat_cv ADD CONSTRAINT candidat_cv_id_sexe_fkey FOREIGN KEY ( id_sexe ) REFERENCES "public".sexe( id_sexe );

ALTER TABLE "public".candidat_cv ADD CONSTRAINT candidat_cv_id_situation_matrimoniale_fkey FOREIGN KEY ( id_situation_matrimoniale ) REFERENCES "public".situation_matrimoniale( id_situation_matrimoniale );

ALTER TABLE "public".candidature ADD CONSTRAINT candidature_id_annonce_fkey FOREIGN KEY ( id_annonce ) REFERENCES "public".annonce( id_annonce );

ALTER TABLE "public".details_contrat ADD CONSTRAINT fk_details_contrat FOREIGN KEY ( id_type_contrat ) REFERENCES "public".type_contrat( id_type_contrat );

ALTER TABLE "public".details_contrat ADD CONSTRAINT fk_details_contrat_employe FOREIGN KEY ( id_employe ) REFERENCES "public".employe( id_employe );

ALTER TABLE "public".employe ADD CONSTRAINT employe_id_candidature_fkey FOREIGN KEY ( id_candidature ) REFERENCES "public".candidature( id_candidature );

ALTER TABLE "public".horaire ADD CONSTRAINT horaire_id_contrat_fkey FOREIGN KEY ( id_contrat ) REFERENCES "public".details_contrat( id_details_contrat );

ALTER TABLE "public".horaire ADD CONSTRAINT fk_horaire_jour FOREIGN KEY ( id_jour ) REFERENCES "public".jour( id_jour );

ALTER TABLE "public".mission ADD CONSTRAINT fk_mission_poste FOREIGN KEY ( id_mission ) REFERENCES "public".poste( id_poste );

ALTER TABLE "public".poste ADD CONSTRAINT poste_id_service_fkey FOREIGN KEY ( id_service ) REFERENCES "public".service( id_service );

ALTER TABLE "public".qualification ADD CONSTRAINT qualification_id_annonce_fkey FOREIGN KEY ( id_annonce ) REFERENCES "public".annonce( id_annonce );

ALTER TABLE "public".question ADD CONSTRAINT question_id_annonce_fkey FOREIGN KEY ( id_annonce ) REFERENCES "public".annonce( id_annonce );

ALTER TABLE "public".reponse ADD CONSTRAINT reponse_id_question_fkey FOREIGN KEY ( id_question ) REFERENCES "public".question( id_question );

ALTER TABLE "public".salaire ADD CONSTRAINT fk_salaire_details_contrat FOREIGN KEY ( id_contrat ) REFERENCES "public".details_contrat( id_details_contrat );

ALTER TABLE "public".salaire ADD CONSTRAINT fk_salaire_type_salaire FOREIGN KEY ( id_type_salaire ) REFERENCES "public".type_salaire( id_type_salaire );

CREATE VIEW "public".v_avantages AS  SELECT ae.id_employe,
                                            ae.id_avantage,
                                            ta.nom
                                     FROM (avantage_employe ae
                                         JOIN type_avantage ta ON ((ae.id_avantage = ta.id_avantage)));

CREATE VIEW "public".v_horaire AS  SELECT h.id_contrat,
                                          h.entree,
                                          h.sortie,
                                          h.id_jour,
                                          j.jour
                                   FROM (horaire h
                                       JOIN jour j ON ((h.id_jour = j.id_jour)));

alter table details_contrat add column is_valide int default 1;