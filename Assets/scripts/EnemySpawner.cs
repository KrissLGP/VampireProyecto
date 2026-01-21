using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Prefab del enemigo

    public Transform player;
    // Referencia al jugador

    public float spawnRadius = 10f;
    // Distancia desde el jugador donde aparece el enemigo

    public float spawnInterval = 2f;
    // Tiempo entre spawns

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (player == null || enemyPrefab == null) return;

        // Elegir una dirección aleatoria
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        // Posición fuera de cámara (alrededor del jugador)
        Vector3 spawnPosition = player.position + (Vector3)(randomDirection * spawnRadius);

        // Crear el enemigo
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
