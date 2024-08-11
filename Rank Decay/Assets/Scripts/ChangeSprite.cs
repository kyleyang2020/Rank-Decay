using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
    public Image img;
    public Sprite pressedButton;
    public Sprite defaultButton;
    public KeyCode playButton;

    // Start is called before the first frame update
    void Start()
    {
        img = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(playButton))
        {
            img.sprite = pressedButton;
        }
        if (Input.GetKeyUp(playButton))
        {
            img.sprite = defaultButton;
        }
    }
}
