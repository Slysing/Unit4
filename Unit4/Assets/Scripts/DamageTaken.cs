using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken : MonoBehaviour
{


    public float lives = 5f;
    public bool lives0 = false;
    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;
    public GameObject Life4;
    public GameObject Life5;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Meteor"))
        {
            lives -= 0.5f;
            Destroy(other.gameObject);

        }


    }

    private void Update()
    {
        if (lives == 5)
        {
            Life1.SetActive(true);
            Life2.SetActive(true);
            Life3.SetActive(true);
            Life4.SetActive(true);
            Life5.SetActive(true);
        }
        if (lives == 4)
        {
            Mathf.Floor(4.0f);
            Life1.SetActive(false);
        }
        if (lives == 3)
        {
            Mathf.Floor(3.0f);
            Life2.SetActive(false);
        }
        if (lives == 2)
        {
            Mathf.Floor(2.0f);
            Life3.SetActive(false);
        }
        if (lives == 1)
        {
            Mathf.Floor(1.0f);
            Life4.SetActive(false);
        }
        if (lives == 0)
        {
            Mathf.Floor(0.0f);
            Life5.SetActive(false);
            //lives0 = true;
        }
    }

}
