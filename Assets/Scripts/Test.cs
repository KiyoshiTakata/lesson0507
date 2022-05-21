using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private int index;
    [SerializeField]
    private int a;
    public string contoroleer;
    public int b;
    [SerializeField]
    private bool isFlag;

    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // スペースを押したらバウンド止まる
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        }
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
