using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public Text scoreText;
    private int gemCount = 0;//���݂̃X�R�A��ێ�����ϐ�
    public int requiredGems = 3; // �S�[���ɕK�v��Gem�̐�

    void Update()
    {
        scoreText.text = "Gem : " + gemCount + " / 3 ";//�\�L
    }

    public void IncreaseScore(int amount)
    {
        gemCount += amount;//gem�̃X�R�A�̗ʂ������₷
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