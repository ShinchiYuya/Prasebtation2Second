using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = null;//ゲーム内で唯一のGameManagerのインスタンス
    public int score;//スコアを表す変数
    public int stagenum;//ステージの番号を表す変数
    public int continueNum;//継続回数を会わらす変数

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;//このGameManagerをインスタンスに設定
            DontDestroyOnLoad(this.gameObject);//このGameManagerオブジェクトをシーン切り替え時に破棄しないように設定
        }
        else
        {
            Destroy(this.gameObject);//GameManagerのインスタンスがすでに存在する場合、重複するインスタンスを破棄
        }
    }

}
