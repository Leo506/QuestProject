using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUseButton : MonoBehaviour
{
    [SerializeField] GameObject btnObj;

    // Start is called before the first frame update
    void Start()
    {
        Player.PlayerLogic.OnSetUsableObj += ShowButton;
        Player.PlayerLogic.OnUnsetUsableObj += HideButton;
    }

    private void HideButton()
    {
        btnObj.SetActive(false);
    }

    private void ShowButton()
    {
        btnObj.SetActive(true);
    }

    private void OnDestroy()
    {
        Player.PlayerLogic.OnSetUsableObj -= ShowButton;
        Player.PlayerLogic.OnUnsetUsableObj -= HideButton;
    }
}
