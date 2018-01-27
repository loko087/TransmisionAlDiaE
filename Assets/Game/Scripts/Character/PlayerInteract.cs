using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
    List<GameEvent> activeEvents;

    private void Start() {
        activeEvents = new List<GameEvent>();
    }

    public bool SubscribeEvent(GameEvent newEvent) {
        if(!activeEvents.Contains(newEvent)) {
            activeEvents.Add(newEvent);
            return true;
        }
        return false;
    }

    private void Update() {
        if (GameState.instance.eventWait) return;
        if (activeEvents.Count > 0) {
            GameEvent activeEvent = activeEvents[0];
            if (activeEvent.AdvanceEvent()) return;
            activeEvents.Remove(activeEvent);
            // Skip input until it encounters no active events.
            return;
        }
    }
}
