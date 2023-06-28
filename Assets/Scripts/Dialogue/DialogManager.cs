using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//Dialog paramaters
public class DialogManager : MonoBehaviour
{


    [Header("GUI reference")]
    [Tooltip("Cancas with dialog script attached")]
    [SerializeField]
    private Transform _dialogGUI;

    [SerializeField]
    private DialogText currentDialog;


    private void Start()
    {
        Dialog dialog = _dialogGUI.GetComponent<Dialog>();

        /*DialogData data = new DialogData();
        data.name = "Test Name";
        data.body = "Hello, my name is Test Name";*/

        dialog.DisplayDialog(currentDialog.text);
    }


}
