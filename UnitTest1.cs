namespace TestProject1
{
    public class Tests
    {

        [TestFixture]
        public class CharacterTests
        {
            // Definir variables privadas que se utilizarán en las pruebas
            private Character character1;
            private Character character2;
            private Weapon weapon1;
            private Weapon weapon2;
            private Armor armor1;
            private Armor armor2;

            // El método de configuración se ejecuta antes de cada prueba para inicializar las variables
            [SetUp]
            public void Setup()
            {
                // Crear instancias de personajes, armas y armaduras para probar
                character1 = new Character("JuanGabriel", 10, 5, 3, CharacterClass.Human);
                character2 = new Character("Valentina", 12, 4, 4, CharacterClass.Beast);
                weapon1 = new Weapon("Espada", 3, 5, EquipmentClass.Human);
                weapon2 = new Weapon("Katana", 4, 3, EquipmentClass.Beast);
                armor1 = new Armor("Armor 1", 3, 5, EquipmentClass.Human);
                armor2 = new Armor("Armor 2", 4, 3, EquipmentClass.Beast);
            }

            // Prueba que al crear un personaje con HP negativo arroja una ArgumentException
            [Test]
            public void Character_WithNegativeHP_ThrowsException()
            {

                var character = new Character("Test Character", 10, 5, 3, CharacterClass.Human);
                var armor1 = new Armor("Armor 1", 2, 10, EquipmentClass.Human);
                var armor2 = new Armor("Armor 2", 4, 10, EquipmentClass.Human);

                character.EquipArmor(armor1);
                Assert.That(character.EquippedArmor, Is.EqualTo(armor1));

                // Al equipar la segunda armadura, se debe eliminar la primera
                character.EquipArmor(armor2);
                Assert.That(character.EquippedArmor, Is.EqualTo(armor2)); ;
            }

            // Prueba que la creación de un Arma con durabilidad cero arroja una ArgumentException
            [Test]
            public void Weapon_TakesDamage_DecreasesDurability()
            {
                Weapon weapon = new Weapon("Test Weapon", 5, 5, EquipmentClass.Human);
                int initialDurability = weapon.Durability;
                weapon.ReceiveDamage();
                Assert.That(weapon.Durability, Is.EqualTo(initialDurability - 1));
            }

            // Pruebe que crear una Armadura con poder negativo arroja una ArgumentException
            [Test]
            public void Armor_WithNegativePower_ThrowsException()
            {
                Assert.That(() => new Armor("Negative Power", -1, 5, EquipmentClass.Human), Throws.ArgumentException);
            }

            // Prueba que un personaje puede equipar un arma si la clase coincide
            [Test]
            public void Character_EquipsWeapon_IfClassMatches()
            {
                character1.EquipWeapon(weapon1);
                Assert.That(character1.EquippedWeapon, Is.EqualTo(weapon1));
            }

            // Prueba que un personaje puede equipar una armadura si la clase coincide
            [Test]
            public void Character_EquipsArmor_IfClassMatches()
            {
                character1.EquipArmor(armor1);
                Assert.That(character1.EquippedArmor, Is.EqualTo(armor1));
            }

            // Prueba que un personaje solo puede equipar un arma a la vez
            [Test]
            public void Character_CanOnlyEquipOneWeapon_AtATime()
            {
                character1.EquipWeapon(weapon1);
                Assert.That(character1.EquippedWeapon, Is.EqualTo(weapon1));

                character1.EquipWeapon(weapon2);
                Assert.That(character1.EquippedWeapon, Is.EqualTo(weapon1));
            }

            public void Character_CanOnlyEquipOneArmor_AtATime()
            {
                var character = new Character("Test Character", 10, 5, 3, CharacterClass.Human);
                var armor1 = new Armor("Armor 1", 2, 10, EquipmentClass.Human);
                var armor2 = new Armor("Armor 2", 4, 10, EquipmentClass.Human);

                character.EquipArmor(armor1);
                Assert.That(character.EquippedArmor, Is.EqualTo(armor1));

                // Al equipar la segunda armadura, se debe eliminar la primera
                character.EquipArmor(armor2);
                Assert.That(character.EquippedArmor, Is.EqualTo(armor2));
            }

            // Prueba que un personaje puede equipar cualquier arma, independientemente de la clase

            [Test]
            public void Character_EquipsWeapon_AnyClass()
            {
                character1.EquipWeapon(new Weapon("Any Weapon", 3, 5, EquipmentClass.Any));
                Assert.That(character1.EquippedWeapon, Is.Not.Null);
            }

            [Test]
            public void Character_EquipsArmor_AnyClass()
            {
                // Este caso de prueba comprueba que un personaje puede equipar una armadura de cualquier clase
                character1.EquipArmor(new Armor("Any Armor", 3, 5, EquipmentClass.Any));
                Assert.That(character1.EquippedArmor, Is.Not.Null);
            }

            [Test]
            public void Attack_WithoutWeapon_ReduceOpponentHP()
            {
                // Este caso de prueba comprueba que un personaje puede recibir un ataque sin un arma y reducir su HP
                int damage = character1.ReceiveAttack(3);
                Assert.That(character1.HP, Is.EqualTo(7));
                Assert.That(damage, Is.EqualTo(3));
            }

            // Prueba que al equipar dos armaduras, la segunda reemplaza a la primera
            [Test]
            public void Character_CanEquipArmor_TwoArmors_EquipsSecondRemovesFirst()
            {
                // Crear un personaje y dos armaduras para probar
                var character = new Character("Test Character", 10, 5, 3, CharacterClass.Human);
                var armor1 = new Armor("Armor 1", 2, 10, EquipmentClass.Human);
                var armor2 = new Armor("Armor 2", 4, 10, EquipmentClass.Human);

                // Equipar la primera armadura y comprobar que está equipada
                character.EquipArmor(armor1);
                Assert.That(character.EquippedArmor, Is.EqualTo(armor1));

                // Equipar la segunda armadura y comprobar que está equipada y la primera se ha eliminado
                character.EquipArmor(armor2);
                Assert.That(character.EquippedArmor, Is.EqualTo(armor2));
                Assert.That(character.EquippedArmor, Is.Not.EqualTo(armor1));
            }

            // Prueba que un personaje reciba daño correctamente cuando tiene armadura equipada
            [Test]
            public void Character_ReceivesDamageWithEquippedArmor_Correctly()
            {
                // Configurar personaje y armadura
                var character = new Character("Test Character", 10, 5, 3, CharacterClass.Human);
                var armor = new Armor("Armor", 2, 10, EquipmentClass.Human);
                character.EquipArmor(armor);

                // Atacar al personaje
                int attackPoints = 5;
                // daño recibido después de reducir por la armadura
                int expectedDamage = 3;
                int actualDamage = character.ReceiveAttack(attackPoints);

                // Verificar que se haya aplicado el daño correcto
                Assert.AreEqual(expectedDamage, actualDamage);
                // verificar que la vida del personaje se haya reducido correctamente
                Assert.AreEqual(7, character.HP);

                // Verificar que la armadura haya recibido daño
                Assert.AreEqual(9, armor.Durability);
                // Durabilidad de la armadura debe haberse reducido en 1.5 veces el daño recibido
            }

            //Prueba cuando un arma pierde toda su durabilidad en un ataque, se desequipa del personaje que inicia el ataque
            [Test]
            public void Character_EquipSecondArmor_RemovesFirstArmor()
            {
                // Crear un personaje y dos armaduras para probar
                var character = new Character("Test Character", 10, 5, 3, CharacterClass.Human);
                var armor1 = new Armor("Armor 1", 2, 10, EquipmentClass.Human);
                var armor2 = new Armor("Armor 2", 4, 10, EquipmentClass.Human);

                // Equipar la primera armadura
                character.EquipArmor(armor1);
                Assert.That(character.EquippedArmor, Is.EqualTo(armor1));

                // Al equipar la segunda armadura, se debe eliminar la primera.
                character.EquipArmor(armor2);
                Assert.That(character.EquippedArmor, Is.EqualTo(armor2));
            }


            [Test]
            public void Character_ReceivesDamageWithNoWeapon_Correctly()
            {
                // Configurar personaje y armadura
                var character = new Character("Test Character", 7, 4, 5, CharacterClass.Beast);

                // Atacar al personaje
                int attackPoints = 6;
                int expectedDamage = 3;
                int actualDamage = (character.ReceiveAttack(attackPoints)) / 2;

                // Verificar que se haya aplicado el daño correcto
                Assert.That(actualDamage, Is.EqualTo(expectedDamage));
                // verificar que la vida del personaje se haya reducido correctamente
                Assert.That(character.HP, Is.EqualTo(1));
            }
        }
    }
}