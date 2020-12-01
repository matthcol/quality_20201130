package cinema.controller.test;

import org.junit.jupiter.api.BeforeEach;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.junit.jupiter.MockitoExtension;

import cinema.controller.MovieController;
import cinema.dto.MovieFull;
import cinema.dto.test.DtoBuilder;
import cinema.persistence.entity.Movie;
import cinema.service.IMovieService;
import cinema.service.impl.MovieService;

import static org.junit.Assert.*;
import static org.mockito.BDDMockito.* ;

import java.util.Optional;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;

// Mockito documentation
// https://javadoc.io/static/org.mockito/mockito-core/3.6.0/org/mockito/Mockito.html
// https://www.codeflow.site/fr/article/bdd-mockito
// https://reflectoring.io/spring-boot-mock/

@ExtendWith(MockitoExtension.class)
public class TestMovieControllerMockito {
	// layer to mock
	@Mock
	private IMovieService movieService;
	
	// layer to test using layer mocked
	@InjectMocks
	private MovieController movieController; 
	
	// BDD Style : Behavior Driven Development
	@Test
	void testMovieByIdPresent() {
		// given
		var id = 1;
		var title = "Joker";
		var year = 2019;
		var movie = DtoBuilder.newMovieFull(id,title, year);
		// prepare perfect answer from mocked service
		given(movieService.getMovieById(id))
			.willReturn(Optional.of(movie));
		// when
		var res = movieController.movieById(id);
		// then
		// check : methode sous-jacente a bien été appelée
		then(movieService)
				.should()
				.getMovieById(eq(id));
		// check : assertions sur le retour de la méthode testée
		// 1. la reponse contient un movie
		assertTrue(res.isPresent());
		// 2. le movie est bien celui prevue comme reponse parfaite
		//     de la couce sous-jacente
		assertSame(movie, res.get());
	}
	
	void testMovieByIdNotPresent() {
		// given
		var id = 2;
		given(movieService.getMovieById(id))
			.willReturn(Optional.empty());
		// when
		var res = movieController.movieById(id);
		// then
		then(movieService)
			.should()
			.getMovieById(eq(id));
		assertTrue(res.isEmpty());
	}

}
