using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgainestTest : MonoBehaviour
{
    Collider pWCollider;
    bool moveRight;
    public Transform eWTrans;
    public float moveSpeed;
    public bool canCounter;

    private void Awake()
    {
        pWCollider = GameObject.FindGameObjectWithTag("PWCollider").GetComponent<Collider>();
    }

    private void Start()
    {
        moveRight = true;
        canCounter = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EWCollider")
        {
            canCounter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "EWCollider")
        {
            canCounter = false;
        }
    }

    void MovePWCollider()
    {
        float dis = transform.position.x - eWTrans.position.x;
        if(moveRight)
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        else
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);

        if (dis > 10)
            moveRight = false;
        else if (dis < -10)
            moveRight = true;
    }

    private void Update()
    {
        MovePWCollider();
    }
}
