using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using static Enums;

[ExecuteInEditMode]
public class Axis : MonoBehaviour
{
    [SerializeField] TextMeshPro _text;
    [SerializeField] int _magicNum;
    [SerializeField] GameObject _objToWatchRotationFrom;
    [SerializeField] RotationAxis _axis;

    private void Update() {
        UpdateText();
    }

    private void OnValidate() {
        UpdateText();
        
    }

    void UpdateText() {
        if(_text && _objToWatchRotationFrom) {
            _text.text = GetFromAxisAngle(_objToWatchRotationFrom.transform).ToString();
                //WrapAngle(transform.localEulerAngles.y).ToString();
        }
    }

    private double GetFromAxisAngle(Transform obj) {
        Vector3 v = _axis == RotationAxis.x? Vector3.right : _axis == RotationAxis.y ? Vector3.up : Vector3.forward;
        float angle = _axis == RotationAxis.x ? obj.localEulerAngles.x : _axis == RotationAxis.y ? obj.localEulerAngles.y : obj.localEulerAngles.z;
        //Vector3 axis;       
        //obj.rotation.ToAngleAxis(out angle, out axis);       
        // if(angle > 180)
        //    return Math.Round(angle - 180, 2);
        //return Math.Round(180 - angle, 2);
        return Math.Round(angle, 2);
    }

    private  double WrapAngle(float angle) {
        angle %= 360;
        if(angle > 180)
            return Math.Round(angle - 360, 2);

        return Math.Round(angle, 2);
    }

    private  float UnwrapAngle(float angle) {
        if(angle >= 0)
            return angle;

        angle = -angle % 360;

        return 360 - angle;
    }
}
