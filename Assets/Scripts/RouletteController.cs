using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0;

    public float velocity = 5.0f;

    bool isReverse = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            this.rotSpeed = 0;
            Debug.Log("Stop");
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            //isReverse = !isReverse;

            if (isReverse == false) {
                isReverse = true;
                Debug.Log("Reverse");
            } else {
                isReverse = false;
                Debug.Log("Normal");
            }
        }



        if (Input.GetMouseButtonDown(0)) {

            //this.rotSpeed = isReverse ? -velocity : velocity;


            if (isReverse == false) {
                this.rotSpeed = velocity;
            } else {
                this.rotSpeed = -velocity;
            }


            //this.rotSpeed = -10f;
        }
        transform.Rotate(0, 0, this.rotSpeed);

        this.rotSpeed *= 0.96f;
    }
}
