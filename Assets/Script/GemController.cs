using UnityEngine;

public class GemController : MonoBehaviour
{
    public int gemScore = 1;　//gemをとった時のスコアポイント

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PointManager scoreManager = FindObjectOfType<PointManager>();//ScoreManagerのインスタンスをscoreManager変数に代入
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(gemScore);//PlayerのスコアをgemScoreとして指定された値だけ増加させる
            }

            Destroy(gameObject);//gemが取得されたときにgemが破壊されるようにする
        }
    }
}
