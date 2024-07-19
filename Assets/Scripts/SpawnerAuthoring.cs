using UnityEngine;
using Unity.Entities;

public class SpawnerAuthoring : MonoBehaviour
{
    public GameObject Prefab;
    public float SpawnRate;
}

public class SpwanerBaker : Baker<SpawnerAuthoring>
{
    public override void Bake(SpawnerAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.None);
        AddComponent(entity, new Spawner
        {
            Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
            SpawnPosition = authoring.transform.position,
            NextSpawnTime = 0,
            SpawnRate = authoring.SpawnRate
        });
    }
}
