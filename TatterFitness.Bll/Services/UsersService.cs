using AutoMapper;
using TatterFitness.Bll.Exceptions;
using TatterFitness.Bll.Interfaces.Services;
using TatterFitness.Dal.Entities;
using TatterFitness.Dal.Interfaces.Persistance;
using TatterFitness.Models;

namespace TatterFitness.Bll.Services
{
    public class UsersService : DataService, IUsersService
    {
        public UserEntity CurrentUser { get; private set; }

        public UsersService(IUnitOfWork uow
            , IMapper dtoMapper)
            : base(uow, dtoMapper)
        {
            CurrentUser = new UserEntity
            {
                Id = 1,
                Name = "Christopher Pope"
            };
        }

        public User GetUser()
        {
            var userEntity = uow.Users.Read(u => u.Id == CurrentUserId).FirstOrDefault();
            if (userEntity == null)
            {
                throw new EntityNotFoundException($"User {CurrentUserId} does not exist.");
            }

            var user = mapper.Map<UserEntity, User>(userEntity);

            return user;
        }
    }
}
