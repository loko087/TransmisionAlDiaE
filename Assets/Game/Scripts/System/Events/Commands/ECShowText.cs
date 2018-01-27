using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECShowText : EventCommand {

    public Dialog dialog;

    public override void Execute() {
        GameState.instance.eventWait = true;
        StartCoroutine("ShowText");
    }

    IEnumerator ShowText() {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
        float endTime = Time.time + 5.0f;
        while(endTime > Time.time) yield return null;
        GameState.instance.eventWait = false;
        Debug.Log("A second passed, you can continue.");
    }
}
