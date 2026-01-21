using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    // Velocidad del personaje

    private Rigidbody2D rb;
    // Rigidbody para mover al jugador

    private Vector2 movement;
    // Dirección del movimiento

    private SpriteRenderer spriteRenderer;
    // Referencia al Sprite Renderer (para hacer el flip)

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // Obtiene el Rigidbody del jugador

        spriteRenderer = GetComponent<SpriteRenderer>();
        // Obtiene el Sprite Renderer del jugador
    }

    void Update()
    {
        // Leer input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalizar para que diagonal no sea más rápida
        movement = movement.normalized;

        // FLIP DEL SPRITE
        if (movement.x > 0)
        {
            // Si se mueve a la derecha, mira a la derecha
            spriteRenderer.flipX = false;
        }
        else if (movement.x < 0)
        {
            // Si se mueve a la izquierda, se voltea
            spriteRenderer.flipX = true;
        }
    }

    void FixedUpdate()
    {
        // Aplicar movimiento
        rb.linearVelocity = movement * moveSpeed;
    }
}