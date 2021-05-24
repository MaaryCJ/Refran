using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pajaro : MonoBehaviour
{
    // Start is called before the first frame update
    private static readonly int minScore = 1;
    private static readonly int maxScore = 100;

    public float minX, minY, maxX, maxY;

    public int numPuntosCamino = 5;
    public Vector2[] camino;
    public int puntoActual;

    public float moveSpeed = 5;


    public int score;

    void Start()
    {
        camino = new Vector2[numPuntosCamino];
        score = Random.Range(minScore, maxScore);

        for(int i = 0; i< numPuntosCamino; i++)
        {
            camino[i] = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }
        puntoActual = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector2.Distance(transform.position,camino[puntoActual]) <= 1)
        {
            puntoActual = (puntoActual + 1) % numPuntosCamino;
        }

        transform.position = Vector2.MoveTowards(transform.position, camino[puntoActual], moveSpeed*Time.deltaTime);




    }

    public void Cazado()
    {
        Destroy(gameObject);
    }
}
