using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float velocidade = 0.02f;

    // Start is called before the first frame update
    void Start()
    {

        //transform.position = new Vector3(100, 0, 0);
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");   // -->  -1 até  1 

        transform.position = transform.position + new Vector3(eixoX, 0f, eixoZ) * velocidade;

        
      
    }
}
