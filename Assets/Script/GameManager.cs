using UnityEngine;

public class GameManager : MonoBehaviour
{
    // GameManagerのインスタンスを格納するプライベート変数
    private static GameManager _instance;
    // 敵の初期位置を保持する変数
    private Vector3 initialEnemyPosition;
    // 外部からGameManagerのインスタンスを取得するプロパティ
    public static GameManager Instance
    {
        get
        {
            // インスタンスがまだ存在しない場合、新しいインスタンスを作成
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    // その他のGameManagerのメソッドや変数...

    // インスタンスが生成された時の初期化
    private void Awake()
    {
        // インスタンスが既に存在する場合、新しいインスタンスを破棄
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        // インスタンスが存在しない場合、このインスタンスを設定
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public Vector3 GetInitialEnemyPosition()
    {
        return initialEnemyPosition;
    }
}
