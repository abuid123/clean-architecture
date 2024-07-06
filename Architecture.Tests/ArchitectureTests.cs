using FluentAssertions;
using NetArchTest.Rules;

namespace Architecture.Tests
{
    public class ArchitectureTests
    {
        private const string DomainNamespace = "Domain";
        private const string ApplicattionNamespace = "Application";

        [Fact]
        public void Domain_Should_Not_HaveAnyDependecyOnOtherProjects()
        {
            //Arrange
            var assembly = typeof(CleanArchitecture.Domain.AssemblyReference).Assembly;

            var otherProjects = new[]
            {
                ApplicattionNamespace,
                //typeof(CleanArchitecture.Infrastructure.AssemblyReference).Assembly,
                //typeof(CleanArchitecture.Persistence.AssemblyReference).Assembly,
            };

            //Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //Assert
            testResult.IsSuccessful.Should().BeTrue();
        }
    }
}