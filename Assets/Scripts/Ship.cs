using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Ship", menuName ="DB_Objects/New Ship")]
public class Ship : BaseVehicle
{
    [SerializeField] private string _displacement;
    [SerializeField] private string _engineType;


    public string Displacement => _displacement;
    public string EngineType => _engineType;


    public void SetDisplacement(string newValue)
    {
        _displacement = newValue;
    }

    public void SetEngineType(string newValue)
    {
        _engineType = newValue;
    }

}
