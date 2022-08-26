using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenHall : MonoBehaviour
{
    [Header("ó��")]
    [SerializeField] GameObject hiddenA;

    [Header("����")]
    [SerializeField] GameObject hiddenB;

    void changeHidden()
    {
        hiddenA.gameObject.SetActive(false);
        hiddenB.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        changeHidden();
    }
}
