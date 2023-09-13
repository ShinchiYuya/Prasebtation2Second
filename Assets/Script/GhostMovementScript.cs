using UnityEngine;
using DG.Tweening;

public class GhostMovementScript : EnemyMovement
{
    [SerializeField] private float verticalDistance = 1f; // ã‰º‚ÉˆÚ“®‚·‚é‹——£
    [SerializeField] private float verticalDuration = 1f; // ã‰º‚ÌˆÚ“®‚É‚©‚©‚éŽžŠÔ

    private bool movingUp = true; // ãŒü‚«‚ÉˆÚ“®’†‚©‚Ç‚¤‚©

    private void Start()
    {
        base.Start();
    }

    private void Update()
    {
        // ¶‚ÉˆÚ“®
        transform.Translate(Vector2.left * _speed * Time.deltaTime);

        // ã‰º‚ÉˆÚ“®
        if (movingUp)
        {
            // ã‚ÉˆÚ“®
            transform.DOMoveY(transform.position.y + verticalDistance, verticalDuration)
                .SetEase(Ease.Linear)
                .OnComplete(() => movingUp = false); // ã¸‚ªŠ®—¹‚µ‚½‚ç‰º~‚Ö
        }
        else
        {
            // ‰º‚ÉˆÚ“®
            transform.DOMoveY(transform.position.y - verticalDistance, verticalDuration)
                .SetEase(Ease.Linear)
                .OnComplete(() => movingUp = true); // ‰º~‚ªŠ®—¹‚µ‚½‚çã¸‚Ö
        }
    }
}
