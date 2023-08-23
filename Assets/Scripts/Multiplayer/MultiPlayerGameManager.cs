namespace Assets.Scripts.Multiplayer
{
    using UnityEngine;
    using Photon.Pun;
    using Assets.Scripts.Core.Management.SceneManagement;
    using Photon.Realtime;
    using TMPro;

    public class MultiPlayerGameManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private SceneManagerGateway _sceneGateway;

        [SerializeField] private Transform _spawn1;
        [SerializeField] private Transform _spawn2;
        [SerializeField] private GameObject _playerPrefabResource;

        [SerializeField] private TextMeshProUGUI _masterNickName;
        [SerializeField] private TextMeshProUGUI _guestNickName;


        public override void OnLeftRoom()
        {
            _sceneGateway.BackToLobby();
        }

        public override void OnPlayerEnteredRoom(Player other)
        {
            if (PhotonNetwork.IsMasterClient)
                LoadArena();
        }

        public override void OnPlayerLeftRoom(Player other)
        {
            PhotonNetwork.LeaveRoom();
        }

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        void LoadArena()
        {
            if (!PhotonNetwork.IsMasterClient)
                return;

            PhotonNetwork.LoadLevel("Arena Multiplayer");
        }

        private void Start()
        {
            SetPlayerInTheirSpawnPositions();
            _masterNickName.text = GetMasterPlayer().NickName;
            _guestNickName.text = GetGuestPlayer().NickName;
        }

        private void SetPlayerInTheirSpawnPositions()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate(_playerPrefabResource.name, _spawn1.position, _spawn1.rotation);
            }
            else
            {
                PhotonNetwork.Instantiate(_playerPrefabResource.name, _spawn2.position, _spawn2.rotation);
            }
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