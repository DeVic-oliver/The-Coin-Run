namespace Assets.Scripts.Core.Management.DataManagement
{
    using TMPro;
    using UnityEngine;
    
    public class JSONDataManagerGateway : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _bestScoreTMP;


        public void SavePlayerBestScore(int currentGameTotalScore)
        {
            PlayerDataJSONParser.SaveBestscore(currentGameTotalScore);
        }

        private void Awake()
        {
            UpdateBestScoreTMP();
        }

        public void UpdateBestScoreTMP()
        {
            int previousScore = PlayerDataJSONParser.GetBestScore();
            _bestScoreTMP.text = previousScore.ToString();
        }

    }
}