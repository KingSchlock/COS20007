using SwinAdventure;
using NUnit.Framework;

namespace SwinAdventureTests
{
    [TestFixture()]
    internal class TestItem
    {
        Item itemTest;
        String testShortDescription;

        [SetUp()]
        public void Setup()
        {
            itemTest = new(new string[] { "sword" }, "sword", "lil poker");
            testShortDescription = "a sword (sword)";
        }

        [Test()]
        public void TestItemIsIdentifiable()
        {
            Assert.That(itemTest.AreYou("sword"), Is.True);
        }

        [Test()]
        public void TestItemShortDescription()
        {
            Assert.That(itemTest.ShortDescription, Is.EqualTo(testShortDescription));
        }

        [Test()]
        public void TestItemFullDescription()
        {
            Assert.That(itemTest.FullDescription, Is.EqualTo("lil poker"));
        }
    }
}
