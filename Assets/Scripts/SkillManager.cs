using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillManager : MonoBehaviour
{
    public enum TempSkills
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
    public TempSkills TempSlot;

    [Header("Cooldown Status")]
    public double TempCD;

    [Header("Player")]
    public GameObject Player;

    [Header("Panel")]
    public GameObject Panel;
    public TMP_Text Text1, Text2, Display_Text;

    public bool SkillSelect = false;

    private void Update()
    {
        if (SkillSelect == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void SetSkillType1()
    {
        switch (TempSlot)
        {
            case TempSkills.VileVigour:
                Player.GetComponent<PlayerSkill>().SpSlot1 = PlayerSkill.SkillTypes.VileVigour;
                Player.GetComponent<PlayerSkill>().MaxSkill1CD = TempCD;
                Text1.SetText("VileVigour");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.CorruptedStrength:
                Player.GetComponent<PlayerSkill>().SpSlot1 = PlayerSkill.SkillTypes.CorruptedStrength;
                Player.GetComponent<PlayerSkill>().MaxSkill1CD = TempCD;
                Text1.SetText("CorruptedStrength");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.HealBurst:
                Player.GetComponent<PlayerSkill>().SpSlot1 = PlayerSkill.SkillTypes.HealBurst;
                Player.GetComponent<PlayerSkill>().MaxSkill1CD = TempCD;
                Text1.SetText("Heal");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.Regeneration:
                Player.GetComponent<PlayerSkill>().SpSlot1 = PlayerSkill.SkillTypes.Regeneration;
                Player.GetComponent<PlayerSkill>().MaxSkill1CD = TempCD;
                Text1.SetText("Regeneration");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.SupportTotem:
                Player.GetComponent<PlayerSkill>().SpSlot1 = PlayerSkill.SkillTypes.SupportTotem;
                Player.GetComponent<PlayerSkill>().MaxSkill1CD = TempCD;
                Text1.SetText("SupportTotem");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.SlowOrb:
                Player.GetComponent<PlayerSkill>().SpSlot1 = PlayerSkill.SkillTypes.SlowOrb;
                Player.GetComponent<PlayerSkill>().MaxSkill1CD = TempCD;
                Text1.SetText("SlowOrb");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.FireBall:
                Player.GetComponent<PlayerSkill>().SpSlot1 = PlayerSkill.SkillTypes.FireBall;
                Player.GetComponent<PlayerSkill>().MaxSkill1CD = TempCD;
                Text1.SetText("FireBall");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.LifeLeech:
                Player.GetComponent<PlayerSkill>().SpSlot1 = PlayerSkill.SkillTypes.LifeLeech;
                Player.GetComponent<PlayerSkill>().MaxSkill1CD = TempCD;
                Text1.SetText("LifeLeech");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.Revive:
                Player.GetComponent<PlayerSkill>().SpSlot1 = PlayerSkill.SkillTypes.Revive;
                Player.GetComponent<PlayerSkill>().MaxSkill1CD = TempCD;
                Text1.SetText("Revive");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.Shield:
                Player.GetComponent<PlayerSkill>().SpSlot1 = PlayerSkill.SkillTypes.Shield;
                Player.GetComponent<PlayerSkill>().MaxSkill1CD = TempCD;
                Text1.SetText("Shield");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.Berserk:
                Player.GetComponent<PlayerSkill>().SpSlot1 = PlayerSkill.SkillTypes.Berserk;
                Player.GetComponent<PlayerSkill>().MaxSkill1CD = TempCD;
                Text1.SetText("Berserk");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
        }
    }

    public void SetSkillType2()
    {
        switch (TempSlot)
        {
            case TempSkills.VileVigour:
                Player.GetComponent<PlayerSkill>().SpSlot2 = PlayerSkill.SkillTypes.VileVigour;
                Player.GetComponent<PlayerSkill>().MaxSkill2CD = TempCD;
                Text2.SetText("VileVigour");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.CorruptedStrength:
                Player.GetComponent<PlayerSkill>().SpSlot2 = PlayerSkill.SkillTypes.CorruptedStrength;
                Player.GetComponent<PlayerSkill>().MaxSkill2CD = TempCD;
                Text2.SetText("CorruptedStrength");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.HealBurst:
                Player.GetComponent<PlayerSkill>().SpSlot2 = PlayerSkill.SkillTypes.HealBurst;
                Player.GetComponent<PlayerSkill>().MaxSkill2CD = TempCD;
                Text2.SetText("Heal");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.Regeneration:
                Player.GetComponent<PlayerSkill>().SpSlot2 = PlayerSkill.SkillTypes.Regeneration;
                Player.GetComponent<PlayerSkill>().MaxSkill2CD = TempCD;
                Text2.SetText("Regeneration");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.SupportTotem:
                Player.GetComponent<PlayerSkill>().SpSlot2 = PlayerSkill.SkillTypes.SupportTotem;
                Player.GetComponent<PlayerSkill>().MaxSkill2CD = TempCD;
                Text2.SetText("SupportTotem");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.SlowOrb:
                Player.GetComponent<PlayerSkill>().SpSlot2 = PlayerSkill.SkillTypes.SlowOrb;
                Player.GetComponent<PlayerSkill>().MaxSkill2CD = TempCD;
                Text2.SetText("SlowOrb");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.FireBall:
                Player.GetComponent<PlayerSkill>().SpSlot2 = PlayerSkill.SkillTypes.FireBall;
                Player.GetComponent<PlayerSkill>().MaxSkill2CD = TempCD;
                Text2.SetText("FireBall");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.LifeLeech:
                Player.GetComponent<PlayerSkill>().SpSlot2 = PlayerSkill.SkillTypes.LifeLeech;
                Player.GetComponent<PlayerSkill>().MaxSkill2CD = TempCD;
                Text2.SetText("LifeLeech");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.Revive:
                Player.GetComponent<PlayerSkill>().SpSlot2 = PlayerSkill.SkillTypes.Revive;
                Player.GetComponent<PlayerSkill>().MaxSkill2CD = TempCD;
                Text2.SetText("Revive");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.Shield:
                Player.GetComponent<PlayerSkill>().SpSlot2 = PlayerSkill.SkillTypes.Shield;
                Player.GetComponent<PlayerSkill>().MaxSkill2CD = TempCD;
                Text2.SetText("Shield");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
            case TempSkills.Berserk:
                Player.GetComponent<PlayerSkill>().SpSlot2 = PlayerSkill.SkillTypes.Berserk;
                Player.GetComponent<PlayerSkill>().MaxSkill2CD = TempCD;
                Text2.SetText("Berserk");
                SkillSelect = false;
                Panel.SetActive(false);
                break;
        }
    }
    
    public void SkillSetFalse()
    {
        SkillSelect = false;
    }
}
