using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private SpriteRenderer photoHolder;
    [SerializeField] private Sprite[] photos;
    [SerializeField] private float[] thresholds;
    float currentValue = 0.5f;

    // Update is called once per frame
    void Update()
    {
        float change = 0.001f + Time.timeSinceLevelLoad / 10000;
        float input = Input.GetAxis("Horizontal") * Time.deltaTime;

        currentValue += input;

        if (currentValue < 0.5f)
            currentValue -= change;
        else if (currentValue > 0.5f)
            currentValue += change;

        slider.value = currentValue;

        Debug.Log(currentValue);

        for (int i = 0; i < thresholds.Length; i++)
        {
            if (currentValue <= thresholds[i])
            {
                photoHolder.sprite = photos[i];
                photoHolder.flipX = (currentValue > 0.5f);

                break;
            }
        }
    }
}
