package cinema.persistence.entity.test;

import static org.junit.jupiter.api.Assertions.*;

import java.time.LocalDate;
import java.util.Collections;
import java.util.List;

import javax.persistence.EntityManager;

import org.junit.jupiter.api.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.jdbc.AutoConfigureTestDatabase;
import org.springframework.boot.test.autoconfigure.jdbc.AutoConfigureTestDatabase.Replace;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.boot.test.autoconfigure.orm.jpa.TestEntityManager;
import org.springframework.dao.DataIntegrityViolationException;
import org.springframework.test.annotation.Rollback;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.transaction.annotation.Transactional;

import cinema.persistence.entity.Movie;
import cinema.persistence.entity.Person;
import cinema.persistence.repository.MovieRepository;

// JUnit 5 + Spring Test

@DataJpaTest  // Test de Spring
@AutoConfigureTestDatabase(replace = Replace.ANY)  // base de test in Memory H2
class TestMovieRepository {

	@Autowired
	MovieRepository movieRepository;
	
	@Autowired
	EntityManager entityManager;
	
	// tous les tests suivants se font base vide (tables vides)
	
	@Test
	void testSave() {
		// given 
		Movie movie = new Movie("Joker", 2019);
		// when
		movieRepository.save(movie);
		// then 
		var id = movie.getIdMovie();
		assertNotNull(id);
	}
	
	@Test
	void testSaveMovieWithTitleTooLong() {
		// given 
		String title = "01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";
		Movie movie = new Movie(title, 2019);
		// when/then
		assertThrows(
				DataIntegrityViolationException.class, 
				() -> movieRepository.save(movie));
	
	}
	
	
	@Test
	void testSaveWithDirector() {
		// Given
		Person person = new Person("Todd Phillips", LocalDate.of(1970, 12, 20));
		Movie movie = new Movie("Joker", 2019, 165, person);
		entityManager.persist(person); // already in cache
		// when 
		movieRepository.save(movie);
		// then 
		var director = movie.getDirector();
		assertSame(person, director);
		var idMovie = movie.getIdMovie();
		assertNotNull(idMovie, "Movie saved");
		// check association in database
		var idPerson = person.getIdPerson();
		entityManager.clear();
		var movieRead = entityManager.find(Movie.class, idMovie);
		assertAll(
				() -> assertEquals(idMovie, movieRead.getIdMovie(), "Movie read 2nd time ok"),
				() -> assertNotNull(movieRead.getDirector(), "Movie read 2nd time has a director"));
		assertEquals(idPerson, movieRead.getDirector().getIdPerson(), "Director has right id");
	}
	
	@Test
	void testSelectAll() {
		// given 
		List<Movie> data = List.of(
				new Movie("Joker", 2019),
				new Movie("Parasite", 2019, 132),				
				new Movie("Interstellar", 2014),				
				new Movie("Gran Torino", 2008, 116)
				);
		data.forEach(entityManager::persist);
		// when
		var dataRead = movieRepository.findAll();
		// then
		assertAll(
				()->assertEquals(data.size(), dataRead.size()),
				()->assertTrue(dataRead.stream()
					.map(Movie::getTitle)
					.allMatch(tr -> data.stream()
								.map(Movie::getTitle)
								.anyMatch(th -> th.equals(tr))
						)));
	}
	
	@Test
	void testFindById() {
		// TODO
		fail();
	}
	
	@Test
	void testFindByTitle() {
		// TODO
		fail();
	}
	
	@Test
	void testFindByYearBetween() {
		// TODO
		fail();
	}
	
	@Test
	void testFindByTitleAndYear() {
		fail();
		// TODO
	}	
	
	@Test
	void testFindByActorsNameEndingWith() {
		// TODO
		fail();
	}
}
