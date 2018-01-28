using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameVariable {
    public string name;
    public int value;
}
[System.Serializable]
public class GameSwitch {
    public string name;
    public bool value;
}

public class GameState : MonoBehaviour {
    private static GameState m_Instance;
    public static GameState Instance {
        get {
            if (m_Instance == null) m_Instance = FindObjectOfType<GameState>();
            return m_Instance;
        }
    }
    
    private void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        m_Instance = this;
    }

    public bool eventWait;
    public bool isMessageOpen;
    [SerializeField] private GameVariable[] variables;
    [SerializeField] private GameSwitch[] switches;

    // Variable operations
    public int GetVar(int id) {
        if (id < 0 || id >= variables.Length) return 0;
        return variables[id].value;
    }
    public int GetVar(string name) {
        foreach(GameVariable var in variables) {
            if (var.name.Equals(name)) return var.value;
        }
        return 0;
    }
    public void SetVar(int id, int value) {
        if (id >= 0 && id < variables.Length) {
            variables[id].value = value;
        }
    }
    public void SetVar(string name, int value) {
        foreach (GameVariable var in variables) {
            if (var.name.Equals(name)) {
                var.value = value;
            }
        }
    }
    public void ChangeVar(int id, int value) {
        if (id >= 0 && id < variables.Length) {
            variables[id].value += value;
        }
    }
    public void ChangeVar(string name, int value) {
        foreach (GameVariable var in variables) {
            if (var.name.Equals(name)) {
                var.value += value;
            }
        }
    }
    public void MultVar(int id, int value) {
        if (id >= 0 && id < variables.Length) {
            variables[id].value *= value;
        }
    }
    public void DivVar(int id, int value) {
        if (id >= 0 && id < variables.Length) {
            variables[id].value /= value;
        }
    }
    public void ModVar(int id, int value) {
        if (id >= 0 && id < variables.Length) {
            variables[id].value %= value;
        }
    }

    // Switch operations
    public bool GetSwitch(int id) {
        if (id < 0 || id >= switches.Length) return false;
        return switches[id].value;
    }
    public bool GetSwitch(string name) {
        foreach (GameSwitch sw in switches) {
            if (sw.name.Equals(name)) return sw.value;
        }
        return false;
    }
    public void SetSwitch(int id, bool value) {
        if (id >= 0 && id < switches.Length) {
            switches[id].value = value;
        }
    }
    public void SetSwitch(string name, bool value) {
        foreach (GameSwitch sw in switches) {
            if (sw.name.Equals(name)) {
                sw.value = value;
            }
        }
    }
    public void ToggleSwitch(int id) {
        if (id >= 0 && id < switches.Length) {
            switches[id].value = !switches[id].value;
        }
    }
    public void ToggleSwitch(string name) {
        foreach (GameSwitch sw in switches) {
            if (sw.name.Equals(name)) {
                sw.value = !sw.value;
            }
        }
    }
}
