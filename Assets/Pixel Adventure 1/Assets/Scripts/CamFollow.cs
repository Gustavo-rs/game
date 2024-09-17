using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player; // Refer�ncia ao transform do jogador
    public float smoothSpeed = 0.125f; // Velocidade de suaviza��o do movimento da c�mera
    public Vector3 offset; // Offset da c�mera em rela��o ao jogador

    void LateUpdate()
    {
        // Define a posi��o da c�mera com base na posi��o do jogador e o offset
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Garante que a c�mera n�o se mova no eixo z
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
