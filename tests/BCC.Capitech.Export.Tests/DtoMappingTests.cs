using BCC.Capitech.Model;
using BCC.Capitech.Services;
using Capitech;
using Capitech.Client.Catalogue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

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


        [TestMethod]
        public async Task TestCapitech()
        {
            var clnt = new CapitechClient(new CapitechOptions
            {
                ApiBaseUri = "https://flow.capitech.no/bcc/api/",
                ApiPassword = "Sommer2022!",
                ApiUsername = "api_user"
            });

            var x = await clnt.Time.GetTimeTransactionsAsync(100, f => {
                f.FromDate = DateTime.Today.AddDays(-30).ToString("yyyy-MM-dd");
                f.ToDate = DateTime.Today.ToString("yyyy-MM-dd");
               });
        }
    }
}
