using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerDefScript : MonoBehaviour
{
    [SerializeField] public float _speed;
    [SerializeField] public float _jumpForce;
    [SerializeField] public bool _isGrounded = true;
    [SerializeField] public int _jumpCount;
    [SerializeField] public int _maxJump = 2;
    [SerializeField] public int _maxHealth = 1;
    [SerializeField] public int _currentHealth;
    [SerializeField] public int _damage = 1; 

    SpriteRenderer _sprtRdr;
    protected Rigidbody2D _rb2d;
    protected Animator _anim;
    protected float _h = 0;

    public GameObject collisionEffectPrefab; // �Փ˃G�t�F�N�g�̃v���n�u
    public float effectDuration = 3f; // �G�t�F�N�g�̎�������
    public AudioClip deathSound; // ���S���̃T�E���h
    private AudioSource audioSource; // �I�[�f�B�I�\�[�X
    private bool _isDead = false; // ���S�t���O

    protected void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        this._sprtRdr = GetComponent<SpriteRenderer>();
        this._sprtRdr.flipX = true;
        _currentHealth = _maxHealth;
    }

    protected void Update()
    {
        Move();
        Jump();
        ForceDown();
        AnimControll();
        ReStart();
    }

    
    public void TakeDamage(int damage)
    {
        if (_isDead) return; // ���Ɏ��S���Ă���ꍇ�͏����𒆒f

        _currentHealth -= _damage; // �_���[�W��̗͂��猸�Z

        // �̗͂�0�ȉ��ɂȂ����ꍇ�͓G��j��
        if (_currentHealth <= 0)
        {
            _isDead = true; // ���S�t���O��ݒ�

            // ���S���̃T�E���h���Đ�
            if (deathSound != null)
            {
                audioSource.PlayOneShot(deathSound);
            }

            SceneManager.LoadScene("TitleScene");
        }
    }
    private void ReStart()
    {
        if (Input.GetKey(KeyCode.R))
        {
            this.gameObject.transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        }
    }
    private void AnimControll()
    {
        this._anim.SetBool("moving", (this._h != 0));
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.W))) { this._anim.SetTrigger("jump"); }
    }

    private void ForceDown()
    {
        if (Input.GetKey(KeyCode.S))
        {
            _rb2d.AddForce(Vector2.down * _jumpForce / 5);
        }
    }

    protected void Move()
    {
        _h = Input.GetAxis("Horizontal");
        this._sprtRdr.flipX = (this._h < 0);
        Vector2 velocity = new Vector2(_h * _speed ,_rb2d.velocity.y);
        _rb2d.velocity = velocity;
    }

    protected void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.W)))
        {
            if (_isGrounded || _jumpCount < _maxJump)
            {
                _rb2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _jumpCount++;
                _isGrounded = false;
            }
        }
    }

    protected void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            _jumpCount = 0;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(_damage);
        }
    }
}
