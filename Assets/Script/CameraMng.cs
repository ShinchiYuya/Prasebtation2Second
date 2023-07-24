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
            // プレイヤーの位置を取得してカメラの位置に設定する
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 1, transform.position.z);
        }
    }
}
