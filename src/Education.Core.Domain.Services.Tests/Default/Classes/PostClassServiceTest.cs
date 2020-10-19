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
    public class PostClassServiceTest
    {
        private PostClassService GetMockedPostClassService()
        {
            var mockedDefaultDbContext = MockDefaultHelper.GetMockedDefaultDbContext();
            var mockedDefaultDbContextQuery = MockDefaultHelper.GetMockedDefaultDbContextQuery();

            var mockedClassValidator = new ClassValidator();

            var mockedClassNameAlreadyExistsSpecification = new ClassNameAlreadyExistsSpecification(
                mockedDefaultDbContextQuery.Object);
            var mockedClassCodeAlreadyExistsSpecification = new ClassCodeAlreadyExistsSpecification(
                mockedDefaultDbContextQuery.Object);

            var mockedPostClassSpecificationsValidator = new PostClassSpecificationsValidator(
                mockedClassNameAlreadyExistsSpecification,
                mockedClassCodeAlreadyExistsSpecification);

            var mockedPostClassService = new PostClassService(
                mockedDefaultDbContext.Object,
                mockedClassValidator,
                mockedPostClassSpecificationsValidator);

            return mockedPostClassService;
        }

        [TestMethod]
        public async Task TestPostClassWithEmptyModelAsync()
        {
            var mockedPostClassService = GetMockedPostClassService();

            var mockedClass = new Class { };

            await Assert.ThrowsExceptionAsync<BusinessException>(() =>
                mockedPostClassService.Run(mockedClass));
        }

        [TestMethod]
        public async Task TestPostClassWithDuplicatedNameOnSchoolAsync()
        {
            var mockedPostClassService = GetMockedPostClassService();

            var mockedClass = new Class
            {
                Name="Class - 002",
                ClassCode="S001C003",
                SchoolID=1
            };

            await Assert.ThrowsExceptionAsync<BusinessException>(() =>
                mockedPostClassService.Run(mockedClass));
        }

        [TestMethod]
        public async Task TestPostClassWithDuplicatedClassCodeOnSchoolAsync()
        {
            var mockedPostClassService = GetMockedPostClassService();

            var mockedClass = new Class{
                Name = "Class - 003",
                ClassCode = "S001C002", 
                SchoolID = 1
            };

            await Assert.ThrowsExceptionAsync<BusinessException>(() =>
                mockedPostClassService.Run(mockedClass));
        }

        [TestMethod]
        public async Task TestPostClassValidModelAsync()
        {
            var mockedPostClassService = GetMockedPostClassService();

            var mockedClass = new Class {
                Name = "Class - 003",
                ClassCode = "S001C003",
                SchoolID = 1
            };

            await mockedPostClassService.Run(mockedClass);
        }
    }
}
