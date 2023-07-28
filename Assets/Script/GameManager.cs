using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _goal;
    Rigidbody2D _rb2d;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    /// <summary> ReStart機能 </summary>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        }
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        /// <summary> See you next time機能 </summary>
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = .6f;
        }

        /// <summary> Goal機能 </summary>
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("StageSelect");
        }
    }
}
