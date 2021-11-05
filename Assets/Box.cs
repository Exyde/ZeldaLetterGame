using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public enum BoxType{ Ring, Flare, Magic, Bubbles, Spark, Flower}
    public BoxType _boxType;

    private void OnTriggerEnter(Collider other) {

        Letter _letter = null;
        if (other.TryGetComponent<Letter>(out _letter)){
            if (_letter != null){
                if((int)_letter._letterType == (int)this._boxType){
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
