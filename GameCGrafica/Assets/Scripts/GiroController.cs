using UnityEngine;
using System.Collections;

public class GiroController : MonoBehaviour {
    public float velocidadRotacion;
    public float valorAtaque;

    private AudioSource audioGiro;

	// Use this for initialization
	void Start () {
        audioGiro = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Rotate(Vector3.back * (Time.deltaTime + this.velocidadRotacion));
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Liz")
        {
            col.gameObject.SendMessage("ataque", this.valorAtaque);
            audioGiro.Play();
        }
    }
}
