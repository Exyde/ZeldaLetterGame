using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject _LetterPrefab;
    public GameObject _LetterHolder;
    GameObject _currentLetter = null;

    public GameObject _cursor;
    public Transform[] _anchors;

    public Vector2 XBound, YBound;
    float cursorStep = 2.5f;
    bool canShoot = false;
    public float timeBtwShoot = .8f;
    float timeBeforeNextShoot = 0;
    public float shootForce = 1000f;
    public float _camSpeed = 2f;

    void Start(){
        _cursor.transform.localPosition = _anchors[0].position;
    }
    void Update(){
        HandleCursor();
        HandleShooting();

        //Camera.main.transform.LookAt(_cursor.transform.position);

    }

    private void HandleCursor(){
        if (Input.GetKeyDown(KeyCode.Q) && _cursor.transform.localPosition.x > XBound.x ){
            _cursor.transform.localPosition += new Vector3 ( -cursorStep, 0, 0);
        Vector3 direction = _cursor.transform.position - Camera.main.transform.position;
        Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
        Camera.main.transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, _camSpeed * Time.time);
        }
        if (Input.GetKeyDown(KeyCode.D) && _cursor.transform.localPosition.x < XBound.y ){
            _cursor.transform.localPosition += new Vector3 ( cursorStep, 0, 0);

        }
        if (Input.GetKeyDown(KeyCode.S) && _cursor.transform.localPosition.y > YBound.x ){
            _cursor.transform.localPosition += new Vector3 (0, -cursorStep,  0);

        }
        if (Input.GetKeyDown(KeyCode.Z) && _cursor.transform.localPosition.y < YBound.y ){
            _cursor.transform.localPosition += new Vector3 ( 0, cursorStep, 0);

        }
    }

    private void HandleShooting(){
        if(timeBeforeNextShoot <= 0 && !canShoot) {
            canShoot = true;
            _currentLetter = Instantiate (_LetterPrefab, _LetterHolder.transform.position, transform.rotation *  Quaternion.Euler(140, 0, 0));
           // _currentLetter.transform.parent = _LetterHolder.transform;
        }

        if(!canShoot ){
            timeBeforeNextShoot -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canShoot){
            canShoot = false;
            timeBeforeNextShoot = timeBtwShoot;

           Rigidbody rb = _currentLetter.GetComponent<Rigidbody>();
           rb.useGravity = true;
           rb.AddForce(((_cursor.transform.position - _currentLetter.transform.position).normalized + new  Vector3 ( 0, Random.Range(0, 0.05f) )) * shootForce, ForceMode.Force);
           _currentLetter.GetComponent<Letter>().isRotating = false;
        }
    }
    
}
