using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Exceptions;
using Education.Core.Domain.Services.Default.Classes;
using Education.Core.Domain.Validations.DomainValidations.Default.Classes;
using Education.Core.Domain.Validations.EntityValidationsDefault;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.Domain.Services.Tests.Default.Classes
{
    [TestClass]
    public class DeleteClassServiceTest
    {
        private DeleteClassService GetMockedDeleteClassService()
        {
            var mockedDefaultDbContext = MockDefaultHelper.GetMockedDefaultDbContext();
            
            var mockedClassValidator = new ClassValidator();

            var mockedDeleteClassSpecificationsValidator = new DeleteClassSpecificationsValidator();

            var mockedDeleteClassService = new DeleteClassService(
                mockedDefaultDbContext.Object,
                mockedClassValidator,
                mockedDeleteClassSpecificationsValidator);

            return mockedDeleteClassService;
        }

        [TestMethod]
        public async Task TestPostClassValidModelAsync()
        {
            var mockedDeleteClassService = GetMockedDeleteClassService();

            var mockedClass = new Class
            {
                ClassID = 1,
                Name = "Class - 001",
                ClassCode = "S001C001",
                SchoolID = 1
            };

            await mockedDeleteClassService.Run(mockedClass);
        }
    }
}
