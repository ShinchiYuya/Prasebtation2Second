using UnityEngine;

public class GemController : MonoBehaviour
{
    [SerializeField] int gemScore = 1; // gemをとった時のスコアポイント
    [SerializeField] AudioClip gemClip; // ジェムを取得したときに再生するオーディオクリップ

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PointManager scoreManager = FindObjectOfType<PointManager>();
            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(gemScore);
            }

            // ジェムを取得したときにオーディオクリップを再生
            if (gemClip != null)
            {
                audioSource.PlayOneShot(gemClip);
            }

            Destroy(gameObject,.3f);
        }
    }
}
