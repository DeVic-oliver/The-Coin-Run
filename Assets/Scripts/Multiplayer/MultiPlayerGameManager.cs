namespace Assets.Scripts.Multiplayer
{
    using UnityEngine;
    using Photon.Pun;
    using Assets.Scripts.Core.Management.SceneManagement;
    using Photon.Realtime;
    using TMPro;
    using Assets.Scripts.Core;


    public class MultiPlayerGameManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private SceneManagerGateway _sceneGateway;

        [SerializeField] private EndGameScoreboard _endScoreboard;

        [Header("Master Setup")]
        [SerializeField] private Transform _spawn1;
        [SerializeField] private TextMeshProUGUI _masterNickTMP;
        [SerializeField] private GameObject _masterPrefabResource;
        [Header("Master Dependencies")]
        [SerializeField] private TextMeshProUGUI _masterScoreTMP;
        private CoinDetector _masterCoinDetector;

        [Header("Guest Setup")]
        [SerializeField] private Transform _spawn2;
        [SerializeField] private TextMeshProUGUI _guestNickTMP;
        [SerializeField] private GameObject _guestPrefabResource;
        [Header("Guest Dependencies")]
        [SerializeField] private TextMeshProUGUI _guestScoreTMP;
        private CoinDetector _guestCoinDetector;



        public override void OnPlayerEnteredRoom(Player other)
        {
            if (PhotonNetwork.IsMasterClient)
                LoadArena();
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            PhotonNetwork.Disconnect();
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            _sceneGateway.BackToLobby();
        }

        public void Disconnect()
        {
            PhotonNetwork.Disconnect();
        }

        void LoadArena()
        public void ShowScoreBoard()
        {
            if (!PhotonNetwork.IsMasterClient)
                return;
            int masterPoints = int.Parse(_masterScoreTMP.text);
            int guestPoints = int.Parse(_guestScoreTMP.text);

            AstronautCompetitor master = new(_masterNickTMP.text, masterPoints);
            AstronautCompetitor guest = new(_guestNickTMP.text, guestPoints);

            _endScoreboard.SetTheWinnderAndLoser(master, guest);
        }

        private void Awake()
        {
            InjectPlayersDependencies();
            SetPlayerInTheirSpawnPositions();
        }

        private void InjectPlayersDependencies()
        {
            InjectMasterDependencies();
            InjectGuestDependencies();
        }

        private void InjectMasterDependencies()
        {
            _masterCoinDetector = _masterPrefabResource.GetComponent<CoinDetector>();
            _masterCoinDetector.CoinsCollectedTMP = _masterScoreTMP;
        }

        private void InjectGuestDependencies()
        {
            _guestCoinDetector = _guestPrefabResource.GetComponent<CoinDetector>();
            _guestCoinDetector.CoinsCollectedTMP = _guestScoreTMP;
        }

        private void SetPlayerInTheirSpawnPositions()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate(_masterPrefabResource.name, _spawn1.position, _spawn1.rotation);
            }
            else
            {
                PhotonNetwork.Instantiate(_guestPrefabResource.name, _spawn2.position, _spawn2.rotation);
            }
        }

        private void Start()
        {

            _masterNickTMP.text = GetMasterPlayer().NickName;
            _guestNickTMP.text = GetGuestPlayer().NickName;
        }

        private Player GetMasterPlayer()
        {
            return PhotonNetwork.PlayerList[0];
        }

        private Player GetGuestPlayer()
        {
            return PhotonNetwork.PlayerList[1];
        }
    }
}