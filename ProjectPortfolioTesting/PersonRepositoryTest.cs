using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Dataservices;
using Dataservices.Domain;
using Dataservices.Repository;

namespace ProjectPortfolioTesting
{
    public class PersonRepositoryTest
    {
        private UnitOfWork unit;
        public PersonRepositoryTest()
        {
            unit = new UnitOfWork(new ImdbContext());
        }
        [Fact]
        public void GetPerson()
        {
            ImdbNameBasics result  =  unit.Persons.Get("nm0000001");
            Assert.Equal("Fred Astaire", result.Name);
        }
    }
}