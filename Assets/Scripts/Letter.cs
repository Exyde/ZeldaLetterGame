using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    public enum LetterType{ Ring, Flare, Magic, Bubbles, Spark, Flower}
    public Material[] _materials;
    public LetterType _letterType;
    public GameObject FaceA;
    public GameObject FaceB;
    Rigidbody rb;

    public bool isRotating = false;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        SetRandomType();
        SetMaterialBasedOnType();
    }

    void SetRandomType (){
        _letterType = (LetterType)(Random.Range(0, 5));
    }

    void SetMaterialBasedOnType(){
       FaceA.GetComponent<MeshRenderer>().material = _materials[(int)_letterType];
       FaceB.GetComponent<MeshRenderer>().material = _materials[(int)_letterType];
    }

    private void Update() {
        if (isRotating){
            transform.Rotate(new Vector3(0,1,1));
        }
    }

}