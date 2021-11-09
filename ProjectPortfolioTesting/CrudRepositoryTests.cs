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

    public class CrudRepositoryTest
    {
        private UnitOfWork unit;
        public PersonRepositoryTest()
        {
            unit = new UnitOfWork(new ImdbContext());
        private PersonRepository _personRepository;
        private EpisodeRepository _episodeRepository;
        private TitleRepository _titleRepository;
        private UserRepository _userRepository;
        private ImdbContext _ctx;
        public CrudRepositoryTest()
        {
            _ctx = new ImdbContext();
            _personRepository = new PersonRepository(_ctx);
            _titleRepository = new TitleRepository(_ctx);
            _episodeRepository = new EpisodeRepository(_ctx);
            _userRepository = new UserRepository(_ctx);
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