using DG.Tweening;
using UnityEngine;

public class EagleMoveScript : EnemyMovement
{
    [SerializeField] float downDistance = 1f; // ���Ɉړ����鋗��
    [SerializeField] float upDistance = 1f; //��Ɉړ����鋗��
    [SerializeField] float verticalDuration = 1f; // �㉺�̈ړ��ɂ����鎞��

    bool movingUp = true; // ������Ɉړ������ǂ���

    void Start()
    {
        base.Start();
    }

    void Update()
    {
        // ���Ɉړ�
        transform.Translate(Vector2.left * _speed * Time.deltaTime);

        // �㉺�Ɉړ�
        if (movingUp)
        {
            // ��Ɉړ�
            transform.DOMoveY(transform.position.y + upDistance, verticalDuration)
            .SetEase(Ease.Linear).OnComplete(() => movingUp = false); // �㏸�����������牺�~��
        }
        else
        {
            // ���Ɉړ�
            transform.DOMoveY(transform.position.y - downDistance, verticalDuration)
            .SetEase(Ease.Linear).OnComplete(() => movingUp = true); // ���~������������㏸��
        }
    }
}
