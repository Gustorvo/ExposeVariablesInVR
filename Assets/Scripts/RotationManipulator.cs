using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Plane {
x, y, z
}
[ExecuteInEditMode]
public class RotationManipulator : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField, Range(0, 360)] int _steps = 10;
    [SerializeField, Range(0.1f, 2)] float _scale = 1f;
    [SerializeField] Plane _plane;

    private HingeJoint _joint;
    private List<Vector3> _positions;

    private void Awake() {
        _joint = GetComponent<HingeJoint>();
    }

    private void OnValidate() {
        _positions = new List<Vector3>(_steps);

        for(int i = 0; i < _steps; i++) {
            float ration = (float)i / (float)_steps;
            ration *= 2 *Mathf.PI;
            float a = Mathf.Sin(ration);          
            float b = Mathf.Cos(ration);
            Vector3 pos = Vector3.zero;
            if (_plane == Plane.x) {
            _positions.Add(new Vector3(0, a, b) * _scale);
            }
            else if (_plane == Plane.y) {
                _positions.Add(new Vector3(a, 0, b) * _scale);
            }
            else {
                _positions.Add(new Vector3(a, b, 0) * _scale);
            }

        }
    }

    private void Update() {
        if (_target) {

        _target.rotation = transform.rotation;
        }
    }

    private void OnDrawGizmosSelected() {
        if(_positions != null) {
            foreach(var pos in _positions) {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(pos + transform.position, 0.025f);
            }
        }
    }
}
