using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dialog {

    public string name;
    public Sprite speakerFace; // TO BE IMPLEMENTED. :^D

    [TextArea(3, 10)]
    public string[] sentences;
}
