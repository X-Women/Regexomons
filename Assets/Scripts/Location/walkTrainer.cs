using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkTrainer : MonoBehaviour {

    public Animation walk;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(transform.hasChanged)
        {
            walk.Play();
            StartCoroutine(Wait());
        }else if(!transform.hasChanged)
        {
            walk.Stop();
        }
		
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        transform.hasChanged = false;
    }
}
