using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Services.Default.Schools;
using Education.Core.Domain.Validations.DomainValidations.Default.Schools;
using Education.Core.Domain.Validations.EntityValidationsDefault;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.Domain.Services.Tests.Default.Schools
{
    [TestClass]
    public class DeleteSchoolServiceTest
    {
        private DeleteSchoolService GetMockedDeleteSchoolService()
        {
            var mockedDefaultDbContext = MockDefaultHelper.GetMockedDefaultDbContext();

            var mockedSchoolValidator = new SchoolValidator();

            var mockedDeleteSchoolSpecificationsValidator = new DeleteSchoolSpecificationsValidator();

            var mockedDeleteSchoolService = new DeleteSchoolService(
                mockedDefaultDbContext.Object,
                mockedSchoolValidator,
                mockedDeleteSchoolSpecificationsValidator);

            return mockedDeleteSchoolService;
        }

        [TestMethod]
        public async Task TestPostSchoolValidModelAsync()
        {
            var mockedDeleteSchoolService = GetMockedDeleteSchoolService();

            var mockedSchool = new School
            {
                SchoolID = 1,
                Name = "School - 001",
            };

            await mockedDeleteSchoolService.Run(mockedSchool);
        }
    }
}
