namespace Assets.Scripts.Core
{
    using Photon.Pun;
    using TMPro;
    using UnityEngine;
    using UnityEngine.Events;

    public class CoinDetector : MonoBehaviourPun
    {
        public UnityEvent<int> OnGetTotalPoints;
        public TextMeshProUGUI CoinsCollectedTMP;

        public static int PlayerPoints { get; private set; }


        public void CountTotalPoints()
        {
            OnGetTotalPoints?.Invoke(PlayerPoints);
        }

        public void CollectCoin(int points)
        {
            if (PhotonNetwork.IsConnected)
            {
                UpdateMultiplayerTMP(points);
            }
            else
            {
                UpdateSinglePlayerTMP(points);
            }
        }

        private void UpdateMultiplayerTMP(int points)
        {
            if (photonView.IsMine)
            {
                PlayerPoints += points;
                photonView.RPC("SyncScore", RpcTarget.All, PlayerPoints);
            }
        }

        [PunRPC]
        private void SyncScore(int points)
        {
            CoinsCollectedTMP.text = points.ToString();
        }

        private void UpdateSinglePlayerTMP(int points)
        {
            PlayerPoints += points;
            CoinsCollectedTMP.text = PlayerPoints.ToString();
        }

        private void Start()
        {
            PlayerPoints = 0;
        }
    }
}