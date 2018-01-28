using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This event command is the simplest one, it makes the event wait for a little bit.
 */
public class ECWait : EventCommand {
    public float waitTime;

    public override void Execute() {
        GameState.instance.eventWait = true;
        StartCoroutine("Wait");
    }

    IEnumerator Wait() {
        float endTime = Time.time + waitTime;
        while (endTime > Time.time) yield return null;
        GameState.instance.eventWait = false;
    }
}
