using UnityEngine;

public class GameManager : MonoBehaviour
{
    // GameManager�̃C���X�^���X���i�[����v���C�x�[�g�ϐ�
    private static GameManager _instance;
    // �G�̏����ʒu��ێ�����ϐ�
    private Vector3 initialEnemyPosition;
    // �O������GameManager�̃C���X�^���X���擾����v���p�e�B
    public static GameManager Instance
    {
        get
        {
            // �C���X�^���X���܂����݂��Ȃ��ꍇ�A�V�����C���X�^���X���쐬
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    // ���̑���GameManager�̃��\�b�h��ϐ�...

    // �C���X�^���X���������ꂽ���̏�����
    private void Awake()
    {
        // �C���X�^���X�����ɑ��݂���ꍇ�A�V�����C���X�^���X��j��
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        // �C���X�^���X�����݂��Ȃ��ꍇ�A���̃C���X�^���X��ݒ�
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public Vector3 GetInitialEnemyPosition()
    {
        return initialEnemyPosition;
    }
}
