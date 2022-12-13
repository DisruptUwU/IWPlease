using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PylonBehaviour : MonoBehaviour
{
    public GameObject player;
    public Slider slider;

    [Header("Stats")]
    public float maxHPValue;

    private void Start()
    {
        
    }

    private void Awake()
    {
        slider.maxValue = maxHPValue;
        slider.value = maxHPValue;
    }

    private void Update()
    {
        if (slider.value <= 0)
        {
            Destroy(gameObject);
        }

        Physics.IgnoreLayerCollision(13, 0, true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Magic")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            slider.value -= player.GetComponent<PlayerShoot>().magicDMG;
        }
        else if (other.tag == "Ranged")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            slider.value -= player.GetComponent<PlayerShoot>().rangedDMG;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10);
    }
}
