using UnityEngine;
using UnityEngine.SceneManagement;

public class Boneco : MonoBehaviour
{
    public Gamemanager gamemanager;
    public bool isSpecialEnemy = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TakeHit();
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gamemanager.PerderV(1);
            gamemanager.PerderP(5);
        }
    }

    public int hitsToDie = 2;
    private int currentHits = 0;

    public void TakeHit()
    {
        currentHits++;

        if (currentHits >= hitsToDie)
        {
            if (isSpecialEnemy)
            {
                NextLevel();
            }
            Destroy(gameObject);
        }
    }
    void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene < 5 && currentScene > 1)
        {
            SceneManager.LoadScene(currentScene + 1);
        }
        else
        {
            Debug.Log("Você terminou todas as fases!");
            
        }
    }
}




