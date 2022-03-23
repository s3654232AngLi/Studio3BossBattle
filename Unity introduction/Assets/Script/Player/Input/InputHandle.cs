using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandle : MonoBehaviour
{
    PlayerControls inputActions;
    AgainestTest againestTest;
    CounterBar counterBar;

    public Vector2 movementInput;
    public bool space_Input;

    private void Awake()
    {
        againestTest = GameObject.Find("PlayerCollider").GetComponent<AgainestTest>();
    }

    private void Start()
    {
        counterBar = GameObject.Find("CounterBar").GetComponent<CounterBar>();
    }

    public void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerControls();
            inputActions.PlayerInput.Move.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
        }

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    void HandleCounterInput()
    {
        inputActions.PlayerInput.Counter.performed += i => space_Input = true;
        if (space_Input)
            StartCoroutine("ResetCounter");
    }

    IEnumerator ResetCounter()
    {
        yield return new WaitForSeconds(0.2f);
        space_Input = false;
    }

    void CheckCounter()
    {
        if (againestTest.canCounter && space_Input)
        {
            counterBar.IncreaseBar(0.34f);
            space_Input = false;
        }
    }

    private void Update()
    {
        HandleCounterInput();
        CheckCounter();
    }
}
