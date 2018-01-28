using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECDespawn : EventCommand {
    [Tooltip("Object to despawn (do not put prefabs here). If this value is nil (missing or unnassigned) it'll do nothing.")]
    [SerializeField] GameObject despawn;

    public override void Execute() {
        if (despawn != null) Destroy(despawn);
    }
}
