package com.example.RH.entity;

import jakarta.persistence.Entity;
import jakarta.persistence.Table;
import jakarta.persistence.Column;
import jakarta.persistence.Id;
import jakarta.persistence.Temporal;
import jakarta.persistence.TemporalType;

import java.util.Date;
import java.time.LocalDateTime;
import java.time.ZoneId;

@Entity
@Table(name="conge")
public class Conge {
    @Id 
    @Column(name = "matricule")
    String matricule;   
    @Column(name = "date_debut")
    Date dateDebut;
    @Column(name = "date_declaration")
    @Temporal(TemporalType.TIMESTAMP)
    Date dateDeclaration;
    @Column(name="date_fin")
    @Temporal(TemporalType.TIMESTAMP)
    Date dateFin;
    @Column(name="date_retour")
    @Temporal(TemporalType.TIMESTAMP)
    Date dateRetour;
    @Column(name="details")
    String details;

    public String getMatricule() {
        return matricule;
    }
    public void setMatricule(String matricule) {
        this.matricule = matricule;
    }
    public Date getDateDebut() {
        return dateDebut;
    }
    public void setDateDebut(Date dateDebut) {
        this.dateDebut = dateDebut;
    }
    public Date getDateDeclaration() {
        return dateDeclaration;
    }
    public void setDateDeclaration(Date dateDeclaration) {
        this.dateDeclaration = dateDeclaration;
    }
    public Date getDateFin() {
        return dateFin;
    }
    public void setDateFin(Date dateFin) {
        this.dateFin = dateFin;
    }
    public Date getDateRetour() {
        return dateRetour;
    }
    public void setDateRetour(Date dateRetour) {
        this.dateRetour = dateRetour;
    }
    public String getDetails() {
        return details;
    }
    public void setDetails(String details) {
        this.details = details;
    }

    public Conge(){}

    public long getCongeDuration(Date d1, Date d2){
        long difference_In_Time = d2.getTime() - d1.getTime();
        long difference_In_Days= (difference_In_Time / (1000 * 60 * 60 * 24)) % 365;
        return difference_In_Days;
    }

    public boolean checkIfMoreThanOneYear(){
        long diff = getCongeDuration(this.getDateDebut(), Date.from(LocalDateTime.now().atZone(ZoneId.systemDefault()).toInstant()  ));
        if(diff > 365)
            return true;
        return false;
    }

    public boolean checkIfCongeOk(String datedebut, String idtypeconge, String duree, Employee emp){
        boolean res = false;
        
        return res;
    }
}
