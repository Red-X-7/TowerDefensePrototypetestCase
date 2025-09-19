using UnityEngine;
using Ilumisoft.HealthSystem;

public class ArrowHit : MonoBehaviour
{
    public string targetTag = "Zombie";
    public float damageAmount = 25f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Ok hedefe çarptý: " + other.name);

            // Sadece klonlar hasar versin
            if (gameObject.name.Contains("Clone"))
            {
                // Canavara hasar ver
                Health health = other.GetComponent<Health>();
                if (health != null)
                {
                    health.ApplyDamage(damageAmount);
                }

                // Oku yok et
                Destroy(gameObject);
            }
        }
    }
}