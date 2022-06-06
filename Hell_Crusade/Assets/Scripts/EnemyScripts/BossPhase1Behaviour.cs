using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase1Behaviour : MonoBehaviour
{
    public bool phase1Active;
    private UnityEngine.AI.NavMeshAgent agent;
    public List<Transform> points;
    private GameObject player;
    private int destPoint;
    public float projectileForce = 10f;
    private float activeCooldown;
    public Transform projexit;
    public GameObject bloodProjectile;
    private Vector3 rayDir;
    public float coolDown = 1f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        phase1Active = true;
        player = GameObject.Find("Player");
        destPoint = 0;
        GotoNextPoint();
        destPoint = 0;
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(phase1Active){
            if(agent.remainingDistance == 0){
                    GotoNextPoint();
                }
            fight();
        }
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

    private void fight(){
        rayDir = transform.TransformDirection(player.transform.position - transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDir);
        if(activeCooldown <= 0){
            StartCoroutine(ShootSequence());
            activeCooldown = coolDown;
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

    private void Shoot(){
        
        GameObject bullet = Instantiate(bloodProjectile, projexit.position, projexit.rotation);
        Rigidbody2D body = bullet.GetComponent<Rigidbody2D>();
        body.AddForce(rayDir * projectileForce, ForceMode2D.Impulse);
        activeCooldown = coolDown;
        
    }
}
