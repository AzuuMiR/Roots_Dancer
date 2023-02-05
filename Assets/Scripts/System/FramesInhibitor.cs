using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FramesInhibitor : MonoBehaviour
{
    [SerializeField] [Range(10, 120)] private int maxFrameRate = 60;

    void Awake()
    {
        StartCoroutine(this.CheckFramerate());
    }

    private IEnumerator CheckFramerate()
    {
        int currentFrameRate = this.maxFrameRate;
        WaitForSeconds wait = new WaitForSeconds(0.5f);

        Application.targetFrameRate = this.maxFrameRate;
        QualitySettings.vSyncCount = 0; // VSync must be disabled
        while (true)
        {
            if (currentFrameRate != this.maxFrameRate)
            {
                Application.targetFrameRate = this.maxFrameRate;
                currentFrameRate = maxFrameRate;
            }
            yield return wait;
        }
    }

    // Used as testing - Update a text to show the current FPS
    // Can work in build
    /* float count;
    public Text framesCounter;

    IEnumerator Start()
    {
        while (true)
        {
            if (Time.timeScale == 1)
            {
                yield return new WaitForSeconds(0.1f);
                count = (1 / Time.deltaTime);
                framesCounter.text = "FPS :" + (Mathf.Round(count));
            }
            else
            {
                framesCounter.text = "Pause";
            }
            yield return new WaitForSeconds(0.5f);
        }
    } */
}
