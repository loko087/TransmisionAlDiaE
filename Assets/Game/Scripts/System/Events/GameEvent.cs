using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour {
    [SerializeField] private EventCommand[] commands;
    private int index;

    private void OnTriggerEnter2D(Collider2D collision) {
        print("Collided with something.");
        PlayerInteract playerInteract = collision.gameObject.GetComponent<PlayerInteract>();
        if(playerInteract != null) {
            Debug.Log("found playerInteract");
            if (playerInteract.SubscribeEvent(this)) InitializeEvent();
        }
    }
    
    private void InitializeEvent() {
        index = 0;
    }

    public bool AdvanceEvent() {
        if(index < commands.Length) {
            commands[index].Execute();
            index++;
            return true;
        }
        return false;
    }
}
