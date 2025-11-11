using UnityEngine;

public class SeguirObjetonoar : MonoBehaviour
{
    [Header("Configurações")]
    public Transform alvo2;         // Objeto a ser seguido
    public float velocidade2 = 2;  // Velocidade de movimento
    public float distancia2 = 8;   // Distância de ativação do movimento

    void Update()
    {
        if (alvo2 == null)
            return;

        // Calcula a distância atual entre os dois objetos (em 2D)
        float distanciaAtual = Vector2.Distance(transform.position, alvo2.position);

        // Só começa a seguir quando o alvo estiver DENTRO da distância2
        if (distanciaAtual < distancia2)
        {
            // Calcula a direção até o alvo
            Vector2 direcao = (alvo2.position - transform.position).normalized;

            // Move o objeto em direção ao alvo
            transform.position += (Vector3)(direcao * velocidade2 * Time.deltaTime);

            // Opcional: virar o sprite na direção do movimento (apenas eixo X)
            if (direcao.x != 0)
            {
                Vector3 escala = transform.localScale;
                escala.x = Mathf.Abs(escala.x) * Mathf.Sign(direcao.x);
                transform.localScale = escala;
            }
        }
    }
}
