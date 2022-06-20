using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogSystem;

public class TestDialog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var phrase = XmlToDialog.ReadDialog(Application.streamingAssetsPath + "/Dialogs/Dialog.xml", "1");
        Debug.Log(phrase.Text);
        foreach (var item in phrase.answers)
        {
            ShowAnswer(item);
        }
    }

    private void ShowAnswer(Answer answer)
    {
        Debug.Log(answer.Text);

        if (answer.Next != null)
        {
            Debug.Log(answer.Next.Text);
            foreach (var item in answer.Next.answers)
            {
                ShowAnswer(item);
            }
        }
    }
}
