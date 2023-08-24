namespace Assets.Scripts.Multiplayer
{
    using Photon.Pun;
    using Photon.Realtime;
    using System.Collections;
    using TMPro;
    using UnityEngine;


    public class Launcher : MonoBehaviourPunCallbacks
    {
        [SerializeField] private int _maxNumberOfPlayers = 2;
        [SerializeField] private GameObject _connectionPanel;
        [SerializeField] private TextMeshProUGUI _playerNick;
        [SerializeField] private TextMeshProUGUI _connectionTMP;

        private readonly string _defaultConnectionText = "Connecting...";
        
        private bool isConnecting;
        private ConnectionLoginFeedback _connectionFeedback;


        public override void OnConnectedToMaster()
        {
            if (isConnecting)
            {
                _connectionFeedback.SetConnectedMessage();
                PhotonNetwork.JoinRandomRoom();
                isConnecting = false;
            }
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            _connectionFeedback.SetCreatingRoomMessage();
            RoomOptions options = new RoomOptions() { MaxPlayers = _maxNumberOfPlayers };
            PhotonNetwork.CreateRoom(null, options);
        }

        public override void OnCreatedRoom()
        {
            _connectionFeedback.SetRoomCreatedMessage();
        }

        public override void OnJoinedRoom()
        {
            _connectionFeedback.UpdateWaitingForPlayers(GetCurrentRoomPlayersCount());
            PhotonNetwork.NickName = _playerNick.text;
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            _connectionFeedback.UpdateWaitingForPlayers(GetCurrentRoomPlayersCount());
            StartCoroutine("LoadLevelAfter1Second");
        }

        private int GetCurrentRoomPlayersCount()
        {
            Room room = PhotonNetwork.CurrentRoom;
            return room.PlayerCount;
        }

        private IEnumerator LoadLevelAfter1Second()
        {
            _connectionFeedback.SetJoiningGameMessage();
            yield return new WaitForSeconds(1f);
            PhotonNetwork.LoadLevel("Arena Multiplayer");
            _connectionTMP.text = _defaultConnectionText;
        }

        public void Connect()
        {
            PhotonNetwork.OfflineMode = false;
            _connectionPanel.SetActive(true);

            PhotonNetwork.NickName = _playerNick.text;

            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                isConnecting = PhotonNetwork.ConnectUsingSettings();
            }
        }

        public void Disconnect()
        {
            PhotonNetwork.Disconnect();
        }

        void Awake()
        {
            _connectionFeedback = new ConnectionLoginFeedback(_connectionTMP, _maxNumberOfPlayers);
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        void Start()
        {
            _connectionPanel.SetActive(false);
            _connectionTMP.text = _defaultConnectionText;
        }
    }
}
