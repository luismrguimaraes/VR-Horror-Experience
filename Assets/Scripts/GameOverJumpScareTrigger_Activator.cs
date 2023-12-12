using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class GameOverJumpScareTrigger_Activator : MonoBehaviour
{
    public GameObject gameOverJumpScareTrigger;

    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.layer != LayerMask.NameToLayer("Character Controller")) return;

        gameOverJumpScareTrigger.SetActive(true);
    }
}
