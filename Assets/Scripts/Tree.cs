using Sirenix.OdinInspector;
using UnityEngine;

public class Tree : MonoBehaviour {

    [SerializeField, ChildGameObjectsOnly]
    private ParticleSystem fireParticles;

    [SerializeField, MaxValue(nameof(fireThresholdMax))]
    private float fireThreshold;

    [SerializeField, MinValue(nameof(fireThreshold))]
    private float fireThresholdMax;

    public Vector3Int TileCell { get; private set; }

    public bool IsOnFire => fireThreshold >= fireThresholdMax;

    private void Start() {
        TileCell = MapManager.Instance.Tilemap.WorldToCell(transform.position);

        // if (Random.Range(0, 10) == 3) {
        //     StartFire();
        // }
    }

    public void AddFireTick(int tickValue) => fireThreshold = Mathf.Min(fireThreshold + tickValue, fireThresholdMax);

    #region Buttons

    [Button]
    public void StartFire() {
        fireParticles.Play();
        TreeManager.Instance.TreesOnFire.Add(this);
    }

    #endregion

}
