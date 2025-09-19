using Ilumisoft.HealthSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterPath : EnemyPathBase
{
    [Header("BossMonster Settings")]
    public float damageAmount = 500f;   // Hasar miktarý

    public float BossMoveSpeed = 0.7f;
    public float BossFixedY = 6f;

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
