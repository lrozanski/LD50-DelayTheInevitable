using LR.Core;
using LR.Core.Utils;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class TilePainter : SingletonMonoBehaviour<TilePainter> {

    [SerializeField, SceneObjectsOnly]
    private Tilemap tilemap;

    [SerializeField, AssetsOnly, AssetSelector(Paths = "Assets/Tiles")]
    private Ditch ditchTile;

    [SerializeField, SceneObjectsOnly]
    private GameObject gridUI;

    [SerializeField, SceneObjectsOnly]
    private GameObject tileSelection;

    private void Update() {
        var mouseWorldPosition = MouseUtils.WorldPosition;
        var cell = tilemap.WorldToCell(mouseWorldPosition);

        var hasTile = tilemap.HasTile(cell);
        gridUI.SetActive(hasTile);

        if (!hasTile) {
            return;
        }
        tileSelection.transform.position = tilemap.GetCellCenterWorld(cell);
        var tile = tilemap.GetTile<Tile>(cell);

        if (tile is Ditch || !Mouse.current.leftButton.wasPressedThisFrame) {
            return;
        }
        PlaceDitch(cell);
    }

    private void PlaceDitch(Vector3Int cell) {
        if (TreeManager.Instance.Trees.TryGetValue(cell, out var tree)) {
            TreeManager.Instance.Trees.Remove(cell);
            Destroy(tree.gameObject);
        }
        tilemap.SetTile(cell, ditchTile);
    }

}
