using System;
using System.Collections.Immutable;
using System.Linq;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DomainTest
{
   [TestClass]
   public class MeasurementSetNodeResultGeneratorTest
   {
      private NodeInputFactory _nodeInputFactory;
      private Mock<IToolCoverageCalculator> _toolCoverageCalculatorMock;
      private DmeBuilder _dmeBuilder;
      private DesignModelBuilder _designModelBuilder;
      private PlanBuilder _planBuilder;
      private RandomNumberGenerator _random;

      [TestInitialize]
      public void Initialize()
      {
         _random = new RandomNumberGenerator(0);
         _dmeBuilder = new DmeBuilder(_random);
         _designModelBuilder = new DesignModelBuilder(_random);
         _planBuilder = new PlanBuilder(_random);
         _toolCoverageCalculatorMock = new Mock<IToolCoverageCalculator>();
      }

      [TestMethod]
      public void TestMethod1()
      {
         MeasurementSetNodeResultGenerator sut = CreateSut();
         var dme = CreateDme(1);
         var plan = CreatePlan(1);
         var nodeInputs = CreateNodeInputs(plan);
         var result = sut.CalculateMeasurementSetNodeResult(dme, nodeInputs.First());
         AssertResult(result, 1, 1);
      }

      private void AssertResult(MeasurementSetNodeResult result, Dme dme, Plan plan)
      {
         Assert.AreEqual(NodeError.None, result.NodeError, "NodeError");
         Assert.AreEqual(1, result.MeasurementSetNodes.Count, "MeasurementSetCount");
      }

      private Plan CreatePlan(int featureCount)
      {
         var part = _designModelBuilder.BuilDesignModel(50, featureCount);
         return _planBuilder.BuildPlan(part);
      }

      private IImmutableList<NodeInput> CreateNodeInputs(Plan plan)
      {
         return plan.PlanFeatures
            .Select(i => new NodeInput(i.Feature, i.MeasurementSets.First()))
            .ToImmutableArray();
      }

      private IDme CreateDme(int toolCount)
      {
         return _dmeBuilder.BuildDme("TestDME", 100, toolCount);
      }

      private MeasurementSetNodeResultGenerator CreateSut()
      {
         return new MeasurementSetNodeResultGenerator(new MeasurementPointCalculator(), _toolCoverageCalculatorMock.Object);
      }
   }
}
