using UnityEngine;
public class Coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int ponto = 0;//crio a variael ponto
    public Gamemanager gamemanager;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//comparo ela com o player
        {
            PlayerAudio som = collision.GetComponent<PlayerAudio>();
            som.PlaySFX(som.coinSound);
            Debug.Log("colidiu");
            gamemanager.Addpontos(5);
            Destroy(gameObject);

        }
    }
}

