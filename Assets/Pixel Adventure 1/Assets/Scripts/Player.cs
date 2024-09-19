using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private Sprite novoSprite;

    Scene cenaAtual;

    [SerializeField]
    private GameObject objectToShow;

    private Rigidbody2D rb;
    private bool isJumping = true;

    public Camera mainCamera;
    public float horizontalOffset = 0f;
    [SerializeField]
    public float smoothSpeed = 10f;
    public float cameraSize = 5f;

    private float posicaoX;

    [SerializeField]
    private float teleportX;

    [SerializeField]
    private float teleportY;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        posicaoX = transform.position.x;

        if (!mainCamera)
            mainCamera = Camera.main;

        if (mainCamera.orthographic)
            mainCamera.orthographicSize = cameraSize;

        cenaAtual = SceneManager.GetActiveScene();

        if (objectToShow != null)
        {
            objectToShow.SetActive(false);
        }
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
            if (cenaAtual.name == "scene-2")
            {
                Debug.Log("Cena atual: " + cenaAtual.name);

                Debug.Log("TESTEEEE0");
                UnityEngine.SceneManagement.SceneManager.LoadScene("game-over-2");
            }

            if (cenaAtual.name == "scene-1")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("game-over");
            }
            
        }

        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(x, 0, 0);

        if (x != 0)
        {
            if (x < 0)
            {
                sr.flipX = true;
            }

            if (x > 0)
            {
                sr.flipX = false;
            }
            animator.SetBool("running", true);
        }
        else
        {
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
            if (cenaAtual.name == "scene-2")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("game-over-2");
            }

            if (cenaAtual.name == "scene-1")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("game-over");
            }
        }

        if (collision.gameObject.tag == "free")
        {
            GameObject idleObject = GameObject.FindGameObjectWithTag("free_enemy");
            GameObject itemObject = GameObject.FindGameObjectWithTag("free");

            if (itemObject != null)
            {
                Destroy(itemObject);
            }

            if (idleObject != null)
            {
                Destroy(idleObject);
            }
        }

        

        if (collision.gameObject.tag == "end")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("congrats");
        }

        if (collision.gameObject.tag == "teleport")
        {
            Vector3 novaPosicao = new Vector3(teleportX, teleportY, 0.0f);
            transform.position = novaPosicao;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "princesa")
        {
            if (objectToShow != null)
            {
                StartCoroutine(AnimateImageAndHide());
            }
        }

        if (other.gameObject.tag == "save_princesa")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("congrats_save_princesa");
        }

        if (other.gameObject.tag == "aprimoramento")
        {
            if (sr != null && novoSprite != null)
            {
                animator.enabled = false;

                GameObject apri = GameObject.FindGameObjectWithTag("aprimoramento");

                if (apri != null)
                {
                    sr.sprite = novoSprite;
                    Destroy(apri);
                }
            }
        }
    }

    private IEnumerator AnimateImageAndHide()
    {
        objectToShow.SetActive(true);
        Vector3 originalScale = objectToShow.transform.localScale;
        Vector3 targetScale = originalScale * 1.5f;

        float duration = 0.5f;
        float time = 0;

        while (time < duration)
        {
            objectToShow.transform.localScale = Vector3.Lerp(originalScale, targetScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        objectToShow.transform.localScale = targetScale; 

        yield return new WaitForSeconds(0.5f);

        objectToShow.transform.localScale = originalScale;
        objectToShow.SetActive(false);
    }

}
