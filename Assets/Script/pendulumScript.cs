using UnityEngine;

public class pendulumScript : MonoBehaviour
{
    [SerializeField] float swingForce = 10f; // U‚èq‚É‰Á‚¦‚é—Í‚Ì‘å‚«‚³
    [SerializeField] float maxSwingAngle = 30f; // U‚èq‚ÌÅ‘åU‚è•iŠp“xj

    Rigidbody2D _rb2d;
    Quaternion startRotation;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        startRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        // U‚èq‚ÌŠp“x‚ğŒvZ
        float currentAngle = Quaternion.Angle(startRotation, transform.rotation);

        // Å‘åU‚è•ˆÈã‚É‚È‚Á‚½‚ç—Í‚ğ”½“]‚³‚¹‚é
        if (currentAngle >= maxSwingAngle)
        {
            swingForce = -swingForce;
        }

        // U‚èq‚É—Í‚ğ‰Á‚¦‚é
        _rb2d.AddTorque(swingForce);
    }
}
