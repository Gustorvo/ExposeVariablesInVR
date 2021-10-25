using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

[ExecuteInEditMode]
public class Rotator : MonoBehaviour {
   
    [SerializeField] float x, y, z;
    private float xOld, yOld, zOld; 
   
    void OnValidate() {

        CalcAngleAxis();

    }

    private void CalcAngleAxis() {
        if(x != xOld) {
            Rotate(Vector3.right, x - xOld);
        }
        if(y != yOld) {
            Rotate(Vector3.up, y - yOld);
        }
        if(z != zOld) {
            Rotate(Vector3.forward, z - zOld);
        }
        zOld = z;
        yOld = y;
        xOld = x;
    }
        

    private void Update() {

        CalcAngleAxis();
    }

    private void Rotate(Vector3 axis, float angle) {      
        var targetRot = Quaternion.AngleAxis(angle, axis);       
        transform.rotation *= targetRot;
    }

}
