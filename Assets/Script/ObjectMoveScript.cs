using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveScript : MonoBehaviour
{
    public float moveSpeed = 5f; // “G‚ÌˆÚ“®‘¬“x

    // Update is called once per frame
    void Update()
    {
        // ¶•ûŒü‚ÉˆÚ“®
        transform.Translate(Vector2.left * moveSpeed);
    }
}
