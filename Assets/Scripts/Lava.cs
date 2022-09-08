using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Lava : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float waitOnAir;
    [SerializeField] private float fallSpeed;
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stacked"))
        {
            other.transform.parent = null;
            PlayerMove.instance.cubes.Remove(other.gameObject);
            Destroy(other.gameObject);
            StartCoroutine(Gravity());

            if (PlayerMove.instance.cubes.Count == 0)
            {
                GameManager.instance.isGameOver = true;
                GameManager.instance.FailPanel();
            }
        }
    }
    
    private IEnumerator Gravity()
    {
        yield return new WaitForSeconds(waitOnAir);
        player.DOMoveY(PlayerMove.instance.cubes.Count, fallSpeed); 
    }
}
