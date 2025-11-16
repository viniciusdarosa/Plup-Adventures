using UnityEngine;
using static Boneco;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;

    [Header("Attack Settings")]
    public float attackRange = 1f;
    public float attackCooldown = 0.3f;
    public LayerMask enemyLayer; // Lembre de configurar para a layer do "inimigo"

    [Header("Invincibility Settings")]
    public float invincibleTime = 0.3f;

    [Header("Push Back Settings")]
    public float pushForce = 5f;

    private bool canAttack = true;
    private bool isInvincible = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    private System.Collections.IEnumerator Attack()
    {
        canAttack = false;

        anim.SetInteger("transition", 2);

        // Player fica intangível por algum tempo
        isInvincible = true;

        // Detecta inimigos pela layer
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        foreach (Collider2D inimigo in hitEnemies)
        {
            // Confirma que a tag é "inimigo"
            if (inimigo.CompareTag("Inimigo"))
            {
                Boneco eh = inimigo.GetComponent<Boneco>();
                if (eh != null)
                {
                    // 2 hits para morrer
                    eh.TakeHit();

                    // Empurrar o inimigo para trás
                    Rigidbody2D rb = inimigo.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        Vector2 pushDir = (inimigo.transform.position - transform.position).normalized;
                        rb.AddForce(pushDir * pushForce, ForceMode2D.Impulse);
                    }
                }
            }
        }

        // Tempo invencível
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;

        // Cooldown do ataque
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
