using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    class Weapon
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int Durability { get; set; }
        public EquipmentClass Class { get; set; }

        public Weapon(string name, int power, int durability, EquipmentClass equipmentClass)
        {
            Name = name;
            Power = power > 0 ? power : 1;
            Durability = durability > 0 ? durability : 1;
            Class = equipmentClass;
        }

        public void ReceiveDamage()
        {
            Durability -= 1;
        }
    }
}
