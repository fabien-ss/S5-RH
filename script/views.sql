create view v_question_reponse
as select q.id_question, q.question, q.id_annonce, r.id_question, r.id_reponse, r.reponse, r.verite from question q
                                                                                                             join reponse r
                                                                                                                  on q.id_question = r.id_question;