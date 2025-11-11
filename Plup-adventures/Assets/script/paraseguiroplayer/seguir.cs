using UnityEngine;

public class SeguirObjeto2D : MonoBehaviour
{
    [Header("Configurações")]
    public Transform alvo;        // Objeto a ser seguido
    public float velocidade = 5f; // Velocidade de movimento
    public float distancia = 5f;  // Distância de ativação do movimento

    void Update()
    {
        if (alvo == null)
            return;

        // Calcula a distância atual no eixo X
        float diferencaX = alvo.position.x - transform.position.x;
        float distanciaAtual = Mathf.Abs(diferencaX);

        // Move somente se o alvo estiver DENTRO da distância de ativação
        if (distanciaAtual < distancia)
        {
            // Direção do movimento (1 = direita, -1 = esquerda)
            float direcao = Mathf.Sign(diferencaX);

            // Move o objeto no eixo X
            transform.position += new Vector3(direcao * velocidade * Time.deltaTime, 0f, 0f);

            // Opcional: virar o sprite conforme o movimento
            Vector3 escala = transform.localScale;
            escala.x = Mathf.Abs(escala.x) * direcao;
            transform.localScale = escala;
        }
    }
}
