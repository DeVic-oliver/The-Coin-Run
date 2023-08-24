using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core.Services;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestTimeFormatter
{
    [Test]
    public void TestTimeFormatterReturnsString()
    {
        float time = 120;
        string result = TimeFormatter.GetTimeFormated(time);

        Assert.IsInstanceOf<string>(result);
    }

    [Test]
    public void TestTimeFormatterReturnsMinutesSecondsFormat()
    {
        string expect = "02:00";

        float time = 120;
        string result = TimeFormatter.GetTimeFormated(time);

        Assert.AreEqual(expect, result);
    }
}
