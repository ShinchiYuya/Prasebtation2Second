using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource; // �Q�[���I�u�W�F�N�g�ɃA�^�b�`���ꂽ�I�[�f�B�I�\�[�X

    // ���̃��\�b�h���Ăяo���ĉ������Đ�
    void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
