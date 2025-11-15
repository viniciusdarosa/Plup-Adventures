
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Referências")]
    public Transform player; // Referência ao player

    [Header("Configurações de movimento")]
    public float smoothSpeed = 5f; // Velocidade de suavização

    [Header("Limites da câmera")]
    public float minX, maxX;
    public float minY, maxY;

    private Vector3 offset = new Vector3(0, 0, -10); // Distância da câmera ao player

    private void LateUpdate()
    {
        if (player == null) return;

        // Posição desejada da câmera com base no player
        Vector3 desiredPosition = player.position + offset;

        // Limita a posição da câmera dentro dos limites definidos
        float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(desiredPosition.y, minY, maxY);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        // Suaviza o movimento entre a posição atual e a desejada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed * Time.deltaTime);

        // Aplica a posição final
        transform.position = smoothedPosition;
    }
}