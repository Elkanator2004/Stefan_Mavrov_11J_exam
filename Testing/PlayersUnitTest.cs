using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using BussinesLayer;

namespace Testing
{
    [TestClass]
    public class PlayersUnitTest
    {
        PlayerContext context;
        Player pleyerche;

        [TestInitialize]
        public void Setup()
        {
            var context = new PlayersDBContext();
            var _context = new PlayerContext(context);
            this.context = _context;

            Player user = new Player("Stefan", "Mavrov", 18, "Elkinator", "hartosh23", "stef@abv.bg");
            pleyerche = user;
        }
        [TestCleanup]
        public void CleanUp()
        {
            //Deletion
            context.Delete(pleyerche);
            //Creation
            context.Create(pleyerche);
        }


        [TestMethod]
        public void CreateTest()
        {
            //Asserting 
            Assert.IsNotNull(context.Read(0));
        }
        [TestMethod]
        public void ReadTest()
        {
            //Doing
            var data = context.Read(0);

            //Doing 
            Assert.AreEqual(21, data.Age);
        }
        [TestMethod]
        public void UpdateTest()
        {
            //Doing
            var newplayer = new Player("Kiro", "Petkov", 38, "KiroKanadata", "obichamBG", "kiro_kanadata@gmail.com");
            context.Update(newplayer);

            //Asserting 
            Assert.AreEqual("Kiro", context.Read(0).First_name);
        }
        [TestMethod]
        public void DeleteTest()
        {
            //Doing 
            context.Delete(0);

            Assert.IsNull(context.Read(0));
        }
        [TestMethod]
        public void ReadAllTest()
        {
            //Doing 
            Assert.IsNotNull(context.ReadAll());
        }
    }
}
