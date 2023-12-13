using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverJumpScare : MonoBehaviour
{
    public GameObject jumpScareImage;
    public float jumpScareImageDuration = 1f;
    public AudioSource jumpScareSound;
    public AudioSource backgroundSound;

    float timer;
    bool counting;


    void Start()
    {
        // find the jumpscare image using find game object with tag
        jumpScareImage = GameObject.FindGameObjectWithTag("JumpScareImage");
    }

    void OnTriggerEnter(Collider collider){

        if (collider.gameObject.layer != LayerMask.NameToLayer("Character Controller")) return;

        jumpScareImage.GetComponent<SpriteRenderer>().enabled = true;
        jumpScareSound.Play();

        backgroundSound.Stop();

        counting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (counting) timer += Time.deltaTime;
        if (timer > jumpScareImageDuration){
            jumpScareImage.GetComponent<SpriteRenderer>().enabled = false;
            // Change scene to GameOver scene
            DontDestroyOnLoad(jumpScareImage);
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }
}
