package cinema.persistence.repository;

import java.util.Set;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import cinema.persistence.entity.Person;

public interface PersonRepository extends JpaRepository<Person, Integer>{
	Set<Person> findByName(String name);
	Set<Person> findByNameContainingIgnoreCase(String name);
	Set<Person> findByNameEndingWith(String name);
	
	// TODO: request is bad
	@Query("select p from Person p where extract(month from p.birthdate) = ?1")
	Set<Person> findByBirthdateYear(int year);
}
