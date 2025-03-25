using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public int FruitsCount;
    public Text FruitsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FruitsText.text = "Fruit Count: " + FruitsCount.ToString();
    }
}
