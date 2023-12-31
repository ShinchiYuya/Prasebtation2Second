using DG.Tweening;
using UnityEngine;

public class EagleMoveScript : EnemyMovement
{
    [SerializeField] float downDistance = 1f; // 下に移動する距離
    [SerializeField] float upDistance = 1f; //上に移動する距離
    [SerializeField] float verticalDuration = 1f; // 上下の移動にかかる時間

    bool movingUp = true; // 上向きに移動中かどうか

    void Start()
    {
        base.Start();
    }

    void Update()
    {
        // 左に移動
        transform.Translate(Vector2.left * _speed * Time.deltaTime);

        // 上下に移動
        if (movingUp)
        {
            // 上に移動
            transform.DOMoveY(transform.position.y + upDistance, verticalDuration)
            .SetEase(Ease.Linear).OnComplete(() => movingUp = false); // 上昇が完了したら下降へ
        }
        else
        {
            // 下に移動
            transform.DOMoveY(transform.position.y - downDistance, verticalDuration)
            .SetEase(Ease.Linear).OnComplete(() => movingUp = true); // 下降が完了したら上昇へ
        }
    }
}
