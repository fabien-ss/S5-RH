    INSERT INTO service (nom) VALUES
    ('Service RH'),
    ('Service Finances'),
    ('Service Informatique');
    
    --INSERT INTO poste (id_service, details) VALUES
    --(1, 'Responsable des Ressources Humaines'),
    --(1, 'Gestionnaire de Paie'),
    --(2, 'Comptable'),
    --(3, 'Développeur Web');
    
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
    INSERT INTO qualification (id_annonce, diplome, experience, sexe, situation_matrimoniale) VALUES
    (1, '1=4;2=3;3=1;4=0', '1=3;2=1;3=1', '1=2;2=1', '1=1;2=1;3=2'),
    (2, '1=1;2=1;3=2;4=4', '1=1;2=1;3=3', '1=2;2=1', '1=1;2=2;3=1'),
    (3, '1=1;2=3;3=1;4=3', '1=2;2=2;3=2', '1=2;2=1', '1=1;2=2;3=2');
    
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
    INSERT INTO candidature (id_annonce, nom, prenom, date_de_naissane, contact,etat) VALUES
    (1, 'Doe', 'John', '1990-05-15', 'john.doe@example.com', 30),
    (2, 'Smith', 'Alice', '1985-12-10', 'alice.smith@example.com', 30),
    (3, 'Brown', 'David', '1995-08-25', 'david.brown@example.com', 30);


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

 --   INSERT INTO annonce (id_service, debut, fin, details) VALUES
 --                                                             (1, '2023-10-01', '2023-10-15', 'Poste de Responsable RH ouvert'),
--                                                              (2, '2023-09-15', '2023-10-30', 'Recherche Comptable expérimenté'),
--                                                              (3, '2023-10-10', '2023-10-25', 'Développeur Web Full Stack recherché');
--
INSERT INTO situation_matrimoniale (details) VALUES
    ('Célibataire'),
    ('Marié(e)'),
    ('Divorcé(e)');

insert  into coefficient (valeur, text ) values (5,'Recommendé'), (3,'Acceptable'), (1, 'Passable');

insert into jour(jour) values ('Lundi'),('Mardi'),('Mercredi'),('Jeudi'),('Vendredi'),('Samedi');

insert into type_avantage(nom) values ('Véhicule'), ('Téléphone'), ('Assistant(e)');

insert into type_contrat(nom) values ('Contrat à Durée Indéterminée'), ('Contrat à Durée Déterminée'),( 'Contrat d Essai');

insert into type_salaire(id_type_salaire,nom) values (1,'Brute'), (2,'Net');


INSERT INTO candidat_cv (id_candidature, id_diplome, id_sexe, id_situation_matrimoniale, id_poste, id_experience) VALUES
(1, 1, 1, 1, 1, 3),
(2, 2, 2, 2, 3, 1),
(3, 3, 1, 1,4, 1);

insert into employe (id_candidature) values 
    (1),
    (2),
    (3);

insert into details_contrat (date_debut, date_fin, id_type_contrat, id_employe,matricule)  values  
    (Now(), now(), 1, 1, "huhu"),
    (Now(), now(), 1,2, "haha"), 
    (Now(), now(), 2,3, "hoho");

insert into salaire (salaire, date_salaire, id_contrat, id_type_salaire)
values (1231, Now(), 1, 1),
       (42431, Now(), 2, 2),
       (4324, Now(), 3, 2);

insert into avantage_employe (id_employe, id_avantage)
values (1, 1), (2, 1), (3, 1);

insert into horaire (id_contrat, entree, sortie, id_jour)
values (1, '12:32', '16:30', 1),
       (1, '12:32', '16:30', 2),
       (1, '12:32', '16:30', 3),
        (1, '12:32', '16:30', 4),
    (2, '12:32', '16:30', 1),
    (2, '12:32', '16:30', 2),
    (2, '12:32', '16:30', 5),
       (3, '12:32', '16:30', 5),
       (3, '12:32', '16:30', 4);    
insert into mission (nom, id_poste)
values ('Conception Objet', 1),
       ('Designer', 2),
       ('Data analyst', 3),
       ('Garder le code propre', 4);

insert into tache(nom, id_mission) values 
       ('Ordinateur', 1),
       ('Netoyé la salle', 1),
       ('Acheter du pain', 2),
       ('Maintenir les systemes propres', 2),
       ('Etre en bonne santé', 3),
       ('Ordinateur maintenance', 4);

insert into entreprise(nom, date_de_creation, siege, numero_fiscal, logo, description) 

values ('MAHAKO', NOW(), 'ANTANANARIVO Ambatondrazaka', 'EAZFGFD9423495043483243204884923423402238444', 'entrepriselogo.png', 'Entreprise livraison');

insert into type_conge(id_type_conge, libelle) values (1, 'Congé mensuel'),
                                                               (2, 'Maternité'),
                                                               (3, 'Partenité'),
                                                               (4, 'Autre');
                        