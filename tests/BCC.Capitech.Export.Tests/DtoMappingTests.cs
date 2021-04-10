using BCC.Capitech.Model;
using Capitech.Client.Catalogue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BCC.Capitech.Export.Tests
{
    [TestClass]
    public class DtoMappingTests
    {
        [TestMethod]
        public void TestMapping()
        {
            var dto = new ProjectDto
            {
                Description = "TEST",
                StartDate = DateTimeOffset.Now
            };

            var project = new Project().MapFromDto(dto);

            Assert.IsTrue(project.StartDate != DateTime.MinValue);
            Assert.AreEqual(project.Description, dto.Description);
        }
    }
}
