using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private int index;
    [SerializeField]
    private int a;
    public string contoroleer;
    public int b;
    [SerializeField]
    private bool isFlag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFlag)
        {
            Init();
        }
    }

    public void Init()
    {
        Debug.Log($"index={index}");
    }
}
