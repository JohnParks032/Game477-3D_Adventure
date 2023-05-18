using UnityEngine;
using HighScore;
using TMPro;
using UnityEditor.Rendering.LookDev;

public class Score : MonoBehaviour
{
    public TMP_InputField inputPlayerName;
    public TextMeshProUGUI scoreText;
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
        scoreText.text = $"Score: {score}";
    }
    public void TrophyCollected()
    {
        score += 10000;
        scoreText.text = $"Score: {score}";
    }

    public void SubmitScore()
    {
        HS.SubmitHighScore(this, inputPlayerName.text, score);
    }

    public void ClearScores()
    {
        HS.Clear(this);
    }
}
