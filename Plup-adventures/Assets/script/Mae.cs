using UnityEngine;
using UnityEngine.SceneManagement;

public class Mae : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fim();
        }
    }

    public void fim()
    {
        SceneManager.LoadScene(6);
        Time.timeScale = 1;
    }
}
