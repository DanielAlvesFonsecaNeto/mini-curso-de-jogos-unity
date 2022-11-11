using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    public float velocidade = 8f;     // velocida de movimento
    public float poderDePulo = 16f;   // pode de pulo
    public int quantidadeDePulos = 2;  // quantidade de vezes que pode pular

    private int quantidadeDePuloRestante;
    private float horizontal;
    private bool FaceViradaPraDireita = true;
    private Vector3 posicaoInicial;

    private Rigidbody2D rb2D;
    private SpriteRenderer sp;
    
    [SerializeField] private Transform checarChao; // SerializrField permite manipular o atributo na janela de inspetor 
    [SerializeField] private LayerMask camadaChao; // mesmo que ele seja privado no codigo. 

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        
        quantidadeDePuloRestante = quantidadeDePulos;
        posicaoInicial = transform.position;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");             // da informação Vector3 de qual tecla esta sendo apertada 

        if (Input.GetButtonDown("Jump") && estaNoChao())         // verificar se pode pular 
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, poderDePulo);
            quantidadeDePuloRestante = quantidadeDePulos;
        }

        else if (Input.GetButtonDown("Jump")  && quantidadeDePuloRestante -1 > 0)  // verifica se pode dar o pulo duplo
        {
            quantidadeDePuloRestante--;
            rb2D.velocity = new Vector2(rb2D.velocity.x, poderDePulo);
        }

        if (Input.GetButtonUp("Jump") && rb2D.velocity.y > 0f)                    // usado para dar um pouco mais de impulso caso o jump continue pressionado 
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
        }

        Flip();

        if(transform.position.y < -10f)  // personagem voltar pro ponto inicial se cair 
        {
            transform.position = posicaoInicial;
        }
    }

    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(horizontal * velocidade , rb2D.velocity.y);  // movimento horizontal baseado na fisica de corpo rigido
    }

    private bool estaNoChao()    //retorna verdadeiro se o objeto "checarChao" estiver no chao
    {
        return Physics2D.OverlapCircle(checarChao.position, 0.2f, camadaChao); // função detecta se em uma area de 0.2f de raio em circulo 
                                                                               // na posição checarChao( que é o GameObject que colocamos no pé do player)
                                                                               // teve colisão com algum objeto da camada "chao"
    }

    private void Flip()
    {
        if (FaceViradaPraDireita && horizontal < 0f || ! FaceViradaPraDireita && horizontal > 0f)  //usa pra flipar o sprite
        {                                                           //EX : se a face estiver virada pra esquerda e o botão apertado for o direito
            FaceViradaPraDireita = ! FaceViradaPraDireita;          // o if é executado e a face atual se inverte 

            sp.flipX = !sp.flipX;                                   // usa o componente de SpriteRender
        }
    }
}
