using UnityEngine;

public class GemController : MonoBehaviour
{
    [SerializeField] int gemScore = 1; // gem���Ƃ������̃X�R�A�|�C���g
    [SerializeField] AudioClip gemClip; // �W�F�����擾�����Ƃ��ɍĐ�����I�[�f�B�I�N���b�v

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

            // �W�F�����擾�����Ƃ��ɃI�[�f�B�I�N���b�v���Đ�
            if (gemClip != null)
            {
                audioSource.PlayOneShot(gemClip);
            }

            Destroy(gameObject,.3f);
        }
    }
}
