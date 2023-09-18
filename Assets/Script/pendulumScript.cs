using System.Collections;
using UnityEngine;

public class pendulumScript : MonoBehaviour
{

    [SerializeField] float _span = 3.0f;
    [SerializeField] float _pendulumForce = 10.0f;

    Rigidbody2D _rb2d;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine("Logging");
    }

    IEnumerator Logging()
    {
        while (true)
        {
            yield return new WaitForSeconds(_span);
            //Debug.LogFormat("{0}ïbåoâﬂ", _span);
            Vector2 forceUp = Vector2.up;
            _rb2d.AddForce(forceUp * _pendulumForce,ForceMode2D.Force);
        }
    }
}
