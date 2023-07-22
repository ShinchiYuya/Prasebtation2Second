using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullPlayer : PlayerDefScript
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        // Your additional logic for grabbing and impulse force here...
    }

    protected override void ImpulseForce(GameObject objToPush, Vector2 forceDirection, float forceMagnitude)
    {
        // Add the impulse force to the object
        Rigidbody2D rb = objToPush.GetComponent<Rigidbody2D>();
        rb.AddForce(forceDirection.normalized * forceMagnitude, ForceMode2D.Impulse);
    }

    protected override void GrabObject(GameObject objToGrab)
    {
        // Implement grabbing logic here
        // For example, change the object's position or attach it to the player's hand
        // For demonstration purposes, let's destroy the grabbed object
        Destroy(objToGrab);
    }
}
