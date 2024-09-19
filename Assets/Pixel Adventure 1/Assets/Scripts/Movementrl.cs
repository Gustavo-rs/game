using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementrl : MonoBehaviour
{
    [SerializeField]
    private bool vertical = false;

    private float initialX;
    private float initialY;

    [SerializeField]
    private float velocity;

    private bool isReverse = true;

    [SerializeField]
    private float distance = 1f;

    void Start()
    {
        initialX = transform.position.x;
        initialY = transform.position.y;
    }

    void Update()
    {
        float currentPos = vertical ? transform.position.y : transform.position.x;
        float initialPos = vertical ? initialY : initialX;

        isReverse = (currentPos < initialPos - distance) ? true : (currentPos > initialPos + distance) ? false : isReverse;

        float direction = isReverse ? distance : -distance;

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
