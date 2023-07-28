using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("")] static int _life = 3;
    [SerializeField, Header("")] static int _iLife;


    public Rigidbody2D _rb2d;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        IntiGame();
    }

    /// <summary> ReStart�@�\ </summary>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        }
    }

    /// <summary> �������Ƃ��Ɍ�����Text </summary>
    void OnCollisionEnter2D(Collision2D collision)
    {
        /// <summary> See you next time�@�\ </summary>
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = .6f;
        }
    }

    /// <summary> Life�Ǘ��P </summary>
    static void IntiGame()
    {
        _iLife = _life;
    }
}
