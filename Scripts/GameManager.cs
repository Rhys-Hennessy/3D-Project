using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int currentSheep;
    public Text sheepText;

	// Use this for initialization
	void Start ()
    {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddSheep(int sheepToAdd)
    {
        currentSheep += sheepToAdd;
        sheepText.text  = " " +currentSheep;
    }
}
