using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private SpriteRenderer photoHolder;
    [SerializeField] private Sprite[] photos;
    [SerializeField] private float[] values;
    float currentValue = 0.5f;
    private Sprite photo;
    int state = 2;

    // Start is called before the first frame update
    void Start()
    {
        //photo = GetComponent<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {
        float change = 0.001f + Time.timeSinceLevelLoad / 10000;
        float input = Input.GetAxis("Horizontal") * Time.deltaTime;
        Debug.Log(input);

        if (input < 0)
        {
            currentValue += input;
        }
        else if (input > 0)
        {
            currentValue += input;
        }

        if (currentValue < 0.5f)
        {
            currentValue -= change;
        }
        else if (currentValue > 0.5f)
        {
            currentValue += change;
        }

        slider.value = currentValue;

        //for (int i = 0; i < photos.Length; i++) { }

        int index = 0;

        foreach (float val in values)
        {
            if (currentValue <= val)
            {
                photoHolder.sprite = photos[index];
                if (currentValue > 0.5f)
                {
                    photoHolder.flipX = true;
                }
                else
                {
                    photoHolder.flipX = false;
                }
                break;
            }
            index++;
        }

    }
}
