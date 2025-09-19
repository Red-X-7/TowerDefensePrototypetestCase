using UnityEngine;
using Ilumisoft.HealthSystem;  // HealthComponent namespace'ine göre uyarlayýn

public class ZombiePath : EnemyPathBase
{
    [Header("Zombie Settings")]
    public float damageAmount = 20f;   // Hasar miktarý

    
     public float ZombieMoveSpeed = 2f;
     public float ZombiFixedY = 5.5f;
    

    // Yolun sonuna gelindiðinde oyuncuya hasar ver, sonra yok et
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