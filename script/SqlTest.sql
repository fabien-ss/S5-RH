select c.nom, c.prenom, c.date_de_naissane date_de_naissance, c.contact, p.details, p.id_poste, dc.date_debut, dc.date_fin, dc.matricule, tc.nom libelle_contrat, e.id_employe,
       s.salaire renumeration, ts.nom typesalaire, ser.nom service, dc, dc.is_valide valide, cc.id_sexe sexe, sx.details genre,   EXTRACT(YEAR FROM age(now(), c.date_de_naissane)) capacite_exercice, extract(year from age(now(), dc.date_debut )) anciennete, c.id_candidature
from employe e
         join candidature c on e.id_candidature = c.id_candidature
         join candidat_cv cc on cc.id_candidature = c.id_candidature
         join poste p on p.id_poste = cc.id_poste
         join details_contrat dc on e.id_employe = dc.id_employe
         join type_contrat tc on dc.id_type_contrat = tc.id_type_contrat
         join salaire s on s.id_contrat = dc.id_details_contrat
         join type_salaire ts on ts.id_type_salaire = s.id_type_salaire
         join service ser on p.id_service = ser.id_service
         join sexe sx on sx.id_sexe = cc.id_sexe
where dc.is_valide = 10