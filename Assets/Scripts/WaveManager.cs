using TMPro;
using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    [Header("References")]
    public EnemySpawner spawner;
    public TMP_Text waveText;
    public TMP_Text countdownText;

    [Header("Wave Settings")]
    public float checkInterval = 5f;   // Kaç saniyede bir düþman kontrolü yapalým
    public float waveTransitionDelay = 10f;  // Dalga bitince bekleme süresi
    public float firstSpawnDelay = 2f;   // Dalga baþlar baþlamaz bir miktar gecikme

    private int currentWave = 0;
    private bool waveActive = false;
    private bool waitingForNextWave = false;
    private float nextWaveTimer = 0f;
    private float waveStartTime = 0f;

    void Start()
    {
        StartNextWave();
        StartCoroutine(CheckWaveEnd());
    }

    void Update()
    {
        // sadece EndWave() tetiklendiðinde buraya girer 
        if (waitingForNextWave)
        {
            // F tuþuna basýnca yeni dalga çaðýrýr
            if (Input.GetKeyDown(KeyCode.F))
            {
                waitingForNextWave = false;
                ClearCountdownUI();
                StartNextWave();
                return;
            }

            // Normal geri sayým
            nextWaveTimer -= Time.deltaTime;
            UpdateCountdownUI();

            // Süre dolunca otomatik yeni dalga
            if (nextWaveTimer <= 0f)
            {
                waitingForNextWave = false;
                ClearCountdownUI();
                StartNextWave();
            }
            return;  // Sayaç aktifken Update'in geri kalaný atlanýr
        }

        // Dalga sürüyorken sayaç modu yok, F tuþu iþlevsiz 
    }

    public void StartNextWave()
    {
        // Baþlamadan önce sayaç modunu kapat
        waitingForNextWave = false;

        currentWave++;
        waveActive = true;
        waveText.text = "Wave " + currentWave;
        countdownText.text = "Next wave incoming...";
        // Önceki spawn'larý iptal et, sonra yeni dalgayý baþlat
        spawner.CancelAllSpawns();
        spawner.StartWave(currentWave);

        // Dalga baþlangýcýný kaydet
        waveStartTime = Time.time;
    }

    public void EndWave()
    {
        // Dalga bitti, sayaç moduna geç
        waveActive = false;
        waitingForNextWave = true;
        nextWaveTimer = waveTransitionDelay;
        UpdateCountdownUI();
    }

    IEnumerator CheckWaveEnd()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkInterval);

            if (!waveActive)
                continue;

            // Henüz ilk spawn gecikmesi geçmediyse bekle
            if (Time.time < waveStartTime + firstSpawnDelay)
                continue;

            // Sahnede "Zombie" tag'lý hiç obje kalmadýysa dalga bitiþi
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Zombie");
            if (enemies.Length == 0)
                EndWave();
        }
    }

    void UpdateCountdownUI()
    {
        
        if (countdownText)
            countdownText.text = $"Next wave in {nextWaveTimer:F1}s (F to skip)";
    }

    void ClearCountdownUI()
    {
        if (countdownText)
            countdownText.text = "Next wave incoming..."; // sabit metin kalýr
    }
    public void ExitGame()
    {
        Debug.Log("Oyun kapatýlýyor...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }


}