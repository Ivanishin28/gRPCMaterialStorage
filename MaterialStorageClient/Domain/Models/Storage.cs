using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Storage
    {
        private object _lock = new object();
        public Material StoredMaterial { get; private set; }
        public Material StorageCapacity { get; private set; }

        public Storage(Material storedMaterial, Material storageCapacity)
        {
            if (storedMaterial.CompareTo(storageCapacity) > 0)
            {
                throw new ArgumentException("Stored amount exciedes storage capacity");
            }

            StoredMaterial = storedMaterial;
            StorageCapacity = storageCapacity;
        }

        public Result StoreMaterial(Material material)
        {
            lock(_lock) {
                var newMaterial = StoredMaterial.Add(material);

                if (StorageCapacity.CompareTo(newMaterial) > 0)
                {
                    return Result.Failure("Stored amount exceedes storage capacity");
                }

                StoredMaterial = newMaterial;
                return Result.Success();
            }
        }

        public Result WithdrawMaterial(Material material)
        {
            lock(_lock)
            {
                if (StoredMaterial.CompareTo(material) < 0)
                {
                    return Result.Failure("Storage does not have enough material");
                }

                StoredMaterial = StoredMaterial.Remove(material);
                return Result.Success();
            }
        }
    }
}
