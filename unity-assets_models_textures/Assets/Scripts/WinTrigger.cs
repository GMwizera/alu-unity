using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public int winFontSize = 60;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Timer timer = other.GetComponent<Timer>();
        timer.enabled = false;
        timer.TimerText.fontSize = winFontSize;
        timer.TimerText.color = Color.green;
    }
}
