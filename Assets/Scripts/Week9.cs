using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week9 : MonoBehaviour
{
    public GameObject Warrior, // Both 
    Archer, // Magic
    Mage, // Range 
    Turret, // Magic
    SuicideBomber, // Both
    Demi1,
    Demi2,
    FinalBoss;

    [SerializeField] private int spawn, keypressed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn == 1 && keypressed == 1)
        {
            Warrior.SetActive(true);
            keypressed += 1;
        }
        if (spawn == 2 && keypressed == 2)
        {
            Archer.SetActive(true);
            keypressed += 1;
        }
        if (spawn == 3 && keypressed == 3)
        {
            Mage.SetActive(true);
            keypressed += 1;
        }
        if (spawn == 4 && keypressed == 4)
        {
            Turret.SetActive(true);
            keypressed += 1;
        }
        if (spawn == 5 && keypressed == 5)
        {
            SuicideBomber.SetActive(true);
            keypressed += 1;
        }
        if (spawn == 6 && keypressed == 6)
        {
            Demi1.SetActive(true);
            keypressed += 1;
        }
        if (spawn == 7 && keypressed == 7)
        {
            Demi2.SetActive(true);
            keypressed += 1;
        }
        if (spawn == 8 && keypressed == 8)
        {
            FinalBoss.SetActive(true);
            keypressed += 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            spawn += 1;
        }
    }
}
