namespace Assets.Scripts.Core.Management.CoinManagement
{
    using TMPro;
    using UnityEngine;
    
    public class UICoinPointsCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentCoinsPointsTMP;


        public void UpdateUICountPoints(int points)
        {
            _currentCoinsPointsTMP.text = points.ToString();
        }

    }
}