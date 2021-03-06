using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public event System.Action JumpKeyPressEvent = delegate { }; //to not always write if null
    public event System.Action KillPlayerKeyPressEvent = delegate { }; //bit stupid, i know
    public event System.Action RevokeKeyPressEvent = delegate { };
    public event System.Action InputDisableEvent = delegate { };
    
    public float HorizontalValue { get; private set; }

    private bool active;
    public bool GetActive () => active;
    public void SetActive (bool val)
    {
        if (!val && active)
        {
            HorizontalValue = 0f;
            InputDisableEvent();
        }
        active = val;
    }

    void Awake()
    {
        ins = this;
    }

    void Update()
    {
        if (!active)
            return;

        HorizontalValue = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
            JumpKeyPressEvent();
        if (Input.GetKeyDown(KeyCode.E))
            KillPlayerKeyPressEvent();
        else if (Input.GetKeyDown(KeyCode.Q))
            RevokeKeyPressEvent();
    }

    public static InputSystem ins { get; private set; } 
}
