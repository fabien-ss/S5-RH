create view v_question_reponse
as select q.id_question, q.question, q.id_annonce, r.id_question, r.id_reponse, r.reponse, r.verite from question q
                                                                                                             join reponse r
create view v_classement
as select c.id_candidature,c.id_annonce,c.nom,c.prenom,n.note,c.contact from candidature c 
join note n on c.id_candidature=n.id_candidature;
