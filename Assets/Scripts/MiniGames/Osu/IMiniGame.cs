using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiniGames
{
    public interface IMiniGame
    {
        public event System.Action<bool> GameOverEvent;
    }
}