using UnityEngine;
using Ilumisoft.HealthSystem;

public class MonsterDeath : MonoBehaviour
{
    private Health health;

    void Start() // Awake yerine Start
    {
        health = GetComponent<Health>();

        if (health != null)
        {
            health.OnHealthEmpty += HandleDeath;
        }
    }

    void HandleDeath()
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        if (health != null)
        {
            health.OnHealthEmpty -= HandleDeath;
        }
    }
}