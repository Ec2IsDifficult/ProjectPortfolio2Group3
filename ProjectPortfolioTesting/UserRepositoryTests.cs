namespace ProjectPortfolioTesting
{
    using System;
    using Dataservices;
    using Dataservices.Repository;

    public class UserRepositoryTests
    {
        private UserRepository _userRepository;

        public UserRepositoryTests()
        {
            var _ctx = new ImdbContext();
            _userRepository = new UserRepository(_ctx);
        }
    }
}