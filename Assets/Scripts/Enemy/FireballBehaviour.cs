using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject Residue;
    public int fireballDMG;

    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Totem_Range" || other.tag == "Pylon_Range" || other.tag == "Fireball_Residue" || other.tag == "Magic" || other.tag == "Ranged")
        {

        }
        else if (other.tag == "Player")
        {
            player = GameObject.FindGameObjectWithTag("Player");

            slider = player.gameObject.GetComponent<Movement>().healthBar;
            slider.value -= fireballDMG;

            Instantiate(Residue, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            Destroy(gameObject);
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");

            Instantiate(Residue, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            Destroy(gameObject);
        }
    }
}
