using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture]
    internal class IdentifiableObjectTest
    {
        IdentifiableObject objectDefaultTest, objectCaseTest, objectNullTest;

        [SetUp()]
        public void Setup()
        {
            objectDefaultTest = new IdentifiableObject(new string[] { "sword", "axe" });
            objectCaseTest = new IdentifiableObject(new string[] { "Sword", "aXE" });
            objectNullTest = new IdentifiableObject(new string[] { "", "sword" });
        }

        [Test()]
        public void TestAreYou()
        {
            Assert.That(objectDefaultTest.AreYou("sword"), Is.True);
            Assert.That(objectDefaultTest.AreYou("axe"), Is.True);
        }

        [Test()]
        public void TestNotAreYou()
        {
            Assert.That(objectDefaultTest.AreYou("gloves"), Is.False);
            Assert.That(objectDefaultTest.AreYou("bow"), Is.False);
        }

        [Test()]
        public void TestCaseSensitivity()
        {
            Assert.That(objectCaseTest.AreYou("sword"), Is.True);
            Assert.That(objectCaseTest.AreYou("axe"), Is.True);
        }

        [Test()]
        public void TestFirstId()
        {
            Assert.That(objectDefaultTest.FirstId, Is.EqualTo("sword"));
        }

        [Test()]
        public void TestNullFirstId()
        {
            Assert.That(objectNullTest.FirstId, Is.EqualTo(""));
        }

        [Test()]
        public void TestAddId()
        {
            objectDefaultTest.AddIdentifier("spatha");

            Assert.Multiple(() => {
                Assert.That(objectDefaultTest.AreYou("sword"), Is.True);
                Assert.That(objectDefaultTest.AreYou("axe"), Is.True);
                Assert.That(objectDefaultTest.AreYou("spatha"), Is.True);
            });
        }
    }
}
