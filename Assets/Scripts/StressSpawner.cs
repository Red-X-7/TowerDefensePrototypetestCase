using UnityEngine;

public class StressSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int spawnCount = 2000;

    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }
    }
}