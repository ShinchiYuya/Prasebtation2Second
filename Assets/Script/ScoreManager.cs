using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score_num = 0;//���݂̃X�R�A��ێ�����ϐ�

    void Update()
    {
        scoreText.text = "Score: " + score_num;//�\�L
    }

    public void IncreaseScore(int amount)
    {
        score_num += amount;//gem�̃X�R�A�̗ʂ������₷
    }
}