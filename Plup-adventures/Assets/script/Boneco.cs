using UnityEngine;

public class Boneco : MonoBehaviour
{
    public Gamemanager gamemanager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"));

        gamemanager.perdervidas(1);
    }
}
