﻿using System.Linq;
using DotNetRuleEngine.Core;
using DotNetRuleEngine.Test.Models;
using DotNetRuleEngine.Test.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetRuleEngine.Test
{
    [TestClass]
    public class TestNestedRule
    {
        [TestMethod]
        public void TestNestedRules()
        {
            var ruleEngineExecutor = new RuleEngineExecutor<Product>(new Product());
            ruleEngineExecutor.AddRules(new ProductNestedRule());
            var ruleResults = ruleEngineExecutor.Execute();
            var nestedRuleResult = ruleResults.FindNestedRuleResult<ProductNestedRuleC>();

            Assert.IsNotNull(nestedRuleResult);
            Assert.AreEqual("ProductNestedRuleC", nestedRuleResult.Name);
        }
    }
}