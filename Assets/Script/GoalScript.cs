using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    [SerializeField] GameObject _goal;
    [SerializeField] string targetSceneName; // ˆÚ“®æ‚ÌƒV[ƒ“–¼‚ğw’è‚·‚é

    Rigidbody2D _rb2d;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            PointManager scoreManager = FindObjectOfType<PointManager>();

            if(scoreManager != null && scoreManager.GetGemCount() >= scoreManager.GetRequiredGems())
            {
                SceneManager.LoadScene(targetSceneName);
            }
        }
    }
}
