using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skills : MonoBehaviour
{
    public enum SkillType
    {
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

    public SkillType SPType;
    public double Cooldown;
    public GameObject SkillPanel;
    [SerializeField] private GameObject SkillManager;
    [SerializeField] private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SkillPanel = GameObject.Find("Canvas_Main").transform.Find("Panel_Skills").gameObject;
        SkillManager = GameObject.FindGameObjectWithTag("SkillManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (SPType)
            {
                case SkillType.VileVigour:
                    SkillPanel.SetActive(true);
                    SkillManager.GetComponent<SkillManager>().TempSlot = global::SkillManager.TempSkills.VileVigour;
                    SkillManager.GetComponent<SkillManager>().TempCD = Cooldown;
                    SkillManager.GetComponent<SkillManager>().SkillSelect = true;
                    SkillManager.GetComponent<SkillManager>().Display_Text.SetText("VileVigour");
                    Destroy(gameObject);
                    break;
                case SkillType.CorruptedStrength:
                    SkillPanel.SetActive(true);
                    SkillManager.GetComponent<SkillManager>().TempSlot = global::SkillManager.TempSkills.CorruptedStrength;
                    SkillManager.GetComponent<SkillManager>().TempCD = Cooldown;
                    SkillManager.GetComponent<SkillManager>().SkillSelect = true;
                    SkillManager.GetComponent<SkillManager>().Display_Text.SetText("CorruptedStrength");
                    Destroy(gameObject);
                    break;
                case SkillType.HealBurst:
                    SkillPanel.SetActive(true);
                    SkillManager.GetComponent<SkillManager>().TempSlot = global::SkillManager.TempSkills.HealBurst;
                    SkillManager.GetComponent<SkillManager>().TempCD = Cooldown;
                    SkillManager.GetComponent<SkillManager>().SkillSelect = true;
                    SkillManager.GetComponent<SkillManager>().Display_Text.SetText("HealBurst");
                    Destroy(gameObject);
                    break;
                case SkillType.Regeneration:
                    SkillPanel.SetActive(true);
                    SkillManager.GetComponent<SkillManager>().TempSlot = global::SkillManager.TempSkills.Regeneration;
                    SkillManager.GetComponent<SkillManager>().TempCD = Cooldown;
                    SkillManager.GetComponent<SkillManager>().SkillSelect = true;
                    SkillManager.GetComponent<SkillManager>().Display_Text.SetText("Regeneration");
                    Destroy(gameObject);
                    break;
                case SkillType.SupportTotem:
                    SkillPanel.SetActive(true);
                    SkillManager.GetComponent<SkillManager>().TempSlot = global::SkillManager.TempSkills.SupportTotem;
                    SkillManager.GetComponent<SkillManager>().TempCD = Cooldown;
                    SkillManager.GetComponent<SkillManager>().SkillSelect = true;
                    SkillManager.GetComponent<SkillManager>().Display_Text.SetText("SupportTotem");
                    Destroy(gameObject);
                    break;
                case SkillType.SlowOrb:
                    SkillPanel.SetActive(true);
                    SkillManager.GetComponent<SkillManager>().TempSlot = global::SkillManager.TempSkills.SlowOrb;
                    SkillManager.GetComponent<SkillManager>().TempCD = Cooldown;
                    SkillManager.GetComponent<SkillManager>().SkillSelect = true;
                    SkillManager.GetComponent<SkillManager>().Display_Text.SetText("SlowOrb");
                    Destroy(gameObject);
                    break;
                case SkillType.FireBall:
                    SkillPanel.SetActive(true);
                    SkillManager.GetComponent<SkillManager>().TempSlot = global::SkillManager.TempSkills.FireBall;
                    SkillManager.GetComponent<SkillManager>().TempCD = Cooldown;
                    SkillManager.GetComponent<SkillManager>().SkillSelect = true;
                    SkillManager.GetComponent<SkillManager>().Display_Text.SetText("FireBall");
                    Destroy(gameObject);
                    break;
                case SkillType.LifeLeech:
                    SkillPanel.SetActive(true);
                    SkillManager.GetComponent<SkillManager>().TempSlot = global::SkillManager.TempSkills.LifeLeech;
                    SkillManager.GetComponent<SkillManager>().TempCD = Cooldown;
                    SkillManager.GetComponent<SkillManager>().SkillSelect = true;
                    SkillManager.GetComponent<SkillManager>().Display_Text.SetText("LifeLeech");
                    Destroy(gameObject);
                    break;
                case SkillType.Revive:
                    SkillPanel.SetActive(true);
                    SkillManager.GetComponent<SkillManager>().TempSlot = global::SkillManager.TempSkills.Revive;
                    SkillManager.GetComponent<SkillManager>().TempCD = Cooldown;
                    SkillManager.GetComponent<SkillManager>().SkillSelect = true;
                    SkillManager.GetComponent<SkillManager>().Display_Text.SetText("Revive");
                    Destroy(gameObject);
                    break;
                case SkillType.Shield:
                    SkillPanel.SetActive(true);
                    SkillManager.GetComponent<SkillManager>().TempSlot = global::SkillManager.TempSkills.Shield;
                    SkillManager.GetComponent<SkillManager>().TempCD = Cooldown;
                    SkillManager.GetComponent<SkillManager>().SkillSelect = true;
                    SkillManager.GetComponent<SkillManager>().Display_Text.SetText("Shield");
                    Destroy(gameObject);
                    break;
                case SkillType.Berserk:
                    SkillPanel.SetActive(true);
                    SkillManager.GetComponent<SkillManager>().TempSlot = global::SkillManager.TempSkills.Berserk;
                    SkillManager.GetComponent<SkillManager>().TempCD = Cooldown;
                    SkillManager.GetComponent<SkillManager>().SkillSelect = true;
                    SkillManager.GetComponent<SkillManager>().Display_Text.SetText("Berserk");
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
