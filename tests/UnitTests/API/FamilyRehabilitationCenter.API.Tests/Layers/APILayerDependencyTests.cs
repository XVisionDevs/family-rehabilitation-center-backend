using FamilyRehabilitationCenter.Tests.Common.Layers;

namespace FamilyRehabilitationCenter.API.Tests.Layers
{
    public class APILayerDependencyTests : ArchitectureTestsBase
    {
        [Theory]
        [InlineData(ApplicationAssemblyName)]
        [InlineData(PersistenceAssemblyName)]
        [InlineData(InfrastructureAssemblyName)]
        [InlineData(DomainAssemblyName)]
        public void API_ShouldDependOn(string AssemblyName)
        {
            AssertHasDependency(APIAssemblyName, AssemblyName);
        }
    }
}