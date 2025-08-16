using UnityEditor.UI;
using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
    public Transform playerPosotion;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UnityEngine.Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerPosotion.position.x, playerPosotion.position.y, playerPosotion.position.z-1);
    }
}
