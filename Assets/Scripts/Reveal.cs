using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Reveal : MonoBehaviour, OnTouch3D
{
    public float debounceTime = 0.3f;
    public Animator anim;
    private float remainingDebounceTime;
    public GameObject Ctrl;
    private GameObject currCube;
    private GameObject prevCube;
    private bool queued;
    List<GameObject> queuedGO = new List<GameObject>();

    void Start()
    {
        remainingDebounceTime = 0;
    }

    void Update()
    {
        if (remainingDebounceTime > 0)
            remainingDebounceTime -= Time.deltaTime;
        
        if (queued && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) {
            foreach (var go in queuedGO) {
                go.SetActive(false);
            }
            queued = false;
        }
    }

    private IEnumerator WaitForAnimation( Animation animation )
    {
        do {
            yield return null;
        } while ( animation.isPlaying );
    }

    public void OnTouch()
    {
        prevCube = Ctrl.GetComponent<GameMechanics>().prevCube;
        currCube = this.gameObject;

        if (remainingDebounceTime <= 0) {
            if (!prevCube) {
                Debug.Log('1');
                Ctrl.GetComponent<GameMechanics>().setPrevCube(currCube);
                anim.Play("rotateUp");
            }
            else if (prevCube == currCube) {
                Debug.Log('2');
                // do nothing
            }
            else if (prevCube.name == currCube.name) {
                Debug.Log('3');
                anim.Play("rotateUp");
                queuedGO.Add(prevCube);
                queuedGO.Add(currCube);
                Ctrl.GetComponent<GameMechanics>().setPrevCube(null);
                Ctrl.GetComponent<GameMechanics>().foundMatch();
                queued = true;
            }
            else {
                Debug.Log('4');
                anim.Play("rotateCube",  -1, 0f);
                prevCube.GetComponent<Animator>().Play("rotateDown", -1, 0f);
                Ctrl.GetComponent<GameMechanics>().setPrevCube(null);

            }
            remainingDebounceTime = debounceTime;
        }
    }

}
