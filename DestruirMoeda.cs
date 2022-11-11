using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirMoeda : MonoBehaviour
{
    
    public GameObject player;
    public contarMoedas cm;
    public GameObject particula;
    private Vector3 posicao;
    // Start is called before the first frame update
    void Start()
    {
        posicao = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(particula, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        player.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f,1f) , Random.Range(0f, 1f), Random.Range(0f, 1f));
        
        //player.GetComponent<contarMoedas>().moedas--;

        cm.moedas--;

        
        
    }
}
