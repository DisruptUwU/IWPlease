using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSkill : MonoBehaviour
{
    public enum SkillTypes
    {
        None,
        VileVigour,
        CorruptedStrength,
        HealBurst,
        Regeneration,
        SupportTotem,
        SlowOrb,
        FireBall,
        LifeLeech,
        BlackHole, //Does not kill Enemies.
        Revive, //Player needs to kill like 50 enemies to activate it. Removed upon revival.
        Shield, //Additional HP.
        Berserk, //Player cannot stop shooting, Increased Dmg, Stunned for 2 sec after berserk.
    }
    [Header("Skill Type")]
    public SkillTypes SpSlot1, SpSlot2;

    [Header("Player")]
    public GameObject Player;

    [Header("Keybinds")]
    public KeyCode skill1Key = KeyCode.E;
    public KeyCode skill2Key = KeyCode.F;

    [Header("Cooldown Status")]
    public double MaxSkill1CD;
    public double MaxSkill2CD;

    [SerializeField]
    private double Skill1CD, Skill2CD;
    [SerializeField]
    private bool skillReady1 = false, skillReady2 = false;

    [Header("GameObjects")]
    public GameObject Totem;
    public GameObject Orb;

    [Header("Skill Values")]
    public float healAmt;
    public float healDuration;

    private float maxHealDuration;
    private bool RegenCheck;

    public bool inRange = false;

    public bool LeechActive = false;

    public bool ZerkActive = false;
    public bool stunned = false;

    [SerializeField]
    private int ShieldAmt;
    [SerializeField]
    private int ReviveKC = 50;

    private void Start()
    {
        maxHealDuration = healDuration;
    }

    private void Update()
    {
        CaculateSkillTimers();

        if (skillReady1 == true)
        {
            if (Input.GetKeyDown(skill1Key))
            {
                UseSpell1();
            }
        }

        if (skillReady2 == true)
        {
            if (Input.GetKeyDown(skill2Key))
            {
                UseSpell2();
            }
        }

        if (inRange == true)
        {
            var playerMovement = Player.GetComponent<Movement>();

            playerMovement.dashCost = 1;
            playerMovement.moveSpeed = 15;
        }
        else
        {
            var playerMovement = Player.GetComponent<Movement>();
 
            playerMovement.ResetDash();
            playerMovement.ResetSpeed();
        }

        if (RegenCheck == true)
        {
            var hpBar = gameObject.GetComponent<Movement>().healthBar;
            if (healDuration >= 0)
            {
                hpBar.value += healAmt / 177.5f;
                healDuration -= Time.deltaTime;
            }
            else
            {
                healDuration = maxHealDuration;
                RegenCheck = false;
            }          
        }
    }

    void UseSpell1()
    {
        var hpBar = gameObject.GetComponent<Movement>().healthBar;
        var shootPoint = gameObject.GetComponent<PlayerShoot>().shootPoint;
        switch (SpSlot1)
        {
            case SkillTypes.VileVigour:
                hpBar.value -= 10;
                var stamRestore = gameObject.GetComponent<Movement>();
                stamRestore.staminaBar.value = stamRestore.staminaBar.maxValue;
                Skill1CD = 0;
                skillReady1 = false;
                break;
            case SkillTypes.CorruptedStrength:
                hpBar.value -= 20;
                //Increase Dmg
                Skill1CD = 0;
                skillReady1 = false;
                break;
            case SkillTypes.HealBurst:
                hpBar.value += 50;
                Skill1CD = 0;
                skillReady1 = false;
                break;
            case SkillTypes.Regeneration:
                RegenCheck = true;
                Skill1CD = 0;
                skillReady1 = false;
                break;
            case SkillTypes.SupportTotem:
                var initTotem = Instantiate(Totem, shootPoint.position, Quaternion.Euler(0, 0, 0));
                initTotem.GetComponent<Rigidbody>().velocity = shootPoint.forward * 5;
                Destroy(initTotem, 30f);
                Skill1CD = 0;
                skillReady1 = false;
                break;
            case SkillTypes.SlowOrb:
                var initOrb = Instantiate(Orb, shootPoint.position, Quaternion.Euler(0, 0, 0));
                initOrb.GetComponent<Rigidbody>().velocity = shootPoint.forward * 5;
                Destroy(initOrb, 30f);
                Skill1CD = 0;
                skillReady1 = false;
                break;
            case SkillTypes.FireBall:
                Skill1CD = 0;
                skillReady1 = false;
                break;
            case SkillTypes.LifeLeech:
                LeechActive = true;
                Skill1CD = 0;
                skillReady1 = false;
                break;
            case SkillTypes.Revive:
                ShieldAmt = 3;
                Skill1CD = 0;
                skillReady1 = false;
                break;
            case SkillTypes.Shield:
                if (ReviveKC == 0)
                {
                    //Revive Player next death
                    Skill1CD = 0;
                    skillReady1 = false;
                }
                break;
            case SkillTypes.Berserk:
                ZerkActive = true;
                Skill1CD = 0;
                skillReady1 = false;
                break;
        }
    }

    void UseSpell2()
    {
        var hpBar = gameObject.GetComponent<Movement>().healthBar;
        var shootPoint = gameObject.GetComponent<PlayerShoot>().shootPoint;
        switch (SpSlot2)
        {
            case SkillTypes.VileVigour:
                hpBar.value -= 10;
                var stamRestore = gameObject.GetComponent<Movement>();
                stamRestore.staminaBar.value = stamRestore.staminaBar.maxValue;
                Skill2CD = 0;
                skillReady2 = false;
                break;
            case SkillTypes.CorruptedStrength:
                hpBar.value -= 20;
                Skill2CD = 0;
                skillReady2 = false;
                break;
            case SkillTypes.HealBurst:
                hpBar.value += 50;
                Skill2CD = 0;
                skillReady2 = false;
                break;
            case SkillTypes.Regeneration:
                RegenCheck = true;
                Skill2CD = 0;
                skillReady2 = false;
                break;
            case SkillTypes.SupportTotem:
                var initTotem = Instantiate(Totem, shootPoint.position, Quaternion.Euler(0, 0, 0));
                initTotem.GetComponent<Rigidbody>().velocity = shootPoint.forward * 5;
                Destroy(initTotem, 30f);
                Skill2CD = 0;
                skillReady2 = false;
                break;
            case SkillTypes.SlowOrb:
                var initOrb = Instantiate(Orb, shootPoint.position, Quaternion.Euler(0, 0, 0));
                initOrb.GetComponent<Rigidbody>().velocity = shootPoint.forward * 5;
                Destroy(initOrb, 30f);
                Skill2CD = 0;
                skillReady2 = false;
                break;
            case SkillTypes.FireBall:
                Skill2CD = 0;
                skillReady2 = false;
                break;
            case SkillTypes.LifeLeech:
                LeechActive = true;
                Skill2CD = 0;
                skillReady2 = false;
                break;
            case SkillTypes.Revive:
                ShieldAmt = 3;
                Skill2CD = 0;
                skillReady2 = false;
                break;
            case SkillTypes.Shield:
                if (ReviveKC == 0)
                {
                    //Revive Player next death
                    Skill2CD = 0;
                    skillReady2 = false;
                }
                break;
            case SkillTypes.Berserk:
                ZerkActive = true;
                Skill2CD = 0;
                skillReady2 = false;
                break;
        }
    }

    void CaculateSkillTimers()
    {
        if (Skill1CD < MaxSkill1CD && skillReady1 == false)
        {
            Skill1CD += Time.deltaTime;
        }
        else if (Skill1CD >= MaxSkill1CD)
        {
            skillReady1 = true;
            Skill1CD = 0;
        }

        if (Skill2CD < MaxSkill2CD && skillReady2 == false)
        {
            Skill2CD += Time.deltaTime;
        }
        else if (Skill2CD >= MaxSkill2CD)
        {
            skillReady2 = true;
            Skill2CD = 0;
        }
    }
}
