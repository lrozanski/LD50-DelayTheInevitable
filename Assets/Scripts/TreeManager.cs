using System.Collections.Generic;
using LR.Core;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TreeManager : SingletonMonoBehaviour<TreeManager> {

    [SerializeField, SceneObjectsOnly]
    private Tilemap tilemap;

    [ShowInInspector]
    public Dictionary<Vector3Int, Tree> Trees { get; } = new();

    private void Start() {
        var trees = FindObjectsOfType<Tree>();

        foreach (var tree in trees) {
            var cell = tilemap.WorldToCell(tree.transform.position);

            Trees.Add(cell, tree);
        }
    }

}
