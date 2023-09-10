using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = null;//�Q�[�����ŗB���GameManager�̃C���X�^���X
    public int score;//�X�R�A��\���ϐ�
    public int stagenum;//�X�e�[�W�̔ԍ���\���ϐ�
    public int continueNum;//�p���񐔂����炷�ϐ�

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;//����GameManager���C���X�^���X�ɐݒ�
            DontDestroyOnLoad(this.gameObject);//����GameManager�I�u�W�F�N�g���V�[���؂�ւ����ɔj�����Ȃ��悤�ɐݒ�
        }
        else
        {
            Destroy(this.gameObject);//GameManager�̃C���X�^���X�����łɑ��݂���ꍇ�A�d������C���X�^���X��j��
        }
    }

}
