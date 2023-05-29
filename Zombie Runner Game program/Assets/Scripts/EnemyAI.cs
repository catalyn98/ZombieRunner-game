using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* pentru a putea folosi clasa NavMeshAgent 
   este necesar să adăugăm următorul namespace: */
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
  /* următorul câmp setează cât de aproape de inamic 
     trebuie să fie jucătorul pentru ca acesta 
     să înceapă să-l urmărească */
  [SerializeField] float chaseRange = 10f;
  /* viteza de deplasare a inamicului */
  [SerializeField] float turnSpeed = 5f;
  NavMeshAgent navMeshAgent;
  /* dorim ca distanța dintre jucător și inamic 
     la pornirea jocului să fie cât de mare posibilă */
  float distanceToTarget = Mathf.Infinity;
  bool isProvoked = false;
  /* câmpul target face referire la jucător */
  Transform target;
  EnemyHealth health;

  void Start() {
    navMeshAgent = GetComponent<NavMeshAgent>();
    health = GetComponent<EnemyHealth>();
    target = FindObjectOfType<PlayerHealth>().transform;
  }

  void Update() {
    if (health.IsDead()) { /* dacă inamicul este ucis */
      /* dezactivează scriptul care-l face să se miște */
      this.enabled = false;
      /* dezactivează navMeshAgent */
      navMeshAgent.enabled = false;
    }
    else {
      /* calculează distanța de la jucător la inamic */
      distanceToTarget = Vector3.Distance(target.position, transform.position);

      /* dacă inamicul a fost provocat prin încercarea de a fi împușcat*/
      if (isProvoked) {
        EngageTarget(); /* apelează funcția EngageTarget()*/
      }
      /* dacă distanța dintre jucător și inamic este mai mică decât cea setată anterior
         inamicul va începe să urmărească jucătorul */
      else if (distanceToTarget <= chaseRange) {
        /* setează câmpul isProvoked pe true astfel încât chiar dacă jucătorul părăsește raza de detecție
           inamicul să-l urmărească pe acesta în continuare */
        isProvoked = true;
      }
    }
  }

  /* această metodă va fi apelată în clasa EnemyHealth.cs*/
  public void OnDamageTaken() {
    isProvoked = true;
  }

  private void EngageTarget() {
    FaceTarget();
    /* dacă inamicul nu este suficient de aproape să poată răni jucătorul */
    if (distanceToTarget >= navMeshAgent.stoppingDistance) {
      ChaseTarget(); /* apelează funcția ChaseTarget() */
    }
    /* dacă inamicul este suficient de aproape să poată răni jucătorul */
    if (distanceToTarget <= navMeshAgent.stoppingDistance) {
      AttackTarget(); /* apelează funcția AttackTarget() */
    }
  }

  private void ChaseTarget() {
    /* setează animația de atac la fals în cazul în care tocmai am atacat și jucătorul părăsește raza de urmărire. 
       Asta presupune că inamicul trebuie să se miște din nou, ceea ce înseamnă că nu poate ataca în timp ce urmărește jucătorul */
    GetComponent<Animator>().SetBool("attack", false);
    /* setează inamicului animația de mișcare */
    GetComponent<Animator>().SetTrigger("move");
    /* destinația inamicului este jucătorul */
    navMeshAgent.SetDestination(target.position);
  }

  private void AttackTarget() {
     /* setează animația de atac la adevărat în cazul în care jucătorul se află în raza de acționare inamicului */
    GetComponent<Animator>().SetBool("attack", true);
  }

  /* metoda FaceTarget() ajută inamicul "să păstreze contactul vizual" cu jucătorul */
  private void FaceTarget() {
    Vector3 direction = (target.position - transform.position).normalized;
    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
  }

  /* metoda OnDrawGizmosSelected() desenează spire în jurul obiectului când acesta este selectat */
  void OnDrawGizmosSelected() {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, chaseRange);
  }
}