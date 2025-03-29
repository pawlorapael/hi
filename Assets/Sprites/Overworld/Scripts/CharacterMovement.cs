using UnityEngine;

public class CharacterMovementOverWorld : MonoBehaviour
{

    public float moveSpeed;

    public bool isFacingRight = false;

    private Rigidbody2D rb;

    private float x; 
    private float y;
    private Vector2 input; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        
        input = new Vector2 (x, y);
        input.Normalize();

        FlipSprite();
    }

    void FixedUpdate()
    {
        rb.velocity = input * moveSpeed;
    }

    void FlipSprite()
    {
        if (x < 0 && !isFacingRight)
            Flip();
        else if (x > 0 && isFacingRight)
            Flip();
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 ls = transform.localScale;
        ls.x *= -1f;
        transform.localScale = ls;
    }
}
