using UnityEngine;


public delegate void Dead();

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float lives = 3f;
    [SerializeField] private float jumpForce = 1.1f;

    public Dead OnDied;

    private bool isGrounded = false;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private static Hero _hero;
    private bool isFacingRight = true;
    private bool isLive;

    public static Hero Instance
    {
        get
        {
            {
                return _hero;
            }
        }
    }

    private void Awake()
    {
        _hero = this;
        isLive = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (isGrounded)
        {
            State = States.idle;
        }

        if (Input.GetButton("Horizontal"))
        {
            Run();
        }

        if (isGrounded && Input.GetButton("Vertical"))
        {
            Jump();
        }
    }

    private void Run()
    {
        if (isGrounded)
        {
            State = States.run;
        }

        float move = Input.GetAxis("Horizontal");
        //Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + (new Vector3(move, 0f, 0f)),
            speed * Time.deltaTime);
        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Касается ли игрок какой либо поверхности
    /// </summary>
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.25f);
        isGrounded = collider.Length > 1;

        if (!isGrounded)
        {
            State = States.jump;
        }
    }

    public void Damage(int damege)
    {
        if (isLive)
        {
            lives -= damege;
            if (lives <= 0)
            {
                isLive = false;
                Die();
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        OnDied?.Invoke();
    }

    /// <summary> Задать/Получить состояние</summary>
    private States State
    {
        get { return (States) anim.GetInteger("State"); }
        set { anim.SetInteger("State", (int) value); } //todo Проверка на вход значения
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.GetComponent<Enemy>())
        {
            Damage(1);
        }
    }
}

/// <summary>enum типов состояний</summary>
public enum States
{
    idle,
    run,
    jump
}