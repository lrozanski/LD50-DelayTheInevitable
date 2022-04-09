using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tiles/Ditch")]
public class Ditch : Tile {

    [SerializeField, MaxValue(nameof(fireThresholdMax))]
    private float fireThreshold;

    [SerializeField, MinValue(nameof(fireThreshold))]
    private float fireThresholdMax;

}
