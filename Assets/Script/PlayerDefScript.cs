using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public class PlayerDefScript : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;
    [SerializeField] string targetSceneName;
    [SerializeField] int _jumpCount;
    [SerializeField] int _damageAmount;
    [SerializeField] AudioClip _jumpAudio;
    [SerializeField] AudioClip _runAudio;
    [SerializeField] AudioClip _deathAudio;

    bool _isGrounded = true;
    int _maxJump = 2;
    int _maxHealth = 1;
    int _currentHealth;
    int _damage = 1;
    //float effectDuration = 3f; // �G�t�F�N�g�̎�������
    float _h = 0;
    bool _isDead = false; // ���S�t���O
    bool isRunning = true;
    bool isJumpping = false;

    SpriteRenderer _sprtRdr;
    Rigidbody2D _rb2d;
    Animator _anim;
    Vector3 initialPosition;
    GameObject collisionEffectPrefab; // �Փ˃G�t�F�N�g�̃v���n�u
    AudioClip deathSound; // ���S���̃T�E���h
    AudioSource audioSource; // �I�[�f�B�I�\�[�X

    public static object Instance { get; internal set; }


    protected void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        this._sprtRdr = GetComponent<SpriteRenderer>();
        this._sprtRdr.flipX = true;
        _currentHealth = _maxHealth;

        initialPosition = transform.position;
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

        _currentHealth -= damage; // �_���[�W��̗͂��猸�Z

        // Refresh���\�b�h�̈����͏C�����K�v�ł��i��̓I��GameManager��PlayerCounterScript�̎����Ɉˑ����邽�߁j�B
        // Refresh(GameManager._life, PlayerCounterScript);

        // �̗͂�0�ȉ��ɂȂ����ꍇ�͓G��j��
        if (_currentHealth <= 0)
        {
            _isDead = true; // ���S�t���O��ݒ�

            // ���S���̃T�E���h���Đ�
            if (deathSound != null)
            {
                audioSource.PlayOneShot(deathSound);
            }

            SceneManager.LoadScene(targetSceneName);
        }
    }

    void ReStart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = initialPosition;
            this.gameObject.transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        }
    }
    void AnimControll()
    {
        this._anim.SetBool("isRunning", Mathf.Abs(_h) > 0); // ���s���̃A�j���[�V����
        this._anim.SetBool("isJumpping", !_isGrounded); // �W�����v���̃A�j���[�V����

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && _isGrounded)
        {
            this._anim.SetTrigger("isJumpping"); // �W�����v�g���K�[���Z�b�g
        }
    }


    void ForceDown()
    {
        if (Input.GetKey(KeyCode.S))
        {
            _rb2d.AddForce(Vector2.down * _jumpForce / 5);
        }
    }

    /*void Move()
    {
        _h = Input.GetAxis("Horizontal");
        this._sprtRdr.flipX = (this._h < 0);
        Vector2 velocity = new Vector2(_h * _speed ,_rb2d.velocity.y);
        _rb2d.velocity = velocity;

        if (Mathf.Abs(_h) > 0 && _isGrounded)
        {
            this._anim.SetBool("isRunning",isRunning);

            if (_runAudio != null && audioSource != null && !audioSource.isPlaying)
            {
                isRunning = true;

                audioSource.PlayOneShot(_runAudio);
            }
        }
        else
        {
            if (audioSource != null)
            {
                isRunning = false;
                audioSource.Stop();
            }
        }
    }*/

    void Move()
    {
        _h = Input.GetAxis("Horizontal");
        this._sprtRdr.flipX = (this._h < 0);
        Vector2 velocity = new Vector2(_h * _speed, _rb2d.velocity.y);
        _rb2d.velocity = velocity;

        // �����Ă��邩�ǂ������A�j���[�V�����ɓ`����
        this._anim.SetBool("isRunning", Mathf.Abs(_h) > 0 && _isGrounded);

        if (Mathf.Abs(_h) > 0 && _isGrounded)
        {
            if (_runAudio != null && audioSource != null && !audioSource.isPlaying)
            {
                isRunning = true;
                audioSource.PlayOneShot(_runAudio);
            }
        }
        else
        {
            if (audioSource != null)
            {
                isRunning = false;
                audioSource.Stop();
            }
        }
    }

    void Jump()
    {
        this._anim.SetTrigger("isJumpping");

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

    public void InflictDamage()
    {
        PlayerDefScript player = GetComponent<PlayerDefScript>();
        if (player != null)
        {
            player.TakeDamage(_damageAmount);
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            _isGrounded = true;
            _jumpCount = 0;
            this.gameObject.transform.parent = collision.gameObject.transform;//Ground �� Wall �̃^�O�ɏ�������q�I�u�W�F�N�g�ɂ���
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(_damage);
        }
    }
}
