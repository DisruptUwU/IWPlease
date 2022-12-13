using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private float maxSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    private bool dash = false;
    public float dashCost;
    private float maxDashCost;

    public double Stamina;
    private double dashCounter = 0.1f;
    private bool isDashing = false;
    private bool drainStamina = false;
    private double MaxStamina;

    [SerializeField] private bool sprint = false;

    [Header("Health")]
    public float Health;
    private float MaxHealth;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    [Header("Sliders")]
    public Slider staminaBar;
    public Slider healthBar;

    [Header("Fire :)")]
    public bool onFire = false;
    public double onFireTimer;

    [Header("Rock :)")]
    public bool Crippled = false;
    public double CrippledTimer;

    Vector3 moveDirection;

    Rigidbody rb;

    private GameObject skillManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        MaxStamina = Stamina;
        staminaBar.value = (float)Stamina;
        staminaBar.maxValue = (float)Stamina;

        readyToJump = true;

        MaxHealth = Health;
        healthBar.value = (float)Health;
        healthBar.maxValue = (float)Health;

        maxSpeed = moveSpeed;
        maxDashCost = dashCost;

        skillManager = GameObject.FindGameObjectWithTag("SkillManager");
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        Dash();
        MyInput();
        SpeedControl();

        OnFire();

        OnCripple();

        Stamina = staminaBar.value;

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        //HealthBar
        Health = healthBar.value;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        var SkillManager = skillManager.GetComponent<SkillManager>().SkillSelect;

        if (SkillManager == true || gameObject.GetComponent<PlayerSkill>().stunned == true)
        {
            horizontalInput = 0;
            verticalInput = 0;
        }
        else
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
        {
            if (dash == true)
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f * 50, ForceMode.Force);
            }
            else if (sprint == true)
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 25f, ForceMode.Force);
            }
            else
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        // in air
        else if (!grounded)
        {
            if (dash == true)
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier * 50, ForceMode.Force);
            }
            else if (sprint == true)
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 25f * airMultiplier, ForceMode.Force);
            }
            else
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void Dash()
    {
        if (staminaBar.value >= 0)
        {
            if (gameObject.GetComponent<PlayerShoot>().WpType == PlayerShoot.WeaponType.Ranged)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    if (staminaBar.value < dashCost)
                    {
                        isDashing = false;
                        drainStamina = false;
                    }
                    else if (staminaBar.value >= dashCost)
                    {
                        isDashing = true;
                        drainStamina = true;
                    }
                }
            }
            if (gameObject.GetComponent<PlayerShoot>().WpType == PlayerShoot.WeaponType.Magic)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    sprint = true;
                    moveSpeed = 10;
                    if (gameObject.GetComponent<Rigidbody>().velocity == new Vector3(0,0,0))
                    {

                    }
                    else
                    {
                        staminaBar.value -= 2.5f * Time.deltaTime;
                    }
                }
                else if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    sprint = false;
                    ResetSpeed();
                }
            }
        }
        else
        {
            isDashing = false;
            drainStamina = false;
        }

        if (staminaBar.value < 0)
        {
            staminaBar.value = 0;
        }
        if (staminaBar.value > MaxStamina)
        {
            staminaBar.value = staminaBar.maxValue;
        }

        if (drainStamina == true)
        {
            staminaBar.value -= dashCost;
            drainStamina = false;
        }
        else
        {
            staminaBar.value += (float)1.5 * Time.deltaTime;
        }

        if (isDashing == true && dashCounter > 0)
        {
            dash = true;
            dashCounter -= 1 * Time.deltaTime;
        }
        else if (isDashing == true && dashCounter <= 0)
        {
            dash = false;
            dashCounter = 0.1f;
            isDashing = false;
        }
    }

    private void OnFire()
    {
        if (onFire == true)
        {
            healthBar.value -= 3 * Time.deltaTime;
            onFireTimer -= 1 * Time.deltaTime;
        }

        if (onFireTimer <= 0)
        {
            onFire = false;
            onFireTimer = 0;
        }
    }

    private void OnCripple()
    {
        if (Crippled == true)
        {
            horizontalInput = 0;
            verticalInput = 0;

            CrippledTimer -= 1 * Time.deltaTime;
        }
        else
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
        }

        if (CrippledTimer <= 0)
        {
            Crippled = false;
            CrippledTimer = 0;
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    public void ResetSpeed()
    {
        moveSpeed = maxSpeed;
    }

    public void ResetDash()
    {
        dashCost = maxDashCost;
    }
}
