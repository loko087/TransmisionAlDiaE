using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECShowText : EventCommand {

    [Tooltip("Dialog to be shown. Fill in details for sentences and locutor properties.")]
    public Dialog dialog;

    public override void Execute() {
        GameState.Instance.eventWait = true;
        StartCoroutine("ShowText");
    }

    IEnumerator ShowText() {
        DialogManager dMan = FindObjectOfType<DialogManager>();
        dMan.StartDialog(dialog);
        while(dMan.IsDialogOpen) yield return null;
        GameState.Instance.eventWait = false;
        Debug.Log("Dialog concluded.");
    }
}
