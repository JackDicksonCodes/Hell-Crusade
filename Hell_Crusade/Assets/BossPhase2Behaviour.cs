using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase2Behaviour : MonoBehaviour
{
    public bool phase2Active;
    private UnityEngine.AI.NavMeshAgent agent;
    public List<Transform> points;
    private GameObject player;
    private int destPoint;
    public float projectileForce = 10f;
    private float activeCooldown;
    public Transform projexit;
    public GameObject bloodProjectile;
    public GameObject hellCircle;
    private Vector3 rayDir;
    public float coolDown = 1f;
    private int attackChoice;
    public float specialProjectileForce;
   
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        phase2Active = false;
        player = GameObject.Find("Player");
        destPoint = 0;
        destPoint = 0;
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(phase2Active){
            if(agent.remainingDistance == 0){
                    GotoNextPoint();
                }
            fight2();
        }
    }

    void StartPhase2(){
        GotoNextPoint();
        phase2Active = true;
    }

    void GotoNextPoint(){
        if(points.Count == 0){
            return;
        }

        agent.destination = points[destPoint].position;

        if(destPoint == points.Count - 1){
            destPoint = 0;
        }
        else{
            destPoint ++;
        }
    }

    private void fight2(){
        rayDir = transform.TransformDirection(player.transform.position - transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDir);
        if(activeCooldown <= 0){
            activeCooldown = coolDown;
            attackChoice = Random.Range(1, 101);
            switch(attackChoice){
            case int i when i > 1 && i <= 40:
                StartCoroutine(ShootSequence());
                break;
            case int i when i > 40 && i <= 80:
                StartCoroutine(ShootTriangleSequence());
                break;
            case int i when i > 80 && i <= 100:
                HellCircle();
                break;
            }
        }

        if(activeCooldown > 0){
            activeCooldown -= Time.deltaTime;
        }
    }

    IEnumerator ShootSequence(){
        int i = 0;
        while(i < 3){
            yield return new WaitForSeconds(0.5f);
            Shoot();
            i ++;
        }
    }

    IEnumerator ShootTriangleSequence(){
        int i = 0;
        while(i < 3){
            yield return new WaitForSeconds(0.5f);
            ShootTriangle();
            i ++;
        }
    }

    // IEnumerator ShootAroundSequence(){
    //     int i = 0;
    //     while( i < 8 ){
    //         yield return new WaitForSeconds(0.5f);
    //         ShootAround();
    //         i ++;
    //         transform.Rotate(0,0,45);
    //     }
    // }

    private void Shoot()
    {
        
        GameObject bullet = Instantiate(bloodProjectile, projexit.position, projexit.rotation);
        Rigidbody2D body = bullet.GetComponent<Rigidbody2D>();
        body.AddForce(rayDir * projectileForce, ForceMode2D.Impulse);
        activeCooldown = coolDown;
        
    }

    private void ShootTriangle()
    {
        
        Vector3 rayDir2 = transform.TransformDirection(rayDir + new Vector3(5,5,0));
        Vector3 rayDir3 = transform.TransformDirection(rayDir - new Vector3(5,5,0));
        GameObject bullet = Instantiate(bloodProjectile, projexit.position, projexit.rotation);
        GameObject bullet2 = Instantiate(bloodProjectile, projexit.position, projexit.rotation);
        GameObject bullet3 = Instantiate(bloodProjectile, projexit.position, projexit.rotation);
        Rigidbody2D body = bullet.GetComponent<Rigidbody2D>();
        body.AddForce(rayDir * projectileForce, ForceMode2D.Impulse);
        Rigidbody2D body2 = bullet2.GetComponent<Rigidbody2D>();
        body2.AddForce(rayDir2 * projectileForce, ForceMode2D.Impulse);
        Rigidbody2D body3 = bullet3.GetComponent<Rigidbody2D>();
        body3.AddForce(rayDir3 * projectileForce, ForceMode2D.Impulse);
        activeCooldown = coolDown;
    }

    private void HellCircle(){
        GameObject newHellCircle = Instantiate(hellCircle, player.transform.position, Quaternion.identity);
        
        activeCooldown = coolDown;
    }
}
