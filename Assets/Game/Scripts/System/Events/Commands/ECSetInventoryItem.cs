using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECSetInventoryItem : EventCommand {
    [Tooltip("Switch ID to change (refer to the GameState instance).")]
    [SerializeField] private int switchId;

    public override void Execute() {
        GameState.Instance.SetInventoryItem(switchId);
    }
}
