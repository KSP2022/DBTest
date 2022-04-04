using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  BaseVehicle: ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private string _name;
    [SerializeField] private string _mass;
    [SerializeField] private string _capacity;
    [SerializeField] private string _maxSpeed;


   
    public string Id => _id;
    public string Name => _name;
    public string Mass => _mass;
    public string Capacity => _capacity;
    public string MaxSpeed => _maxSpeed;

    public void SetID(string new_value)
    {
        _id = new_value;
    }


    public void SetName(string new_value)
    {
        _name = new_value;
    }


    public void SetMass(string new_value)
    {
        _mass = new_value;
    }

    public void SetCapacity(string new_value)
    {
        _capacity = new_value;
    }

    public void SetMaxSpeed(string new_value)
    {
        _maxSpeed = new_value;
    }

}
