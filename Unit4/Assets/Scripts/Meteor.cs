using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{

    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public float speed = 0.1f;

    public int CheckOne;
    public int CheckTwo;
    public int CheckThree;

    private void Start()
    {

        CheckOne = Random.Range(1, 3);
        CheckTwo = Random.Range(1, 3);
        CheckThree = Random.Range(1, 3);

    }

    void Update()
    {
       

        if (CheckOne == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1.transform.position, speed);
        }
        if (CheckOne == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, speed);
        }
        if (CheckOne == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, target3.transform.position, speed);
        }

    }
}
