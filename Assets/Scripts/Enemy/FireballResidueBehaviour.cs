using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballResidueBehaviour : MonoBehaviour
{
    public GameObject player;
    public double timer;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(14, 10);
        player = GameObject.FindGameObjectWithTag("Player");

        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<Movement>().onFire = true;
            player.GetComponent<Movement>().onFireTimer = timer;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<Movement>().onFireTimer = timer;
        }
    }
}
