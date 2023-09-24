using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextBlink : MonoBehaviour
{
    [SerializeField] private Text blinkText1;
    [SerializeField] private Text blinkText2;

    private bool isBlinking = false;

    private static TextBlink _instance;

    public static TextBlink Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TextBlink>();
            }
            return _instance;
        }
    }

    private void Start()
    {
        // テキストの点滅アニメーションを開始しないようにする
        blinkText1.DOFade(0, 0);
        blinkText2.DOFade(0, 0);
    }

    public void StartBlinking()
    {
        isBlinking = true;
        BlinkText();
    }

    public void StopBlinking()
    {
        isBlinking = false;
        StopTextBlink();
    }

    private void BlinkText()
    {
        if (isBlinking)
        {
            blinkText1.DOFade(0, 0.5f)
                .SetLoops(-1, LoopType.Yoyo);
            blinkText2.DOFade(0, 0.5f)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }

    private void StopTextBlink()
    {
        blinkText1.DOFade(1, 0);
        blinkText2.DOFade(1, 0);
    }
}
