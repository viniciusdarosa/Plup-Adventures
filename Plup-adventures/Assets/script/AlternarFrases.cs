using UnityEngine;
using TMPro;

public class AlternarFrases : MonoBehaviour
{
    private TMP_Text texto;

    // Tempo que cada frase fica na tela
    public float tempoPorFrase = 30f;

    private float timer = 0f;
    private int indiceFrase = 0;

    // As frases que vão aparecer
    private string[] frases = 
    { 
        "Direção e Level Design - Gustavo Budny – Desenvolvimento do mapa, cenários e ambientação",
        "Programação Principal - Izabely – Implementação do código, sistemas e mecânicas gerais",
        "Design e Mecânicas dos Personagens - Vinicius – Criação, animação e programação das ações dos personagens",
        "Agradecimentos Especiais A todos que apoiaram o desenvolvimento"
    };

    private void Awake()
    {
        texto = GetComponent<TMP_Text>();
        texto.text = frases[indiceFrase]; // mostra a primeira
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= tempoPorFrase)
        {
            timer = 0f;

            // muda para a próxima frase
            indiceFrase++;

            // se passar da última, volta para a primeira
            if (indiceFrase >= frases.Length)
                indiceFrase = 0;

            texto.text = frases[indiceFrase];
        }
    }
}
