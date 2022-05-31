using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntSO", menuName = "ScriptableObjects/IntSO")]
public class IntSO : ScriptableObject
{
    [SerializeField]
    private int _value;

    public int Value
    {
        get {return _value;}
        set {_value = Value;}
    }
}
