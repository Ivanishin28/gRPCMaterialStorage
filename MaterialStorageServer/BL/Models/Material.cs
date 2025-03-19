using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Material : IComparable<Material>
    {
        public uint Amount { get; private set; }

        public Material(uint amount)
        {
            Amount = amount;
        }

        public Material Add(Material material)
        {
            return new Material(Amount + material.Amount);
        }

        public Material Remove(Material material)
        {
            var newAmount = Amount - material.Amount;

            if(newAmount < 0)
            {
                throw new ArgumentException("Amount of material can not be lesser than zero");
            }

            return new Material(newAmount);
        }

        public int CompareTo(Material other)
        {
            return Amount.CompareTo(other.Amount);
        }
    }
}
