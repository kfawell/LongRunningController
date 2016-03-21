using Domain;

namespace DomainTest
{
   public class PlanTestBase
   {
      protected RandomNumberGenerator _random;
      protected DmeBuilder _dmeBuilder;
      protected IDme _dme;
      protected DesignModelBuilder _designModelBuilder;
      private DesignModel _designModel;
      private int _designModelSize;
      protected PlanBuilder _planBuilder;

      protected void Initialize()
      {
         _random = new RandomNumberGenerator(0);
         _dmeBuilder = new DmeBuilder(_random);
         _designModelBuilder = new DesignModelBuilder(_random);
         _designModelSize = 50;
         _planBuilder = new PlanBuilder(_random);
      }

      protected Plan CreatePlan(int featureCount)
      {
         if (_dme == null)
            CreateDme(1);
         if (_designModel == null)
            CreateDesignModel(featureCount);
         return _planBuilder.BuildPlan(_designModel, featureCount);
      }

      private DesignModel CreateDesignModel(int featureCount)
      {
         _designModel = _designModelBuilder.BuilDesignModel(_designModelSize, featureCount);
         return _designModel;
      }

      protected IDme CreateDme(int toolCount)
      {
         _dme = _dmeBuilder.BuildDme("TestDME", 100, toolCount);
         return _dme;
      }
   }
}