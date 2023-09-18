using UnityEngine;

public class pendulumScript : MonoBehaviour
{
    [SerializeField] float swingForce = 10f; // �U��q�ɉ�����͂̑傫��
    [SerializeField] float maxSwingAngle = 30f; // �U��q�̍ő�U�蕝�i�p�x�j

    Rigidbody2D _rb2d;
    Quaternion startRotation;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        startRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        // �U��q�̊p�x���v�Z
        float currentAngle = Quaternion.Angle(startRotation, transform.rotation);

        // �ő�U�蕝�ȏ�ɂȂ�����͂𔽓]������
        if (currentAngle >= maxSwingAngle)
        {
            swingForce = -swingForce;
        }

        // �U��q�ɗ͂�������
        _rb2d.AddTorque(swingForce);
    }
}
