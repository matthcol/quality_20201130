using System;
using System.Globalization;
using Xunit;

namespace XUnitTestProject1
{
    /**
     * dummy test for illustrating purpose on tests dealings with string data
     */
    #nullable enable
    public class StringTests
    {
        
        [Fact]
        public void EmptyStringTest() {
            String? nullString = null;
            String emptyString = "";
            Assert.Null(nullString);
            Assert.Empty(emptyString);
            Assert.True(string.IsNullOrEmpty(nullString));
            Assert.True(string.IsNullOrEmpty(emptyString));
        }

        [Fact]
        public void UnicodeStringTest() {
            string city1 = "東京";
            char char1 = '東';
            char char2 = '京';
            Assert.Equal(char1, city1[0]);
            Assert.Equal(char2, city1[1]);
            // char parrotChar = '🦜'; // parrot 2019 unicode character accepted as comment not as char !
        }

        [Fact]
        public void IgnoreCaseStringTest() {
            var city = "Toulouse";
            Assert.Equal("TOULOUSE", city, true);
            Assert.Equal("toulouse", city, true);
            Assert.Equal("tOuLoUsE", city, true);
            // var germanWord = "Straße";
            // Assert.Equal("STRAẞE", germanWord, true); // NOK
            // Assert.True("STRASSE", germanWord, true); // NOK
            // Assert.Equal("STRAẞE", "STRASSE"); // NOK
            // var ci = new CultureInfo("de-DE", false);
            // var compareOptions = CompareOptions.IgnoreCase;
            // Assert.True(string.Compare("STRAẞE", germanWord, ci, compareOptions)<0);
            // CultureInfo.CurrentCulture = ci; // wrong idea for other tests !
            // Assert.True(string.Equals("STRAẞE", "STRASSE"));
        }

        [Fact]
        public void WhiteSpaceStringTest() {
            Assert.Equal("Toulouse la   ville rose", "Toulouse\tla\tville rose", false, false, true);
        }

        [Fact]
        public void AlphabeticOrderTest() {
            Assert.True(string.Compare("été","étuve")<0);
            Assert.False(string.CompareOrdinal("été", "étuve") < 0);
        }


    }
}
