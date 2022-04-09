using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using LR.Core;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FireUpdater : SingletonMonoBehaviour<FireUpdater> {

    private readonly Queue<Vector3Int> open = new();
    private readonly HashSet<Vector3Int> visited = new();

    [SerializeField, PropertyRange(1, 10_000)]
    private int tickInterval = 1000;

    private void Start() => SpreadFire().Forget();

    private async UniTaskVoid SpreadFire() {
        var tilemap = MapManager.Instance.Tilemap;

        while (UniTask.CompletedTask.Status.IsCompleted()) {
            foreach (var tree in TreeManager.Instance.TreesOnFire) {
                open.Enqueue(tree.TileCell);
            }

            while (open.Count > 0) {
                var current = open.Dequeue();
                visited.Add(current);

                AddFireToCell(current + Vector3Int.up, tilemap);
                AddFireToCell(current + Vector3Int.right, tilemap);
                AddFireToCell(current + Vector3Int.down, tilemap);
                AddFireToCell(current + Vector3Int.left, tilemap);
            }
            open.Clear();
            visited.Clear();

            await UniTask.Delay(tickInterval);
        }
    }

    private void AddFireToCell(Vector3Int targetCell, Tilemap tilemap) {
        if (visited.Contains(targetCell) || !tilemap.HasTile(targetCell)) {
            return;
        }
        TreeManager.Instance.AddFireTick(targetCell);
        visited.Add(targetCell);
    }

}
