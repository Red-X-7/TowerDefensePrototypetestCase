using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject fpsPanel;

    //Ayarlar butonu için script 
    public void Start()
    {
        fpsPanel.SetActive(false);
    }


    public void OpenFPSPanel()
    {
        fpsPanel.SetActive(true);
    }

    public void CloseFPSPanel()
    {
        fpsPanel.SetActive(false);
    }




    public void SetFPS30()
    {
        Application.targetFrameRate = 30;
        Debug.Log("FPS 30 olarak ayarlandý.");
    }

    public void SetFPS60()
    {
        Application.targetFrameRate = 60;
        Debug.Log("FPS 60 olarak ayarlandý.");
    }
}