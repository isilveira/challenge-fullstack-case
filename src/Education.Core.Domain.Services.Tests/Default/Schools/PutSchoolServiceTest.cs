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
    public class PutSchoolServiceTest
    {
        private PutSchoolService GetMockedPutSchoolService()
        {
            var mockedDefaultDbContext = MockDefaultHelper.GetMockedDefaultDbContext();
            var mockedDefaultDbContextQuery = MockDefaultHelper.GetMockedDefaultDbContextQuery();

            var mockedSchoolValidator = new SchoolValidator();

            var mockedSchoolNameAlreadyExistsSpecification = new SchoolNameAlreadyExistsSpecification(
                mockedDefaultDbContextQuery.Object);

            var mockedPutSchoolSpecificationsValidator = new PutSchoolSpecificationsValidator(
                mockedSchoolNameAlreadyExistsSpecification);

            var mockedPutSchoolService = new PutSchoolService(
                mockedDefaultDbContext.Object,
                mockedSchoolValidator,
                mockedPutSchoolSpecificationsValidator);

            return mockedPutSchoolService;
        }

        [TestMethod]
        public async Task TestPutSchoolWithEmptyModelAsync()
        {
            var mockedPutSchoolService = GetMockedPutSchoolService();

            var mockedSchool = new School { };

            await Assert.ThrowsExceptionAsync<BusinessException>(() =>
                mockedPutSchoolService.Run(mockedSchool));
        }

        [TestMethod]
        public async Task TestPutSchoolWithDuplicatedNameOnSchoolAsync()
        {
            var mockedPutSchoolService = GetMockedPutSchoolService();

            var mockedSchool = new School
            {
                SchoolID = 1,
                Name = "School - 002",
            };

            await Assert.ThrowsExceptionAsync<BusinessException>(() =>
                mockedPutSchoolService.Run(mockedSchool));
        }

        [TestMethod]
        public async Task TestPutSchoolValidModelAsync()
        {
            var mockedPutSchoolService = GetMockedPutSchoolService();

            var mockedSchool = new School
            {
                SchoolID = 1,
                Name = "School - 003",
            };

            await mockedPutSchoolService.Run(mockedSchool);
        }
    }
}
