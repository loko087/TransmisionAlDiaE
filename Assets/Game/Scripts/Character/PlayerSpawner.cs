using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    [SerializeField] private int id;

    public static Vector3 GetRespawnById(int id) {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Respawn");
        foreach(GameObject go in spawners) {
            PlayerSpawner spawn = go.GetComponent<PlayerSpawner>();
            if(spawn != null) {
                if (spawn.id == id) return spawn.transform.position;
            }
        }
        return Vector3.zero;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawIcon(transform.position, "SpawnPoint");
    }
}
