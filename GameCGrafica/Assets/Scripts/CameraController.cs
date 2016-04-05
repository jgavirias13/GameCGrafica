using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    //Objeto al que va a mirar la camara
    public Transform target;
    public float velocidadSeguimiento;

    private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.target)
        {
            this.targetPosition = this.target.position;
            this.targetPosition.z = -5;
            this.transform.position = Vector3.Lerp(this.transform.position, this.targetPosition, Time.deltaTime * velocidadSeguimiento);
        }
    }
}
