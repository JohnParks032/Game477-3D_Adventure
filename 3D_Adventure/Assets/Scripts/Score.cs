using UnityEngine;
using HighScore;
using TMPro;
using UnityEditor.Rendering.LookDev;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public TMP_InputField inputPlayerNameDeath;
    public TMP_InputField inputPlayerNameWin;
    public TextMeshProUGUI scoreTextDeath;
    public TextMeshProUGUI scoreTextWin;
    public int score;

    public void Start()
    {
        score = 0;
        HS.Init(this, "Danole the Anole and the Harmonic Tree"); // you can hard code your game's name
    }
    public void OnEnable()
    {
        Coin.OnCoinCollected += CoinCollected;
        Trophy.OnTrophyCollected += TrophyCollected;
    }
    public void OnDisable()
    {
        Coin.OnCoinCollected -= CoinCollected;
        Trophy.OnTrophyCollected += TrophyCollected;
    }
    public void CoinCollected()
    {
        score += 100;
        scoreTextWin.text = $"Score: {score}";
        scoreTextDeath.text = $"Score: {score}";
    }
    public void TrophyCollected()
    {
        score += 10000;
        scoreTextWin.text = $"Score: {score}";
        scoreTextDeath.text = $"Score: {score}";
    }

    public void SubmitScoreDeath()
    {
        HS.SubmitHighScore(this, inputPlayerNameDeath.text, score);
        Time.timeScale = 1f;
        Camera.main.GetComponent<CinemachineBrain>().enabled = true;
        SceneManager.LoadScene("MainMenu");
    }
    public void SubmitScoreWin()
    {
        HS.SubmitHighScore(this, inputPlayerNameWin.text, score);
        Time.timeScale = 1f;
        Camera.main.GetComponent<CinemachineBrain>().enabled = true;
        SceneManager.LoadScene("MainMenu");
    }

    public void ClearScores()
    {
        HS.Clear(this);
    }
}
