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

    private void Update() {
        var mouseWorldPosition = MouseUtils.WorldPosition;
        var cell = tilemap.WorldToCell(mouseWorldPosition);

        if (!tilemap.HasTile(cell)) {
            return;
        }
        var tile = tilemap.GetTile<Tile>(cell);

        if (tile is Ditch || !Mouse.current.leftButton.wasPressedThisFrame) {
            return;
        }
        tilemap.SetTile(cell, ditchTile);
    }

}
