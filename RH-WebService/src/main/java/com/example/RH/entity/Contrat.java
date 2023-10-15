package com.example.RH.entity;

import jakarta.persistence.Entity;
import jakarta.persistence.Table;
import jakarta.persistence.Column;
import jakarta.persistence.Id;
import jakarta.persistence.Temporal;
import jakarta.persistence.TemporalType;
import java.util.Date;

@Entity
@Table(name="v_details_contrat")
public class Contrat {
    @Id
    @Column(name="id_details_contrat")
    int iDetailsContrat;
    @Column(name="date_debut")
    @Temporal(TemporalType.TIMESTAMP)
    Date dateDebut;
    @Column(name="date_fin")
    @Temporal(TemporalType.TIMESTAMP)
    Date dateFin;
    @Column(name="nom")
    String nom;

    public int getiDetailsContrat() {
        return iDetailsContrat;
    }
    public void setiDetailsContrat(int iDetailsContrat) {
        this.iDetailsContrat = iDetailsContrat;
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
    public String getNom() {
        return nom;
    }
    public void setNom(String nom) {
        this.nom = nom;
    }
    
    public Contrat() {
    }
}
