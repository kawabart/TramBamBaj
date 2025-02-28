using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private SpriteRenderer photoHolder;
    [SerializeField] private Sprite[] photos;
    [SerializeField] private float[] thresholds;
    float currentValue = 0f;
    bool levelStarted = false;
    float levelStartTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (!levelStarted && currentValue != 0)
        {
            levelStarted = true;
            levelStartTime = Time.timeSinceLevelLoad;
        }

        float change = 0.001f + (Time.timeSinceLevelLoad - levelStartTime) / 10000;
        float input = Input.GetAxis("Horizontal") * Time.deltaTime;

        currentValue += input;
        currentValue += change * currentValue;
        currentValue = Mathf.Clamp(currentValue, -1f, 1f);
        slider.value = currentValue;

        Debug.Log(currentValue);

        for (int i = 0; i < thresholds.Length; i++)
        {
            if (currentValue <= thresholds[i])
            {
                photoHolder.sprite = photos[i];
                photoHolder.flipX = (currentValue > 0);

                break;
            }
        }
    }
}
