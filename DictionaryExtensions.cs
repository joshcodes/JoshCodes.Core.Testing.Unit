using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using JoshCodes.Collections.Generic;

namespace JoshCodes.Core.Testing.Unit
{
    [TestClass]
    public class DictionaryExtensions
    {
        [TestMethod]
        public void KeysAsSeparatedString()
        {
            var testDictionary = new Dictionary<string, string>() {
                {"asdf", "qwer"},
                {"foo", "bar"},
                {"food", "barf"}
            };
            var example = testDictionary.KeysAsSeparatedString(",", (s) => s);
            Assert.AreEqual("asdf,foo,food", example);
        }
    }
}
