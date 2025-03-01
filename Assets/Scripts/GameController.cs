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

        float change = 0.8f + (Time.timeSinceLevelLoad - levelStartTime) / 100;
        float input = Input.GetAxis("Horizontal");
        
        currentValue += change * currentValue * Time.deltaTime;
        currentValue += input * Time.deltaTime;
        currentValue = Mathf.Clamp(currentValue, -1f, 1f);
        slider.value = currentValue;

        Debug.Log(currentValue);
        Debug.Log(Time.timeSinceLevelLoad);

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
