using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECSetVariable : EventCommand {
    [System.Serializable]
    public enum OperKind {
        EQUAL, SUM, REST, MULTIPLY, DIVISION, MODULUS
    }

    [Tooltip("Variable ID to be changed (refer to the GameState instance).")]
    [SerializeField] private int varId;
    [Tooltip("Operation to be applied, either EQUAL, SUM (+), REST (-), MULTIPLY (*), DIVISION (/) and MODULUS (%).")]
    [SerializeField] private OperKind operation;
    [Tooltip("Value to be used when evaluating the change.")]
    [SerializeField] private int value;

    public override void Execute() {
        switch(operation) {
            case OperKind.EQUAL:
                GameState.Instance.SetVar(varId, value);
                break;
            case OperKind.SUM:
                GameState.Instance.ChangeVar(varId, value);
                break;
            case OperKind.REST:
                GameState.Instance.ChangeVar(varId, -value);
                break;
            case OperKind.MULTIPLY:
                GameState.Instance.MultVar(varId, value);
                break;
            case OperKind.DIVISION:
                GameState.Instance.DivVar(varId, value);
                break;
            case OperKind.MODULUS:
                GameState.Instance.ModVar(varId, value);
                break;
        }
    }
}
