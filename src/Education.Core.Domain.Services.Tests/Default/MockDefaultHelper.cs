using Education.Core.Domain.Entities.Default;
using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Education.Core.Domain.Services.Tests.Default
{
    public static class MockDefaultHelper
    {
        private static Mock<DbSet<T>> BuildMockDbSet<T>(this IQueryable<T> source)
           where T : class
        {
            var mock = new Mock<DbSet<T>>();

            mock.As<IQueryable<T>>()
                .Setup(x => x.Provider)
                .Returns(source.Provider);

            mock.As<IQueryable<T>>()
                .Setup(x => x.Expression)
                .Returns(source.Expression);

            mock.As<IQueryable<T>>()
                .Setup(x => x.ElementType)
                .Returns(source.ElementType);

            mock.As<IQueryable<T>>()
                .Setup(x => x.GetEnumerator())
                .Returns(source.GetEnumerator());

            return mock;
        }
        private static IQueryable<School> GetSchoolsCollection()
        {
            return new List<School> {
                new School { SchoolID = 1, Name = "School - 001" },
                new School { SchoolID = 2, Name = "School - 002" },
            }.AsQueryable();
        }
        private static IQueryable<Class> GetClassesCollection()
        {
            return new List<Class> {
                new Class { ClassID = 1, Name = "Class - 001", ClassCode = "S001C001", SchoolID = 1},
                new Class { ClassID = 2, Name = "Class - 002", ClassCode = "S001C002", SchoolID = 1},
                new Class { ClassID = 3, Name = "Class - 001", ClassCode = "S002C001", SchoolID = 2},
            }.AsQueryable();
        }
        private static Mock<DbSet<School>> GetMockedDbSetSchools()
        {
            var schoolsCollection = GetSchoolsCollection();

            var mockedDbSetSchools = schoolsCollection.BuildMockDbSet();

            return mockedDbSetSchools;
        }
        private static Mock<DbSet<Class>> GetMockedDbSetClasses()
        {
            var classesCollection = GetClassesCollection();

            var mockedDbSetClasses = classesCollection.BuildMockDbSet();

            return mockedDbSetClasses;
        }
        internal static Mock<IDefaultDbContext> GetMockedDefaultDbContext()
        {
            var mockedDbSetSchools = GetMockedDbSetSchools();
            var mockedDbSetClasses = GetMockedDbSetClasses();

            var mockedDeafultDbContext = new Mock<IDefaultDbContext>();

            mockedDeafultDbContext.Setup(setup => setup.Schools).Returns(mockedDbSetSchools.Object);
            mockedDeafultDbContext.Setup(setup => setup.Classes).Returns(mockedDbSetClasses.Object);

            return mockedDeafultDbContext;
        }
        internal static Mock<IDefaultDbContextQuery> GetMockedDefaultDbContextQuery()
        {
            var mockedDbSetSchools = GetMockedDbSetSchools();
            var mockedDbSetClasses = GetMockedDbSetClasses();

            var mockedDeafultDbContextQuery = new Mock<IDefaultDbContextQuery>();

            mockedDeafultDbContextQuery.Setup(setup => setup.Schools).Returns(mockedDbSetSchools.Object);
            mockedDeafultDbContextQuery.Setup(setup => setup.Classes).Returns(mockedDbSetClasses.Object);

            return mockedDeafultDbContextQuery;
        }
    }
}
