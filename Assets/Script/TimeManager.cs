using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float _totalTime; // トータル制限時間
    [SerializeField] int _minute; // 制限時間（分）
    [SerializeField] float _second; // 制限時間（秒）
    [SerializeField] float _oldSeconds; // Updateの秒数

    Text _timeText;

    void Start()
    {
        _totalTime = _minute * 60 + _second;
        _oldSeconds = 0f;
        _timeText = GetComponent<Text>();
    }

    void Update()
    {
        //制限時間が０秒以下なら何もしない
        if (_totalTime <= 0f)
        {
            return;
        }

        //一旦トータルの制限時間を計測
        _totalTime = _minute * 60 + _second;
        _totalTime -= Time.deltaTime;
        
        //再設定
        _minute = (int)_totalTime / 60;
        _totalTime -= Time.deltaTime;

        //　タイマー表示用UIテキストに時間を表示する
        if ((int)_second != (int)_oldSeconds)
        {
            _timeText.text = _minute.ToString("00") + ":" + ((int)_second);
        }
        _oldSeconds = _second;

        //　制限時間以下になったら
        if (_totalTime <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
