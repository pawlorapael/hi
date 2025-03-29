using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public LayerMask wallLayer;

    public Sprite frontSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite upSprite;

    private SpriteRenderer spriteRenderer;
    private Vector2 moveDirection;
    private bool isMoving = false;
    private CameraShake cameraShake;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    void Update()
    {
        if (!isMoving)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (horizontal != 0)
            {
                StartMoving(new Vector2(horizontal, 0));
                ChangeSprite(horizontal < 0 ? leftSprite : rightSprite);
            }
            else if (vertical != 0)
            {
                StartMoving(new Vector2(0, vertical));
                ChangeSprite(vertical > 0 ? upSprite : frontSprite);
            }
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Move();
        }
    }

    void StartMoving(Vector2 direction)
    {
        moveDirection = direction.normalized;
        isMoving = true;
    }

    void Move()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, 1.5f, wallLayer);

        if (hit.collider != null)
        {
            isMoving = false;
            ChangeSprite(frontSprite); 

            if (cameraShake != null)
            {
                StartCoroutine(cameraShake.Shake(0.2f, 2f));
            }
            return;
        }

        transform.position += (Vector3)(moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void ChangeSprite(Sprite newSprite)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}
