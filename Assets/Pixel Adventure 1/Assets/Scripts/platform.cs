using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    [SerializeField]
    private float time = 1f;

    [SerializeField]
    private int velocity = 1;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float playerTriggerX = -24.64f;

    private float timer = 0f;
    private bool shouldMove = false;

    void Update()
    {
        if (player.position.x >= playerTriggerX && !shouldMove)
        {
            timer += Time.deltaTime;

            if (timer >= time)
            {
                shouldMove = true;
            }
        }

        if (shouldMove)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * velocity);

            if (transform.position.y < -10f)
            {
                shouldMove = false;
            }
        }
    }
}
