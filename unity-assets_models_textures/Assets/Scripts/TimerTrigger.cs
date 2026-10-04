using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    private Transform player;
    private Timer timer;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.transform;
        timer = playerObject.GetComponent<Timer>();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            StartTimer();
    }

    void Update()
    {
        // This trigger is scaled to 0 on X and Z, so physics may never report the exit.
        // Also start the timer once the Player has moved away from it.
        Vector3 offset = player.position - transform.position;
        offset.y = 0f;
        if (offset.sqrMagnitude > 0.01f)
            StartTimer();
    }

    void StartTimer()
    {
        timer.enabled = true;
        // Only needed once; falling and restarting keeps the timer running.
        enabled = false;
    }
}
