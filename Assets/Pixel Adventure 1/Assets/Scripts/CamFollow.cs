using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador
    public float smoothSpeed = 0.125f; // Velocidade de suavização do movimento da câmera
    public Vector3 offset; // Offset da câmera em relação ao jogador

    void LateUpdate()
    {
        // Define a posição da câmera com base na posição do jogador e o offset
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Garante que a câmera não se mova no eixo z
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
