using UnityEngine;

public class FPSManager : MonoBehaviour
{
    float deltaTime = 0f;

    void Awake()
    {
        Application.targetFrameRate = 30;         // Baþlangýçta sabit 30 FPS
        DontDestroyOnLoad(gameObject);            // Sahne geçiþlerinde silinmesin
    }

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int fps = Mathf.RoundToInt(1f / deltaTime);
        GUIStyle style = new GUIStyle();
        style.fontSize = 20;
        style.normal.textColor = Color.white;

        GUI.Label(new Rect(10, 10, 100, 30), $"FPS: {fps}", style);
    }
}