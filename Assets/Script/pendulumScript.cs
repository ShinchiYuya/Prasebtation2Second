using UnityEngine;

public class PendulumScript : MonoBehaviour
{
    [SerializeField] float swingForce = 10f; // 振り子に加える力の大きさ
    [SerializeField] float maxSwingAngle = 30f; // 振り子の最大振り幅（角度）

    Rigidbody2D _rb2d;
    Quaternion startRotation;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        startRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        // 振り子の角度を計算
        float currentAngle = Quaternion.Angle(startRotation, transform.rotation);

        // 最大振り幅以上になったら力を反転させる
        if (currentAngle >= maxSwingAngle)
        {
            swingForce = -swingForce;
        }

        // 振り子に力を加える
        _rb2d.AddTorque(swingForce);
    }
}
