INSERT INTO service (nom) VALUES
('Service RH'),
('Service Finances'),
('Service Informatique');

INSERT INTO poste (id_service, details) VALUES
(1, 'Responsable des Ressources Humaines'),
(1, 'Gestionnaire de Paie'),
(2, 'Comptable'),
(3, 'Développeur Web');

INSERT INTO annonce (id_service, debut, fin, details) VALUES
(1, '2023-10-01', '2023-10-15', 'Poste de Responsable RH ouvert'),
(2, '2023-09-15', '2023-10-30', 'Recherche Comptable expérimenté'),
(3, '2023-10-10', '2023-10-25', 'Développeur Web Full Stack recherché');

INSERT INTO diplome (details) VALUES
('Doctorat'),
('Master'),
('Licence'),
('Baccalauréat');

INSERT INTO experience (details) VALUES
('+5 ans'),
('+3 ans'),
('+2 ans');

INSERT INTO sexe (details) VALUES
('Homme'),
('Femme');

INSERT INTO situation_matrimoniale (details) VALUES
('Célibataire'),
('Marié(e)'),
('Divorcé(e)');

-- Remplacez les valeurs des colonnes id_annonce, diplome, experience, sexe, et situation_matrimoniale
INSERT INTO qualification (id_annonce, dimplome, experience, sexe, situation_matrimoniale) VALUES
(1, '1=4;2=3;3=1;4=0', '1=3;2=1;3=1', '1=2;2=1', '1=1;2=1;3=2'),
(2, '1=1;2=1;3=2;4=4', '1=1,2=1,3=3', '1=2;2=1', '1=1;2=2;3=1'),
(3, '1=1;2=3;3=1;4=3', '1=2,2=2,3=2', '1=2;2=1', '1=1;2=2;3=2');

INSERT INTO question (question) VALUES
('Avez-vous de l''expérience en gestion des ressources humaines?'),
('Quel est votre diplôme le plus élevé?'),
('Combien d''années d''expérience avez-vous en comptabilité?');

-- Remplacez les valeurs des colonnes id_question et verite
INSERT INTO reponse (id_question, reponse, verite) VALUES
(1, 'Oui', 1),
(1, 'Non', 0),
(2, 'Licence en Gestion des Ressources Humaines', 1),
(2, 'Baccalauréat en Informatique', 0),
(3, '3 ans', 1),
(3, '1 an', 0);

-- Remplacez les valeurs des colonnes id_annonce, nom, prenom, date_de_naissance et contact
INSERT INTO candidature (id_annonce, nom, prenom, date_de_naissane, contact) VALUES
(1, 'Doe', 'John', '1990-05-15', 'john.doe@example.com'),
(2, 'Smith', 'Alice', '1985-12-10', 'alice.smith@example.com'),
(3, 'Brown', 'David', '1995-08-25', 'david.brown@example.com');

-- Remplacez les valeurs des colonnes id_candidature, id_diplome, id_sexe et id_situation_matrimoniale
INSERT INTO candidat_cv (id_candidature, id_diplome, id_sexe, id_situation_matrimoniale) VALUES
(1, 1, 1, 1),
(2, 2, 2, 2),
(3, 3, 1, 1);

-- Remplacez les valeurs des colonnes id_candidature et note
INSERT INTO note (id_candidature, note) VALUES
(1, 4.5),
(2, 3.8),
(3, 4.2);


INSERT INTO poste (id_service, details) VALUES
                                            (1, 'Responsable des Ressources Humaines'),
                                            (1, 'Gestionnaire de Paie'),
                                            (2, 'Comptable'),
                                            (3, 'Développeur Web');

INSERT INTO annonce (id_service, debut, fin, details) VALUES
                                                          (1, '2023-10-01', '2023-10-15', 'Poste de Responsable RH ouvert'),
                                                          (2, '2023-09-15', '2023-10-30', 'Recherche Comptable expérimenté'),
                                                          (3, '2023-10-10', '2023-10-25', 'Développeur Web Full Stack recherché');

INSERT INTO diplome (details) VALUES
    ('Doctorat'),
('Master'),
('Licence'),
('Baccalauréat');

INSERT INTO experience (details) VALUES
                                     ('+5 ans'),
                                     ('+3 ans'),
                                     ('+2 ans');

INSERT INTO sexe (details) VALUES
                               ('Homme'),
                               ('Femme');

INSERT INTO situation_matrimoniale (details) VALUES
                                                 ('Célibataire'),
                                                 ('Marié(e)'),
                                                 ('Divorcé(e)');

-- Remplacez les valeurs des colonnes id_annonce, diplome, experience, sexe, et situation_matrimoniale
INSERT INTO qualification (id_annonce, dimplome, experience, sexe, situation_matrimoniale) VALUES
    (1, '1=4;2=3;3=1;4=0', '1=3;2=1;3=1', '1=2;2=1', '1=1;2=1;3=2'),
(2, '1=1;2=1;3=2;4=4', '1=1,2=1,3=3', '1=2;2=1', '1=1;2=2;3=1'),
(3, '1=1;2=3;3=1;4=3', '1=2,2=2,3=2', '1=2;2=1', '1=1;2=2;3=2');

INSERT INTO question (question, id_annonce) VALUES
                                    ('Avez-vous de l''expérience en gestion des ressources humaines?', 1),
                                    ('Quel est votre diplôme le plus élevé?', 1),
                                    ('Combien d''années d''expérience avez-vous en comptabilité?', 1);

-- Remplacez les valeurs des colonnes id_question et verite
INSERT INTO reponse (id_question, reponse, verite) VALUES
                                                       (1, 'Oui', 1),
                                                       (1, 'Non', 0),
                                                       (2, 'Licence en Gestion des Ressources Humaines', 1),
                                                       (2, 'Baccalauréat en Informatique', 0),
                                                       (3, '3 ans', 1),
                                                       (3, '1 an', 0);

-- Remplacez les valeurs des colonnes id_annonce, nom, prenom, date_de_naissance et contact
INSERT INTO candidature (id_annonce, nom, prenom, date_de_naissane, contact) VALUES
                                                                                 (1, 'Doe', 'John', '1990-05-15', 'john.doe@example.com'),
                                                                                 (2, 'Smith', 'Alice', '1985-12-10', 'alice.smith@example.com'),
                                                                                 (3, 'Brown', 'David', '1995-08-25', 'david.brown@example.com');

-- Remplacez les valeurs des colonnes id_candidature, id_diplome, id_sexe et id_situation_matrimoniale
INSERT INTO candidat_cv (id_candidature, id_diplome, id_sexe, id_situation_matrimoniale) VALUES
                                                                                             (1, 1, 1, 1),
                                                                                             (2, 2, 2, 2),
                                                                                             (3, 3, 1, 1);

-- Remplacez les valeurs des colonnes id_candidature et note
INSERT INTO note (id_candidature, note) VALUES
                                            (1, 4.5),
                                            (2, 3.8),
                                            (3, 4.2);

insert  into coefficient (valeur, text )
    values (5,"Recommendé"), (3,"Acceptable"), (1, "Passable");
