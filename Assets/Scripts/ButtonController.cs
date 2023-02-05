using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer sprite;
    public Vector3 baseScale = new Vector3(1f, 1f, 1f);
    public Vector3 pressedScale = new Vector3(1.5f, 1.5f, 1.5f);

    public KeyCode keyToPress;
    public KeyCode altKey;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            sprite.transform.localScale = pressedScale;
        }
        if (Input.GetKeyDown(altKey))
        {
            sprite.transform.localScale = pressedScale;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            sprite.transform.localScale = baseScale;
        }
        if (Input.GetKeyUp(altKey))
        {
            sprite.transform.localScale = baseScale;
        }
    }
}
