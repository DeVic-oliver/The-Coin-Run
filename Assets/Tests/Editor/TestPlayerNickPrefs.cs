using Assets.Scripts.Core.Services.Prefs;
using NUnit.Framework;
using UnityEngine;

public class TestPlayerNickPrefs
{
    [Test]
    public void TestPlayerNickPrefCreatePrefItNotExists()
    {
        PlayerPrefs.DeleteKey("player_nick");

        string defaultNick = "BigBoy";
        string result = PlayerNickPref.GetPlayerNickPref();

        Assert.AreEqual(defaultNick, result);
    }

    [Test]
    public void TestPlayerNickPrefNeverNull()
    {
        PlayerPrefs.DeleteKey("player_nick");
        string result = PlayerNickPref.GetPlayerNickPref();
        Assert.IsNotNull(result);
    }
    
}
