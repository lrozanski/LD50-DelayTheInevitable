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

    public HashSet<Tree> TreesOnFire { get; private set; }

    private void Start() {
        var trees = FindObjectsOfType<Tree>();

        foreach (var tree in trees) {
            var cell = tilemap.WorldToCell(tree.transform.position);

            Trees.Add(cell, tree);
        }
        TreesOnFire = new HashSet<Tree>(trees.Length);
    }

    public bool IsTreeOnFire(Vector3Int cell) => Trees[cell].IsOnFire;
    public void AddFireTick(Vector3Int cell) {
        var tree = Trees[cell];
        tree.AddFireTick();
        
        if (tree.IsOnFire) {
            TreesOnFire.Add(tree);
            tree.StartFire();
        }
    }

}
