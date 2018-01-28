using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECJumpToLabel : EventCommand {
    [Tooltip("Identifier to search and go to within the event command order.")]
    [SerializeField] protected string label;
    public bool returnValue = true;

    public bool CompareToLabel(ECLabel other) {
        return label.Equals(other.Label());
    }
}
