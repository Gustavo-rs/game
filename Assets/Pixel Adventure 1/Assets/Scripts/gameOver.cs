using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("scene-1");
    }
}
