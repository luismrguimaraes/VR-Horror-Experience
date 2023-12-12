using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverJumpScare : MonoBehaviour
{
    public GameObject jumpScareImage;
    public float jumpScareImageDuration = 0.5f;
    public AudioSource jumpScareSound;
    public AudioSource backgroundSound;

    float timer;
    bool counting;

    void OnTriggerEnter(Collider collider){
        if (collider.gameObject.layer != LayerMask.NameToLayer("Character Controller")) return;

        jumpScareImage.SetActive(true);
        jumpScareSound.Play();

        backgroundSound.Stop();

        counting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (counting) timer += Time.deltaTime;
        if (timer > jumpScareImageDuration) jumpScareImage.SetActive(false);
    }
}
