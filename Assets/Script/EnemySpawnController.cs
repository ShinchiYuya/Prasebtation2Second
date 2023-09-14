using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        // �G�̏����ʒu���擾
        initialPosition = transform.position;
    }

    // ���炩�̗��R�œG�������ʒu�ɖ߂��K�v������΁A�ȉ��̂悤�Ɏg���܂��B
    void ResetToInitialPosition()
    {
        transform.position = initialPosition;
    }
}
