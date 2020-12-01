package cinema.controller.test;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.ArgumentMatchers.eq;
import static org.mockito.BDDMockito.given;
import static org.mockito.BDDMockito.then;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

import java.util.Optional;

import javax.persistence.EntityManager;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.jdbc.AutoConfigureTestDatabase;
import org.springframework.boot.test.autoconfigure.jdbc.AutoConfigureTestDatabase.Replace;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.mock.mockito.SpyBean;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;
import org.springframework.test.web.servlet.result.MockMvcResultMatchers;

import cinema.dto.test.DtoBuilder;
import cinema.persistence.entity.Movie;
import cinema.service.IMovieService;

@SpringBootTest
@AutoConfigureMockMvc
@AutoConfigureTestDatabase(replace = Replace.ANY)
class TestMovieControllerMockSpy {

	@Autowired
	private MockMvc mockMvc;

	@SpyBean
	private IMovieService movieService;
	
	@Autowired
	EntityManager entityManager;
	
	@Test
	void testMovieByIdPresent() throws Exception  {
		// given
		var movie0 = DtoBuilder.newMovieFull("Joker", 2019);
		var movieSaved = movieService.addMovie(movie0);
		var id = movieSaved.getIdMovie();
		// when
		mockMvc.perform(MockMvcRequestBuilders
			      .get("/api/movie/"+id)
			      .accept(MediaType.APPLICATION_JSON))
			      .andDo(print())
			      .andExpect(status().isOk())
			      .andExpect(MockMvcResultMatchers.jsonPath("$.title").exists())
			      .andExpect(MockMvcResultMatchers.jsonPath("$.idMovie").value(id));
		// spy : regarde si la méthode est appelée sur le service réel
		//       encapsulé par un espion
		then(movieService)
			.should()
			.getMovieById(eq(id));
	}


}
