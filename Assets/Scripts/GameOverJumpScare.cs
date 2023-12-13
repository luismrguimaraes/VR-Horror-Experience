using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverJumpScare : MonoBehaviour
{
    public GameObject completeXROriginSetUp;
    public GameObject jumpScareImage;
    public float jumpScareImageDuration = 1f;
    public AudioSource jumpScareSound;
    public AudioSource backgroundSound;
    public Vector3 finalPlayerPosition;
    public Vector3 finalPlayerRotation;

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

            // Get the complete xr origin set up game object
            completeXROriginSetUp = GameObject.FindGameObjectWithTag("CompleteXROriginSetUp");
            DontDestroyOnLoad(completeXROriginSetUp);

            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
            completeXROriginSetUp.transform.position = finalPlayerPosition;
            completeXROriginSetUp.transform.rotation = Quaternion.Euler(finalPlayerRotation);
        }
    }
}
