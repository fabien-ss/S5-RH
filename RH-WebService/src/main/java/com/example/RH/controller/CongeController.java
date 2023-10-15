package com.example.RH.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
// import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
// import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.ResponseBody;
import com.example.RH.entity.Conge;
import com.example.RH.repository.CongeRepository;

import java.sql.Date;
import java.util.List;

@Controller
@RequestMapping(path="/conge") 
public class CongeController {
    @Autowired
    private CongeRepository con;

    @GetMapping(path="/getall")
    public @ResponseBody Iterable<Conge> getAllEmployee() {
      return con.findAll();
    }

    @GetMapping(path="/getByMatricule/{matricule}")
    public @ResponseBody List<Conge> getByMatricule(@PathVariable String matricule) {
        return con.findAllByMatricule(matricule);
    }

    @GetMapping(path="/getDuree/{date1}/{date2}")
    public @ResponseBody long getDuree(@PathVariable String date1, @PathVariable String date2) {
        return new Conge().getCongeDuration(Date.valueOf(date1),Date.valueOf(date2));
    }
    
}
