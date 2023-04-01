namespace TestProject1
{
    public class Tests
    {

        [TestFixture]
        public class CharacterTests
        {
            // Definir variables privadas que se utilizar�n en las pruebas.
            private Character character1;
            private Character character2;
            private Weapon weapon1;
            private Weapon weapon2;
            private Armor armor1;
            private Armor armor2;

            // El m�todo de configuraci�n se ejecuta antes de cada prueba para inicializar las variables
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
                Assert.That(() => new Character("Negative HP", -1, 5, 3, CharacterClass.Human), Throws.ArgumentException);
            }

            // Prueba que la creaci�n de un Arma con durabilidad cero arroja una ArgumentException
            [Test]
            public void Weapon_WithZeroDurability_ThrowsException()
            {
                Assert.That(() => new Weapon("Zero Durability", 3, 0, EquipmentClass.Human), Throws.ArgumentException);
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
                character1.EquipWeapon(weapon2);
                Assert.That(character1.EquippedWeapon, Is.EqualTo(weapon2));
            }

            // Prueba que un Personaje solo puede equipar una Armadura a la vez
            [Test]
            public void Character_CanOnlyEquipOneArmor_AtATime()
            {
                character1.EquipArmor(armor1);
                character1.EquipArmor(armor2);
                Assert.That(character1.EquippedArmor, Is.EqualTo(armor2));
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


        }
    }
}