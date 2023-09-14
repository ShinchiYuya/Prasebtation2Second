using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed; // 移動速度
    [SerializeField] float moveDistance; // 移動距離

    Vector2 initialPosition; // 初期位置
    int direction = 1; // 移動方向
    void Start()
    {
        initialPosition = transform.position; // 初期位置を保存
    }
    void Update()
    {
        // オブジェクトを水平方向に移動させる
        transform.Translate(Vector2.right * moveSpeed * direction * Time.deltaTime);

        // オブジェクトが指定した移動距離を超えたら逆方向に移動
        if (Mathf.Abs(transform.position.x - initialPosition.x) >= moveDistance)
        {
            direction *= -1;
        }
    }
}
