using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public enum WeaponType
    {
        Magic,
        Ranged,
    }
    public WeaponType WpType;

    [Header("Weapon Stats")]
    public Transform shootPoint;
    public Slider bowSlider;
    public float fireRate = 0.2f;
    public float Speed;
    private float maxSpeed;
    public float bowCharge;
    public float MaxbowCharge;
    public static float bowPercent;
    public bool isShooting = false;

    [Header("Bullets")]
    public GameObject magicPrefab;
    public float magicDMG;
    public GameObject arrowPrefab;
    public float rangedDMG;
    private float maxRangedDMG;

    [Header("ZerkTimer")]
    public double stunTime;
    public double zerkTimer;

    private double maxStunTime;
    private double maxZerkTimer;

    private bool arrowShot = false;
    private float maxFireRate;

    BulletFly bf;

    // Start is called before the first frame update
    void Start()
    {
        maxFireRate = fireRate;
        maxSpeed = Speed;
        maxZerkTimer = zerkTimer;
        maxStunTime = stunTime;

        maxRangedDMG = rangedDMG;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WpType = WeaponType.Magic;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WpType = WeaponType.Ranged;
        }

        if (gameObject.GetComponent<PlayerSkill>().ZerkActive == true)
        {
            zerkTimer -= Time.deltaTime;
            if (zerkTimer <= 0)
            {
                gameObject.GetComponent<PlayerSkill>().ZerkActive = false;
                gameObject.GetComponent<PlayerSkill>().stunned = true;
                zerkTimer = maxZerkTimer;
            }
        }

        if (gameObject.GetComponent<PlayerSkill>().stunned == true)
        {
            stunTime -= Time.deltaTime;

            if (stunTime <= 0)
            {
                gameObject.GetComponent<PlayerSkill>().stunned = false;
                stunTime = maxStunTime;
            }
        }

        switch (WpType)
        {
            case WeaponType.Magic:
                bowSlider.gameObject.SetActive(false);
                if (Input.GetKey(KeyCode.Mouse0) || gameObject.GetComponent<PlayerSkill>().ZerkActive == true)
                {
                    if (gameObject.GetComponent<PlayerSkill>().stunned == true)
                    {

                    }
                    else
                    {
                        if (fireRate <= 0)
                        {
                            var bullet = Instantiate(magicPrefab, shootPoint.position, shootPoint.rotation);
                            bullet.GetComponent<Rigidbody>().velocity = shootPoint.forward * Speed;
                            fireRate = maxFireRate;
                        }
                        else
                        {
                            fireRate -= Time.deltaTime;
                        }
                    }
                }
                else
                {
                    fireRate = maxFireRate;
                }
                break;

            case WeaponType.Ranged:
                bowSlider.gameObject.SetActive(true);
                if (Input.GetKey(KeyCode.Mouse0))
                {                  
                    isShooting = true;
                    if (arrowShot == false)
                    {
                        bowCharge += 1 * Time.deltaTime;
                        bowSlider.value = (float)bowCharge;

                        if (bowCharge >= MaxbowCharge)
                        {
                            bowCharge = MaxbowCharge;
                        }
                    }
                }
                else if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    Speed = (((float)bowCharge / (float)MaxbowCharge)) * Speed;
                    if (arrowShot == false)
                    {
                        var arrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
                        arrow.GetComponent<Rigidbody>().velocity = shootPoint.forward * Speed;
                        arrowShot = true;
                    }
                    bowSlider.value = 0;
                    bowPercent = bowCharge / MaxbowCharge;
                    rangedDMG = (maxRangedDMG * bowPercent);

                    arrowShot = false;
                }
                else
                {
                    bowCharge = 0;
                    Speed = maxSpeed;
                    isShooting = false;
                }
                break;
        }
    }
}
