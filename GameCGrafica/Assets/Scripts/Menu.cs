using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject panel;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void IniciarJuego()
    {
        PlayerPrefs.SetInt("Muertes", 0);
        SceneManager.LoadScene(1);

    }

    public void Ayuda()
    {
        this.panel.SetActive(true);
    }

    public void CerrarAyuda()
    {
        this.panel.SetActive(false);
    }
}
