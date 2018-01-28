using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECSetSwitch : EventCommand {
    [System.Serializable]
    public enum OperKind {
        EQUAL, TOGGLE
    }

    [SerializeField] private int varId;
    [SerializeField] private OperKind operation;
    [SerializeField] private bool value;

    public override void Execute() {
        switch(operation) {
            case OperKind.EQUAL:
                GameState.instance.SetSwitch(varId, value);
                break;
            case OperKind.TOGGLE:
                GameState.instance.ToggleSwitch(varId);
                break;
        }
    }
}
