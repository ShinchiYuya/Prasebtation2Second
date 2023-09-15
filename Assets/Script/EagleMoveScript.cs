using DG.Tweening;
using UnityEngine;

public class EagleMoveScript : EnemyMovement
{
    [SerializeField] float downDistance = 1f; // ‰º‚ÉˆÚ“®‚·‚é‹——£
    [SerializeField] float upDistance = 1f; //ã‚ÉˆÚ“®‚·‚é‹——£
    [SerializeField] float verticalDuration = 1f; // ã‰º‚ÌˆÚ“®‚É‚©‚©‚éŽžŠÔ

    bool movingUp = true; // ãŒü‚«‚ÉˆÚ“®’†‚©‚Ç‚¤‚©

    void Start()
    {
        base.Start();
    }

    void Update()
    {
        // ¶‚ÉˆÚ“®
        transform.Translate(Vector2.left * _speed * Time.deltaTime);

        // ã‰º‚ÉˆÚ“®
        if (movingUp)
        {
            // ã‚ÉˆÚ“®
            transform.DOMoveY(transform.position.y + upDistance, verticalDuration)
            .SetEase(Ease.Linear).OnComplete(() => movingUp = false); // ã¸‚ªŠ®—¹‚µ‚½‚ç‰º~‚Ö
        }
        else
        {
            // ‰º‚ÉˆÚ“®
            transform.DOMoveY(transform.position.y - downDistance, verticalDuration)
            .SetEase(Ease.Linear).OnComplete(() => movingUp = true); // ‰º~‚ªŠ®—¹‚µ‚½‚çã¸‚Ö
        }
    }
}
