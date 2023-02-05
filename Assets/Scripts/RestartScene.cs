using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Restart();
        }
    }

    void Restart()
    {
        Initiate.Fade("Main", Color.black, 2f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
