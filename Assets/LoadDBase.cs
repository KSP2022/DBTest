using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LoadDBase : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ItemCardPrefab;
    public GameObject ItemsContainer;
    private GameObject _tmpCard;

    public void CardPrepare(string type)
    {
        _tmpCard = Instantiate(ItemCardPrefab);
        _tmpCard.transform.SetParent(ItemsContainer.transform);
        _tmpCard.transform.localPosition = Vector3.zero;
        _tmpCard.transform.localScale = new Vector3(1,1,1);
        _tmpCard.GetComponent<ItemCardControl>().SetType(type);
    }


    public void ClearGrid(GameObject grid)
    {
        grid.GetComponent<GridLayoutGroup>().enabled = true;
        int ck = grid.transform.childCount;
        for (int i = 0; i < ck; i++)
        {
            GameObject go = grid.transform.GetChild(i).gameObject;
            Destroy(go);
        }
        grid.transform.DetachChildren();
    }

    public void LoadBase()
    {
        ClearGrid(ItemsContainer);
        
        var Items = Resources.LoadAll<BaseVehicle>("");
        foreach (var Item in Items)
        {

            //Item.
            CardPrepare(Item.Id);
            _tmpCard.GetComponent<ItemCardControl>().MyName.text = Item.Name;
            _tmpCard.GetComponent<ItemCardControl>().Mass.text = Item.Mass;
            _tmpCard.GetComponent<ItemCardControl>().Capacity.text = Item.Capacity;
            _tmpCard.GetComponent<ItemCardControl>().MaxSpeed.text = Item.MaxSpeed;




            switch (Item.Id)
            {
                case "car":
                    Car tmp_car;
                    tmp_car = (Car)Item;



                    _tmpCard.GetComponent<ItemCardControl>().AdditionalFields[0].GetComponent<Text>().text = "Кол-во дверей:";
                    _tmpCard.GetComponent<ItemCardControl>().AdditionalFields[0].transform.GetChild(0).GetComponent<Text>().text = tmp_car.DoorsCount;

                    _tmpCard.GetComponent<ItemCardControl>().AdditionalFields[1].GetComponent<Text>().text = "Тип:";
                    _tmpCard.GetComponent<ItemCardControl>().AdditionalFields[1].transform.GetChild(0).GetComponent<Text>().text = tmp_car.Type;
                    _tmpCard.GetComponent<ItemCardControl>().obj = tmp_car;

                    break;

                case "ship":
                    Ship tmp_ship;
                    tmp_ship = (Ship)Item;


                    _tmpCard.GetComponent<ItemCardControl>().AdditionalFields[0].GetComponent<Text>().text = "Водоизмещение:";
                    _tmpCard.GetComponent<ItemCardControl>().AdditionalFields[0].transform.GetChild(0).GetComponent<Text>().text = tmp_ship.Displacement;

                    _tmpCard.GetComponent<ItemCardControl>().AdditionalFields[1].GetComponent<Text>().text = "Тип двигателя:";
                    _tmpCard.GetComponent<ItemCardControl>().AdditionalFields[1].transform.GetChild(0).GetComponent<Text>().text = tmp_ship.EngineType;
                    _tmpCard.GetComponent<ItemCardControl>().obj = tmp_ship;

                    break;

                case "plane":
                    Plane tmp_plane;
                    tmp_plane = (Plane)Item;

                    _tmpCard.GetComponent<ItemCardControl>().AdditionalFields[0].GetComponent<Text>().text = "Max высота:";
                    _tmpCard.GetComponent<ItemCardControl>().AdditionalFields[0].transform.GetChild(0).GetComponent<Text>().text = tmp_plane.MaxAltitude;

                    _tmpCard.GetComponent<ItemCardControl>().AdditionalFields[1].GetComponent<Text>().text = "Дальность:";
                    _tmpCard.GetComponent<ItemCardControl>().AdditionalFields[1].transform.GetChild(0).GetComponent<Text>().text = tmp_plane.MaxDistance;
                    _tmpCard.GetComponent<ItemCardControl>().obj = tmp_plane;
                    break;


            }




            Debug.Log(Item.Id);
        }

    }


    void Start()
    {
        LoadBase();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
