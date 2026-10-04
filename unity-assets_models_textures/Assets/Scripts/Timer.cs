using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;

    private float elapsed = 0f;

    void Update()
    {
        elapsed += Time.deltaTime;
        int minutes = (int)(elapsed / 60f);
        float seconds = elapsed % 60f;
        TimerText.text = string.Format("{0}:{1:00.00}", minutes, seconds);
    }
}
