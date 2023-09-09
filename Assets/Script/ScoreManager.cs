using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score_num = 0;

    void Update()
    {
        scoreText.text = "Score: " + score_num;
    }

    public void IncreaseScore(int amount)
    {
        score_num += amount;
    }
}