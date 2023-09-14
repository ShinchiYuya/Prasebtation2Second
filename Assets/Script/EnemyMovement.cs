using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float _speed = 1f;

    protected Rigidbody2D _rb2d;
    protected Animation _anim;
    private Vector3 initialPosition;

    protected void Start()
    {
        _anim = GetComponent<Animation>();
        _rb2d = GetComponent<Rigidbody2D>();
        
        GameManager gameManager = GameManager.Instance; // GameManagerのインスタンスを取得
        if (gameManager != null)
        {
            initialPosition = gameManager.GetInitialEnemyPosition(); // 初期位置を取得
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);//左に移動させる
    }

    void ReStart()
    {
        if (Input.GetKey(KeyCode.R))
        {
            // リスタート時に初期位置に戻す
            transform.position = initialPosition;
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            this.gameObject.transform.parent = collision.gameObject.transform;
        }
    }
}