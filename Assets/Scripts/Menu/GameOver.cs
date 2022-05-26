using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AdMobManager adMobManager;
    public GameObject GameStop;
    public GameObject GameOverMenu;
    public GameObject AudioManager;
    public GameObject StopCanvas;
    private bool nGameOver=true;
    private int admobP=0;
    // Update is called once per frame
    private void Start()
    {
        AudioManager.gameObject.SetActive(true);
        GameOverMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        admobP = PlayerPrefs.GetInt("AdmobP", admobP);
    }
    void Update()
    {
        if (nGameOver)
        {
            if (Time.timeScale == 0)
            {
                GameOverMenu.gameObject.SetActive(true);
                AudioManager.gameObject.SetActive(false);
            }
        }
    }
    public void AdmobCC()
    {
        admobP++;
        PlayerPrefs.SetInt("AdmobP", admobP);
        admobP = PlayerPrefs.GetInt("AdmobP", admobP);
        if (admobP > 4)
        {
            admobP = 0;
            PlayerPrefs.SetInt("AdmobP", 0);
            //adMobManager.ShowInterstitialAd();
            AdMobManager._adMobManager.ShowInterstitialAd();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        AdmobCC();
    }
    public void Home()
    {
        SceneManager.LoadScene("GMAGO");
        AdmobCC();
    }
    public void Resume()
    {
        Time.timeScale = 1;
        nGameOver = true;
        GameOverMenu.gameObject.SetActive(false);
        GameStop.gameObject.SetActive(false);
        AudioManager.gameObject.SetActive(true);
        StopCanvas.gameObject.SetActive(true);
        AdmobCC();
    }
    public void Stop()
    {
        AudioManager.gameObject.SetActive(false);
        nGameOver = false;
        StopCanvas.gameObject.SetActive(false);
        GameStop.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}