using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMechanics : MonoBehaviour
{

    public bool gameDone;
    public GameObject endMessage;
    public GameObject prevCube; 
    private int numOfPairs;

    // Start is called before the first frame update
    void Start()
    {
        numOfPairs = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfPairs <= 0) {
            Debug.Log("Done! You win!");
            gameDone = true;
            if (!endMessage.activeSelf) {
                endMessage.SetActive(true);
            }
        }
    }

    public void setPrevCube(GameObject cube) {
        prevCube = cube;
    }

    public void foundMatch() {
        numOfPairs -= 1;
        Debug.LogFormat("{0} of pairs left", numOfPairs);
    }
}
