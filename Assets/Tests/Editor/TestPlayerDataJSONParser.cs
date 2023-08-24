using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core.Management.DataManagement;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayerDataJSONParser
{
    [Test]
    public void TestPlayerDataJSONParserReturnsNotNull()
    {
        int result = PlayerDataJSONParser.GetBestScore();
        Assert.IsNotNull(result);
    }
}
