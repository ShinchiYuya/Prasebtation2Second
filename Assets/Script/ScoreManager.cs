using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score_num = 0;//���݂̃X�R�A��ێ�����ϐ�

    void Update()
    {
        scoreText.text = "Gem : " + score_num + " / 3 ";//�\�L
    }

    public void IncreaseScore(int amount)
    {
        score_num += amount;//gem�̃X�R�A�̗ʂ������₷
    }
}