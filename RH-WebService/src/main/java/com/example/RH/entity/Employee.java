package com.example.RH.entity;

import jakarta.persistence.Entity;
import jakarta.persistence.Table;
import jakarta.persistence.Column;
import jakarta.persistence.Id;
import jakarta.persistence.Temporal;
import jakarta.persistence.TemporalType;
import java.util.Date;

@Entity
@Table( name = "v_details_employe" )
public class Employee {
    @Column(name = "nom")
    String nom;
    @Column(name = "prenom")
    String prenom;
    @Column(name = "date_de_naissance")
    @Temporal(TemporalType.TIMESTAMP)
    Date dateNaissance;
    @Column(name = "contact")
    String contact;
    @Column(name = "details")
    String details;
    @Column(name = "id_poste")
    Integer idPoste;
    @Column(name = "date_debut")
    @Temporal(TemporalType.TIMESTAMP)
    Date dateDebut;
    @Column(name = "date_fin")
    @Temporal(TemporalType.TIMESTAMP)
    Date dateFin;
    @Id
    @Column(name = "matricule")
    String matricule;
    @Column(name = "id_employe")
    Integer idEmploye;
    @Column(name = "renumeration")
    Double renumeration;
    @Column(name = "typesalaire")
    String typeSalaire;
    @Column(name = "service")
    String service;

    public String getNom() {
        return nom;
    }
    public void setNom(String nom) {
        this.nom = nom;
    }
    public String getPrenom() {
        return prenom;
    }
    public void setPrenom(String prenom) {
        this.prenom = prenom;
    }
    public Date getDateNaissance() {
        return dateNaissance;
    }
    public void setDateNaissance(Date dateNaissance) {
        this.dateNaissance = dateNaissance;
    }
    public String getContact() {
        return contact;
    }
    public void setContact(String contact) {
        this.contact = contact;
    }
    public String getDetails() {
        return details;
    }
    public void setDetails(String details) {
        this.details = details;
    }
    public Integer getIdPoste() {
        return idPoste;
    }
    public void setIdPoste(Integer idPoste) {
        this.idPoste = idPoste;
    }
    public Date getDateDebut() {
        return dateDebut;
    }
    public void setDateDebut(Date dateDebut) {
        this.dateDebut = dateDebut;
    }
    public Date getDateFin() {
        return dateFin;
    }
    public void setDateFin(Date dateFin) {
        this.dateFin = dateFin;
    }
    public String getMatricule() {
        return matricule;
    }
    public void setMatricule(String matricule) {
        this.matricule = matricule;
    }
    public Integer getIdEmploye() {
        return idEmploye;
    }
    public void setIdEmploye(Integer idEmploye) {
        this.idEmploye = idEmploye;
    }
    public Double getRenumeration() {
        return renumeration;
    }
    public void setRenumeration(Double renumeration) {
        this.renumeration = renumeration;
    }
    public String getTypeSalaire() {
        return typeSalaire;
    }
    public void setTypeSalaire(String typeSalaire) {
        this.typeSalaire = typeSalaire;
    }
    public String getService() {
        return service;
    }
    public void setService(String service) {
        this.service = service;
    }

    public Employee(){}
}
