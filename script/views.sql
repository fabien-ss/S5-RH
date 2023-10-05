create view v_question_reponse
as select q.id_question, q.question, q.id_annonce, r.id_question, r.id_reponse, r.reponse, r.verite from question q
    join reponse r
        on q.id_question = r.id_question;


CREATE or replace view v_avantages as
select ae.id_employe, ae.id_avantage, nom from avantage_employe ae join type_avantage ta
                                                                        on ae.id_avantage = ta.id_avantage;

CREATE or replace view v_missions as
select m.nom, me.id_mission, me.id_fiche_de_poste from mission m join mission_employe me
                                                                      on m.id_mission = me.id_mission;