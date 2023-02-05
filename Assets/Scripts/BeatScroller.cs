using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    private float beatTempo;
    public bool hasStarted;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public GameObject waterNote1;
    public GameObject waterNote2;

    void Start()
    {
        beatTempo = GameManager.Instance.BeatTempo;
    }

    public void StartScrolling()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            if (Random.value < 0.5f) Instantiate(waterNote1, spawnPoint1);
            else Instantiate(waterNote2, spawnPoint2);
            yield return new WaitForSeconds(beatTempo);
        }
    }

    public void StopScrolling()
    {
        StopAllCoroutines();
    }
}
