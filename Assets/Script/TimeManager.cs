using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float _totalTime; // �g�[�^����������
    [SerializeField] int _minute; // �������ԁi���j
    [SerializeField] float _second; // �������ԁi�b�j
    [SerializeField] float _oldSeconds; // Update�̕b��

    Text _timeText;

    void Start()
    {
        _totalTime = _minute * 60 + _second;
        _oldSeconds = 0f;
        _timeText = GetComponent<Text>();
    }

    void Update()
    {
        //�������Ԃ��O�b�ȉ��Ȃ牽�����Ȃ�
        if (_totalTime <= 0f)
        {
            return;
        }

        //��U�g�[�^���̐������Ԃ��v��
        _totalTime = _minute * 60 + _second;
        _totalTime -= Time.deltaTime;
        
        //�Đݒ�
        _minute = (int)_totalTime / 60;
        _totalTime -= Time.deltaTime;

        //�@�^�C�}�[�\���pUI�e�L�X�g�Ɏ��Ԃ�\������
        if ((int)_second != (int)_oldSeconds)
        {
            _timeText.text = _minute.ToString("00") + ":" + ((int)_second);
        }
        _oldSeconds = _second;

        //�@�������Ԉȉ��ɂȂ�����
        if (_totalTime <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
