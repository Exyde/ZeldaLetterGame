using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject _LetterPrefab;
    public GameObject _cursor;
    public Transform[] _anchors;

    public Vector2 XBound, YBound;
    float cursorStep = 2.5f;

    void Start(){
        _cursor.transform.localPosition = _anchors[0].position;
    }
    void Update(){
        HandleCursor();
    }

    private void HandleCursor(){
        if (Input.GetKeyDown(KeyCode.Q) && _cursor.transform.localPosition.x > XBound.x ){
            _cursor.transform.localPosition += new Vector3 ( -cursorStep, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D) && _cursor.transform.localPosition.x < XBound.y ){
            _cursor.transform.localPosition += new Vector3 ( cursorStep, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.S) && _cursor.transform.localPosition.y > YBound.x ){
            print(_cursor.transform.localPosition);
            _cursor.transform.localPosition += new Vector3 (0, -cursorStep,  0);
            print(_cursor.transform.localPosition);

        }
        if (Input.GetKeyDown(KeyCode.Z) && _cursor.transform.localPosition.y < YBound.y ){
            print(_cursor.transform.localPosition);
            _cursor.transform.localPosition += new Vector3 ( 0, cursorStep, 0);
            print(_cursor.transform.localPosition);

        }
    }
    
}
