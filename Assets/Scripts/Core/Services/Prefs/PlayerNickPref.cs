namespace Assets.Scripts.Core.Services.Prefs
{
    using UnityEngine;
    using WebSocketSharp;

    public static class PlayerNickPref
    {
        private static readonly string _prefID = "player_nick";
        private static string _defaultNick = "BigBoy";


        public static void SaveNickPref(string nick)
        {
            string nickName = (nick.IsNullOrEmpty()) ? _defaultNick : nick;
            PlayerPrefs.SetString(_prefID, nickName);
        }

        public static string GetPlayerNickPref()
        {
            return (PlayerPrefs.HasKey(_prefID)) ? PlayerPrefs.GetString(_prefID) : SetPrefDefaultNickThenGetIt();
        }

        private static string SetPrefDefaultNickThenGetIt()
        {
            PlayerPrefs.SetString(_prefID, _defaultNick);
            return _defaultNick;
        }

    }
}