using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public struct DialogData
{
    public string name;
    public string body;
}

public class Dialog : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text bodyText;

    public void DisplayDialog(DialogData dialogData)
    {
        nameText.text = dialogData.name;
        bodyText.text = dialogData.body;
    }
}
