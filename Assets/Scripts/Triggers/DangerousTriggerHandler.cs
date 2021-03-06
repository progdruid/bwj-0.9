using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousTriggerHandler : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag != "Player" || !InputSystem.ins.GetActive())
            return;

        gameManager.KillPlayer();
    }
}
