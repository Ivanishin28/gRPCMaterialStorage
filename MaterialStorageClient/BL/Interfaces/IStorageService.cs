using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IStorageService
    {
        Task<Result> Store(Material material);
        Task<Result> Withdraw(Material material);
    }
}
