using UnityEngine;
using System.Collections;

public class LizController : MonoBehaviour {

    //Atributos del movimiento del personaje
    public float velocidadMovimiento;
    public float impulsoSalto;
    public float maxVelocidadCaida;


    //Atributos del suelo para el salto
    public Transform groundCheck;
    public LayerMask ground;

    //Cuerpo del personaje
    private Rigidbody2D lizBody;
    private Vector2 movimiento;

    private float entradaHorizontal;
    private bool entradaVertical;
    private bool inGround;
    private bool mirarDerecha;
    private bool enSalto;
    private bool entradaAccion;

    private Animator animador;
    private AudioSource audioSalto;

	// Use this for initialization
	void Start () {

        this.lizBody = this.GetComponent<Rigidbody2D>();
        this.inGround = false;
        this.animador = this.GetComponent<Animator>();
        this.mirarDerecha = true;
        this.enSalto = false;
        this.audioSalto = this.GetComponent<AudioSource>();
	    
	}
	
	// Update is called once per frame
	void Update () {

        //Capturar el valor del axis horizontal en el momento
        //-1 Izquierda
        //0 No pulsado
        //1 Derecha
        this.entradaHorizontal = Input.GetAxis("Horizontal");
        if (this.entradaHorizontal < 0 && this.mirarDerecha)
        {
            this.Flip();
            this.mirarDerecha = false;
        }
        if(this.entradaHorizontal > 0 && !this.mirarDerecha)
        {
            this.Flip();
            this.mirarDerecha = true;
        }
        this.entradaAccion = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

        this.animador.SetFloat("VelocidadHorizontal", Mathf.Abs(this.lizBody.velocity.x));
        this.animador.SetFloat("VelocidadVertical", Mathf.Abs(this.lizBody.velocity.y));
        this.animador.SetBool("RealizarAccion", this.entradaAccion);

        this.entradaVertical = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);

        //Verificacion para el salto
        if (Physics2D.OverlapCircle(this.groundCheck.position, 0.02f, this.ground))
        {
            this.inGround = true;
        }
        else
        {
            this.inGround = false;
        }

	}

    //Update de la fisica del personaje
    void FixedUpdate(){

        this.movimiento = this.lizBody.velocity;

        //Realizar el movimiento en x del personaje dependiendo de la entrada en el axis horizontal
        this.movimiento.x = this.entradaHorizontal * this.velocidadMovimiento;
        //Comprobar el salto y realizarlo
        if (this.entradaVertical && this.inGround && !this.enSalto)
        {
            this.movimiento.y = this.impulsoSalto;
            this.enSalto = true;
            this.audioSalto.Play();
        }else if (!this.entradaVertical)
        {
            this.enSalto = false;
        }

        if (!this.inGround)
        {
            if(this.movimiento.y < this.maxVelocidadCaida)
            {
                this.movimiento.y = this.maxVelocidadCaida;
            }
        }

        this.lizBody.velocity = this.movimiento;

    }

    void Flip()
    {
        this.transform.Rotate(Vector3.up, 180);
    }

    void OnKill()
    {
        GameMaster.current.GameOver();
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name == "puerta" && this.entradaAccion)
        {
            GameMaster.current.LoadNext();
        }
    }
}
