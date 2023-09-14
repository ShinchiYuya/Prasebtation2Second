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
        
        GameManager gameManager = GameManager.Instance; // GameManager�̃C���X�^���X���擾
        if (gameManager != null)
        {
            initialPosition = gameManager.GetInitialEnemyPosition(); // �����ʒu���擾
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);//���Ɉړ�������
    }

    void ReStart()
    {
        if (Input.GetKey(KeyCode.R))
        {
            // ���X�^�[�g���ɏ����ʒu�ɖ߂�
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