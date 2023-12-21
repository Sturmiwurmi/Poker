using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Updatetextmitte : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = Geldmitte.gettextmitte();
    }
}
