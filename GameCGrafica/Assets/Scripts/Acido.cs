using UnityEngine;
using System.Collections;

public class Acido : MonoBehaviour {

    public float valorAtaque;

    private AudioSource AudioAcid;

	// Use this for initialization
	void Start () {
        AudioAcid = this.gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Liz")
        {
            col.gameObject.SendMessage("ataque", this.valorAtaque);
            AudioAcid.Play();
        }
    }
}
