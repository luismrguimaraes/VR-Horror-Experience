using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class SpookyRoomOnEnter : MonoBehaviour
{
    public GameObject doorUnlocked;
    public GameObject doorLocked;
    public bool hasEntered;
    void OnTriggerEnter(Collider collider){
        if (hasEntered) return;
        if (collider.gameObject.layer != LayerMask.NameToLayer("Character Controller")) return;
        
        //door.transform.SetPositionAndRotation(door.transform.position, Quaternion.Euler(new Vector3(door.transform.rotation.eulerAngles.x, 0, door.transform.rotation.eulerAngles.z)));
        doorUnlocked.SetActive(false);
        doorLocked.SetActive(true);
        AudioSource[] sounds = doorLocked.GetComponents<AudioSource>();
        for (int i = 0; i < sounds.Length; i++) 
        {
            sounds[i].Play();
        }   
        print("Enter");
        hasEntered = true;
    }
}

