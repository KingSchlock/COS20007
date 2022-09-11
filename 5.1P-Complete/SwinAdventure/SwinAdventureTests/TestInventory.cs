using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture()]
    internal class TestInventory
    {
        Inventory inventoryTest;
        Item swordTest, axeTest, glovesTest, bowTest;
        string testList;

        [SetUp()]
        public void Setup()
        {
            inventoryTest = new();
            swordTest = new(new string[] { "sword" }, "sword", "lil poker");
            axeTest = new(new string[] { "axe" }, "axe", "beeeeeg hacker");
            glovesTest = new(new string[] { "gloves" }, "gloves", "the fingerless kind for minimal effect");
            bowTest = new(new string[] { "bow" }, "bow", "pew pew pew");

            inventoryTest.Put(swordTest);
            inventoryTest.Put(axeTest);
            inventoryTest.Put(glovesTest);

            testList = $"\t{swordTest.ShortDescription}\n\t{axeTest.ShortDescription}\n\t{glovesTest.ShortDescription}\n";
        }

        //! Tests the inventory can find items contained within it
        [Test()]
        public void TestFindItem()
        {
            Assert.Multiple(() =>{
                Assert.That(inventoryTest.HasItem("sword"), Is.True);
                Assert.That(inventoryTest.HasItem("axe"), Is.True);
                Assert.That(inventoryTest.HasItem("gloves"), Is.True);
            });
        }

        //! Checks that the inventory returns false if it doesn't contain a queried item
        [Test()]
        public void TestNoFoundItem()
        {
            Assert.Multiple(()=>{
                Assert.That(inventoryTest.HasItem("bow"), Is.False);
                Assert.That(inventoryTest.HasItem("randomitem123"), Is.False);
            });
        }

        //! Checks the inventory can fetch items & items remain in inventory
        [Test()]
        public void TestFetchItem()
        {
            Assert.Multiple(()=>{
                Assert.That(swordTest, Is.EqualTo(inventoryTest.Fetch("sword")));
                Assert.That(axeTest, Is.EqualTo(inventoryTest.Fetch("axe")));

                Assert.That(inventoryTest.HasItem("sword"), Is.True);
                Assert.That(inventoryTest.HasItem("axe"), Is.True);
            });
        }

        //! Checks if the inventory can take an item
        [Test()]
        public void TestTakeItem()
        {
            Assert.Multiple(() => {
                Assert.That(swordTest, Is.EqualTo(inventoryTest.Take("sword")));
                Assert.That(axeTest, Is.EqualTo(inventoryTest.Take("axe")));

                Assert.That(inventoryTest.HasItem("sword"), Is.False);
                Assert.That(inventoryTest.HasItem("axe"), Is.False);
            });
        }

        //! Checks if the inventory can return a multiobject, tab indented, short descript of each item
        [Test()]
        public void TestItemList()
        {
            Assert.That(testList, Is.EqualTo(inventoryTest.ItemList));
        }
    }
}
