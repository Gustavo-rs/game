using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("scene-1");
    }

    public void StartGameScene2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("scene-2");
    }

    public void TelaInicial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("start");
    }
}
