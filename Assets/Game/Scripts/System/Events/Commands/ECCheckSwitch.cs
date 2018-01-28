using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECCheckSwitch : ECJumpToLabel {
    [System.Serializable]
    public enum OperKind {
        EQUAL, NOT
    }

    [Tooltip("Switch ID to affect (refer to the GameState instance).")]
    [SerializeField] private int switchId;
    [Tooltip("If set to EQUAL, compares switch state to the value provided. If NOT, compares it to its opposite.")]
    [SerializeField] private OperKind check;
    [Tooltip("Value to compare the Switch ID provided with.")]
    [SerializeField] private bool value;

    public override void Execute() {
        switch(check) {
            case OperKind.EQUAL:
                returnValue = GameState.Instance.GetSwitch(switchId) == value;
                break;
            case OperKind.NOT:
                returnValue = GameState.Instance.GetSwitch(switchId) != value;
                break;
            default:
                returnValue = false;
                break;
        }
    }
}
