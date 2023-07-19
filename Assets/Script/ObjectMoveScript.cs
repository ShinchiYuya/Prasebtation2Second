using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveScript : MonoBehaviour
{
    public float moveSpeed = 5f; // 敵の移動速度

    // Update is called once per frame
    void Update()
    {
        // 左方向に移動
        transform.Translate(Vector2.left * moveSpeed);
    }
}
