using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallController : MonoBehaviour {

    private bool played;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        GameManager gameManager = GameManager.GetComponent<GameManager > ();

        if ( gameManager.currentSheep == 5 && played == false)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.Play(44100);
            played = true;
        }

        if(gameManager.currentSheep == 5)
        {
            transform.Translate(0f, -0.1f, 0);
        }
    }
}
