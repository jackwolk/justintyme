using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //FRANCIS  VI

    //UI
    public HealthBarUI healthbarUI;
    public CoinCounterUI coincounterUI;
    public HealthPotionUI healthpotionUI;

    [SerializeField] int damage;

    public Rigidbody2D hitbox;

    public Health health;

    //Movement
    float walkSpeed = 3f;
    float inputX;
    float inputY;

    //Animation
    Animator _animator;
    public GameObject playerSprite;
    string currentAnimation;
    const string PLAYER_IDLE = "PlayerIdleAnim";
    const string PLAYER_RUN = "PlayerRunAnim";
    const string SWORD_ATTACK = "SwordAttack";
    const string SWORD_IDLE = "SwordIdle";

    public GameObject deathmenu;
    //Sprite
    public GameObject sprite;
    public GameObject weapon;
    Vector3 offset;
    public Data data;


    //items
    int coins;
    public GameObject admin;



    // Start is called before the first frame update
    void Start()

    {
        data = GameObject.Find("Data").GetComponent<Data>();

        coins = 0;
        health = gameObject.GetComponent<Health>();

        _animator = playerSprite.GetComponent<Animator>();

        hitbox = gameObject.GetComponent<Rigidbody2D>();
        ChangeAnimationState(PLAYER_IDLE);


        coincounterUI.SetStartingCoins(coins);
        healthbarUI.SetMaxHealth(health.maxHealth);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Instantiate(admin, gameObject.transform.position, Quaternion.identity);
        }

        if (health.currentHealth <= 0)
        {
            Time.timeScale = 0;
            deathmenu.active = true;
        }

        coins = coincounterUI.coins;
        healthbarUI.SetHealth(health.currentHealth);
        coincounterUI.displayCoins();

        offset = new Vector3(1, 0, 0);

        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        sprite.transform.position = transform.position;

        //if player hits left, player will turn left
        if (inputX > 0f)
        {
            sprite.transform.localScale = new Vector2(1f, 1f);

        }
        if (inputX < 0f)
        {
            sprite.transform.localScale = new Vector2(-1f, 1f);

        }

        if (Input.GetKeyDown(KeyCode.H) && healthpotionUI.healthPotions > 0)
        {
            healthpotionUI.healthPotions -= 1;
            health.currentHealth += 5;


        }

    }
    private void FixedUpdate()
    {


        if (inputX != 0 || inputY != 0)
        {

            ChangeAnimationState(PLAYER_RUN);

            if(inputX != 0 && inputY != 0)
            {
                //Stops increased speed when holding both horizontal and vertical buttons
                inputX *= 0.7f;
                inputY *= 0.7f;
            }
            hitbox.velocity = new Vector2(inputX * walkSpeed, inputY * walkSpeed);
        }
        else
        {
            hitbox.velocity = new Vector2(0f, 0f);
            ChangeAnimationState(PLAYER_IDLE);
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
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(stateName) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Coin(Clone)")
        {
            coincounterUI.addCoins(1);
            Destroy(collision.gameObject);
        }
    }

    private void OnDestroy()
    {
        data.health = health.currentHealth;
    }

}
