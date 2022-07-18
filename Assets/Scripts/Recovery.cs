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
        StartCoroutine(ParticalTime());
        FindObjectOfType<ParticleSystem>().Play();
    }

    IEnumerator ParticalTime()
    {
        yield return new WaitForSeconds(4);
        FindObjectOfType<ParticleSystem>().Stop();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
