using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventCondition : MonoBehaviour {
    [System.Serializable] public enum ValueKind { VARIABLE, SWITCH }
    
    public ValueKind valueKind;
    public int valueId;
    public ECCheckVariable.OperKind varOper;
    public ECCheckSwitch.OperKind switchOper;
    public int valueVar;
    public bool valueSwitch;

    public bool PerformCheck() {
        switch (valueKind) {
            case ValueKind.VARIABLE:
                return CheckForVariable();
            case ValueKind.SWITCH:
                return CheckForSwitch();
        }
        return false;
    }

    public bool CheckForVariable() {
        switch(varOper) {
            case ECCheckVariable.OperKind.EQUAL:
                return GameState.Instance.GetVar(valueId) == valueVar;
            case ECCheckVariable.OperKind.NOT:
                return GameState.Instance.GetVar(valueId) != valueVar;
            case ECCheckVariable.OperKind.MORE_THAN:
                return GameState.Instance.GetVar(valueId) > valueVar;
            case ECCheckVariable.OperKind.LESS_THAN:
                return GameState.Instance.GetVar(valueId) < valueVar;
            case ECCheckVariable.OperKind.MORE_OR_EQUAL:
                return GameState.Instance.GetVar(valueId) >= valueVar;
            case ECCheckVariable.OperKind.LESS_OR_EQUAL:
                return GameState.Instance.GetVar(valueId) <= valueVar;
        }
        return false;
    }

    public bool CheckForSwitch() {
        switch(switchOper) {
            case ECCheckSwitch.OperKind.EQUAL:
                return GameState.Instance.GetSwitch(valueId) == valueSwitch;
            case ECCheckSwitch.OperKind.NOT:
                return GameState.Instance.GetSwitch(valueId) != valueSwitch;
        }
        return false;
    }

    private void Awake() {
        if(!PerformCheck()) {
            gameObject.SetActive(false);
        }
    }
}
