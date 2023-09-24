using UnityEngine;

public class PlayerCheckScript : MonoBehaviour
{
    bool isOn = false;//範囲内にplayerがいるか確認するフラグ

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOn = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOn = false;
        }
    }
}
