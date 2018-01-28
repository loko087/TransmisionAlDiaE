using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECCheckSwitch : ECJumpToLabel {
    [System.Serializable]
    public enum OperKind {
        EQUAL, NOT
    }

    [SerializeField] private int switchId;
    [SerializeField] private OperKind check;
    [SerializeField] private bool value;

    public override void Execute() {
        switch(check) {
            case OperKind.EQUAL:
                returnValue = GameState.instance.GetSwitch(switchId) == value;
                break;
            case OperKind.NOT:
                returnValue = GameState.instance.GetSwitch(switchId) != value;
                break;
            default:
                returnValue = false;
                break;
        }
    }
}
