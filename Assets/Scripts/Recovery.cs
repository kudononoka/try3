using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : ItemBase
{
    private float _recovery = 30f;
    // Start is called before the first frame update
    public override void Action()
    {
        FindObjectOfType<PlayerManager>().Recovery(_recovery);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
