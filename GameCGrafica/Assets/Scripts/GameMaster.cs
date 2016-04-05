using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public static GameMaster current;
    public GameObject player;
    public GameObject panel;
    public Text deadText;
    public int sceneNumber;
    public int sceneNextNumber;

    private int muertes;
    private Vector3 posicionInicio;

    
	void Start () {
        GameMaster.current = this;
        this.muertes = PlayerPrefs.GetInt("Muertes");

        this.posicionInicio = GameObject.FindGameObjectWithTag("Player").transform.position;
	}

    public void AgregarMuerte()
    {
        this.muertes += 1;
    }

    public void GameOver()
    {
        this.AgregarMuerte();
        this.deadText.text = "Muertes: " + this.muertes;
        PlayerPrefs.SetInt("Muertes", this.muertes);
        this.panel.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(this.sceneNumber);
    }

    public void Salir()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNext()
    {
        Invoke("LoadAux", 0.2f);
    }

    void LoadAux()
    {
        SceneManager.LoadScene(this.sceneNextNumber);
    }
    
}
