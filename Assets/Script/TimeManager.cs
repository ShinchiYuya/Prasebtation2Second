using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] static float _timerText;
    [SerializeField] float _maxTime;
    [SerializeField] Text _textCountDown;
    [SerializeField] PlayerDefScript playerDamageScript; // プレイヤーにダメージを与えるスクリプト

    private void Start()
    {
        _timerText = _maxTime;
    }

    private void Update()
    {
        _textCountDown.text = string.Format("Time: {0:00.00}", _timerText);

        _timerText -= Time.deltaTime;

        if (_timerText <= 0f)
        {
            playerDamageScript.InflictDamage();
        }
    }
}
