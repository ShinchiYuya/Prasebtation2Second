using UnityEngine;
using DG.Tweening;

public class GhostMovementScript : EnemyMovement
{
    [SerializeField] private float verticalDistance = 1f; // �㉺�Ɉړ����鋗��
    [SerializeField] private float verticalDuration = 1f; // �㉺�̈ړ��ɂ����鎞��

    private bool movingUp = true; // ������Ɉړ������ǂ���

    private void Start()
    {
        base.Start();
    }

    private void Update()
    {
        // ���Ɉړ�
        transform.Translate(Vector2.left * _speed * Time.deltaTime);

        // �㉺�Ɉړ�
        if (movingUp)
        {
            // ��Ɉړ�
            transform.DOMoveY(transform.position.y + verticalDistance, verticalDuration)
                .SetEase(Ease.Linear)
                .OnComplete(() => movingUp = false); // �㏸�����������牺�~��
        }
        else
        {
            // ���Ɉړ�
            transform.DOMoveY(transform.position.y - verticalDistance, verticalDuration)
                .SetEase(Ease.Linear)
                .OnComplete(() => movingUp = true); // ���~������������㏸��
        }
    }
}
