create view v_question_reponse
as select q.id_question, q.question, q.id_annonce, r.id_reponse, r.reponse, r.verite from question q
    join reponse r
        on q.id_question = r.id_question;


CREATE or replace view v_avantages as
select ae.id_employe, ae.id_avantage, nom from avantage_employe ae join type_avantage ta
        on ae.id_avantage = ta.id_avantage;

CREATE or replace view v_missions as
select m.nom, me.id_mission, me.id_fiche_de_poste from mission m join mission_employe me
      on m.id_mission = me.id_mission;


create or replace view v_details_contrat as
select dc.id_details_contrat, dc.date_debut, dc.date_fin, tc.nom from details_contrat dc join type_contrat tc 
on dc.id_type_contrat = tc.id_type_contrat;

create or replace view v_horaire
       as select h.id_contrat, h.entree, h.sortie, h.id_jour, j.jour, dc.date_debut, dc.is_valide valide from horaire h 
          join jour j on h.id_jour = j.id_jour
            join details_contrat dc on h.id_contrat = dc.id_details_contrat where
            dc.is_valide = 0
;

create or replace view v_details_employe as 
       select c.nom, c.prenom, c.date_de_naissane date_de_naissance, c.contact, p.details, p.id_poste, dc.date_debut, dc.date_fin, dc.matricule, tc.nom libelle_contrat, e.id_employe,
     s.salaire renumeration, ts.nom typesalaire, ser.nom service, dc, dc.is_valide valide
       from employe e 
           join candidature c on e.id_candidature = c.id_candidature 
           join candidat_cv cc on cc.id_candidature = c.id_candidature
            join poste p on p.id_poste = cc.id_poste 
           join details_contrat dc on e.id_employe = dc.id_employe 
           join type_contrat tc on dc.id_type_contrat = tc.id_type_contrat
           join salaire s on s.id_contrat = dc.id_details_contrat
           join type_salaire ts on ts.id_type_salaire = s.id_type_salaire
           join service ser on p.id_service = ser.id_service
            where dc.is_valide = 0
       ;

create or replace view v_employe as 
    select e.id_candidature,  e.id_superieur, c.nom, c.prenom, p.details, e.id_employe, c.etat 
        from employe e 
        join candidature c on e.id_candidature = c.id_candidature
        join candidat_cv cc on cc.id_candidature = c.id_candidature 
        join poste p on cc.id_poste = p.id_poste;

create or replace view v_horraire as
    select h.id_contrat, h.entree, h.sortie, j.jour, e.id_employe from jour j join horaire h  on j.id_jour = h.id_jour
    join details_contrat dc on dc.id_details_contrat = h.id_contrat join employe e on e.id_employe = dc.id_employe where dc.is_valide = 0;
;