using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour {
    [SerializeField] private EventCondition condition;
    [SerializeField] private EventCommand[] commands;
    [SerializeField] private bool activated;
    private int index;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!activated)
        {
            return;
        }
        print("Collided with something.");
        PlayerInteract playerInteract = collision.gameObject.GetComponent<PlayerInteract>();
        if(playerInteract != null) {
            Debug.Log("found playerInteract");
            if (playerInteract.SubscribeEvent(this)) InitializeEvent();
        }
    }
    
    public void InitializeEvent() {
        index = 0;
    }

    public bool AdvanceEvent() {
        if(index < commands.Length) {
            commands[index].Execute();
            if(commands[index] is ECJumpToLabel) {
                ECJumpToLabel jump = (ECJumpToLabel)commands[index];
                if (jump.returnValue) index = JumpToLabel(jump);
            }
            index++;
            return true;
        }
        return false;
    }

    public int JumpToLabel(ECJumpToLabel jump) {
        for(int i = 0; i < commands.Length; i++) {
            if(commands[i] is ECLabel) {
                ECLabel label = (ECLabel) commands[i];
                if (jump.CompareToLabel(label)) return i;
            }
        }
        return index;
    }
}
