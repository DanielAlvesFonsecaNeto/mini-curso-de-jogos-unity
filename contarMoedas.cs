using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class contarMoedas : MonoBehaviour
{
    public int moedas = 3;
    public string proximaCena;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moedas <= 0)
        {
            Debug.Log("aaaaaa");
            SceneManager.LoadScene(proximaCena);
        }
    }
}
