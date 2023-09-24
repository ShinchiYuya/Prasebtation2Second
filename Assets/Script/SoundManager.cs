using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource; // ゲームオブジェクトにアタッチされたオーディオソース

    // このメソッドを呼び出して音声を再生
    void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
