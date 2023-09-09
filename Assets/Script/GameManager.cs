using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = null;
    public int score;
    public int stagenum;
    public int continueNum;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
