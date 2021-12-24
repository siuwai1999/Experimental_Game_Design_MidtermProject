using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 10f;
    public Vector3 Size;
    public Vector3 Of;
    public LayerMask PlayerLayer;
    public bool GetPlayer;
    public Transform Player;
    public float Angle;

    private Rigidbody2D rb;
    private Animator animator;

    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position + transform.TransformDirection(Of) , Size);
    }

    public void CheckPlayer()
    {
        Collider2D PlayerIn = Physics2D.OverlapBox(transform.position + transform.TransformDirection(Of), Size,0, PlayerLayer);
        GetPlayer = PlayerIn;
    }

    public void Move()
    {
        if (Input.GetButtonUp("Jump"))
        {
            rb.AddForce(new Vector2(0, 400));
        }
        if (Player.position.x > transform.position.x)
        {
            Angle = 180;
            transform.rotation = new Quaternion(0, Angle, 0, 0);
        }
        else if (Player.position.x < transform.position.x)
        {
            Angle = 0;
            transform.rotation = new Quaternion(0, Angle, 0, 0);
        }
        if (GetPlayer)
        {
            rb.velocity = transform.TransformDirection( new Vector2(- Speed * Time.deltaTime, rb.velocity.y));
            animator.SetBool("Walk_Bool", true);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("Walk_Bool", false);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        CheckPlayer();
        Move();
    }
}
