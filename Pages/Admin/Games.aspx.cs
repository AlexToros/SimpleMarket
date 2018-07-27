using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStore.Pages.Admin
{
    public partial class Games : System.Web.UI.Page
    {
        private Repository rep = new Repository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Game> GetGames()
        {
            return rep.Games; 
        }

        public void UpdateGame(int GameID)
        {
            Game myGame = rep.Games
                .FirstOrDefault(p => p.GameID == GameID);
            if (myGame != null && TryUpdateModel(myGame, new FormValueProvider(ModelBindingExecutionContext)))
            {
                rep.SaveGame(myGame);
            }
        }

        public void DeleteGame(int GameID)
        {
            Game myGame = rep.Games
                .FirstOrDefault(p => p.GameID == GameID);
            if (myGame != null)
            {
                rep.DeleteGame(myGame);
            }
        }

        public void InsertGame()
        {
            Game myGame = new Game();
            if (TryUpdateModel(myGame, new FormValueProvider(ModelBindingExecutionContext)))
            {
                rep.SaveGame(myGame);
            }
        }
    }
}