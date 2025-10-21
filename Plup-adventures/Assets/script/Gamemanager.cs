using UnityEngine;
using TMPro;
public class Gamemanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int pontos = 0; //crio os pontos e as vidas
    public int vidas = 3;

    public TextMeshProUGUI textPontos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Addpontos(int qtd)
    {
        pontos += qtd;

        Debug.Log("pontos: " + pontos);
        if (pontos < 0)
        {

            pontos = 0;

        }

        textPontos.text = "pontos: " + pontos;
        Debug.Log("prontos: " + pontos);
}
