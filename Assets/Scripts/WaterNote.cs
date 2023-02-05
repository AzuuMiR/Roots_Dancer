using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterNote : MonoBehaviour
{
    [SerializeField] int directionId;
    public bool canBePressed;
    public KeyCode keyToPress;
    public KeyCode altKey;

    void Update()
    {
        transform.position += new Vector3(0f, GameManager.Instance.BeatTempo * Time.deltaTime, 0f);

        if (Input.GetKeyDown(keyToPress) || Input.GetKeyDown(altKey))
        {
            if (canBePressed)
            {
                GameManager.Instance.NoteHit(directionId);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            GameManager.Instance.NoteMissed();
            Destroy(gameObject);
        }
    }
}
