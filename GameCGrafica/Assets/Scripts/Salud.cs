using UnityEngine;
using System.Collections;

public class Salud : MonoBehaviour {


    public GameObject sangreExplosion;

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ataque(float valor)
    {
        if (valor != 0)
        {
            GameObject sangre = Instantiate(this.sangreExplosion, this.transform.position, Quaternion.identity) as GameObject;
            Destroy(sangre, 0.5f);
            this.gameObject.SendMessage("OnKill");
            Destroy(this.gameObject);
        }
    }
}
