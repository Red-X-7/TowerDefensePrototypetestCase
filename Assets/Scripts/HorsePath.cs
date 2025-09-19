using Ilumisoft.HealthSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorsePath : EnemyPathBase
{
    [Header("Horse Settings")]
    public float damageAmount = 100f;   // Hasar miktar�

    public float HorseMoveSpeed = 1f;
    public float HorseFixedY = 5.22f;

    // Yolun sonuna gelindi�inde oyuncuya hasar ver, sonra yok et
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
