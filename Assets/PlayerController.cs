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

    void Start()
    {
        _cursor.transform.position = _anchors[0].position;
    }
    void Update()
    {
        HandleCursor();
    }

    private void HandleCursor(){
        if (Input.GetKeyDown(KeyCode.Q) && _cursor.transform.position.x > XBound.x ){
            _cursor.transform.position += new Vector3 ( -cursorStep, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D) && _cursor.transform.position.x < XBound.y ){
            _cursor.transform.position += new Vector3 ( cursorStep, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Z) && _cursor.transform.position.y < YBound.x ){
            _cursor.transform.position += new Vector3 ( 0, cursorStep, 0);
        }
        if (Input.GetKeyDown(KeyCode.S) && _cursor.transform.position.y > YBound.y ){
            _cursor.transform.position += new Vector3 (0, -cursorStep,  0);
        }
    }
    
}
