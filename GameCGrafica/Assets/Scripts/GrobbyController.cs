using UnityEngine;
using System.Collections;

public class GrobbyController : MonoBehaviour {

    //Atributos del movimiento del personaje
    public float velocidadMovimiento;
    public float maxVelocidadCaida;
    public float xInicial;
    public float xFinal;
    public float valorAtaque;

    

    //Atributos del suelo para el salto
    public Transform groundCheck;
    public LayerMask ground;

    public GameObject target;
    

    //Cuerpo del personaje
    private Rigidbody2D rataBody;
    private Vector2 movimiento;

    private float entradaHorizontal;
    private bool entradaVertical;
    private bool inGround;
    private bool mirarDerecha;
    private Animator animador;

    private AudioSource AudioAttack;

	// Use this for initialization
	void Start () {

        this.rataBody = this.GetComponent<Rigidbody2D>();
        this.inGround = false;
        this.animador = this.GetComponent<Animator>();
        this.mirarDerecha = true;
        this.entradaHorizontal = -1;
        this.AudioAttack = this.GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
        if (target)
        {
            if (this.transform.position.x > this.target.transform.position.x && this.transform.position.x > this.xInicial)
            {
                this.entradaHorizontal = -1;
            }
            else if (this.transform.position.x < this.target.transform.position.x && this.transform.position.x < this.xFinal)
            {
                this.entradaHorizontal = 1;
            }
            else
            {
                this.entradaHorizontal = 0;
            }
        }
        

        if (this.entradaHorizontal > 0 && this.mirarDerecha)
        {
            this.Flip();
            this.mirarDerecha = false;
        }
        if(this.entradaHorizontal < 0 && !this.mirarDerecha)
        {
            this.Flip();
            this.mirarDerecha = true;
        }
        Debug.Log(this.rataBody.velocity.x);
        this.animador.SetFloat("VelocidadHorizontal", Mathf.Abs(this.rataBody.velocity.x));
        this.animador.SetFloat("VelocidadVertical", Mathf.Abs(this.rataBody.velocity.y));

	}

    //Update de la fisica del personaje
    void FixedUpdate(){

        this.movimiento = this.rataBody.velocity;

        //Realizar el movimiento en x del personaje dependiendo de la entrada en el axis horizontal
        this.movimiento.x = this.entradaHorizontal * this.velocidadMovimiento;
       
        if (!this.inGround)
        {
            if(this.movimiento.y < this.maxVelocidadCaida)
            {
                this.movimiento.y = this.maxVelocidadCaida;
            }
        }

        this.rataBody.velocity = this.movimiento;

    }

    void Flip()
    {
        this.transform.Rotate(Vector3.up, 180);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Liz")
        {
            col.gameObject.SendMessage("ataque", this.valorAtaque);
            this.AudioAttack.Play();
        }
    }
    
}
