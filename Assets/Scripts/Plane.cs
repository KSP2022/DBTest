using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plane", menuName = "DB_Objects/New Plane")]
public class Plane : BaseVehicle
{
    [SerializeField] private string _maxAltitude;
    [SerializeField] private string _maxDistance;


    public string MaxAltitude => _maxAltitude;
    public string MaxDistance => _maxDistance;

    public void SetMaxAltitude(string newValue)
    {
        _maxAltitude = newValue;
    }

    public void SetMaxDistance(string newValue)
    {
        _maxDistance = newValue;
    }
}
