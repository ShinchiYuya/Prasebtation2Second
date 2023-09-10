using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed; // �ړ����x
    [SerializeField] float moveDistance; // �ړ�����

    Vector2 initialPosition; // �����ʒu
    int direction = 1; // �ړ�����

    void Start()
    {
        initialPosition = transform.position; // �����ʒu��ۑ�
    }

    void Update()
    {
        // �I�u�W�F�N�g�𐅕������Ɉړ�������
        transform.Translate(Vector2.right * moveSpeed * direction * Time.deltaTime);

        // �I�u�W�F�N�g���w�肵���ړ������𒴂�����t�����Ɉړ�
        if (Mathf.Abs(transform.position.x - initialPosition.x) >= moveDistance)
        {
            direction *= -1;
        }
    }
}
