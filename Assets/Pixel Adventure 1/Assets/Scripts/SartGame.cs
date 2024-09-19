using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameeee()
    {
        Debug.Log("CLICK");
        UnityEngine.SceneManagement.SceneManager.LoadScene("scene-1");
    }
}
