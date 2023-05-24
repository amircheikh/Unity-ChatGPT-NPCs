using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintingSpeed = 15f;
    private float walkingSpeed;
    public float stamina = 100f;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Slider staminaBar;
    public AudioSource footStepSound;

    Vector3 velocity;
    bool isGrounded;
    private float defaultFOV;
    bool canSprint;
    private float maxStamina;

    void Start()
    {
        defaultFOV = Camera.main.fieldOfView;
        walkingSpeed = speed;
        maxStamina = stamina;
    }

    void Sprint(bool toggle)
    {

        if (stamina >= maxStamina/2)
        {
            canSprint = true;
        }

        if (toggle && stamina > 0f && canSprint == true)
        {
            speed = sprintingSpeed;
            stamina -= 50 * Time.deltaTime;
            //staminaBar.value = stamina;
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, defaultFOV + sprintingSpeed, 10f * Time.deltaTime);   //Multiplying by deltatime makes the animation consistent with all framerates :). This is the same for each line that this occurs in.... 
            Camera.main.GetComponent<Animator>().speed = 2f;
        }

        else if (toggle && stamina <= 0f)
        {
            stamina = 0f;
            canSprint = false;
            speed = walkingSpeed;
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, defaultFOV, 10f * Time.deltaTime);
            Camera.main.GetComponent<Animator>().speed = 1f;
        }
        else if (stamina < maxStamina)
        {
            speed = walkingSpeed;
            stamina += 50 * Time.deltaTime;
            //staminaBar.value = stamina;
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, defaultFOV, 10f * Time.deltaTime);
            Camera.main.GetComponent<Animator>().speed = 1f;
        }

    }
    void Update()
    {
        //if(controller.isGrounded && Input.GetAxis("Vertical") != 0 | Input.GetAxis("Horizontal") != 0 && !footStepSound.isPlaying)    //If statement for footsteps. You should probably make this better later
       // {
           // footStepSound.Play();
        //}

        if (Input.GetAxis("Vertical") != 0 | Input.GetAxis("Horizontal") != 0 && isGrounded)
        {
            Camera.main.GetComponent<Animator>().Play("Head Bobbing");
        }
        else
        {
            Camera.main.GetComponent<Animator>().CrossFade("Not Bobbing", 0.1f);
        }



        if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") != 0)  //If holding shift and moving
        {
            Sprint(true);   //Enable sprint

        }
        if (Input.GetAxis("Vertical") == 0 | !Input.GetKey(KeyCode.LeftShift))  //If not holding shift and not moving
        {
            Sprint(false);  //Disable sprint

        }


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = Vector3.ClampMagnitude((transform.right * x + transform.forward * z) , 1f);

        controller.Move(move * speed * Time.deltaTime);

        //Camera.main.fieldOfView = defaultFOV + controller.velocity.magnitude;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
