using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Tree : MonoBehaviour {

    [SerializeField, ChildGameObjectsOnly]
    private ParticleSystem fireParticles;

    private Vector3Int tileCell;

    private void Start() {
        tileCell = MapManager.Instance.Tilemap.WorldToCell(transform.position);

        if (Random.Range(0, 10) == 3) {
            StartFire();
        }
    }

    public void SpreadFire() {
        var queue = new Queue<Vector3Int>();
        var start = tileCell;
    }

    #region Buttons

    [Button]
    public void StartFire() {
        fireParticles.Play();
    }

    #endregion

}
