package cinema.controller.test;

import static org.junit.Assert.assertSame;
import static org.junit.Assert.assertTrue;
import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.ArgumentMatchers.eq;
import static org.mockito.BDDMockito.given;
import static org.mockito.BDDMockito.then;

import java.util.Optional;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;
import org.springframework.test.web.servlet.result.MockMvcResultMatchers;

import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;

import cinema.controller.MovieController;
import cinema.dto.test.DtoBuilder;
import cinema.persistence.entity.Movie;
import cinema.service.IMovieService;
import cinema.service.impl.MovieService;

@WebMvcTest(controllers = MovieController.class)
class TestMovieControllerMockMvc {

	@Autowired
	private MockMvc mockMvc;

	@MockBean
	private IMovieService movieService;
	
	@Test
	void testMovieByIdPresent() throws Exception  {
		// given
		var id = 1;
		var title = "Joker";
		var year = 2019;
		var movie = DtoBuilder.newMovieFull(id,title, year);
		given(movieService.getMovieById(id))
			.willReturn(Optional.of(movie));
		// when
		mockMvc.perform(MockMvcRequestBuilders
			      .get("/api/movie/"+id)
			      .accept(MediaType.APPLICATION_JSON))
			      .andDo(print())
			      .andExpect(status().isOk())
			      .andExpect(MockMvcResultMatchers.jsonPath("$.title").exists())
			      .andExpect(MockMvcResultMatchers.jsonPath("$.idMovie").value(id));
	}
}
		