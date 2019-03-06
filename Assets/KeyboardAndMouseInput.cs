using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyboardAndMouseInput : MonoBehaviour {


    Vector2 MovementControls() {
        float x = 0f;
        float y = 0f;

        if (Input.GetKey(KeyCode.W))
            y += 1f;

        if (Input.GetKey(KeyCode.A))
            x -= 1f;

        if (Input.GetKey(KeyCode.S))
            y -= 1f;

        if (Input.GetKey(KeyCode.D))
            x += 1f;

        return new Vector2(x, y);
    }

    Vector2 AimControls() { 
        
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            return new Vector2(x, y);
        }
    }

