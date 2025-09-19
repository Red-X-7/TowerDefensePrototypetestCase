using UnityEngine;
using Ilumisoft.HealthSystem;

public class LionPath : EnemyPathBase
{
    [Header("Lion Settings")]
    public float damageAmount = 50f;

    public float LionMoveSpeed = 4f;
    public float lionFixedY = 5.12f;

    protected override void OnReachedDestination()
    {
        var player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            var health = player.GetComponent<Health>();
            if (health != null)
                health.ApplyDamage(damageAmount);
        }

        base.OnReachedDestination();
    }
}