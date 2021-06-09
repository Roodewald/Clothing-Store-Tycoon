using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HummanMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;

    GameObject[] ShopСunterPoints;
    GameObject[] CassPoits;
    bool readyToGo = true;
    bool coroutine = false;

    private void Start()
    {
        ShopСunterPoints = GameObject.FindGameObjectsWithTag("ShopСunterPoint");
        CassPoits = GameObject.FindGameObjectsWithTag("CassPoit");
    }

    private void Update()
    {
        if (readyToGo)
        {
            readyToGo = false;
            Move(1);
        }
        if (gameObject.transform.position.x == navMeshAgent.destination.x || gameObject.transform.position.y == navMeshAgent.destination.y)
        {
            if (!coroutine)
            {
                coroutine = true;
                StartCoroutine(Wait());
                
            }
        }
    }
    IEnumerator Wait()
    {
        print("coroutine start");
        yield return new WaitForSeconds(2);
        readyToGo = true;
        print("coroutine midle");
        yield return new WaitForSeconds(.1f);
        coroutine = false;
        print("coroutine end");
    }

    void Move(int place)//0 Shop //1 OutFromShop
    {
        Vector3 target;
        if (place == 0)
        {
            target = ShopСunterPoints[Random.Range(0, ShopСunterPoints.Length)].transform.position;
            navMeshAgent.SetDestination(target);
        }
        if (place == 1)
        {
            target = CassPoits[Random.Range(0,CassPoits.Length)].transform.position;
            navMeshAgent.SetDestination(target);
        }  
    }
}
