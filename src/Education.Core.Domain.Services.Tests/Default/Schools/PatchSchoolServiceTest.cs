using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Exceptions;
using Education.Core.Domain.Services.Default.Schools;
using Education.Core.Domain.Validations.DomainValidations.Default.Schools;
using Education.Core.Domain.Validations.EntityValidationsDefault;
using Education.Core.Domain.Validations.Specifications.Default.Schools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.Domain.Services.Tests.Default.Schools
{
    [TestClass]
    public class PatchSchoolServiceTest
    {

        private PatchSchoolService GetMockedPatchSchoolService()
        {
            var mockedDefaultDbContext = MockDefaultHelper.GetMockedDefaultDbContext();
            var mockedDefaultDbContextQuery = MockDefaultHelper.GetMockedDefaultDbContextQuery();

            var mockedSchoolValidator = new SchoolValidator();

            var mockedSchoolNameAlreadyExistsSpecification = new SchoolNameAlreadyExistsSpecification(
                mockedDefaultDbContextQuery.Object);

            var mockedPatchSchoolSpecificationsValidator = new PatchSchoolSpecificationsValidator(
                mockedSchoolNameAlreadyExistsSpecification);

            var mockedPatchSchoolService = new PatchSchoolService(
                mockedDefaultDbContext.Object,
                mockedSchoolValidator,
                mockedPatchSchoolSpecificationsValidator);

            return mockedPatchSchoolService;
        }

        [TestMethod]
        public async Task TestPatchSchoolWithEmptyModelAsync()
        {
            var mockedPatchSchoolService = GetMockedPatchSchoolService();

            var mockedSchool = new School { };

            await Assert.ThrowsExceptionAsync<BusinessException>(() =>
                mockedPatchSchoolService.Run(mockedSchool));
        }

        [TestMethod]
        public async Task TestPatchSchoolWithDuplicatedNameOnSchoolAsync()
        {
            var mockedPatchSchoolService = GetMockedPatchSchoolService();

            var mockedSchool = new School
            {
                SchoolID = 1,
                Name = "School - 002",
            };

            await Assert.ThrowsExceptionAsync<BusinessException>(() =>
                mockedPatchSchoolService.Run(mockedSchool));
        }

        [TestMethod]
        public async Task TestPatchSchoolValidModelAsync()
        {
            var mockedPatchSchoolService = GetMockedPatchSchoolService();

            var mockedSchool = new School
            {
                SchoolID = 1,
                Name = "School - 003",
            };

            await mockedPatchSchoolService.Run(mockedSchool);
        }
    }
}
