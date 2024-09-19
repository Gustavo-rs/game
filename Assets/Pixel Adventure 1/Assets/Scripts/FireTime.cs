using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTime : MonoBehaviour
{
    [SerializeField]
    private float delayInSeconds = 5;

    [SerializeField]
    private Sprite spriteOn;

    [SerializeField]
    private Sprite spriteOff;

    [SerializeField]
    private string onTag = "Ground";

    [SerializeField]
    private string offTag = "dead";

    private SpriteRenderer spriteRenderer;
    private bool isOn = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ToggleSpriteAndTag());
    }

    private IEnumerator ToggleSpriteAndTag()
    {
        while (true)
        {
            isOn = !isOn;

            if (isOn)
            {
                spriteRenderer.sprite = spriteOn;
                gameObject.tag = onTag;
            }
            else
            {
                spriteRenderer.sprite = spriteOff;
                gameObject.tag = offTag;
            }

            yield return new WaitForSeconds(delayInSeconds);
        }
    }
}
