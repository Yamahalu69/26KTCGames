using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Fiveminitu : MonoBehaviour
{
    [Tooltip("Seconds until game over.")]
    [SerializeField] private float countdownSeconds = 60f;

    [Tooltip("Optional scene name to load when the timer expires.")]
    [SerializeField] private string gameOverSceneName = "";

    [Tooltip("Optional UnityEvent invoked when the timer reaches zero.")]
    [SerializeField] private UnityEvent onGameOver;

    private float remainingTime;
    private bool isGameOver;

    void Start()
    {
        remainingTime = countdownSeconds;
        isGameOver = false;
    }

    void Update()
    {
        if (isGameOver)
            return;

        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        if (isGameOver)
            return;

        isGameOver = true;
        Debug.Log("Time's up: Game Over");

        if (onGameOver != null)
            onGameOver.Invoke();

        if (!string.IsNullOrEmpty(gameOverSceneName))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(gameOverSceneName);
        }
        else
        {
            Time.timeScale = 0f;
        }
    }

    public float GetRemainingTime()
    {
        return remainingTime;
    }
}
