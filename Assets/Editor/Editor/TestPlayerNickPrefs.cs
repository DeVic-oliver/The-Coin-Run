using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core.Services.Prefs;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayerNickPrefs
{
    [Test]
    public void TestPlayerNickPrefIsNotNull()
    {
        string result = PlayerNickPref.GetPlayerNickPref();
        Assert.IsNotNull(result);
    }
}
