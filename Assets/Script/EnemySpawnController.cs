using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        // 敵の初期位置を取得
        initialPosition = transform.position;
    }

    // 何らかの理由で敵を初期位置に戻す必要があれば、以下のように使えます。
    void ResetToInitialPosition()
    {
        transform.position = initialPosition;
    }
}
