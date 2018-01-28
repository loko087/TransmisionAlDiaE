using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSelfDestroy : MonoBehaviour {
    [SerializeField] ParticleSystem particles;

	void Update () {
        if (particles == null) return;
        if (!particles.IsAlive()) Destroy(gameObject);
	}
}
