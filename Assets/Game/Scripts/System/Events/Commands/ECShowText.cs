using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECShowText : EventCommand {
    [SerializeField] string text;

    public override void Execute() {
        Debug.Log(text);
        GameState.instance.eventWait = true;
        StartCoroutine("ShowText");
    }

    IEnumerator ShowText() {
        Debug.Log("Waiting for event command to end arbitrarily.");
        float endTime = Time.time + 5.0f;
        while(endTime > Time.time) yield return null;
        GameState.instance.eventWait = false;
        Debug.Log("A second passed, you can continue.");
    }
}
