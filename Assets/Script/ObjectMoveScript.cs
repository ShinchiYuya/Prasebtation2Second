using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveScript : MonoBehaviour
{
    public float moveSpeed = 5f; // �G�̈ړ����x

    // Update is called once per frame
    void Update()
    {
        // �������Ɉړ�
        transform.Translate(Vector2.left * moveSpeed);
    }
}
