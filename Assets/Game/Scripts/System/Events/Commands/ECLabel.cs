using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECLabel : EventCommand {
    [SerializeField] private string label;
    public string Label() {
        return label;
    }
}
