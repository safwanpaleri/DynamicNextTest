using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

//The main script to be attached
public class EnemyScript : MonoBehaviour
{
    //values that can be configured by the player
    [Header("Configurations")]
    [SerializeField] public int Health = 100;
    [SerializeField] public int Damage = 10;
    [SerializeField] public NavMeshAgent navigationAgent;
    [SerializeField] private Animator animator;

    //References to UI Items
    [Space(10)]
    [Header("UI")]
    [SerializeField] private Slider HealthSlider;
    [SerializeField] private TMP_Text HealthText;
    [SerializeField] private CanvasManager canvasManager;

    //Other value references needed for codes
    private List<EnemyScript> Enemies = new List<EnemyScript>();
    [HideInInspector] public bool isDead = false;
    [HideInInspector] public bool isAttacking = false;
    [HideInInspector] public bool isTakingDamage = false;

    public bool isBlue = false;
    private EnemyScript[] currentEnemies;
    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if not dead,
        //Find all the enemies, and everyone is an enemy
        //Attack the first enemy to be spawned
        if (isDead || !isActive)
            return;

        if (canvasManager == null)
            canvasManager = FindObjectOfType<CanvasManager>();

        if (Enemies.Count > 0)
        {
            if (Enemies[0] != null && !Enemies[0].isDead)
            {
                LookAndMove(Enemies[0]);
            }
            else
                RefreshEnemies();
        }
        else
            RefreshEnemies();
    }

    public void RefreshEnemies()
    {
        Enemies.Clear();
        currentEnemies = FindObjectsOfType<EnemyScript>();
        if (isBlue)
        {
            foreach (EnemyScript enemy in currentEnemies)
            {
                if (!enemy.isBlue && enemy.isActive)
                    Enemies.Add(enemy);
            }
        }
        else
        {
            foreach (EnemyScript enemy in currentEnemies)
            {
                if (enemy.isBlue && enemy.isActive)
                    Enemies.Add(enemy);
            }
        }
    }

    //Function to move forward towards the currently selected enemy.
    public void LookAndMove(EnemyScript CurrentEnemy)
    {
        //First look at the enemy, and calculate the path way using Unity Navigation
        //And Move towards to it until it reaches the stopping distance.
        //and when reached stopping distance, start attacking the player, if we are not still recovering from the attack of other attack
        //or we are not already attacking or the enemy is not dead
        gameObject.transform.LookAt(CurrentEnemy.transform);
        float Distance = Vector3.Distance(navigationAgent.transform.position, CurrentEnemy.navigationAgent.transform.position);
        if (Distance >= navigationAgent.stoppingDistance)
        {
            navigationAgent.SetDestination(CurrentEnemy.navigationAgent.transform.position);
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
            if(!isAttacking && !CurrentEnemy.isDead &&!isTakingDamage)
            {
                StartCoroutine(Attack());
            }
        }
    }

    //Function responsible for attacking the enemy
    private IEnumerator Attack()
    {
        //there are 2 type of attack, randomly selecting one
        isAttacking = true;
        var rand = Random.Range(0f, 1f);
        if(rand > 0.5f)
        {
            animator.SetTrigger("AttackA");
        }
        else
        {
            animator.SetTrigger("AttackB");
        }
        
        //there is wait time to attack, randomizing it so the gameplay looks more dynamic
        var rand2 = Random.Range(1.0f, 2.0f);
        yield return new WaitForSeconds(rand2);
        isAttacking = false;
    }

    //Function responsible for taking damage by this gameobject.
    public void TakeDamage(int Damage, GameObject enemy)
    {
        
        StartCoroutine(TakeDamageCoroutine(Damage, enemy));
    }

    //Function which do things to do when damaged
    private IEnumerator TakeDamageCoroutine(int Damage, GameObject enemy)
    {
        //Firstly we call animation
        //Decrease the health and update the ui
        //if the health is 0 or less than 0 then calling Death Function
        //there is a small recovery time, randomizing it to look more dynamic
        animator.SetTrigger("Damage");
       
        isTakingDamage = true;
        Health -= Damage;
        HealthSlider.value = (Health / 100f);
        if(Health >= 0)
            HealthText.text = Health.ToString();
        if (Health <= 0)
            StartCoroutine(Death(enemy));
        var rand = Random.Range(1.0f, 2.0f);
        yield return new WaitForSeconds(rand);
        isTakingDamage = false;
    }

    //Function called when enemy is dead.
    private IEnumerator Death(GameObject enemy)
    {
        //calls the animation and destroy gameobject after the animation
        isDead = true;
        animator.SetTrigger("Death");

        //if the object blue update the UI and increase the score of the opposite team
        if (!isBlue)
        {
            canvasManager.CreateUI(gameObject.name, gameObject.name + " killed by " +enemy.name, "Red");
            canvasManager.CreateUI("Blue_Team", " Blue team score updated by 10 ", "Blue");
            Debug.LogWarning(enemy.name);
            Debug.LogWarning(enemy.gameObject.name);
        }
        else
        {
            canvasManager.CreateUI(gameObject.name, gameObject.name + " killed by " + enemy.name, "Blue");
            canvasManager.CreateUI("Red_Team", " Red team score updated by 10 ", "Red");
        }

        isActive = false;
        yield return new WaitForSeconds(1.5f);
        ResetGameObject();
        //Destroy(gameObject);
    }

    public void ResetGameObject()
    {
        var enemyPool = FindObjectOfType<EnemyPool>();
        if(enemyPool != null)
        {
            gameObject.transform.position = enemyPool.gameObject.transform.position;
            gameObject.transform.rotation = Quaternion.identity;
            isDead = false;
            Health = 100;
            HealthSlider.value = (Health / 100f);
        }

    }
}
