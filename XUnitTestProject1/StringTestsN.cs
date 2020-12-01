using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace XUnitTestProject1
{
    
    public class StringTestsN
    {
        [Test, SetCulture("de-DE")]
        public void TestCultureInfoGerman()
        {
            // 2017 approved in Germany and accepted by ISO ! 
            Assert.IsTrue(string.Equals("STRAẞE", "STRASSE")); // doesn't work
        }

        [Test, SetCulture("es-ES")]
        public void TestCultureInfoSpain()
        {
            Assert.IsTrue(string.Compare("mano", "mañana")<0);
        }

        [Test, SetCulture("fr-FR")]
        public void TestCultureInfoSpanishWithFrenchCulture()
        {
            Assert.IsTrue(string.Compare("mano", "mañana") > 0);
        }

    }
}
