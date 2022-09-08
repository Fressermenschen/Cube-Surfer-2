using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFloor : MonoBehaviour
{
    [SerializeField] public int FinishFloorNum;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stacked"))
        {
            other.transform.parent = null;
            PlayerMove.instance.cubes.Remove(other.gameObject);
            Destroy(other.gameObject, 2f);

            if (PlayerMove.instance.cubes.Count == 0 || FinishFloorNum == 10)
            {
                CoinManager.instance.AddCoins(50*FinishFloorNum);
                GameManager.instance.isGameWin = true;
                GameManager.instance.WinPanel();
            }
        }
    }
}
