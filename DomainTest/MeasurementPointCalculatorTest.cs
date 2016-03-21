using System;
using System.Collections.Immutable;
using System.Linq;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DomainTest
{
   [TestClass]
   public class MeasurementPointCalculatorTest : PlanTestBase
   {
      [TestInitialize]
      public new void Initialize()
      {
         base.Initialize();
      }

      [TestMethod]
      public void TestMethod()
      {
         MeasurementPointCalculator sut = CreateSut();
         var dme = CreateDme(1);
         var plan = CreatePlan(1);
         var nodeInputs = CreateNodeInput(plan);
         var result = sut.CalculatePoints(nodeInputs.First());
         AssertResult(result, 1, 1);
      }

      private void AssertResult(MeasurementSetNodeResult result, Dme dme, Plan plan)
      {
         Assert.AreEqual(NodeError.None, result.NodeError, "NodeError");
         Assert.AreEqual(1, result.MeasurementSetNodes.Count, "MeasurementSetCount");
      }

      private IImmutableList<NodeInput> CreateNodeInput(Plan plan)
      {
         return plan.PlanFeatures
            .Select(i => new NodeInput(i.Feature, i.MeasurementSets.First()))
            .ToImmutableArray();
      }

      private MeasurementPointCalculator CreateSut()
      {
         return new MeasurementPointCalculator();
      }
   }
}
