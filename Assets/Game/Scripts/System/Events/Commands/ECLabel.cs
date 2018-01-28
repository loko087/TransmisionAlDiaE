using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECLabel : EventCommand {
    [Tooltip("Identifier for this label command. This is used for any other 'jump label' kind command to find this command and continue from where it is.")]
    [SerializeField] private string label;
    public string Label() {
        return label;
    }
}
