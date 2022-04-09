using JetBrains.Annotations;
using LR.Core;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : SingletonMonoBehaviour<MapManager> {

    [field: SerializeField]
    public Tilemap Tilemap { get; [UsedImplicitly] private set; }

}
