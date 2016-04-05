using UnityEngine;
using System.Collections;

public class Agua : MonoBehaviour {
    

    private AudioSource audioAgua;

	void Start () {
        this.audioAgua = this.gameObject.GetComponent<AudioSource>();
	}
	

	void Update () {
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Liz")
        {
            audioAgua.Play();
        }
    }
}
