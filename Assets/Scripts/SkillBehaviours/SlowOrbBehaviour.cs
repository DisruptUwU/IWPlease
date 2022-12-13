using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowOrbBehaviour : MonoBehaviour
{
    public GameObject Orb;
    public GameObject baseCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Orb")
        {

        }
        else
        {
            baseCollider.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Orb")
        {

        }
        else
        {
            // slow stuff :)
        }
    }
}
