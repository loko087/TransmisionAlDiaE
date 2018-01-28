using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECSpawnPrefab : EventCommand {
    [Tooltip("Game prefab to spawn.")]
    [SerializeField] GameObject spawn;
    [Tooltip("Position where the object will be spawned.")]
    [SerializeField] Vector3 position;
    [Tooltip("Is the position relative to an object or not?")]
    [SerializeField] bool relative;
    [Tooltip("Put here the instance to which the spawning will be relative to.")]
    [SerializeField] Transform referenceObject;

    public override void Execute() {
        if(spawn != null) Instantiate(spawn, SpawnPosition(), Quaternion.identity);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(SpawnPosition(), Vector3.one * .2f);
    }

    private Vector3 SpawnPosition() {
        if (referenceObject == null) referenceObject = transform;
        return relative ? (referenceObject.position + position) : position;
    }
}
