using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECSetActive : EventCommand {
    [SerializeField] GameObject targetObject;
    [SerializeField] bool value;
    [SerializeField] int switchId = -1;

    public override void Execute() {
        if (switchId >= 0) targetObject.SetActive(GameState.Instance.GetSwitch(switchId));
        else targetObject.SetActive(value);
    }
}
