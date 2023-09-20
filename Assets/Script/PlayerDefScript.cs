using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerDefScript : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;
    [SerializeField] string targetSceneName;
    [SerializeField] int _jumpCount;

    bool _isGrounded = true;
    int _maxJump = 2;
    int _maxHealth = 1;
    int _currentHealth;
    int _damage = 1;
    float effectDuration = 3f; // エフェクトの持続時間
    float _h = 0;
    bool _isDead = false; // 死亡フラグ

    SpriteRenderer _sprtRdr;
    Rigidbody2D _rb2d;
    Animator _anim;
    Vector3 initialPosition;
    GameObject collisionEffectPrefab; // 衝突エフェクトのプレハブ
    AudioClip deathSound; // 死亡時のサウンド
    AudioSource audioSource; // オーディオソース

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
        if (_isDead) return; // 既に死亡している場合は処理を中断

        _currentHealth -= damage; // ダメージを体力から減算

        // Refreshメソッドの引数は修正が必要です（具体的なGameManagerやPlayerCounterScriptの実装に依存するため）。
        // Refresh(GameManager._life, PlayerCounterScript);

        // 体力が0以下になった場合は敵を破壊
        if (_currentHealth <= 0)
        {
            _isDead = true; // 死亡フラグを設定

            // 死亡時のサウンドを再生
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
        this._anim.SetBool("moving", (this._h != 0));
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.W))) { this._anim.SetTrigger("jump"); }
    }

    void ForceDown()
    {
        if (Input.GetKey(KeyCode.S))
        {
            _rb2d.AddForce(Vector2.down * _jumpForce / 5);
        }
    }

    void Move()
    {
        _h = Input.GetAxis("Horizontal");
        this._sprtRdr.flipX = (this._h < 0);
        Vector2 velocity = new Vector2(_h * _speed ,_rb2d.velocity.y);
        _rb2d.velocity = velocity;
    }

    void Jump()
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
