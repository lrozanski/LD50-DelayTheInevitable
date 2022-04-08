using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tree : MonoBehaviour {

    [SerializeField, ChildGameObjectsOnly]
    private ParticleSystem fireParticles;

    [Button]
    public void StartFire() {
        fireParticles.Play();
    }

    private void Start() {
        if (Random.Range(0, 10) == 3) {
            StartFire();
        }
    }

}
