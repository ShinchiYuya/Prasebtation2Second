using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public Text scoreText;
    private int gemCount = 0;//現在のスコアを保持する変数
    public int requiredGems = 3; // ゴールに必要なGemの数

    void Update()
    {
        scoreText.text = "Gem : " + gemCount + " / 3 ";//表記
    }

    public void IncreaseScore(int amount)
    {
        gemCount += amount;//gemのスコアの量だけ増やす
    }

    public int GetGemCount()
    {
        return gemCount;
    }

    public int GetRequiredGems()
    {
        return requiredGems;
    }
}