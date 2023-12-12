using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public GameObject completeXROriginSetUp;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(completeXROriginSetUp);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("VR Horror Scene");
    }
}