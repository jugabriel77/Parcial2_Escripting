using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    enum EquipmentClass { Human, Beast, Hybrid, Any }
    enum CharacterClass { Human, Beast, Hybrid, Any }

    class Character
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public int BaseAtk { get; set; }
        public int BaseDef { get; set; }
        public CharacterClass Class { get; set; }

        public Character(string name, int hp, int baseAtk, int baseDef, CharacterClass characterClass)
        {
            Name = name;
            HP = hp > 0 ? hp : 1;
            BaseAtk = baseAtk > 0 ? baseAtk : 1;
            BaseDef = baseDef > 0 ? baseDef : 1;
            Class = characterClass;
        }

        public void EquipWeapon(Weapon weapon)
        {
            if (weapon != null && weapon.Durability > 0 &&
                (weapon.Class == (EquipmentClass)Class || weapon.Class == EquipmentClass.Any))
            {
                EquippedWeapon = weapon;
            }
        }

        public void EquipArmor(Armor armor)
        {
            if (armor != null && armor.Durability > 0 &&
                (armor.Class == (EquipmentClass)Class || armor.Class == EquipmentClass.Any))
            {
                EquippedArmor = armor;
            }
        }

        public int GetTotalAtk()
        {
            return BaseAtk + (EquippedWeapon != null ? EquippedWeapon.Power : 0);
        }

        public int GetTotalDef()
        {
            return BaseDef + (EquippedArmor != null ? EquippedArmor.Power : 0);
        }

         public int ReceiveAttack(int attackPoints)
         {
             int damage = attackPoints;
             if (EquippedArmor != null)
             {
                 int armorDamage = attackPoints / 2;
                 armorDamage = armorDamage > 0 ? armorDamage : 1;
                 EquippedArmor.ReceiveDamage(armorDamage);
                 damage = attackPoints - armorDamage;
             }

             damage = damage > 0 ? damage : 1;
             HP -= damage;

             return damage;
         }
    }

}

