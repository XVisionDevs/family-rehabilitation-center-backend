using System.Reflection;

namespace FamilyRehabilitationCenter.Tests.Common.Layers
{
    public abstract class ArchitectureTestsBase
    {
        protected const string APIAssemblyName = "FamilyRehabilitationCenter.API";
        protected const string ApplicationAssemblyName = "FamilyRehabilitationCenter.Application";
        protected const string DomainAssemblyName = "FamilyRehabilitationCenter.Domain";
        protected const string InfrastructureAssemblyName = "FamilyRehabilitationCenter.Infrastructure";
        protected const string PersistenceAssemblyName = "FamilyRehabilitationCenter.Persistence";

        protected static Assembly GetAssembly(string layerName) =>
               layerName switch
               {
                   APIAssemblyName => Assembly.Load(APIAssemblyName),
                   ApplicationAssemblyName => Assembly.Load(ApplicationAssemblyName),
                   DomainAssemblyName => Assembly.Load(DomainAssemblyName),
                   InfrastructureAssemblyName => Assembly.Load(InfrastructureAssemblyName),
                   PersistenceAssemblyName => Assembly.Load(PersistenceAssemblyName),
                   _ => throw new ArgumentException($"Invalid assembly name: {layerName}")
               };

        protected void AssertNoDependency(string sourceLayer, string targetLayer)
        {
            var sourceAsm = GetAssembly(sourceLayer);
            var referenced = sourceAsm.GetReferencedAssemblies().Select(a => a.Name);
            Assert.DoesNotContain(targetLayer, referenced);
        }

        protected void AssertHasDependency(string sourceLayer, string targetLayer)
        {
            var sourceAsm = GetAssembly(sourceLayer);
            var referenced = sourceAsm.GetReferencedAssemblies().Select(a => a.Name);
            Assert.Contains(targetLayer, referenced);
        }
    }
}
