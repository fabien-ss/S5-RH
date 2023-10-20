package com.example.RH.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
// import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
// import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.ResponseBody;
import com.example.RH.entity.Contrat;
import com.example.RH.repository.ContratRepository;

@Controller
@RequestMapping(path="/contrat") 
public class ContratController {
    @Autowired
    private ContratRepository con;

    @GetMapping(path="/getall")
    public @ResponseBody Iterable<Contrat> getAllEmployee() {
      return con.findAll();
    }

    @GetMapping(path="/getById/{id}")
    public @ResponseBody Contrat getByMatricule(@PathVariable String id) {
        return con.findById(id).get();
    }
    
}
