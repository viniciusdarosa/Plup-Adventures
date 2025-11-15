using UnityEngine;

public class Player : MonoBehaviour
{


    private Rigidbody2D rigd; // vou declarar o rigidbory publico para acessar ele 
    public float speed; // vou declarar a velocidade  publico para mudar ela 
    public Animator anim;

    //pulo
    public float jumpForce = 5f;//configurar a força do pulo(posso configurar ou dar direto)
    public bool isground;//para ver se ele ta no chão

    public Vector2 posicaoI;//chamo o vetor x e y
    public Gamemanager gamemanager;//chamo tbm o gamermanager


    private PlayerAudio playerAudio;
    void Start()
    {
        anim = GetComponent<Animator>();//digo de onde o anim é
        rigd = GetComponent<Rigidbody2D>();//digo de onde o rigd é
        posicaoI = transform.position; //pega a posição inicial

        playerAudio = GetComponent<PlayerAudio>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();//chamo o move pra cá
        jump();//chamo o pulo 
        atack();//chama atack
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tagGround")
        {
            isground = true;
            Debug.Log("esta no chão");
        }
    }

public void reiniciarposicao()
    {
        transform.position = posicaoI;
    }


    void Move()
    {
        float teclas = Input.GetAxis("Horizontal");
        rigd.linearVelocity = new Vector2(teclas * speed, rigd.linearVelocity.y);
        if (teclas > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
            anim.SetInteger("transition", 1);
        }
        if (teclas < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
            anim.SetInteger("transition", 1);
        }
        if (teclas == 0)
        {
            anim.SetInteger("transition", 0);
        }
    }
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isground == true)//se a tecla for precionada para baixo e o chão for vdd
        {
            rigd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isground = false;

            playerAudio.PlaySFX(playerAudio.jumpSound);

        }

    }
    void atack()
    {
        bool isLeftButtonDown = Input.GetMouseButtonDown(0);
        if (isLeftButtonDown == true) {
            anim.SetInteger("transition", 2);
        }
    }
}




