using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public float Speed;
    public float Time;
    public Rigidbody rb;
    public GameObject Bullet;
    public GameObject residueFireball;
    public ParticleSystem DeathParticle;

    private PlayerShoot ps;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").gameObject;
        Destroy(gameObject, Time);
    }

    private void OnTriggerEnter(Collider other)
    {
        var hpBar = player.GetComponent<Movement>().healthBar;

        if (gameObject.tag == "Magic")
        {
            if (other.tag == "Player" || other.tag == "Totem_Range" || other.tag == "Pylon_Range" || other.tag == "Fireball_Residue" || other.tag == "Bullet")
            {

            }
            else
            {
                ParticleSystem ps = (ParticleSystem)Instantiate(DeathParticle, transform.position, transform.rotation);
                Destroy(ps, 2f);
                Destroy(Bullet);
            }
        }

        if (gameObject.tag == "Ranged")
        {
            if (other.tag == "Player" || other.tag == "Totem_Range" || other.tag == "Pylon_Range" || other.tag == "Fireball_Residue" || other.tag == "Bullet")
            {

            }
            else
            {
                ParticleSystem ps = (ParticleSystem)Instantiate(DeathParticle, transform.position, transform.rotation);
                Destroy(ps, 2f);
                Destroy(Bullet);
            }
        }

        if (gameObject.tag == "Ranged_Enemy")
        {
            if (other.tag == "Enemy" || other.tag == "Totem_Range" || other.tag == "Pylon_Range" || other.tag == "Fireball_Residue" || other.tag == "Bullet" || other.tag == "Magic" || other.tag == "Ranged")
            {

            }
            else
            {
                if (other.tag == "Player")
                {
                    hpBar.value -= 5;
                    ParticleSystem ps = (ParticleSystem)Instantiate(DeathParticle, transform.position, transform.rotation);
                    Destroy(ps, 2f);
                    Destroy(Bullet);
                }
                else
                {
                    ParticleSystem ps = (ParticleSystem)Instantiate(DeathParticle, transform.position, transform.rotation);
                    Destroy(ps, 2f);
                    Destroy(Bullet);
                }
            }
        }

        if (gameObject.tag == "Magic_Enemy")
        {
            if (other.tag == "Enemy" || other.tag == "Totem_Range" || other.tag == "Pylon_Range" || other.tag == "Fireball_Residue" || other.tag == "Bullet" || other.tag == "Magic" || other.tag == "Ranged")
            {

            }
            else
            {
                if (other.tag == "Player")
                {
                    hpBar.value -= 5;
                    ParticleSystem ps = (ParticleSystem)Instantiate(DeathParticle, transform.position, transform.rotation);
                    Destroy(ps, 2f);
                    Destroy(Bullet);
                }
                else
                {
                    ParticleSystem ps = (ParticleSystem)Instantiate(DeathParticle, transform.position, transform.rotation);
                    Destroy(ps, 2f);
                    Destroy(Bullet);
                }
            }
        }

        if (gameObject.tag == "Fireball")
        {
            if (other.tag == "Enemy" || other.tag == "Totem_Range" || other.tag == "Pylon_Range" || other.tag == "Fireball_Residue" || other.tag == "Magic" || other.tag == "Ranged")
            {

            }
            else if (other.tag == "Player")
            {
                hpBar.value -= 10;

                Instantiate(residueFireball, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                Destroy(gameObject);
            }
            else
            {
                player = GameObject.FindGameObjectWithTag("Player");

                Instantiate(residueFireball, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                Destroy(gameObject);
            }
        }

        if (gameObject.tag == "Fireball_Residue")
        {
            if (other.tag == "Player")
            {
                player.GetComponent<Movement>().onFire = true;
                player.GetComponent<Movement>().onFireTimer = 5;
            }
        }

        if (gameObject.tag == "Rock")
        {
            if (other.tag == "Enemy" || other.tag == "Totem_Range" || other.tag == "Pylon_Range" || other.tag == "Fireball_Residue" || other.tag == "Magic" || other.tag == "Ranged")
            {

            }
            else if (other.tag == "Player")
            {
                hpBar.value -= 20;

                player.GetComponent<Movement>().staminaBar.value = 0;

                player.GetComponent<Movement>().Crippled = true;
                player.GetComponent<Movement>().CrippledTimer = 1f;

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

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.tag == "Fireball_Residue")
        {
            if (other.tag == "Player")
            {
                player.GetComponent<Movement>().onFire = true;
                player.GetComponent<Movement>().onFireTimer = 5;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Ranged" || gameObject.tag == "Ranged_Enemy")
        {
            Arrow();
        }
    }

    void Arrow()
    {
        if (rb.velocity != Vector3.zero)
            rb.rotation = Quaternion.LookRotation(rb.velocity);
    }
}
