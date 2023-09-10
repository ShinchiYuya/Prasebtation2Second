using UnityEngine;
using DG.Tweening;

public class GhostMovementScript : EnemyMovement
{
    [SerializeField] private float verticalDistance = 1f; // 上下に移動する距離
    [SerializeField] private float verticalDuration = 1f; // 上下の移動にかかる時間

    private bool movingUp = true; // 上向きに移動中かどうか

    private void Start()
    {
        // 基底クラスの Start メソッドを呼び出す
        base.Start();
    }

    private void Update()
    {
        // 左に移動
        transform.Translate(Vector2.left * _speed * Time.deltaTime);

        // 上下に移動
        if (movingUp)
        {
            // 上に移動
            transform.DOMoveY(transform.position.y + verticalDistance, verticalDuration)
                .SetEase(Ease.Linear)
                .OnComplete(() => movingUp = false); // 上昇が完了したら下降へ
        }
        else
        {
            // 下に移動
            transform.DOMoveY(transform.position.y - verticalDistance, verticalDuration)
                .SetEase(Ease.Linear)
                .OnComplete(() => movingUp = true); // 下降が完了したら上昇へ
        }
    }
}
