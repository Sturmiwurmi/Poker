using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Geldmitte : MonoBehaviour
{
    
    static string text; 
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void updatetext(string t)
    {
       text = t;
    }
    public static string gettextmitte()
    {
        return text;
    }
}
