using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemCardControl : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    public Sprite[] Icons;
    public Image Icon;
    public BaseVehicle obj;
    private string _card_type;
    private int _currentField;

    public Text MyName;
    public Text Mass;
    public Text Capacity;
    public Text MaxSpeed;

    public GameObject[] AdditionalFields;


    public void SetType(string type)
    {
        _card_type = type;
       
        foreach (Sprite item in Icons)
        {

          if (item.name.Equals(_card_type))
          {
              Icon.GetComponent<Image>().sprite = item;
              return;
          }

        }
    }

    void Start()
    {
        _currentField = 0;
        Debug.Log("Hello from ICC!!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("EditPanel").GetComponent<EditRoutines>().SetEditableObject(obj, obj.Id);
    }
}
