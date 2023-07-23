using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullPlayer : PlayerDefScript
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        // Your additional logic for grabbing and impulse force here...

        if (Input.GetKeyDown(KeyCode.G))
        {
            // Grab logic here
            GameObject[] grabbableObjects = GameObject.FindGameObjectsWithTag("GrabbableObject");
            if (grabbableObjects.Length > 0)
            {
                GameObject objToGrab = grabbableObjects[0];
                GrabObject(objToGrab);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            // Impulse force logic here
            GameObject[] pushableObjects = GameObject.FindGameObjectsWithTag("PushableObject");
            if (pushableObjects.Length > 0)
            {
                GameObject objToPush = pushableObjects[0];
                Vector2 forceDirection = Vector2.up; // Set the desired force direction (you can change this as needed)
                float forceMagnitude = 10f; // Set the desired force magnitude (you can change this as needed)
                ImpulseForce(objToPush, forceDirection, forceMagnitude);
            }
        }
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
