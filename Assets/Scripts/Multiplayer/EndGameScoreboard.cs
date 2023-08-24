namespace Assets.Scripts.Multiplayer
{
    using TMPro;
    using UnityEngine;

    public class EndGameScoreboard : MonoBehaviour
    {
        [SerializeField] private GameObject _scoreBoardPanel;
        [SerializeField] private GameObject _drawPanel;
        [SerializeField] private TextMeshProUGUI _winnerNick;
        [SerializeField] private TextMeshProUGUI _winnerPoints;
        [SerializeField] private TextMeshProUGUI _loserNick;
        [SerializeField] private TextMeshProUGUI _loserPoints;

        private AstronautCompetitor _master;
        private AstronautCompetitor _guest;


        public void SetTheWinnderAndLoser(AstronautCompetitor master, AstronautCompetitor guest)
        {
            _master = master;
            _guest = guest;

            if (_master.Points == _guest.Points)
                _drawPanel.SetActive(true);
            else
                SetScoreBoardActiveThenSetWinnerAndLoser();
        }

        private void SetScoreBoardActiveThenSetWinnerAndLoser()
        {
            _scoreBoardPanel.SetActive(true);

            if (_master.Points > _guest.Points)
                SetMasterWinnerAndGuestLoser();

            if (_master.Points < _guest.Points)
                SetGuestWinnerAndMasterLoser();
        }

        private void SetMasterWinnerAndGuestLoser()
        {
            _winnerNick.text = _master.Nick;
            _winnerPoints.text = GetString(_master.Points);

            _loserNick.text = _guest.Nick;
            _loserPoints.text = GetString(_guest.Points);
        }

        private void SetGuestWinnerAndMasterLoser()
        {
            _winnerNick.text = _guest.Nick;
            _winnerPoints.text = GetString(_guest.Points);

            _loserNick.text = _master.Nick;
            _loserPoints.text = _master.Points.ToString();
        }

        private string GetString(int number)
        {
            return number.ToString();
        }
    }
}