using System;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Dataservices;
using Dataservices.Domain;

namespace ProjectPortfolioTesting
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using Autofac.Extras.Moq;
    using Dataservices.CRUDRepository;
    using Dataservices.IRepositories;
    using Dataservices.Repository;
    using Dataservices.Domain.User;

    public class PersonRepositoryTest
    {

        private PersonRepository _personRepository;
        private EpisodeRepository _episodeRepository;
        private TitleRepository _titleRepository;
        private UserRepository _userRepository;
        private ImdbContext _ctx;
        public PersonRepositoryTest()
        {
            _ctx = new ImdbContext();
            _personRepository = new PersonRepository(_ctx);
            _titleRepository = new TitleRepository(_ctx);
            _episodeRepository = new EpisodeRepository(_ctx);
        }
        
        //Testing the Get method on Persons framework
        [Theory]
        [InlineData("nm0000001", "Fred Astaire")]
        [InlineData("nm0000002", "Lauren Bacall")]
        public void GetPersons(string input, string expected)
        {
            ImdbNameBasics result = _personRepository.Get(input);
            Assert.NotNull(result);
            Assert.Equal(expected, result.Name);
        }
        [Fact]
        public void GetAll()
        {
            IEnumerable<ImdbNameBasics> result = _personRepository.GetAll();
            Assert.Equal(234484, result.Count());
        }
        
        [Fact]
        public void GetEpisode()
        {
            ImdbTitleEpisode result = _episodeRepository.Get("tt0734667");
            Assert.Equal("tt0734667", result.EpisodeTconst);
        }
        
        [Fact]
        public void GetTitle()
        {
            ImdbTitleBasics result = _titleRepository.Get("tt0734667");
            Assert.Equal("The Obsolete Man", result.PrimaryTitle);
        }
        
        [Fact]
        public void CreateUser()
        {
            CUser newUser = new CUser();
            newUser.UserName = "TestUser";
            newUser.Email = "TestUser@Test.dk";
            newUser.Password = "Jajo";
            _userRepository.Add(newUser);
            CUser user = _userRepository.Get(newUser.UserId);
            Assert.Equal("TestUser", user.UserName);
            Assert.Equal("TestUser", user.UserName);
        }
    }
}