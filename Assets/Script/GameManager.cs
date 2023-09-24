using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] AudioClip yourBGMClip;
    [SerializeField] GameObject pauseMenuUI1;
    [SerializeField] GameObject pauseMenuUI2;

    [SerializeField] string targetSceneName; // 移動先のシーン名を指定する

    private bool isUIPaused = false;
    private static GameManager _instance;
    private bool isPaused = false;
    private Vector3 initialEnemyPosition;

    private void Start()
    {
        // 最初からUIを非表示にする
        pauseMenuUI1.SetActive(false);
        pauseMenuUI2.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene(targetSceneName); // 指定したシーン名に移動する
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
        }
        else
        {
            Time.timeScale = 1f;
            PlayBGM(yourBGMClip);
            pauseMenuUI1.SetActive(false);
            pauseMenuUI2.SetActive(false);
        }
    }
}
