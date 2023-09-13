using UnityEngine;

public class GemController : MonoBehaviour
{
    public int gemScore = 1;�@//gem���Ƃ������̃X�R�A�|�C���g

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PointManager scoreManager = FindObjectOfType<PointManager>();//ScoreManager�̃C���X�^���X��scoreManager�ϐ��ɑ��
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(gemScore);//Player�̃X�R�A��gemScore�Ƃ��Ďw�肳�ꂽ�l��������������
            }

            Destroy(gameObject);//gem���擾���ꂽ�Ƃ���gem���j�󂳂��悤�ɂ���
        }
    }
}
