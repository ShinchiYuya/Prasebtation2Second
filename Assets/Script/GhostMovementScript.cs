using UnityEngine;
using DG.Tweening;

public class GhostMovementScript : EnemyMovement
{

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animation>();
    }

    void Update()
    {
        
    }
}
