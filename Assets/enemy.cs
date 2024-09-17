using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private bool vertical = false;

    private float initialX;
    private float initialY;

    [SerializeField]
    private float velocity;

    private bool isReverse = true;

    void Start()
    {
        initialX = transform.position.x;
        initialY = transform.position.y;
    }

    void Update()
    {
        float currentPos = vertical ? transform.position.y : transform.position.x;
        float initialPos = vertical ? initialY : initialX;

        isReverse = (currentPos < initialPos - 1) ? true : (currentPos > initialPos + 1) ? false : isReverse;

        float direction = isReverse ? 1 : -1;

        if (vertical)
        {
            transform.Translate(0, direction * velocity * Time.deltaTime, 0);
        }
        else
        {
            transform.Translate(direction * velocity * Time.deltaTime, 0, 0);
        }
    }
}
