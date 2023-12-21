using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wuerfelscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setSprite(Sprite sprite)
    {
        this.GetComponent<Image>().sprite = sprite;
    }
    void Update()
    {
        
    }
}
