using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : Singleton<HighScoreManager>
{
    public Text scoreText, highScoreText, newRecordText, scoreEndingText;
    private int score, highScore;

    protected override void Awake()
    {
        base.Awake();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            highScoreText.text = highScore.ToString();
        }

    }

    void Start()
    {
        score = 0;
        newRecordText.gameObject.SetActive(false);
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString();
        scoreEndingText.text = scoreText.text;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;

        UpdateHighScore();
        UpdateScore();
    }

    public void UpdateHighScore()
    {
        if (score > highScore)
        {
            newRecordText.gameObject.SetActive(true);
            highScore = score;
            highScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

}
