using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    // El objeto que la cámara va a seguir (el Player)

    public float smoothSpeed = 5f;
    // Qué tan suave sigue la cámara (más alto = más rápido)

    void LateUpdate()
    {
        // LateUpdate se ejecuta después del movimiento del jugador
        // Ideal para cámaras

        if (target == null) return;
        // Seguridad: si no hay objetivo, no hace nada

        Vector3 desiredPosition = new Vector3(
            target.position.x,
            target.position.y,
            transform.position.z
        );
        // Posición deseada: misma X e Y que el jugador,
        // pero mantiene la Z de la cámara (-10)

        Vector3 smoothPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );
        // Interpolación suave entre posición actual y deseada

        transform.position = smoothPosition;
        // Mueve la cámara
    }
}