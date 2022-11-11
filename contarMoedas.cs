using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class contarMoedas : MonoBehaviour
{
    public int moedas = 3;
    private int moedasFix;
    public string proximaCena;
    private Text texto;

    

    void Start()
    {
        texto = GetComponent<Text>();
        moedasFix = moedas;
    }

    // Update is called once per frame
    void Update()
    {
        texto.text = moedasFix - moedas + "  /  " + moedasFix;


        if(moedas <= 0)
        {
            Debug.Log("aaaaaa");
            SceneManager.LoadScene(proximaCena);
        }
    }


}
