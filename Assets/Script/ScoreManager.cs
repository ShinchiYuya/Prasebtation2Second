using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score_num = 0;//現在のスコアを保持する変数

    void Update()
    {
        scoreText.text = "Gem : " + score_num + " / 3 ";//表記
    }

    public void IncreaseScore(int amount)
    {
        score_num += amount;//gemのスコアの量だけ増やす
    }
}