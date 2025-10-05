using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Movimiento : MonoBehaviour
{
    public NavMeshAgent miagente;
    public Transform objetivo;

    // Start is called before the first frame update
    void Start()
    {
        miagente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        miagente.destination = objetivo.position;
    }
}
