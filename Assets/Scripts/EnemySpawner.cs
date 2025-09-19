// EnemySpawner.cs
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Prefabs & Transforms")]
    public GameObject zombiePrefab;
    public GameObject lionPrefab;
    public GameObject spiderPrefab;
    public GameObject horsePrefab;
    public GameObject bossmonsterPrefab;

    public Transform spawnPoint;
    public Transform pathPoint1;
    public Transform pathPoint2;
    public Transform endPoint;

    [Header("Spawn Settings")]
    public float spawnHeight = 5.5f;
    public float spawnInterval = 2f;

    [Header("Per-Wave Limits")]
    public int maxZombieCount = 5;
    public int maxLionCount = 3;
    public int maxSpiderCount = 2;
    public int maxHorseCount = 1;
    public int maxBossMonsterCount = 1;

    private int zombieSpawnCount;
    private int lionSpawnCount;
    private int spiderSpawnCount;
    private int horseSpawnCount;
    private int bossmonsterSpawnCount;

    public void StartWave(int waveIndex)
    {
        
        zombieSpawnCount = 0;
        lionSpawnCount = 0;
        spiderSpawnCount = 0;
        horseSpawnCount = 0;
        bossmonsterSpawnCount = 0;

        // herzaman zombie spawnla
        InvokeRepeating(nameof(SpawnZombie), spawnInterval, spawnInterval);

        
        if (waveIndex >= 2)
            InvokeRepeating(nameof(SpawnLion), spawnInterval, spawnInterval);

        
        if (waveIndex >= 3)
            InvokeRepeating(nameof(SpawnSpider), spawnInterval, spawnInterval);

        
        if (waveIndex >= 4)
            InvokeRepeating(nameof(SpawnHorse), spawnInterval, spawnInterval);

        
        if (waveIndex % 5 == 0)
            InvokeRepeating(nameof(SpawnBossMonster), spawnInterval, spawnInterval);
    }

    public void CancelAllSpawns()
    {
        CancelInvoke(nameof(SpawnZombie));
        CancelInvoke(nameof(SpawnLion));
        CancelInvoke(nameof(SpawnSpider));
        CancelInvoke(nameof(SpawnHorse));
        CancelInvoke(nameof(SpawnBossMonster));
    }

    void SpawnZombie()
    {
        if (zombieSpawnCount >= maxZombieCount)
        {
            CancelInvoke(nameof(SpawnZombie));
            return;
        }
        DoSpawn(zombiePrefab, 180f);
        zombieSpawnCount++;
    }

    void SpawnLion()
    {
        if (lionSpawnCount >= maxLionCount)
        {
            CancelInvoke(nameof(SpawnLion));
            return;
        }
        DoSpawn(lionPrefab, 0f);
        lionSpawnCount++;
    }

    void SpawnSpider()
    {
        int currentSpiderCount = GameObject
            .FindGameObjectsWithTag("Zombie")
            .Count(o => o.name.Contains("Spider"));
        if (currentSpiderCount >= maxSpiderCount)
        {
            CancelInvoke(nameof(SpawnSpider));
            return;
        }
        DoSpawn(spiderPrefab, 0f);
        spiderSpawnCount++;
    }

    void SpawnHorse()
    {
        int currentHorseCount = GameObject
            .FindGameObjectsWithTag("Zombie")
            .Count(o => o.name.Contains("Horse"));
        if (currentHorseCount >= maxHorseCount)
        {
            CancelInvoke(nameof(SpawnHorse));
            return;
        }
        DoSpawn(horsePrefab, 0f);
        horseSpawnCount++;
    }

    void SpawnBossMonster()
    {
        if (bossmonsterSpawnCount >= maxBossMonsterCount)
        {
            CancelInvoke(nameof(SpawnBossMonster));
            return;
        }
        DoSpawn(bossmonsterPrefab, 0f);
        bossmonsterSpawnCount++;
    }

    private void DoSpawn(GameObject prefab, float yRotation)
    {
        Vector3 pos = spawnPoint.position;
        pos.y = spawnHeight;
        Quaternion rot = Quaternion.Euler(0f, yRotation, 0f);

        GameObject go = Instantiate(prefab, pos, rot);
        var pathCtrl = go.GetComponent<EnemyPathBase>();
        if (pathCtrl != null)
        {
            pathCtrl.startPoint = spawnPoint;
            pathCtrl.pathPoint1 = pathPoint1;
            pathCtrl.pathPoint2 = pathPoint2;
            pathCtrl.endPoint = endPoint;
        }
    }
}