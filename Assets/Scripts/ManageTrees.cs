using LR.Core.Extensions;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ManageTrees : MonoBehaviour {

    private const int MaxOrder = 1000;

    [SerializeField]
    private Tilemap tilemap;

    [SerializeField, AssetsOnly, AssetSelector(Paths = "Assets/Prefabs/")]
    private GameObject treePrefab;

    [SerializeField, MinMaxSlider(0f, 1f)]
    private Vector2 maxDistanceFromCorner;

    [Button]
    public void PlaceTrees() {
        tilemap.CompressBounds();

        var width = tilemap.size.x;
        var height = tilemap.size.y;

        transform.DestroyChildren(true);

        for (var x = 0; x < width; x++) {
            for (var y = 0; y < height; y++) {
                var position = new Vector3(
                    x + Random.Range(maxDistanceFromCorner.x, maxDistanceFromCorner.y),
                    y + Random.Range(maxDistanceFromCorner.x, maxDistanceFromCorner.y)
                );

                var tree = Instantiate(treePrefab, position, Quaternion.identity, tilemap.transform);
                tree.name = "Tree";
            }
        }
        Sort();
    }

    [Button]
    public void Sort() {
        var renderers = transform.GetComponentsInChildren<SpriteRenderer>();

        foreach (var spriteRenderer in renderers) {
            var y = spriteRenderer.transform.position.y;

            spriteRenderer.sortingOrder = Mathf.RoundToInt(MaxOrder - y * 10f);
            spriteRenderer.GetComponentInChildren<ParticleSystemRenderer>().sortingOrder = spriteRenderer.sortingOrder + 1;
        }
    }

}
