using UnityEngine;

public class Player : MonoBehaviour
{

    //animação
    public Animator anim; // vou declarar o animator publico para acessar ele 
    private Rigidbody2D rigd; // vou declarar o rigidbory publico para acessar ele 
    public float speed; // vou declarar a velocidade  publico para mudar ela 

    //pulo
    public float jumpForce = 5f;//configurar a força do pulo(posso configurar ou dar direto)
    public bool isground;//para ver se ele ta no chão

    public Vector2 posicaoI;//chamo o vetor x e y
    public Gamemanager gamemanager;//chamo tbm o gamermanager
    void Start()
    {
        anim = GetComponent<Animator>();//digo de onde o anim é
        rigd = GetComponent<Rigidbody2D>();//digo de onde o rigd é
        posicaoI = transform.position; //pega a posição inicial
    }

    // Update is called once per frame
    void Update()
    {
        Move();//chamo o move pra cá
        jump();//chamo o pulo 
    }

    public void reiniciarposicao()
    {

        transform.position = posicaoI;

    }


    void Move()
    {
        float teclas = Input.GetAxis("Horizontal");//eu configuro as teclas horizontais
        rigd.linearVelocity = new Vector2(teclas * speed, rigd.linearVelocity.y); //multiplico a velocidade pelas teclas

        if (teclas > 0 && isground == true)//se for + q 0
        {
            transform.eulerAngles = new Vector2(0, 0); //vai para a direita
            anim.SetInteger("Transition", 1);
        }
        if (teclas < 0 && isground == true)//se for menor
        {
            transform.eulerAngles = new Vector2(0, 180); //vira para esquerda
            anim.SetInteger("Transition", 1);
        }
        if (teclas == 0 && isground == true) //se for igual
        {
            anim.SetInteger("Transition", 0);//fica parado virado normal
        }
    }
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isground == true)//se a tecla for precionada para baixo e o chão for vdd
        {
            rigd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetInteger("Transition", 2);
            isground = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tagGround")
        {
            isground = false;
            Debug.Log("esta no chão");
        }
    }
}


