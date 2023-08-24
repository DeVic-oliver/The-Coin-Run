namespace Assets.Scripts.Multiplayer
{
    using TMPro;
    
    public class ConnectionLoginFeedback
    {
        public int RoomCapacity { get; private set; }
        
        private readonly string _defaultConnectionText = "Connecting...";
        
        private TextMeshProUGUI _log;


        public ConnectionLoginFeedback(TextMeshProUGUI log, int roomCapacity)
        {
            RoomCapacity = roomCapacity;
            _log = log;
            SetConnectingMessage();
        }

        public void SetConnectingMessage()
        {
            _log.text = _defaultConnectionText;
        }

        public void SetConnectedMessage()
        {
            _log.text = _defaultConnectionText;
        }

        public void SetJoiningMessage()
        {
            _log.text = "Joining Room...";
        }

        public void SetLoadingMessage()
        {
            _log.text = "Loading...";
        }

        public void UpdateWaitingForPlayers(int playersInRoom)
        {
            _log.text = $"Waiting for players: {playersInRoom} / {RoomCapacity}";
        }

        public void SetJoiningGameMessage()
        {
            _log.text = "Joining Game!";
        }

        public void SetCreatingRoomMessage()
        {
            _log.text = "Creating Room...";
        }

        public void SetRoomCreatedMessage()
        {
            _log.text = "Room Created!";
        }

        public void SetFeedbackMessage(string message)
        {
            _log.text = message;
        }

    }
}