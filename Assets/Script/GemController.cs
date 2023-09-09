using UnityEngine;

public class GemController : MonoBehaviour
{
    public int gemScore = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(gemScore);
            }

            Destroy(gameObject);
        }
    }
}
