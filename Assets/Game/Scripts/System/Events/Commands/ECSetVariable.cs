using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECSetVariable : EventCommand {
    [System.Serializable]
    public enum OperKind {
        EQUAL, SUM, REST, MULTIPLY, DIVISION, MODULUS
    }

    [SerializeField] private int varId;
    [SerializeField] private OperKind operation;
    [SerializeField] private int value;

    public override void Execute() {
        switch(operation) {
            case OperKind.EQUAL:
                GameState.instance.SetVar(varId, value);
                break;
            case OperKind.SUM:
                GameState.instance.ChangeVar(varId, value);
                break;
            case OperKind.REST:
                GameState.instance.ChangeVar(varId, -value);
                break;
            case OperKind.MULTIPLY:
                GameState.instance.MultVar(varId, value);
                break;
            case OperKind.DIVISION:
                GameState.instance.DivVar(varId, value);
                break;
            case OperKind.MODULUS:
                GameState.instance.ModVar(varId, value);
                break;
        }
    }
}
