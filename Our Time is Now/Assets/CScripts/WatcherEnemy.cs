using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WatcherEnemy : MonoBehaviour
{

    //Movement
    [SerializeField] float moveSpeed = 7f;
    Rigidbody2D rb;
    [SerializeField] Transform player;
    Vector2 moveDirection;
    public PlayerInRange isPlayerInRange;
    Vector2 stationary = new Vector2(0, 0);


    //Health + Damage
    [SerializeField] int health;
    [SerializeField] int damage;
    [SerializeField] float knockbackStrength;

    //Animation
    Animator _animator;
    string currentAnimation;
    const string WATCHER_IDLE = "Idle";
    const string WATCHER_MOVEMENT = "Movement";
    const string WATCHER_DEATH = "Death";
    const string WATCHER_DAMAGE = "Damage";
    const string WATCHER_OPEN = "EyeOpen";
    const string WATCHER_CLOSE = "EyeClose";
    const string WATCHER_DETECTION = "Detection";


    //Detection
    float timer = 15;
    bool doOnce = true;
    [SerializeField] Collider2D _collider;
    public Transform circleOrigin;
    public float radius;



    public UnityEvent OnBegin, OnDone;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _collider.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;


        ChangeAnimationState(WATCHER_IDLE);
    }


    IEnumerator openEye()
    {
        yield return new WaitForSeconds(timer);

        _animator.Play(WATCHER_OPEN);
        doOnce = true;
        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {

        if(player)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            
            moveDirection = direction;
        }

        
        if(doOnce == true)
        {
            doOnce = false;
            StartCoroutine(openEye());
        }

        if(isAnimationPlaying(_animator, WATCHER_DETECTION))
        {
            _collider.enabled = true;
        }
        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName(WATCHER_MOVEMENT))
        {
            _collider.enabled = true;
        }
        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName(WATCHER_DAMAGE))
        {
            _collider.enabled = true;
        }
        else
        {
            _collider.enabled = false;
        }

        if(_animator.GetCurrentAnimatorStateInfo(0).IsName(WATCHER_MOVEMENT) && isPlayerInRange.canSeePlayer == false)
        {
            ChangeAnimationState(WATCHER_CLOSE);
        }

    }

    private void FixedUpdate()
    {
        if(isPlayerInRange.canSeePlayer == true)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
            _animator.SetBool("IsSeen", true);




        }
        else
        {
            rb.velocity = stationary;
            
        }

    }

    private void ChangeAnimationState(string newState)
    {
        if (newState == currentAnimation)
        {
            return;
        }

        _animator.Play(newState);
        currentAnimation = newState;

    }

    bool isAnimationPlaying(Animator animator, string stateName)
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName(stateName) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            Health health;
            health = collider.GetComponent<Health>();
            if (collider.GetComponent<PlayerMovement>() != null)
            {
                health.GetHit(1, transform.parent.gameObject);
            }
        }
    }


}
