using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager: MonoBehaviour
{
    private int highScore;
    public Text scoreText = null;
    public Text highScoreText = null;
    public Text highScoreText2 = null;
    public AttackAnimation attackAnimation=null;
    int scorePoint=0;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(ScoreTimeP());
        highScore = PlayerPrefs.GetInt("highScore",0);
        highScoreText.text = "HighScore" + "\n" + highScore;
        highScoreText2.text = "HighScore" + "\n" + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackAnimation.pscore)
        {
            scorePoint += 50;
            attackAnimation.pscore = false;
            scoreText.text = "" + scorePoint;
        }
        if (scorePoint > highScore)
        {
            PlayerPrefs.SetInt("highScore", scorePoint);
            highScore = PlayerPrefs.GetInt("highScore",0);
            highScoreText.text = "HighScore" + "\n" + highScore;
            highScoreText2.text = "HighScore" + "\n" + highScore;
        }
    }
    IEnumerator ScoreTimeP()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
                scorePoint += 5;
            scoreText.text = "" + scorePoint;
        }
    }
}
