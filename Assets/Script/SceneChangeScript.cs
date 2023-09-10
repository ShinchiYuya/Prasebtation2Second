using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeScript : MonoBehaviour
{
    [SerializeField] string targetSceneName; // �ړ���̃V�[�������w�肷��

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ChangeScene);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneName); // �w�肵���V�[�����Ɉړ�����
    }
}
