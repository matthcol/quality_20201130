package cinema.dto.test;

import cinema.dto.MovieFull;

public class DtoBuilder {
	public static MovieFull newMovieFull(String title, int year) {
		var movie = new MovieFull();
		movie.setTitle(title);
		movie.setYear(year);
		return movie;
	}
	
	public static MovieFull newMovieFull(Integer idMovie, String title, int year) {
		var movie = newMovieFull(title, year);
		movie.setIdMovie(idMovie);
		return movie;
	}

}
