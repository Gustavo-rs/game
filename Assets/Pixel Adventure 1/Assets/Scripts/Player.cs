using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    Animator animator;
    [SerializeField]
    SpriteRenderer sr;

    private Rigidbody2D rb;
    private bool isJumping = true;

    public Camera mainCamera;
    public float horizontalOffset = 0f;
    [SerializeField]
    public float smoothSpeed = 10f;
    public float cameraSize = 5f;

    private float posicaoX;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        posicaoX = transform.position.x;

        if (!mainCamera)
            mainCamera = Camera.main;

        if (mainCamera.orthographic)
            mainCamera.orthographicSize = cameraSize;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        };

        float y = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(0, y, 0);


        if (transform.position.y < -5f)
        {
            transform.position = new Vector2(posicaoX, 0);
        }

        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(x, 0, 0);

        if(x != 0){
            if(x < 0)
            {
                sr.flipX = true;
            }

            if(x > 0)
            {
                sr.flipX = false;
            }
            animator.SetBool("running",true);
        }else{
            animator.SetBool("running", false);
        }

        if (mainCamera)
        {
            Vector3 targetPosition = new Vector3(transform.position.x + horizontalOffset, mainCamera.transform.position.y, mainCamera.transform.position.z);
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("jump", false);
            isJumping = false; 
        }

        if (collision.gameObject.tag == "dead")
        {
            transform.position = new Vector2(posicaoX, 0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("jump", true);
            isJumping = true;
        }
    }
}
