using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
{
    public GameObject cubo;
    private Vector3 distanciaCompensada;
    // Start is called before the first frame update
    void Start()
    {
        distanciaCompensada = transform.position - cubo.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = distanciaCompensada + cubo.transform.position;
    }
}
