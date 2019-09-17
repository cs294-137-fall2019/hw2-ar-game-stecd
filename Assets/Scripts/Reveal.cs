using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Reveal : MonoBehaviour, OnTouch3D
{
// Debouncing is a term from Electrical Engineering referring to 
    // preventing multiple presses of a button due to the physical switch
    // inside the button "bouncing".
    // In CS we use it to mean any action to prevent repeated input. 
    // Here we will simply wait a specified time before letting the button
    // be pressed again.
    // We set this to a public variable so you can easily adjust this in the
    // Unity UI.
    public float debounceTime = 0.3f;
    public Animator anim;
    // Stores a counter for the current remaining wait time.
    private float remainingDebounceTime;

    void Start()
    {
        remainingDebounceTime = 0;
    }

    void Update()
    {
        // Time.deltaTime stores the time since the last update.
        // So all we need to do here is subtract this from the remaining
        // time at each update.
        if (remainingDebounceTime > 0)
            remainingDebounceTime -= Time.deltaTime;
    }

    public void OnTouch()
    {
        // If a touch is found and we are not waiting,
        if (remainingDebounceTime <= 0)
        {
            anim.Play("rotateCube");
            remainingDebounceTime = debounceTime;
        }
    }

}
