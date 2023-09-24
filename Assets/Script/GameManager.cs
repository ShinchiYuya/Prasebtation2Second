using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] AudioClip yourBGMClip;
    [SerializeField] GameObject pauseMenuUI1;
    [SerializeField] GameObject pauseMenuUI2;

    private bool isUIPaused = false;
    private static GameManager _instance;
    private bool isPaused = false;
    private Vector3 initialEnemyPosition;

    private void Start()
    {
        // �ŏ�����UI���\���ɂ���
        pauseMenuUI1.SetActive(false);
        pauseMenuUI2.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    public Vector3 GetInitialEnemyPosition()
    {
        return initialEnemyPosition;
    }

    public void PlayBGM(AudioClip bgmClip)
    {
        if (bgmAudioSource != null && bgmClip != null)
        {
            bgmAudioSource.clip = bgmClip;
            bgmAudioSource.Play();
        }
    }

    public void StopBGM()
    {
        if (bgmAudioSource != null)
        {
            bgmAudioSource.Stop();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            StopBGM();
            pauseMenuUI1.SetActive(true);
            pauseMenuUI2.SetActive(true);

            // �e�L�X�g�̓_�ł𐧌䂷��X�N���v�g�ɒʒm
            TextBlink.Instance.StartBlinking();
        }
        else
        {
            Time.timeScale = 1f;
            PlayBGM(yourBGMClip);
            pauseMenuUI1.SetActive(false);
            pauseMenuUI2.SetActive(false);

            // �e�L�X�g�̓_�ł𐧌䂷��X�N���v�g�ɒʒm
            TextBlink.Instance.StopBlinking();
        }
    }
}
