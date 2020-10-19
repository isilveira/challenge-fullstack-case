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
    public class PostSchoolServiceTest
    {
        private PostSchoolService GetMockedPostSchoolService()
        {
            var mockedDefaultDbContext = MockDefaultHelper.GetMockedDefaultDbContext();
            var mockedDefaultDbContextQuery = MockDefaultHelper.GetMockedDefaultDbContextQuery();

            var mockedSchoolValidator = new SchoolValidator();

            var mockedSchoolNameAlreadyExistsSpecification = new SchoolNameAlreadyExistsSpecification(
                mockedDefaultDbContextQuery.Object);

            var mockedPostSchoolSpecificationsValidator = new PostSchoolSpecificationsValidator(
                mockedSchoolNameAlreadyExistsSpecification);

            var mockedPostSchoolService = new PostSchoolService(
                mockedDefaultDbContext.Object,
                mockedSchoolValidator,
                mockedPostSchoolSpecificationsValidator);

            return mockedPostSchoolService;
        }

        [TestMethod]
        public async Task TestPostSchoolWithEmptyModelAsync()
        {
            var mockedPostSchoolService = GetMockedPostSchoolService();

            var mockedSchool = new School { };

            await Assert.ThrowsExceptionAsync<BusinessException>(() =>
                mockedPostSchoolService.Run(mockedSchool));
        }

        [TestMethod]
        public async Task TestPostSchoolWithDuplicatedNameOnSchoolAsync()
        {
            var mockedPostSchoolService = GetMockedPostSchoolService();

            var mockedSchool = new School
            {
                Name = "School - 002"
            };

            await Assert.ThrowsExceptionAsync<BusinessException>(() =>
                mockedPostSchoolService.Run(mockedSchool));
        }

        [TestMethod]
        public async Task TestPostSchoolValidModelAsync()
        {
            var mockedPostSchoolService = GetMockedPostSchoolService();

            var mockedSchool = new School
            {
                Name = "School - 003"
            };

            await mockedPostSchoolService.Run(mockedSchool);
        }
    }
}
