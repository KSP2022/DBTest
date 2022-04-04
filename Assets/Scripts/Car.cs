using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Car", menuName = "DB_Objects/New Car")]
public class Car : BaseVehicle
{
  
    [SerializeField] private string _doorsCount;
    [SerializeField] private string _type;


    public string DoorsCount => this._doorsCount;
    public string Type => this._type;


    public void SetDoorsCount(string newValue)
    {
        _doorsCount = newValue;
    }

    public void SetType(string newValue)
    {
        _type = newValue;
    }
}
