using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : ItemBase
{
    private float _recovery = 30f;
    private ParticleSystem _recoveryPartical;
    private ParticleSystem _attackUpPartical;

    // Start is called before the first frame update

    void Start()
    {
        _recoveryPartical = GameObject.Find("Player").GetComponent<ParticleSystem>();
        _attackUpPartical = GameObject.Find("model").GetComponent<ParticleSystem>();
    }

    public override void Action()
    {
        FindObjectOfType<PlayerManager>().Recovery(_recovery);
        StartCoroutine(ParticalTime());
        _recoveryPartical.Play();
        _attackUpPartical.Stop();
    }

    IEnumerator ParticalTime()
    {
        yield return new WaitForSeconds(4);
        _recoveryPartical.Stop();
    }
}
