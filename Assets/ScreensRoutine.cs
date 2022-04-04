using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensRoutine : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject InitialScreen;
    public GameObject DataVeiewScreen;

    public void ShowDataView(bool show)
    {
        DataVeiewScreen.SetActive(show);
        InitialScreen.SetActive(!show);
    }

    public void ShowMainView(bool show)
    {
        InitialScreen.SetActive(show);
        DataVeiewScreen.SetActive(!show);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
