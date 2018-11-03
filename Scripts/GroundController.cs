using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundController : MonoBehaviour {

    public Animator anim;
    public string scene;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        GameManager gameManager = GameManager.GetComponent<GameManager>();

        if (gameManager.currentSheep == 6)
        {
            anim.SetTrigger("Contact");
            Initiate.Fade(scene, Color.black, 0.25f);
        }
    }
 
}
