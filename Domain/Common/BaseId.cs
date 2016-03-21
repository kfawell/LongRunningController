using System;

namespace Domain
{
   public abstract class BaseId
   {
      private readonly Guid _guid;

      protected BaseId()
      {
         _guid = Guid.NewGuid();
      }

      protected bool Equals(BaseId other)
      {
         return _guid.Equals(other._guid);
      }

      public override bool Equals(object obj)
      {
         if (ReferenceEquals(null, obj)) return false;
         if (ReferenceEquals(this, obj)) return true;
         if (obj.GetType() != this.GetType()) return false;
         return Equals((PlanFeatureId) obj);
      }

      public override int GetHashCode()
      {
         return _guid.GetHashCode();
      }
   }
}