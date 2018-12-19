using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepPickup : MonoBehaviour
{
    
    public int value;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddSheep(value);

            Destroy(gameObject);
        }
    }
}
