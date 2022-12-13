using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockBehaviour : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem DeathParticle;
    public int rockDMG;
    public double timer;

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
            slider = player.gameObject.GetComponent<Movement>().healthBar;
            slider.value -= rockDMG;

            player.GetComponent<Movement>().staminaBar.value = 0;

            player.GetComponent<Movement>().Crippled = true;
            player.GetComponent<Movement>().CrippledTimer = timer;

            ParticleSystem ps = (ParticleSystem)Instantiate(DeathParticle, transform.position, transform.rotation);
            Destroy(ps, 2f);
            Destroy(gameObject);
        }
        else
        {
            ParticleSystem ps = (ParticleSystem)Instantiate(DeathParticle, transform.position, transform.rotation);
            Destroy(ps, 2f);
            Destroy(gameObject);
        }
    }
}
