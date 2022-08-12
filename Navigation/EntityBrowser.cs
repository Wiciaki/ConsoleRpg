namespace ProjektKD.Navigation
{
    using System;

    using ProjektKD.Entities;

    public class EntityBrowser : INavigation
    {
        private readonly Game game;

        private readonly Entity[] entities;

        public EntityBrowser(Game game, Entity[] entities)
        {
            this.game = game;
            this.entities = entities;
        }

        public EntityBrowser(Game game, Entity entity) : this(game, new Entity[] { entity })
        {

        }

        public void Show()
        {
            var i = 0;

            while (true)
            {
                switch (ShowEntity(entities[i]))
                {
                    case 0:
                        i = Math.Min(i + 1, entities.Length - 1);
                        break;
                    case 1:
                        i = Math.Max(i - 1, 0);
                        break;
                    case 2:
                        game.Show();
                        return;
                }
            }
        }

        private int ShowEntity(Entity entity)
        {
            var options = new string[] { "Next", "Previous", "Return" };

            return game.Gui.ShowSelection(entity.GetName(), entity.GetDescription(), options);
        }
    }
}