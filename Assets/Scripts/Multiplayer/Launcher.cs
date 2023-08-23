namespace Assets.Scripts.Multiplayer
{
    using Photon.Pun;
    using Photon.Realtime;
    using System.Collections;
    using TMPro;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class Launcher : MonoBehaviourPunCallbacks
    {
        [SerializeField] private int _maxNumberOfPlayers = 2;
        [SerializeField] private GameObject _connectionPanel;
        [SerializeField] private TextMeshProUGUI _playerNick;
        [SerializeField] private TextMeshProUGUI _connectionTMP;

        private bool isConnecting;

        private readonly string _defaultConnectionText = "Connecting...";


        public override void OnConnectedToMaster()
        {
            if (isConnecting)
            {
                _connectionTMP.text = "Joining";
                PhotonNetwork.JoinRandomRoom();
                isConnecting = false;
            }
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            _connectionTMP.text = "Creating Room";
            RoomOptions options = new RoomOptions() { MaxPlayers = _maxNumberOfPlayers };
            PhotonNetwork.CreateRoom(null, options);
        }

        public override void OnCreatedRoom()
        {
            _connectionTMP.text = "Room Created";
        }

        public override void OnJoinedRoom()
        {
            _connectionTMP.text = "Waiting for players: 1/2";
            PhotonNetwork.NickName = _playerNick.text;
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            _connectionTMP.text = "Waiting for players: 2/2";
            StartCoroutine("LoadLevelAfter1Second");
        }

        private IEnumerator LoadLevelAfter1Second()
        {
            _connectionTMP.text = "Loading...";
            yield return new WaitForSeconds(1f);
            PhotonNetwork.LoadLevel("Arena Multiplayer");
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

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        void Start()
        {
            _connectionPanel.SetActive(false);
            _connectionTMP.text = _defaultConnectionText;
        }
    }
}
