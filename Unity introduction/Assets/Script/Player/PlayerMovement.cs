using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputHandle inputHandle;
    public Transform playerCamera;
    public CharacterController controller;
    public float speed;
    float smoothVel;

    float gravity = -1;
    float currentGravity;
    float constanGravity = 0.6f;
    float maxGravity = -15f;
    Vector3 gravityDirection;
    Vector3 gravityMovement;

    public bool isWalk = false;
    

    private void Awake()
    {
        gravityDirection = Vector3.down;
        inputHandle = GameObject.Find("InputHandler").GetComponent<InputHandle>();
    }

    

    void Move()
    {
        float horizontal = inputHandle.movementInput.x;
        float vertical = inputHandle.movementInput.y;

        Vector3 dir = new Vector3(horizontal, 0f, vertical);
        Vector3 moveDir = dir;
        dir.Normalize();
        if (dir.magnitude >= 0.1f)
        {
            float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            float angle_smooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref smoothVel, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle_smooth, 0f);

            moveDir = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            isWalk = true;

        }
        else
            isWalk = false;

        controller.Move(moveDir.normalized * speed * Time.deltaTime + gravityMovement);
    }

    bool IsGround()
    {
        return controller.isGrounded;
    }

    void CalculateGravity()
    {
        if(IsGround())
        {
            currentGravity = constanGravity;
        }
        else
        {
            if(currentGravity > maxGravity)
            {
                currentGravity -= gravity * Time.deltaTime;
            }
        }

        gravityMovement = gravityDirection * currentGravity;

    }
    void Update()
    {
        Move();
        CalculateGravity();

    }
}
