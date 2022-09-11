using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture()]
    internal class TestPlayer
    {
        Player playerTest;
        Inventory inventoryTest;
        Item swordTest, axeTest;
        string testDescription;

        [SetUp()]
        public void Setup()
        {
            playerTest = new("thomas", "The mighty keyboard warrior");
            inventoryTest = new();
            swordTest = new(new string[] { "sword" }, "sword", "lil poker");
            axeTest = new(new string[] { "axe" }, "axe", "beeeeeg hacker");

            playerTest.Inventory.Put(swordTest);
            playerTest.Inventory.Put(axeTest);

            testDescription = $"You are thomas The mighty keyboard warrior.\nYou are carrying\n{playerTest.Inventory.ItemList}";
        }

        //! Checks the player can identify itself
        [Test()]
        public void TestPlayerIsIdentifiable()
        {
            Assert.IsTrue(playerTest.AreYou("me"));
        }

        //! Tests the play can locate itself
        [Test()]
        public void TestPlayerisLocatable()
        {
            Assert.That(playerTest, Is.EqualTo(playerTest.Locate("me")));
            Assert.That(playerTest, Is.EqualTo(playerTest.Locate("inventory")));
        }

        //! Checks the player can locate items
        [Test()]
        public void TestLocateItems()
        {
            Assert.Multiple(()=>{
                Assert.That(playerTest.Locate("sword"), Is.EqualTo(swordTest));
                Assert.That(playerTest.Locate("axe"), Is.EqualTo(axeTest));

                Assert.That(playerTest.Inventory.HasItem("sword"), Is.True);
                Assert.That(playerTest.Inventory.HasItem("axe"), Is.True);
            });
        }

        //! Tests the player returns null when no object of id is found
        [Test()]
        public void TestLocateNothing()
        {
            Assert.That(playerTest.Locate("randomitem123"), Is.EqualTo(null));
        }

        //! Tests the player returns a correct full description
        [Test()]
        public void TestFullDescription()
        {
            Assert.That(playerTest.FullDescription, Is.EqualTo(testDescription));
        }
    }
}
