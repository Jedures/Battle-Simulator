/*
* Basic AI
* Foundation on NavMesh
* by Vladislav Gorik
* Last update 23.04.2017
*/

using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public enum TypeAI
{
    Nothing = 0,

    Warrior = 1,
    Skelet = 2
}
public class AIController : MonoBehaviour
{
    #region Public var

    [Header("Type")]
    public TypeAI _type = 0;

    [Header("Health")]
    public float CurHealth = 100f;
    public float MaxHealth = 100f;

    [Header("Damage")]
    public float MinDamage = 10f;
    public float MaxDamage = 20f;

    
    #endregion

    #region Private var

    private float AttackDelay = 0;
    private float deadDelay = 10f;

    private bool _isAttack = false;
    public bool _isDeath = false;

    private Transform _target;
    private NavMeshAgent _agent;
    private Animator _animator;

    #endregion

    #region Unity methods

    void Awake()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
        _animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        EnemyController();
        AnimationController();
    }

    #endregion

    #region Controllers

    private void EnemyController()
    {
        if (_isDeath)
            return;

        HealthController();

        _target = FindClosestEnemy();

        if (_target != null)
        {
            if (_target.GetComponent<AIController>()._isDeath)
            {
                _target = null;
                return;
            }

            if (Vector3.Distance(transform.position, _target.position) > 2.5f)
            {
                _agent.destination = _target.position;
            }
            else
            {
                _agent.destination = transform.position;

                if (AttackDelay >= 0)
                    AttackDelay -= Time.deltaTime;
                else
                {
                    _isAttack = true;
                    AttackDelay = Random.Range(2, 6);
                }
            }
        }
        else
        {
            _agent.destination = transform.position;
        }
    }

    private void AnimationController()
    {
        if (!_isDeath)
        {
            if (!_isAttack)
            {
                if (_agent.destination == transform.position)
                {
                    _animator.SetTrigger("Idle");
                }
                else
                {
                    _animator.SetTrigger("Walk");
                }
            }
            else
            {
                _animator.SetTrigger("Attack");
                _isAttack = false;
            }
        }
        else
        {
            _animator.SetTrigger("dead");
        }
    }

    private void HealthController()
    {
        if (CurHealth <= 0)
        {
            _isDeath = true;
            CurHealth = 0;

            StartCoroutine(DeleteObj());
        }
        if (CurHealth > MaxHealth)
            CurHealth = MaxHealth;
    }

    #endregion

    #region My methods

    public void SendDamage()
    {
        if (_target != null)
            _target.gameObject.GetComponent<AIController>().GetDamage(Random.Range(MinDamage, MaxDamage));
    }

    public void GetDamage(float damage)
    {
        CurHealth -= damage;
        // to do HIT Animation
    }

    private Transform FindClosestEnemy()
    {
        var findTag = "";

        // TODO find by tag
        if (_type == TypeAI.Warrior)
            findTag = "Skelet";
        else
            findTag = "Warrior";

        GameObject[] gos = GameObject.FindGameObjectsWithTag(findTag);

        Transform closest = null;

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject go in gos)
        {
            if (!go.GetComponent<AIController>()._isDeath)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;

                if (curDistance < distance)
                {
                    closest = go.transform;
                    distance = curDistance;
                }
            }
        }

        return closest;
    }

    private IEnumerator DeleteObj()
    {
        yield return new WaitForSeconds(deadDelay);
        Destroy(gameObject);
    }

    #endregion 
}