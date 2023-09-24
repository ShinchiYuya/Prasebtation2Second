using UnityEngine.SceneManagement;
using UnityEngine;

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
    //float effectDuration = 3f; // エフェクトの持続時間
    float _h = 0;
    bool _isDead = false; // 死亡フラグ
    bool isRunning = true;
    bool isJumpping = false;

    SpriteRenderer _sprtRdr;
    Rigidbody2D _rb2d;
    Animator _anim;
    Vector3 transPos;
    GameObject collisionEffectPrefab; // 衝突エフェクトのプレハブ
    AudioSource audioSource; // オーディオソース

    public static object Instance { get; internal set; }


    protected void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        this._sprtRdr = GetComponent<SpriteRenderer>();
        this._sprtRdr.flipX = true;
        _currentHealth = _maxHealth;
        audioSource = GetComponent<AudioSource>();
        transPos = transform.position;
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
        if (_isDead) return; // 既に死亡している場合は処理を中断

        _currentHealth -= damage; // ダメージを体力から減算

        // Refreshメソッドの引数は修正が必要です（具体的なGameManagerやPlayerCounterScriptの実装に依存するため）。
        // Refresh(GameManager._life, PlayerCounterScript);

        // 体力が0以下になった場合は敵を破壊
        if (_currentHealth <= 0)
        {
            _isDead = true; // 死亡フラグを設定

            // 死亡時のサウンドを再生
            if (_deathAudio != null)
            {
                audioSource.PlayOneShot(_deathAudio);
            }

            SceneManager.LoadScene(targetSceneName);
        }
    }

    void ReStart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = transPos;
            this.gameObject.transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        }
    }
    void AnimControll()
    {
        this._anim.SetBool("isRunning", Mathf.Abs(_h) > 0); // 走行中のアニメーション
        this._anim.SetBool("isJumpping", !_isGrounded); // ジャンプ中のアニメーション

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && _isGrounded)
        {
            this._anim.SetTrigger("isJumpping"); // ジャンプトリガーをセット
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

        // 走っているかどうかをアニメーションに伝える
        this._anim.SetBool("isRunning", Mathf.Abs(_h) > 0 && _isGrounded);

        if (Mathf.Abs(_h) > 0 && _isGrounded)
        {
            if (_runAudio != null && audioSource != null && !audioSource.isPlaying)
            {
                isRunning = true;
                audioSource.PlayOneShot(_runAudio); // 走っている時のサウンド再生
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

                if (_jumpAudio != null && audioSource != null) // ジャンプ時のサウンド再生
                {
                    isJumpping = true;
                    audioSource.PlayOneShot(_jumpAudio);
                    Debug.Log("aaa0");
                }
                else
                {
                    isJumpping = false;
                    audioSource.Stop();
                }
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
            this.gameObject.transform.parent = collision.gameObject.transform;//Ground か Wall のタグに乗った時子オブジェクトにする
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(_damage);
        }
    }
}
