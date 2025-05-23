using FamilyRehabilitationCenter.Tests.Common.Layers;

namespace FamilyRehabilitationCenter.Domain.Tests.Layers
{
    public class DomainLayerDependencyTests : ArchitectureTestsBase
    {
        [Theory]
        [InlineData(APIAssemblyName)]
        [InlineData(InfrastructureAssemblyName)]
        [InlineData(PersistenceAssemblyName)]
        [InlineData(ApplicationAssemblyName)]
        public void Domain_ShouldNotDependOn(string AssemblyName)
        {
            AssertNoDependency(DomainAssemblyName, AssemblyName);
        }

    }
}