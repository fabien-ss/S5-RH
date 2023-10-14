package com.example.RH.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.ResponseBody;
import com.example.RH.entity.Employee;
import com.example.RH.repository.EmployeeRepository;

@Controller
@RequestMapping(path="/employee") 

public class EmployeeController {
    @Autowired
    private EmployeeRepository emp;
    
    // @PostMapping(path="/add") // Map ONLY POST Requests
    // public @ResponseBody String addNewTest (@RequestBody String content) {
    //   // @ResponseBody means the returned String is the response, not a view name
    //   // @RequestParam means it is a parameter from the GET or POST request
    //   Employee n = new Employee();
    //   // System.out.println(n);
    //   testRepository.save(n);

    //   return "Saved"; 
    // }
    
    @GetMapping(path="/getall")
    public @ResponseBody Iterable<Employee> getAllEmployee() {
      // This returns a JSON or XML with the employees
      return emp.findAll();
    }

    @GetMapping(path="/getByMatricule/{matricule}")
    public @ResponseBody Employee getByMatricule(@PathVariable String matricule) {
        Employee result =  emp.findById(matricule).get();
        return result;
    }
}
