using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeScript : MonoBehaviour
{
    [SerializeField] string targetSceneName; // 移動先のシーン名を指定する

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ChangeScene);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneName); // 指定したシーン名に移動する
    }
}
