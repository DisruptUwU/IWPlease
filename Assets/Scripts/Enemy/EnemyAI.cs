using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyType
    {
        Warrior, // Both 
        Archer, // Magic
        Mage, // Range 
        Turret, // Magic
        SuicideBomber, // Both
        Demi1,
        Demi2,
        FinalBoss,
        Pylon,
    }

    [Header("EnemyType")]
    public EnemyType enemyType;

    [Header("Variables")]
    public float maxHPValue;
    [SerializeField] private float halfHP;
    [SerializeField] private bool inRange; 

    public NavMeshAgent agent;
    public Slider slider;
    public Slider ShieldSlider;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    [Header("Patroling")]
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    [Header("Attacking")]
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    [Header("States")]
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private bool WarriorRage = false;

    [Header("Demi1")]
    public GameObject PylonObj;
    public GameObject fireballObj;
    public GameObject imageFireball;
    public int AtksB4Fireball;

    private int PylonTimerInt;
    private double PylonTimer;
    private bool Demi1Phase2 = false;

    [Header("Demi2")]
    public GameObject summons;
    public GameObject rockObj;
    public GameObject imageRock;
    public int AtksB4Rock;

    private int SummonTimerInt;
    private double SummonTimer;
    private bool Demi2Phase2 = false;

    [Header("FinalBoss")]
    public GameObject shieldSlider;
    public GameObject imageEye;
    public float maxShieldValue;

    public double PetrifyTimer;
    [SerializeField] private double MaxPetrifyTimer;
    public bool Petrify;
    [SerializeField] private bool PetrifyCheck = true;
    [SerializeField] private double PetrifyTimerSkill = 10f;

    public int AtksB45050;
    public int check5050;

    [SerializeField] private bool FinalPhase2 = false;


    private void Start()
    {
        slider.maxValue = maxHPValue;
        slider.value = maxHPValue;

        halfHP = maxHPValue / 2;

        switch (enemyType)
        {
            case EnemyType.FinalBoss:
                MaxPetrifyTimer = PetrifyTimer;
                ShieldSlider.maxValue = maxShieldValue;
                ShieldSlider.value = maxShieldValue;
                break;
        }

        Physics.IgnoreLayerCollision(13, 0, true);
    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        Physics.IgnoreLayerCollision(10, 11);
    }

    private void Update()
    {
        if (inRange == true)
        {
            slider.value += 20 * Time.deltaTime;
        }

        switch (enemyType)
        {
            case EnemyType.Warrior:
                playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
                playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

                if (slider.value <= slider.maxValue / 2 && WarriorRage == false)
                {
                    agent.speed = agent.speed * 2;
                    WarriorRage = true;
                }

                if (!playerInSightRange && !playerInAttackRange)
                    Patroling();
                if (playerInSightRange && !playerInAttackRange)
                    ChasePlayer();
                if (playerInSightRange && playerInAttackRange)
                    AttackPlayer();
                break;
            case EnemyType.Archer:
                playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
                playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

                if (!playerInSightRange && !playerInAttackRange)
                    Patroling();
                if (playerInSightRange && !playerInAttackRange)
                    ChasePlayer();
                if (playerInSightRange && playerInAttackRange)
                    AttackPlayer();
                break;
            case EnemyType.Mage:
                playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
                playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

                if (!playerInSightRange && !playerInAttackRange)
                    Patroling();
                if (playerInSightRange && !playerInAttackRange)
                    ChasePlayer();
                if (playerInSightRange && playerInAttackRange)
                    AttackPlayer();
                break;
            case EnemyType.Turret:
                playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
                playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

                if (!playerInSightRange && !playerInAttackRange)
                    Patroling();
                if (playerInSightRange && !playerInAttackRange)
                    ChasePlayer();
                if (playerInSightRange && playerInAttackRange)
                    AttackPlayer();
                break;
            case EnemyType.SuicideBomber:
                playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
                playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

                if (!playerInSightRange && !playerInAttackRange)
                    Patroling();
                if (playerInSightRange && !playerInAttackRange)
                    ChasePlayer();
                if (playerInSightRange && playerInAttackRange)
                    AttackPlayer();
                break;
            case EnemyType.Demi1:
                playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
                playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

                if (Demi1Phase2 == false && slider.value <= halfHP)
                {
                    Demi1Skill1();
                    Demi1Phase2 = true;
                }
                else if (Demi1Phase2 == true && PylonTimer >= PylonTimerInt)
                {
                    Demi1Skill1();
                }

                if (Demi1Phase2 == true)
                {
                    PylonTimer += 1 * Time.deltaTime;
                }

                if (!playerInSightRange && !playerInAttackRange)
                    Patroling();
                if (playerInSightRange && !playerInAttackRange)
                    ChasePlayer();
                if (playerInSightRange && playerInAttackRange)
                    AttackPlayer();
                break;
            case EnemyType.Demi2:
                playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
                playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

                if (Demi2Phase2 == false && slider.value <= halfHP)
                {
                    Demi2Skill1();
                    Demi2Phase2 = true;
                }
                else if (Demi2Phase2 == true && SummonTimer >= SummonTimerInt)
                {
                    Demi2Skill1();
                }

                if (Demi2Phase2 == true && PylonTimer >= PylonTimerInt)
                {
                    SummonTimer += 1 * Time.deltaTime;
                }

                if (!playerInSightRange && !playerInAttackRange)
                    Patroling();
                if (playerInSightRange && !playerInAttackRange)
                    ChasePlayer();
                if (playerInSightRange && playerInAttackRange)
                    AttackPlayer();
                break;
            case EnemyType.FinalBoss:
                playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
                playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

                if (Petrify == false && PetrifyTimerSkill <= 0)
                {
                    TruePetrify();
                }
                else if (Petrify == true)
                {
                    PetrifyTimer -= 1 * Time.deltaTime;
                }
                else
                {
                    PetrifyTimerSkill -= 1 * Time.deltaTime;
                }

                if (ShieldSlider.value <= 0 && Petrify == true)
                {
                    imageEye.SetActive(false);
                    shieldSlider.SetActive(false);
                    ShieldSlider.value = maxShieldValue;
                    PetrifyCheck = true;

                    Petrify = false;
                }

                if (FinalPhase2 == false && slider.value <= halfHP)
                {
                    Demi1Skill1();
                    FinalPhase2 = true;
                }

                if (FinalPhase2 == true && PylonTimer >= PylonTimerInt)
                {
                    Demi1Skill1();
                }

                if (FinalPhase2 == true)
                {
                    PylonTimer += 1 * Time.deltaTime;
                }

                if (!playerInSightRange && !playerInAttackRange)
                    Patroling();
                if (playerInSightRange && !playerInAttackRange)
                    ChasePlayer();
                if (playerInSightRange && playerInAttackRange)
                    AttackPlayer();
                break;
        }

        Die();
    }

    private void Patroling()
    {
        if (!walkPointSet) 
            SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //if reached;
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        transform.LookAt(player);
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            var hpBar = player.GetComponent<Movement>().healthBar;
            switch (enemyType)
            {
                case EnemyType.Warrior:
                    //Attack Code
                    agent.SetDestination(transform.position);
                    hpBar.value -= 10;
              
                    alreadyAttacked = true;
                    Invoke(nameof(ResetAttack), timeBetweenAttacks);
                    break;
                case EnemyType.Archer:
                    //Attack Code
                    Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

                    rb.AddForce(transform.forward * 20f, ForceMode.Impulse);
                    rb.AddForce(transform.up * 4.5f, ForceMode.Impulse);

                    alreadyAttacked = true;
                    Invoke(nameof(ResetAttack), timeBetweenAttacks);

                    Patroling();
                    break;
                case EnemyType.Mage:
                    //Attack Code
                    Rigidbody rb1 = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

                    rb1.AddForce(transform.forward * 20f, ForceMode.Impulse);
                    rb1.AddForce(transform.up * 4.5f, ForceMode.Impulse);

                    alreadyAttacked = true;
                    Invoke(nameof(ResetAttack), timeBetweenAttacks);

                    Patroling();
                    break;
                case EnemyType.Turret:
                    //Attack Code
                    Rigidbody rb2 = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

                    rb2.AddForce(transform.forward * 55f, ForceMode.Impulse);
                    rb2.AddForce(transform.up * 4.5f, ForceMode.Impulse);

                    alreadyAttacked = true;
                    Invoke(nameof(ResetAttack), timeBetweenAttacks);
                    break;
                case EnemyType.SuicideBomber:
                    //Attack Code
                    agent.SetDestination(transform.position);
                    hpBar.value -= 50;
                    slider.value = 0;
                    break;
                case EnemyType.Demi1:
                    //Attack Code
                    agent.SetDestination(transform.position);

                    if (AtksB4Fireball <= 0)
                    {
                        Rigidbody fireball = Instantiate(fireballObj, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

                        fireball.AddForce(transform.forward * 20f, ForceMode.Impulse);
                        fireball.AddForce(transform.up * 4.5f, ForceMode.Impulse);

                        AtksB4Fireball = Random.Range(3, 5);

                        imageFireball.SetActive(false);
                    }
                    else
                    {
                        Rigidbody rb3 = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

                        rb3.AddForce(transform.forward * 20f, ForceMode.Impulse);
                        rb3.AddForce(transform.up * 4.5f, ForceMode.Impulse);

                        AtksB4Fireball -= 1;

                        if (AtksB4Fireball == 0)
                        {
                            imageFireball.SetActive(true);
                        }
                    }

                    alreadyAttacked = true;

                    Invoke(nameof(ResetAttack), timeBetweenAttacks);

                    Patroling();
                    break;
                case EnemyType.Demi2:
                    //Attack Code
                    agent.SetDestination(transform.position);

                    if (AtksB4Rock <= 0)
                    {
                        Rigidbody rock = Instantiate(rockObj, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

                        rock.AddForce(transform.forward * 40f, ForceMode.Impulse);
                        rock.AddForce(transform.up * 5f, ForceMode.Impulse);

                        AtksB4Rock = Random.Range(6, 10);

                        imageRock.SetActive(false);
                    }
                    else
                    {
                        Rigidbody rb3 = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

                        rb3.AddForce(transform.forward * 22f, ForceMode.Impulse);
                        rb3.AddForce(transform.up * 4.5f, ForceMode.Impulse);

                        AtksB4Rock -= 1;

                        if (AtksB4Rock == 0)
                        {
                            imageRock.SetActive(true);
                        }
                    }

                    alreadyAttacked = true;

                    Invoke(nameof(ResetAttack), timeBetweenAttacks);
                    break;
                case EnemyType.FinalBoss:
                    //Attack Code
                    agent.SetDestination(transform.position);

                    if (Petrify == true)
                    {
                        if (PetrifyCheck == true)
                        {
                            SetPetrify();
                        }

                        if (PetrifyTimer <= 0 && ShieldSlider.value > 0)
                        {
                            player.GetComponent<Movement>().healthBar.value -= 20;
                            player.GetComponent<Movement>().staminaBar.value = 0;

                            player.GetComponent<Movement>().Crippled = true;
                            player.GetComponent<Movement>().CrippledTimer = 3f;

                            imageEye.SetActive(false);
                            shieldSlider.SetActive(false);

                            Petrify = false;
                        }
                    }

                    if (AtksB45050 <= 0 && FinalPhase2 == true)
                    {
                        if (check5050 == 1) // rock
                        {
                            Rigidbody rock = Instantiate(rockObj, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

                            rock.AddForce(transform.forward * 28f, ForceMode.Impulse);
                            rock.AddForce(transform.up * 5f, ForceMode.Impulse);

                            AtksB45050 = Random.Range(5, 9);
                            check5050 = Random.Range(1, 3);

                            imageRock.SetActive(false);
                        }
                        else if (check5050 == 2) // fireball
                        {
                            Rigidbody fireball = Instantiate(fireballObj, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

                            fireball.AddForce(transform.forward * 12f, ForceMode.Impulse);
                            fireball.AddForce(transform.up * 4.5f, ForceMode.Impulse);

                            AtksB45050 = Random.Range(5, 9);
                            check5050 = Random.Range(1, 3);

                            imageFireball.SetActive(false);
                        }
                    }
                    else
                    {
                        Rigidbody rb3 = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

                        rb3.AddForce(transform.forward * 22f, ForceMode.Impulse);
                        rb3.AddForce(transform.up * 4.5f, ForceMode.Impulse);

                        if (FinalPhase2 == true)
                        {
                            AtksB45050 -= 1;
                        }

                        if (AtksB45050 == 0)
                        {
                            if (check5050 == 1)
                                imageRock.SetActive(true);
                            else if (check5050 == 2)
                                imageFireball.SetActive(true);
                        }
                    }

                    alreadyAttacked = true;

                    Invoke(nameof(ResetAttack), timeBetweenAttacks);
                    break;
            }
        }
    }

    private void Demi1Skill1() // Pylon
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        Vector3 SpawnPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // Drop Pylon in Range

        Rigidbody Pylon = Instantiate(PylonObj, SpawnPoint, Quaternion.identity).GetComponent<Rigidbody>();

        PylonTimer = 0;
        PylonTimerInt = Random.Range(10, 20);
    }

    private void Demi2Skill1() // Summon Enemies
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        Vector3 SpawnPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // Drop Pylon in Range

        Rigidbody summon = Instantiate(summons, SpawnPoint, Quaternion.identity).GetComponent<Rigidbody>();

        SummonTimer = 0;
        SummonTimerInt = Random.Range(30, 40);
    }

    private void TruePetrify()
    {
        Petrify = true;
        PetrifyCheck = true;

        PetrifyTimerSkill = 10f;
    }

    private void SetPetrify()
    {
        imageEye.SetActive(true);
        shieldSlider.SetActive(true);
        ShieldSlider.value = maxShieldValue;

        PetrifyTimer = MaxPetrifyTimer;
        PetrifyCheck = false;
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Magic")
        {
            switch (enemyType)
            {
                case EnemyType.Warrior:
                    slider.value -= player.GetComponent<PlayerShoot>().magicDMG;
                    break;
                case EnemyType.Archer:
                    slider.value -= player.GetComponent<PlayerShoot>().magicDMG;
                    break;
                case EnemyType.Mage:
                    slider.value -= 0;
                    break;
                case EnemyType.Turret:
                    slider.value -= player.GetComponent<PlayerShoot>().magicDMG;
                    break;
                case EnemyType.SuicideBomber:
                    slider.value -= player.GetComponent<PlayerShoot>().magicDMG;
                    break;
                case EnemyType.Demi1:
                    slider.value -= 0;
                    break;
                case EnemyType.Demi2:
                    slider.value -= player.GetComponent<PlayerShoot>().magicDMG;
                    break;
                case EnemyType.FinalBoss:
                    if (Petrify == true)
                    {
                        ShieldSlider.value -= player.GetComponent<PlayerShoot>().magicDMG;
                    }
                    else
                    {
                        slider.value -= player.GetComponent<PlayerShoot>().magicDMG;
                    }
                    break;
                case EnemyType.Pylon:
                    slider.value -= player.GetComponent<PlayerShoot>().magicDMG;
                    break;
            }
        }
        else if (other.tag == "Ranged")
        {
            switch (enemyType)
            {
                case EnemyType.Warrior:
                    slider.value -= player.GetComponent<PlayerShoot>().rangedDMG;
                    break;
                case EnemyType.Archer:
                    slider.value -= 0;
                    break;
                case EnemyType.Mage:
                    slider.value -= player.GetComponent<PlayerShoot>().rangedDMG;
                    break;
                case EnemyType.Turret:
                    slider.value -= 0;
                    break;
                case EnemyType.SuicideBomber:
                    slider.value -= player.GetComponent<PlayerShoot>().rangedDMG;
                    break;
                case EnemyType.Demi1:
                    slider.value -= player.GetComponent<PlayerShoot>().rangedDMG;
                    break;
                case EnemyType.Demi2:
                    slider.value -= 0;
                    break;
                case EnemyType.FinalBoss:
                    if (Petrify == true)
                    {
                        ShieldSlider.value -= player.GetComponent<PlayerShoot>().rangedDMG;
                    }
                    else
                    {
                        slider.value -= player.GetComponent<PlayerShoot>().rangedDMG;
                    }
                    break;
                case EnemyType.Pylon:
                    slider.value -= player.GetComponent<PlayerShoot>().rangedDMG;
                    break;
            }
        }
        else
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Pylon_Range")
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }

    private void Die()
    {
        if (slider.value <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
