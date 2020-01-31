using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("called");
            GameObject missle = Instantiate(Resources.Load("missile", typeof(GameObject)), this.transform) as GameObject;
        }
    }
}
