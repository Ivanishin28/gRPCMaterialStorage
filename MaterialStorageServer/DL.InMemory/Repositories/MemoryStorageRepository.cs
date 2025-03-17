using Domain;
using DL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DL.InMemory.Repositories
{
    public class MemoryStorageRepository : IStorageRepository
    {
        private static Storage _storage;

        static MemoryStorageRepository()
        {
            _storage = new Storage(new Material(1000), new Material(10000));
        }

        public Storage GetStorage()
        {
            return _storage;
        }
    }
}
