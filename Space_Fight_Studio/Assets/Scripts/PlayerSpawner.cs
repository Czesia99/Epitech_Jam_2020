using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.activeSelf == false) {
            if (Input.GetButtonDown("P1.Start"))
                player1.SetActive(true);
        }
        if (player2.activeSelf == false) {
            if (Input.GetButtonDown("P2.Start"))
                player2.SetActive(true);
        }
    }
}
