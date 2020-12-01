package cinema.controller.whole.test;

import static org.junit.jupiter.api.Assertions.*;

import javax.persistence.EntityManager;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.jdbc.AutoConfigureTestDatabase;
import org.springframework.boot.test.autoconfigure.jdbc.AutoConfigureTestDatabase.Replace;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.transaction.annotation.Transactional;

import cinema.controller.MovieController;
import cinema.persistence.entity.Movie;

@SpringBootTest
@AutoConfigureTestDatabase(replace = Replace.ANY)
@Transactional
class TestMovieController {
	
	@Autowired
	EntityManager entityManager;
	
	@Autowired
	MovieController movieController;

	@Test
	void testMovieByIdPresent() { 
		// given
		var movie = new Movie("Joker", 2019, null);
		entityManager.persist(movie);
		var id = movie.getIdMovie();
		System.out.println(movie);
		// when
		var optMovie = movieController.movieById(id);
		System.out.println(optMovie);
		assertTrue(optMovie.isPresent(), "movie is present");
		assertEquals(id, optMovie.get().getIdMovie(), "movie read with wright id");
	}
	
	@Test
	void testMovieByIdNotPresent() { 
		// given (base de données vide)
		var id = 1;
		// when
		var optMovie = movieController.movieById(id);
		System.out.println(optMovie);
		assertTrue(optMovie.isEmpty(), "movie is not present");
	}

}
