using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Exceptions;
using Education.Core.Domain.Services.Default.Classes;
using Education.Core.Domain.Validations.DomainValidations.Default.Classes;
using Education.Core.Domain.Validations.EntityValidationsDefault;
using Education.Core.Domain.Validations.Specifications.Default.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.Domain.Services.Tests.Default.Classes
{
    [TestClass]
    public class PutClassServiceTest
    {
        private PutClassService GetMockedPutClassService()
        {
            var mockedDefaultDbContext = MockDefaultHelper.GetMockedDefaultDbContext();
            var mockedDefaultDbContextQuery = MockDefaultHelper.GetMockedDefaultDbContextQuery();

            var mockedClassValidator = new ClassValidator();

            var mockedClassNameAlreadyExistsSpecification = new ClassNameAlreadyExistsSpecification(
                mockedDefaultDbContextQuery.Object);
            var mockedClassCodeAlreadyExistsSpecification = new ClassCodeAlreadyExistsSpecification(
                mockedDefaultDbContextQuery.Object);

            var mockedPutClassSpecificationsValidator = new PutClassSpecificationsValidator(
                mockedClassNameAlreadyExistsSpecification,
                mockedClassCodeAlreadyExistsSpecification);

            var mockedPutClassService = new PutClassService(
                mockedDefaultDbContext.Object,
                mockedClassValidator,
                mockedPutClassSpecificationsValidator);

            return mockedPutClassService;
        }

        [TestMethod]
        public async Task TestPutClassWithEmptyModelAsync()
        {
            var mockedPutClassService = GetMockedPutClassService();

            var mockedClass = new Class { };

            await Assert.ThrowsExceptionAsync<BusinessException>(() =>
                mockedPutClassService.Run(mockedClass));
        }

        [TestMethod]
        public async Task TestPostClassWithDuplicatedNameOnSchoolAsync()
        {
            var mockedPutClassService = GetMockedPutClassService();

            var mockedClass = new Class
            {
                ClassID = 1,
                Name = "Class - 002",
                ClassCode = "S001C003",
                SchoolID = 1
            };

            await Assert.ThrowsExceptionAsync<BusinessException>(() =>
                mockedPutClassService.Run(mockedClass));
        }

        [TestMethod]
        public async Task TestPostClassWithDuplicatedClassCodeOnSchoolAsync()
        {
            var mockedPutClassService = GetMockedPutClassService();

            var mockedClass = new Class
            {
                ClassID = 1,
                Name = "Class - 003",
                ClassCode = "S001C002",
                SchoolID = 1
            };

            await Assert.ThrowsExceptionAsync<BusinessException>(() =>
                mockedPutClassService.Run(mockedClass));
        }

        [TestMethod]
        public async Task TestPostClassValidModelAsync()
        {
            var mockedPutClassService = GetMockedPutClassService();

            var mockedClass = new Class
            {
                ClassID = 1,
                Name = "Class - 003",
                ClassCode = "S001C003",
                SchoolID = 1
            };

            await mockedPutClassService.Run(mockedClass);
        }
    }
}
