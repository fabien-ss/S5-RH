package com.example.RH.repository;

import org.springframework.data.repository.CrudRepository;
import com.example.RH.entity.Conge;
import java.util.List;

public interface CongeRepository extends CrudRepository<Conge, String>{

    List<Conge> findAllByMatricule(String matricule);
}
