using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitController : MonoBehaviour
{
    public int Fruitscount;
    public Text FruitsText;
    public GameObject Door;
    private bool doorDestroyd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FruitsText.text = ":" + Fruitscount.ToString();

        if (Fruitscount == 5 && doorDestroyd)
        {
            doorDestroyd = true;
            Destroy(Door);
        }
    }

}
