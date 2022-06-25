using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService: ICrud<UserModel>
    {
        Task<IEnumerable<UserModel>> GetUsersByLotIdAsync(int LotId);
    }
}
