using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECSetSwitch : EventCommand {
    [System.Serializable]
    public enum OperKind {
        EQUAL, TOGGLE
    }

    [Tooltip("Switch ID to change (refer to the GameState instance).")]
    [SerializeField] private int switchId;
    [Tooltip("Operation kind to be applied. EQUAL sets the value to the one provided. TOGGLE changes the actual value to its opposite (true->false, false->true).")]
    [SerializeField] private OperKind operation;
    [Tooltip("Value to be used at the EQUAL operation.")]
    [SerializeField] private bool value;

    public override void Execute() {
        switch(operation) {
            case OperKind.EQUAL:
                GameState.Instance.SetSwitch(switchId, value);
                break;
            case OperKind.TOGGLE:
                GameState.Instance.ToggleSwitch(switchId);
                break;
        }
    }
}
