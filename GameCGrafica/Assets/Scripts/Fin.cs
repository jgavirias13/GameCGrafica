using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fin : MonoBehaviour {

    public Text textoGanador;

	// Use this for initialization
	void Start () {
        int muertes = PlayerPrefs.GetInt("Muertes");
        if(muertes == 0)
        {
            textoGanador.text = "Felicidades, has ganado y Liz no ha muerto ninguna vez";
        }
        else
        {
            textoGanador.text = "Felicidades, has ganado y Liz solo ha tenido que morir " + muertes + " veces para poder salir";
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void goMenu()
    {
        SceneManager.LoadScene(0);
    }
}
