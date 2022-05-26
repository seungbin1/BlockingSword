using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private int highScore;
    public Text highScoreText = null;
    public void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore",0);
        highScoreText.text = "HighScore" + "\n" + highScore;
    }
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
