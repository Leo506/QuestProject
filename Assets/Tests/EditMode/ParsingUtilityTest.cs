using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using QuestLanguage;

public class ParsingUtilityTest
{
    [Test]
    public void GetValueFromStringSuccess()
    {
        string str = "name MyName age 20 height 198,23 bool true";
        ParsingUtility utility = new ParsingUtility(str);

        Assert.AreEqual("MyName", utility.GetValue<string>("name"));
        Assert.AreEqual(20, utility.GetValue<int>("age"));
        Assert.AreEqual(198.23f, utility.GetValue<float>("height"));
        Assert.IsTrue(utility.GetValue<bool>("bool"));
    }


    [Test]
    public void GetNotExistValueFromStringFailed()
    {
        string str = "name MyName";

        ParsingUtility utility = new ParsingUtility(str);

        bool processed = false;

        try
        {
            utility.GetValue<string>("nameeeee");
        }
        catch (System.InvalidOperationException)
        {
            processed = true;
        }

        Assert.IsTrue(processed);
    }


    [Test]
    public void GetSomeValuesFromStringSuccess()
    {
        string str = "id 0 1 2";

        ParsingUtility utility = new ParsingUtility(str);

        var result = utility.GetValues<int>("id", 3);

        var expected = new int[] { 0, 1, 2 };

        Assert.AreEqual(expected, result);
    }
}
