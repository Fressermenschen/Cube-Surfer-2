using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NoStacked"))
        {
            other.transform.parent = player;
            Vector3 lastParent = PlayerMove.instance.cubes[PlayerMove.instance.cubes.Count - 1].transform.localPosition;
            other.transform.localPosition = lastParent - new Vector3(0,transform.localScale.x,0);
            player.position += Vector3.up;
            PlayerMove.instance.cubes.Add(other.gameObject);
            other.tag = "Stacked";
        }

        else if (other.gameObject.CompareTag("Finish"))
        {
            GameManager.instance.isFinish = true;
        }
    }
}
