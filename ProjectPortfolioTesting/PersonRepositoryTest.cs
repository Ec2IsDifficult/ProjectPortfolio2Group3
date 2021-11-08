using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Dataservices;
using Dataservices.Domain;

namespace ProjectPortfolioTesting
{
    using System.Collections.Generic;
    using System.Linq;
    using Dataservices.Domain.Functions;
    using DataServices.UnitOfWork;

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
        [Fact]
        public void GetAll()
        {
            IEnumerable<ImdbNameBasics> result  =  unit.Persons.GetAll();
            Assert.Equal(234484, result.Count());
        }
        [Fact]
        public void Testfunction()
        {
            ImdbContext _ctx = new ImdbContext();
            var _input = "nm0000001";
            var res = _ctx.ImdbNameBasics.FromSqlInterpolated($"select * from testfunction({_input});");
            foreach (var VARIABLE in res)
            {
                Assert.Equal("Fred Astaire", VARIABLE.Name);
            }
        }
    }
}