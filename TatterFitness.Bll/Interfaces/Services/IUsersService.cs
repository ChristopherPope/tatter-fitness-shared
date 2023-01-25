using System.Collections.Generic;
using TatterFitness.Dal.Entities;
using TatterFitness.Models;

namespace TatterFitness.Bll.Interfaces.Services
{
    public interface IUsersService
    {
        UserEntity CurrentUser { get; }
        User GetUser();
    }
}
