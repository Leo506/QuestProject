using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Player;
using UnityEngine.InputSystem;

public class PlayerLogicTests : InputTestFixture
{
    
    [Test]
    public void UseObjectSuccess()
    {
        var playerObj = new GameObject();
        var player = playerObj.AddComponent<PlayerLogic>();

        var testUseObj = new GameObject();
        var testUse = testUseObj.AddComponent<TestUsableClass>();

        player.SetUsableObj(testUse);

        player.UseObj();

        Assert.IsTrue(testUse.Used);
    }

    [Test]
    public void DieEventInvokeSuccess()
    {
        var playerObj = new GameObject();
        var player = playerObj.AddComponent<PlayerLogic>();

        PlayerLogic.PlayerDiedEvent += OnPlayerDie;

        player.Die();
    }


    [Test]
    public void UseWhenUseKeyDown()
    {
        var input = new PlayerInput();
        var player = new GameObject().AddComponent<PlayerLogic>();
        var testUse = new GameObject().AddComponent<TestUsableClass>();
        player.SetUsableObj(testUse);

        var keyboard = InputSystem.AddDevice<Keyboard>();

        Press(keyboard.eKey);

        Assert.IsTrue(testUse.Used);
    }


    [Test]
    public void SetUsableObjEventInvokeSuccess()
    {
        var player = new GameObject().AddComponent<PlayerLogic>();
        var testUse = new GameObject().AddComponent<TestUsableClass>();

        bool processed = false;
        PlayerLogic.OnSetUsableObj += () => processed = true;

        player.SetUsableObj(testUse);

        Assert.IsTrue(processed);
    }


    [Test]
    public void UnsetUsableObjetEventInvokeSuccess()
    {
        var player = new GameObject().AddComponent<PlayerLogic>();
        var testUse = new GameObject().AddComponent<TestUsableClass>();

        bool processed = false;
        PlayerLogic.OnUnsetUsableObj += () => processed = true;

        player.SetUsableObj(testUse);
        player.UseObj();

        Assert.IsTrue(processed);
    }


    [Test]
    public void UnsetUsableObjectSuccess()
    {
        var player = new GameObject().AddComponent<PlayerLogic>();
        var testUse = new GameObject().AddComponent<TestUsableClass>();

        player.SetUsableObj(testUse);
        player.UnsetUsableObj();

        player.UseObj();

        Assert.IsFalse(testUse.Used);
        
    }

    private void OnPlayerDie()
    {
        Assert.IsTrue(true);
    }


    class TestUsableClass : MonoBehaviour, IUsable
    {
        public bool Used = false;
        public void Use()
        {
            Used = true;
        }
    }
}
