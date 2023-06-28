using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//Text sizes and text lists
[Serializable]
public struct DialogData
{
    public string name;
    [TextArea(10,10)]
    public List<string> body;
}

public class Dialog : MonoBehaviour
{
    public int pageNumber = 0;

    private DialogData _dialogData;

    //Text, buttons & gameobject paramaters
    public TMP_Text nextText;
    public TMP_Text prevText;
    public TMP_Text nameText;
    public TMP_Text bodyText;
    public Button nextButton;
    public Button prevButton;
    public GameObject dialogPanel;

    //On start get object
    private void Start()
    {
        dialogPanel = GameObject.Find("Dialog GUI");
    }

    //Dialog pages and text
    public void DisplayDialog(DialogData dialogData)
    {
        _dialogData = dialogData;
        pageNumber = 0;
        nameText.text = dialogData.name;
        bodyText.text = dialogData.body[pageNumber];
    }

    //Buttons can control the dialog
    //Buttons are interactable
    //Button text disapears once it can't be pressed
    public void NextPage()
    {
        if (pageNumber + 1 < _dialogData.body.Count)
        {
            pageNumber++;
            prevButton.interactable = true;
            prevText.text = "Previous (Q)";

        }
        else
        {
            if(nextButton != null)
            {
                nextButton.interactable = false;
                nextText.text = " ";
            }
        }

        bodyText.text = _dialogData.body[pageNumber];
    }
    public void PreviousPage()
    {
        if (pageNumber - 1 >= 0)
        {
            pageNumber--;
            nextButton.interactable = true;
            nextText.text = "Next (E)";

        }
        else
        {
            if (prevButton != null)
            {
                prevButton.interactable = false;
                prevText.text = " ";
            }
        }

        bodyText.text = _dialogData.body[pageNumber];
    }

    //Exit dialog
    public void ExitDialog()
    {
        dialogPanel.SetActive(false);
    }

    //Another key can control the dialog
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextPage();
            Debug.Log("E key was pressed");
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PreviousPage();
            Debug.Log("Q key was pressed");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ExitDialog();
            Debug.Log("X key was pressed");
        }

    }
}
