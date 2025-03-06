using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private SpriteRenderer photoHolder;
    [SerializeField] private Sprite[] photos;
    [SerializeField] private float[] thresholds;
    float currentBalance = 0f;
    float levelStartTime = 0f;
    bool levelStarted = false;

    // Update is called once per frame
    void Update()
    {
        if (levelStarted)
        {
            if (Input.GetKey(KeyCode.R))
            {
                levelStarted = false;
                levelStartTime = 0;
                currentBalance = 0;
                slider.value = currentBalance;
            }
        }
        else if (currentBalance != 0)
        {
            levelStarted = true;
            levelStartTime = Time.timeSinceLevelLoad;
        }

        float force = 0.8f + (Time.timeSinceLevelLoad - levelStartTime) / 100;
        float input = Input.GetAxis("Horizontal");
        
        currentBalance += force * currentBalance * Time.deltaTime;
        currentBalance += input * Time.deltaTime;
        currentBalance = Mathf.Clamp(currentBalance, -1f, 1f);
        slider.value = currentBalance;

        Debug.Log($"balance: {currentBalance}");
        Debug.Log("time: " + Time.timeSinceLevelLoad);

        for (int i = 0; i < thresholds.Length; i++)
        {
            if (currentBalance <= thresholds[i])
            {
                photoHolder.sprite = photos[i];
                photoHolder.flipX = (currentBalance > 0);

                break;
            }
        }
    }
}
