using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ECTeleport : EventCommand {
    [SerializeField] private string sceneName;
    [SerializeField] private int doorId;

    public override void Execute() {
        GameState.Instance.warpId = doorId;
        SceneManager.LoadScene(sceneName);
    }
}
