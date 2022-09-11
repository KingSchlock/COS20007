using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture()]
    internal class TestBag
    {
        //! Setup
        Bag b1Test, b2Test;
        Inventory inventoryTest;
        Item swordTest, axeTest, bottleTest;
        
        [SetUp()]
        public void Setup()
        {
            b1Test = new(new string[] { "travelpack" }, "travelpack", "it's big");
            b2Test = new(new string[] { "daypack" }, "daypack", "it's smol");

            inventoryTest = new();
            swordTest = new(new string[] { "sword" }, "sword", "lil poker");
            axeTest = new(new string[] { "axe" }, "axe", "beeeeeg hacker");
            bottleTest = new(new string[] { "bottle" }, "bottle", "slurp");

            b1Test.Inventory.Put(swordTest);
            b1Test.Inventory.Put(axeTest);

            b2Test.Inventory.Put(bottleTest);
        }

        //! Tests the bag can locate items within it
        [Test()]
        public void TestLocateItems()
        {
            Assert.Multiple(() => {

                Assert.That(b1Test.Locate("sword"), Is.EqualTo(swordTest));
                Assert.That(b1Test.Locate("axe"), Is.EqualTo(axeTest));

                Assert.IsTrue(b1Test.Inventory.HasItem("sword"));
                Assert.IsTrue(b1Test.Inventory.HasItem("axe"));
            });
        }

        //! Checks the bag knows it exists
        [Test()]
        public void TestLocateSelf()
        {
            Assert.That(b1Test, Is.EqualTo(b1Test.Locate("travelpack")));
        }

        //! Checks the Bag cannot locate an object it doesn't have
        [Test()]
        public void TestLocateNothing()
        {
            Assert.That(b1Test.Locate("randomitem123"), Is.EqualTo(null));
        }

        //! Tests the Bags full descriptions
        [Test()]
        public void TestBagFullDescription()
        {
            string testBagDescription = $"In the {b1Test.Name} you can see\n{b1Test.Inventory.ItemList}";
            Assert.That(b1Test.FullDescription, Is.EqualTo(testBagDescription));
        }

        //! Runs 3 tests regarding bags within bags
        [Test()]
        public void TestBagInBag()
        {
            b1Test.Inventory.Put(b2Test);

            Assert.Multiple(() => {            
                // Tests that a bag can locate a bag held within it
                Assert.That(b1Test.Locate("daypack"), Is.EqualTo(b2Test));

                // Tests that a bag can locate other items whilst there's a bag within it
                Assert.That(b1Test.Locate("sword"), Is.EqualTo(swordTest));
                Assert.That(b1Test.Locate("axe"), Is.EqualTo(axeTest));

                // Checks that b1 cannot access items held within b2 even though b2 resides in b1
                Assert.That(b1Test.Locate("bottle"), Is.EqualTo(null));
            }); 
        }
    }
}