package com.example.RH.repository;

import org.springframework.data.repository.CrudRepository;
import com.example.RH.entity.Employee;

public interface EmployeeRepository extends CrudRepository<Employee, String> {
    
}