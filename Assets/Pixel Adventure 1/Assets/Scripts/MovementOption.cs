using UnityEngine;

public class MovementOption : MonoBehaviour
{
    [SerializeField]
    private float velocity = 1f;

    [SerializeField]
    private float targetXPosition = -5f;

    [SerializeField]
    private float playerTriggerXPosition = 2f;

    private bool moveLeft = false;

    [SerializeField]
    private Transform playerTransform;

    void Update()
    {
        if (playerTransform.position.x >= playerTriggerXPosition)
        {
            moveLeft = true;
        }

        if (moveLeft)
        {
            transform.Translate(0, velocity * Time.deltaTime, 0);

            if (transform.position.x <= targetXPosition)
            {
                moveLeft = false;
                transform.position = new Vector3(0, 0, 0);
            }
        }
    }
}
