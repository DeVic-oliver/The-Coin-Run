namespace Assets.Scripts.Multiplayer
{
    public class AstronautCompetitor
    {
        public string Nick { get; private set; }
        public int Points { get; private set; }


        public AstronautCompetitor(string playerNick, int points) 
        { 
            Nick = playerNick;
            Points = points;
        }

    }
}