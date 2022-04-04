using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EditRoutines : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField NameEdit;
    public TMP_InputField MassEdit;
    public TMP_InputField CapacityEdit;
    public TMP_InputField MaxspeedEdit;
    public TMP_InputField AddEdit1;
    public TMP_InputField AddEdit2;
    public TMP_Text StateText;
    public TMP_Dropdown TypeDropDown;
    public GameObject TypeSelect;
    private Car _tmpCar;
    private Ship _tmpShip;
    private Plane _tmpPlane;
    private BaseVehicle _obj;
    private string _type;
    private string _state;
    public void FillData(string type, BaseVehicle obj)
    {

        NameEdit.text = obj.Name;
        MassEdit.text = obj.Mass;
        CapacityEdit.text = obj.Capacity;
        MaxspeedEdit.text = obj.MaxSpeed;
    }

    public void SetEditableObject(BaseVehicle obj, string type)
    {
        TypeSelect.SetActive(false);
        _state = "EDIT";
        _type = type;
        _obj = obj;
        switch (type)
        {
            case "car":
                _tmpCar = new Car();
                _tmpCar = (Car)obj;
                AddEdit1.text = _tmpCar.DoorsCount;
                AddEdit2.text = _tmpCar.Type;
                break;

            case "ship":
                _tmpShip = new Ship();
                _tmpShip = (Ship)obj;

                AddEdit1.text = _tmpShip.Displacement;
                AddEdit2.text = _tmpShip.EngineType;
                break;

            case "plane":
                 _tmpPlane = new Plane();
                _tmpPlane = (Plane)obj;

                AddEdit1.text = _tmpPlane.MaxAltitude;
                AddEdit2.text = _tmpPlane.MaxDistance;
                break;
        }

        FillData(type, obj);

    }

    

    public void SaveChanges()
    {
        if (_obj == null)
        {

            switch (_state)
            {
                case "EDIT":
                    Debug.Log("Нечего сохранять!!!!!!!!");
                    StateText.text = "Нечего сохранять, выберите объект сначала";
                    return;

                    break;
                case "ADD":

                    
                    switch (_type)
                    {
                        case "NONE":
                            Debug.Log("Выберите тип!");
                            StateText.text = "Выберите тип! Ошибка сохранения!";
                            return;
                            break;
                        case "car":
                            
                            _tmpCar = new Car();
                           
                            _tmpCar.SetID(_type);
                            _tmpCar.SetName(NameEdit.text);
                            _tmpCar.SetMass(MassEdit.text);
                            _tmpCar.SetCapacity(CapacityEdit.text);
                            _tmpCar.SetMaxSpeed(MaxspeedEdit.text);

                            _tmpCar.SetDoorsCount(AddEdit1.text);
                            _tmpCar.SetType(AddEdit2.text);


                            EditorUtility.SetDirty(_tmpCar);
                            AssetDatabase.CreateAsset(_tmpCar, "Assets/Resources/"+Random.RandomRange(0, 5000000)+ Random.RandomRange(0, 5000000) + _type + ".asset");
                            AssetDatabase.SaveAssets();
                            GameObject.Find("Main Camera").GetComponent<LoadDBase>().LoadBase();

                            AddNewItem();
                            //AssetDatabase.AddObjectToAsset(_tmpCar, "Resources");

                            break;

                        case "ship":
                           
                            _tmpShip = new Ship();
                            _tmpShip.SetID(_type);
                            _tmpShip.SetName(NameEdit.text);
                            _tmpShip.SetMass(MassEdit.text);
                            _tmpShip.SetCapacity(CapacityEdit.text);
                            _tmpShip.SetMaxSpeed(MaxspeedEdit.text);

                            _tmpShip.SetDisplacement(AddEdit1.text);
                            _tmpShip.SetEngineType(AddEdit2.text);

                            EditorUtility.SetDirty(_tmpShip);
                            AssetDatabase.CreateAsset(_tmpShip, "Assets/Resources/" + Random.RandomRange(0, 5000000) + Random.RandomRange(0, 5000000) + _type + ".asset");
                            AssetDatabase.SaveAssets();
                            GameObject.Find("Main Camera").GetComponent<LoadDBase>().LoadBase();
                            AddNewItem();
                            break;

                        case "plane":
                         
                            _tmpPlane = new Plane();
                            _tmpPlane.SetID(_type);
                            _tmpPlane.SetName(NameEdit.text);
                            _tmpPlane.SetMass(MassEdit.text);
                            _tmpPlane.SetCapacity(CapacityEdit.text);
                            _tmpPlane.SetMaxSpeed(MaxspeedEdit.text);

                            _tmpPlane.SetMaxAltitude(AddEdit1.text);
                            _tmpPlane.SetMaxDistance(AddEdit2.text);
                            EditorUtility.SetDirty(_tmpPlane);
                            AssetDatabase.CreateAsset(_tmpPlane, "Assets/Resources/" + Random.RandomRange(0, 5000000) + Random.RandomRange(0, 5000000) + _type + ".asset");
                            AssetDatabase.SaveAssets();
                            GameObject.Find("Main Camera").GetComponent<LoadDBase>().LoadBase();
                            AddNewItem();
                            break;

                    }


                    return; 
                    break;

            }



            return;
        }

        _obj.SetName(NameEdit.text);
        _obj.SetMass(MassEdit.text);
        _obj.SetCapacity(CapacityEdit.text);
        _obj.SetMaxSpeed(MaxspeedEdit.text);

        
        switch (_type)
        {
            case "car":
                _tmpCar.SetDoorsCount(AddEdit1.text);
                _tmpCar.SetType(AddEdit2.text);
                EditorUtility.SetDirty(_tmpCar);
                AssetDatabase.SaveAssets();
                
                break;

            case "ship":
                _tmpShip.SetDisplacement(AddEdit1.text);
                _tmpShip.SetEngineType(AddEdit2.text);
                EditorUtility.SetDirty(_tmpShip);
                AssetDatabase.SaveAssets();

                break;

            case "plane":
                _tmpPlane.SetMaxAltitude(AddEdit1.text);
                _tmpPlane.SetMaxDistance(AddEdit2.text);
                EditorUtility.SetDirty(_tmpPlane);
                AssetDatabase.SaveAssets();

                break;
        }
        StateText.text = "успешно сохранен объект типа ["+_type+"]  на "+Time.timeSinceLevelLoad +" секунде";
        GameObject.Find("Main Camera").GetComponent<LoadDBase>().LoadBase();





    }

    void Start()
    {
        TypeSelect.SetActive(false);
        _state = "EDIT";
    }


    public void OnTypeSelect(TMP_Dropdown change)
    {

        Debug.Log("Type value changed.."+ change.value);
       

        switch (change.value)
        {
            case 1: //car
                AddEdit1.GetComponentInChildren<TMP_Text>().text  = "Количество дверей";
                AddEdit2.GetComponentInChildren<TMP_Text>().text = "Тип кузова";
                _type = "car";
                break;

            case 2: //ship
                AddEdit1.GetComponentInChildren<TMP_Text>().text = "Водоизмещение";
                AddEdit2.GetComponentInChildren<TMP_Text>().text = "Тип двигателя";
                _type = "ship";
                break;

            case 3: //plane
                AddEdit1.GetComponentInChildren<TMP_Text>().text = "Максимальная высота";
                AddEdit2.GetComponentInChildren<TMP_Text>().text = "Максимальная дальность";
                _type = "plane";
                break;
        }

        //AddEdit1
    }

    public void AddNewItem()
    {
        _state = "ADD";
        _type = "NONE";
        _obj = null;
        _tmpCar = null;
        _tmpPlane = null;
        _tmpShip = null;
        TypeSelect.SetActive(true);
        NameEdit.text = "";
        MassEdit.text = "";
        CapacityEdit.text = "";
        MaxspeedEdit.text = "";
        AddEdit1.text = "";
        AddEdit2.text = "";
        TypeDropDown.value = -1;
    }


    public void DeleteItem()
    {
        if (_obj == null)
        {
            StateText.text = "Нечего удалять.... [" + _type + "]  на " + Time.timeSinceLevelLoad + " секунде";
            return;
        }

        switch (_type)
        {
            case "car":

                AssetDatabase.DeleteAsset(EditorUtility.GetAssetPath(_tmpCar));

                break;

            case "ship":
               
                AssetDatabase.DeleteAsset(EditorUtility.GetAssetPath(_tmpShip));
                break;

            case "plane":
              
                AssetDatabase.DeleteAsset(EditorUtility.GetAssetPath(_tmpPlane));
               
                break;

    
        }
        StateText.text = "успешно удален объект типа [" + _type + "]  на " + Time.timeSinceLevelLoad + " секунде";
        GameObject.Find("Main Camera").GetComponent<LoadDBase>().LoadBase();


        _state = "DELETE";
        _type = "NONE";
        _obj = null;
        _tmpCar = null;
        _tmpPlane = null;
        _tmpShip = null;
        TypeSelect.SetActive(false);
        NameEdit.text = "";
        MassEdit.text = "";
        CapacityEdit.text = "";
        MaxspeedEdit.text = "";
        AddEdit1.text = "";
        AddEdit2.text = "";
        TypeDropDown.value = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
