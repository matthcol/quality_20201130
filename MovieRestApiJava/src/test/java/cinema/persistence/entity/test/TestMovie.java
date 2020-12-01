package cinema.persistence.entity.test;

import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.ValueSource;

import cinema.persistence.entity.Movie;

/**
 * valider la classe entité Movie en mémoire seule (hors BDD)
 *
 */
class TestMovie {

	@BeforeEach
	void initSomethingBeforeEachTest() {}
	
	// once only
	@BeforeAll
	static void initSomethingBeforeAllTest() {}
	
	
	@Test
	void testConstructorDefault() {
		// given
		// when
		var m = new Movie();
		// then
		assertAll(
				() -> assertNull(m.getIdMovie()),
				() -> assertNull(m.getTitle()),
				() -> assertNull(m.getYear()),
				() -> assertNull(m.getDuration()),
				() -> assertNull(m.getDirector()));
	}
	
	
	// tester le domaine des valeurs correcte pour les titres
	// 1 lettre : Z
	// le + long : "Night of the Day of the Dawn of the Son of the Bride of the Return of the Revenge of the Terror of the Attack of the Evil Mutant Hellbound Flesh Eating Crawling Alien Zombified Subhumanoid Living Dead, Part 5"	
	@ParameterizedTest
	@ValueSource(strings={
			"Z", 
			"Joker", 
			"Night of the Day of the Dawn of the Son of the Bride of the Return of the Revenge of the Terror of the Attack of the Evil Mutant Hellbound Flesh Eating Crawling Alien Zombified Subhumanoid Living Dead, Part 5"})
	void testConstructorTitleYear(String title) {
		// given (include params)
		var year = 2019;
		// when
		var m = new Movie(title, year);
		// then
		// id non généré + 2 informations enregistrees et 2 laissées vide par défaut
		assertAll(
				() -> assertNull(m.getIdMovie()),
				() -> assertEquals(title, m.getTitle()),
				() -> assertEquals(year, m.getYear()),
				() -> assertNull(m.getDuration()),
				() -> assertNull(m.getDirector()));	
	}
	
	
//	@Test
//	void testConstructorWrongDataType() {
//		// given
//		var title = 1984;
//		var year = "1956";
//		// when
//		var m = new Movie(title, year);
//	}

}
