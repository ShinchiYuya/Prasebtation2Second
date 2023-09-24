using UnityEngine;

public class PlayerCheckScript : MonoBehaviour
{
    bool isOn = false;//�͈͓���player�����邩�m�F����t���O

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
