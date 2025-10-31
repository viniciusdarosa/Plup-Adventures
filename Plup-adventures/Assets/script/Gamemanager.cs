﻿using UnityEngine;
using TMPro;
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

        }

        textVidas.text = "vidas: " + vidas;
        Debug.Log("vidas: " + vidas);

    }

    public void perdervidas(int vida)
    {
        vidas -= vida;
        Debug.Log("vidas: " + vidas);

        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Player>().reiniciarposicao();

        if (vidas <= 0)
        {

            vidas = 0;
            Time.timeScale = 0;

            Debug.Log("gamer-over");

        }
    }

    public void perderpontos(int point)
    {
        pontos -= point;
        Debug.Log("pontos: " + vidas);

        GameObject player = GameObject.FindWithTag("Player");

        if (pontos <= 0)
        {

            pontos = 0;
            Time.timeScale = 0;

            Debug.Log("gamer-over");

        }
    }
}
