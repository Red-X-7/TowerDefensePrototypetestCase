using Ilumisoft.HealthSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderPath : EnemyPathBase
{
    [Header("Spider Settings")]
    public float damageAmount = 30f;   // Hasar miktar�


    public float SpiderMoveSpeed = 3f;
    public float SpiderFixedY = 5.3f;
    

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
