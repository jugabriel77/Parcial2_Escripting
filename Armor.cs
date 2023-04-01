using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    class Armor
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int Durability { get; set; }
        public EquipmentClass Class { get; set; }

        public Armor(string name, int power, int durability, EquipmentClass equipmentClass)
        {
            if (power <= 0)
            {
                throw new ArgumentException("El valor de poder debe ser mayor que cero.", nameof(power));
            }

            Name = name;
            Power = power;
            Durability = durability > 0 ? durability : 1;
            Class = equipmentClass;
        }

        public void ReceiveDamage(int damage)
        {
            Durability -= damage / 2;
            Durability = Durability > 0 ? Durability : 0;
        }
        public abstract class Equipment
        {
            public string Name { get; set; }
            public int Weight { get; set; }
            public int Value { get; set; }
            public EquipmentClass Class { get; set; }
            public bool IsEquipped { get; set; }
            public int Defense { get; set; }
            public int Durability { get; set; }

            // constructor
            public Equipment(string name, int weight, int value, EquipmentClass equipmentClass, int defense, int durability)
            {
                Name = name;
                Weight = weight;
                Value = value;
                Class = equipmentClass;
                IsEquipped = false; // valor inicial
                Defense = defense > 0 ? defense : 1; // establecer la propiedad Defense
            }

            // metodos
            public virtual void Equip(Character character)
            {
                IsEquipped = true;
            }

            public virtual void Unequip(Character character)
            {
                IsEquipped = false;
            }
            public int ReceiveAttack(int attackPoints)
            {
                int damage = attackPoints - Defense;
                damage = damage > 0 ? damage : 1;
                Durability--;

                return damage;
            }
        }
    }
}
