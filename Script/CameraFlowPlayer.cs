using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFlowPlayer : MonoBehaviour
{
    public Vector3 offset; 
    public Transform mainPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mainPlayer==null)
            return; 
        transform.position = new Vector3(mainPlayer.position.x + offset.x, mainPlayer.position.y+offset.y,transform.position.z) ;
    }
}
