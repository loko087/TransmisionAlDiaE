using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECCheckVariable : ECJumpToLabel {
    [System.Serializable]
    public enum OperKind {
        EQUAL, NOT, MORE_THAN, LESS_THAN, MORE_OR_EQUAL, LESS_OR_EQUAL
    }

    [Tooltip("Variable ID to check (refer to the GameState instance).")]
    [SerializeField] private int varId;
    [Tooltip("Comparation to apply between the value stored inside variable and the value provided.")]
    [SerializeField] private OperKind check;
    [Tooltip("Value provided to be used at the compare.")]
    [SerializeField] private int value;

    public override void Execute() {
        switch(check) {
            case OperKind.EQUAL:
                returnValue = (GameState.Instance.GetVar(varId) == value);
                break;
            case OperKind.NOT:
                returnValue = (GameState.Instance.GetVar(varId) != value);
                break;
            case OperKind.MORE_THAN:
                returnValue = (GameState.Instance.GetVar(varId) > value);
                break;
            case OperKind.LESS_THAN:
                returnValue = (GameState.Instance.GetVar(varId) < value);
                break;
            case OperKind.MORE_OR_EQUAL:
                returnValue = (GameState.Instance.GetVar(varId) >= value);
                break;
            case OperKind.LESS_OR_EQUAL:
                returnValue = (GameState.Instance.GetVar(varId) <= value);
                break;
            default:
                returnValue = false;
                break;
        }
    }
}
