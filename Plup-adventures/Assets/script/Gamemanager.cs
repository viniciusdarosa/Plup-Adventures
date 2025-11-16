using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Gamemanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int pontos = 0; //crio os pontos e as vidas
    public int vidas = 1;
    
    public TextMeshProUGUI textPontos;
    public TextMeshProUGUI textVidas;


    public void Addpontos(int qtd)
    {
        pontos += qtd;

        Debug.Log("pontos: " + pontos);
        if (pontos < 0)
        {

            pontos = 0;
            

        }

        textPontos.text = "pontos: " + pontos;
        Debug.Log("pontos: " + pontos);

    }

    public void Addvidas(int qtd)
    {
        vidas += qtd;

        Debug.Log("vidas: " + vidas);
        if (vidas < 0)
        {

            vidas = 0;

            Time.timeScale = 0;
            
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
            Debug.Log("gamer-over");



        }

        textVidas.text = "vidas: " + vidas;
        Debug.Log("vidas: " + vidas);

    }



    public void PerderV(int vida)
    {
        Debug.Log("Vidas: " + vidas);
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().reiniciarposicao();
        vidas -= vida;
        if (vidas <= 0)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(1);
            Time.timeScale = 1;

            Debug.Log("gamer-over");
        }
        textVidas.text = "vidas: " + vidas;
        Debug.Log("vidas: " + vidas);
    }

    public void PerderP(int point)
    {
        Debug.Log("pontos: " + pontos);
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().reiniciarposicao();
        pontos -= point;
        if (pontos <= 0)
        {
            pontos = 0;
            
        }
        textPontos.text = "pontos: " + pontos;
        Debug.Log("pontos: " + pontos);
    }


}
