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
    public float checkInterval = 5f;   // Ka� saniyede bir d��man kontrol� yapal�m
    public float waveTransitionDelay = 10f;  // Dalga bitince bekleme s�resi
    public float firstSpawnDelay = 2f;   // Dalga ba�lar ba�lamaz bir miktar gecikme

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
        // sadece EndWave() tetiklendi�inde buraya girer 
        if (waitingForNextWave)
        {
            // F tu�una bas�nca yeni dalga �a��r�r
            if (Input.GetKeyDown(KeyCode.F))
            {
                waitingForNextWave = false;
                ClearCountdownUI();
                StartNextWave();
                return;
            }

            // Normal geri say�m
            nextWaveTimer -= Time.deltaTime;
            UpdateCountdownUI();

            // S�re dolunca otomatik yeni dalga
            if (nextWaveTimer <= 0f)
            {
                waitingForNextWave = false;
                ClearCountdownUI();
                StartNextWave();
            }
            return;  // Saya� aktifken Update'in geri kalan� atlan�r
        }

        // Dalga s�r�yorken saya� modu yok, F tu�u i�levsiz 
    }

    public void StartNextWave()
    {
        // Ba�lamadan �nce saya� modunu kapat
        waitingForNextWave = false;

        currentWave++;
        waveActive = true;
        waveText.text = "Wave " + currentWave;
        countdownText.text = "Next wave incoming...";
        // �nceki spawn'lar� iptal et, sonra yeni dalgay� ba�lat
        spawner.CancelAllSpawns();
        spawner.StartWave(currentWave);

        // Dalga ba�lang�c�n� kaydet
        waveStartTime = Time.time;
    }

    public void EndWave()
    {
        // Dalga bitti, saya� moduna ge�
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

            // Hen�z ilk spawn gecikmesi ge�mediyse bekle
            if (Time.time < waveStartTime + firstSpawnDelay)
                continue;

            // Sahnede "Zombie" tag'l� hi� obje kalmad�ysa dalga biti�i
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
            countdownText.text = "Next wave incoming..."; // sabit metin kal�r
    }
    public void ExitGame()
    {
        Debug.Log("Oyun kapat�l�yor...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }


}