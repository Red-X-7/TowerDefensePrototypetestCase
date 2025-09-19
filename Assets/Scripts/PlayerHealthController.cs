using Ilumisoft.HealthSystem;
using System.Collections;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public GameObject GameOverpanel;
    private Health health;

    private void Start()
    {
        GameOverpanel.SetActive(false);
    }

    void Awake()
    {
        
        health = GetComponent<Health>();
        health.OnHealthEmpty += OnPlayerDead;
    }

    public void ApplyDamage(float damage)
    {
        health.ApplyDamage(damage);
    }

    private void OnPlayerDead()
    {
        
        GameOverpanel.SetActive(true);
        Time.timeScale = 0f;
    }
}