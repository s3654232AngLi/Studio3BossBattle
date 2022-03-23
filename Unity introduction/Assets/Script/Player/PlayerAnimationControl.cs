using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    Animator anim;
    bool isWalk;
    PlayerMovement playerMovement;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        isWalk = playerMovement.isWalk;
    }

    void CheckIsWalk()
    {
        if (playerMovement.isWalk)
            anim.SetBool("Walk", true);
        else
            anim.SetBool("Walk", false);
    }

    private void Update()
    {
        CheckIsWalk();
    }
}
