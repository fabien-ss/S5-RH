package com.example.RH.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
// import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
// import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.example.RH.entity.Employee;
import com.example.RH.repository.EmployeeRepository;

@RestController
@RequestMapping("/employee") 
public class EmployeeController {
    @Autowired
    private EmployeeRepository emp;
    
    @GetMapping("/")
    public @ResponseBody Iterable<Employee> getAllEmployee() {
      return emp.findAll();
    }

    @GetMapping("/{matricule}")
    public @ResponseBody Employee getByMatricule(@PathVariable String matricule) {
      System.out.println(matricule);
      return emp.findById(matricule).get();
    }
}
