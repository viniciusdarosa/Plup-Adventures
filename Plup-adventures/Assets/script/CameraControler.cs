
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Refer�ncias")]
    public Transform player; // Refer�ncia ao player

    [Header("Configura��es de movimento")]
    public float smoothSpeed = 5f; // Velocidade de suaviza��o

    [Header("Limites da c�mera")]
    public float minX, maxX;
    public float minY, maxY;

    private Vector3 offset = new Vector3(0, 0, -10); // Dist�ncia da c�mera ao player

    private void LateUpdate()
    {
        if (player == null) return;

        // Posi��o desejada da c�mera com base no player
        Vector3 desiredPosition = player.position + offset;

        // Limita a posi��o da c�mera dentro dos limites definidos
        float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(desiredPosition.y, minY, maxY);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        // Suaviza o movimento entre a posi��o atual e a desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed * Time.deltaTime);

        // Aplica a posi��o final
        transform.position = smoothedPosition;
    }
}