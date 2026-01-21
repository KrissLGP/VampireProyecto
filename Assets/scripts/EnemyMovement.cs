using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    // Velocidad del enemigo

    private Transform player;
    // Referencia al jugador

    void Start()
    {
        // Buscar al jugador por su tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        // Dirección hacia el jugador
        Vector2 direction = (player.position - transform.position).normalized;

        // Moverse hacia el jugador
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }
}
