using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ArcherProximity : MonoBehaviour
{
    [Header("Detection Settings")]
    public float detectionRadius = 5f;
    public string enemyTag = "Zombie";

    [Header("Attack Settings")]
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float fireCooldown = 1f;

    private List<Transform> nearbyEnemies = new List<Transform>();
    private float cooldownTimer = 0f;

    private PlayerController playerController;

    void Awake()
    {
        // PlayerController referansýný al
        playerController = GetComponent<PlayerController>();
    }

    void Start()
    {
        // Etki alaný ayarý
        SphereCollider sc = GetComponent<SphereCollider>();
        sc.isTrigger = true;
        sc.radius = detectionRadius;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0f)
        {
            Transform target = GetNearestEnemy();
            if (target != null)
            {
                // Saldýrý animasyonunu tetikle
                if (playerController != null)
                    playerController.StartAttackAnimation();

                // Ok fýrlat
                ShootArrow(target);
                cooldownTimer = fireCooldown;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            Debug.Log("Zombie alana girdi: " + other.name);
            nearbyEnemies.Add(other.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            Debug.Log("Zombie alandan çýktý: " + other.name);
            nearbyEnemies.Remove(other.transform);
        }
    }

    Transform GetNearestEnemy()
    {
        Transform nearest = null;
        float minDist = Mathf.Infinity;

        foreach (Transform enemy in nearbyEnemies)
        {
            if (enemy == null) continue;

            float dist = Vector3.Distance(transform.position, enemy.position);
            if (dist < minDist)
            {
                minDist = dist;
                nearest = enemy;
            }
        }

        return nearest;
    }


    //Atýlan okun Hýzý
    void ShootArrow(Transform target)
    {
        if (arrowPrefab == null || arrowSpawnPoint == null || target == null) return;

        Vector3 dir = (target.position - arrowSpawnPoint.position).normalized;
        Quaternion rot = Quaternion.LookRotation(dir);

        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, rot);

        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        if (rb != null)
        {
            float arrowSpeed = 25f;
            rb.velocity = dir * arrowSpeed;
        }
    }
}