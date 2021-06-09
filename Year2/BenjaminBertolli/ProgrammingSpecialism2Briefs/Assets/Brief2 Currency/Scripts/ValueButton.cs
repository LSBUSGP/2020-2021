using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueButton : MonoBehaviour
{
    public float Value = 1;
    private ValueManager VM;
    
    // Start is called before the first frame update
    void Start()
    {
        VM = transform.parent.GetComponent<ValueManager>();
        gameObject.GetComponent<Button>().onClick.AddListener(delegate { VM.ChangeValue(Value); });
    }

    
}
