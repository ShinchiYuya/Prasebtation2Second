using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMng : MonoBehaviour
{
    public Transform playerTransform;

    void Update()
    {
        if (playerTransform != null)
        {
            // �v���C���[�̈ʒu���擾���ăJ�����̈ʒu�ɐݒ肷��
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 1, transform.position.z);
        }
    }
}
