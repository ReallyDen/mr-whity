using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript2D : MonoBehaviour
{
    private Rigidbody2D rb;                 // упоминаем рижит бади в скрипт чтобы потом взаимодействовать с ним
    private float HorizontalMove = 0f;      // ну типа то что ты идешь вродь по горизонтали
    private bool FacingRight = true;        // По дефолту смотришь направо


    public Joystick joystick; // Туда надо закинуть жойстик в иерархии лол

    [Header("Player Movement Settings")]
    [Range(0, 10f)] public float speed = 1f;       // устонавливаем скорость в иерархии        (в скобках предел от 0 до 10, можно поменять) 
    public float maxspeed = 10f;
    [Range(0, 15f)] public float jumpForce = 8f;   // устонавливаем силу прыжка в иерархии     (в скобках предел от 0 до 15, можно поменять) 

    [Header("Player Animation Settings")]
    public Animator animator;               // в иерархии кидаем анимацию

    [Space]
    [Header("Ground Checker Settings")]
    public bool isGrounded = false;
    [Range(-5f, 5f)] public float checkGroundOffsetY = -1.8f;       // хуйня для регулировки ис граундед. Там потыкать нужно, чтобы оно чекало
    [Range(0, 5f)] public float checkGroundRadius = 0.3f;           // радиус чекания
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // добавляем нашему игроку рижит бади
        maxspeed = Mathf.Max(maxspeed, speed*10f); // макс скорость не должна быть меньше скорости чтобы не замедлять вайти.. 
    }
   

    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space) && Time.timeScale > 0)     // если ис граундед и нажимаешь на спейс и время больше 0, то
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);               // Прыгаем
        }

        #if !UNITY_ANDROID
        HorizontalMove = Input.GetAxisRaw("Horizontal") * speed; // расслабуха :cool:
        #else
        HorizontalMove = joystick.Horizontal * speed;
        #endif
        animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));      // анимация при прыжке

        if (isGrounded == false)    // если ис граундед тру
        {
            animator.SetBool("Jumping", true);  // Анимация джампинг (название) тру
        }
        else                         // иначе
        {
            animator.SetBool("Jumping", false); // Анимация Джампинг фолс
        }
        if (HorizontalMove < 0 && FacingRight)   // Если Хоризонталмув меньше 0 и Смотришь направо
        {
            Flip();                             // поворот
        }
        else if (HorizontalMove > 0 && !FacingRight)  // если ХоризонталМув больше 0 и не смотришь направо
        {
            Flip();                             // поворот
        }
    }
    private void FixedUpdate()
    {

        CheckGround();       // проверка пола

        Vector2 targetVelocity = new Vector2(HorizontalMove * 10f, rb.velocity.y);
        rb.velocity = Vector2.ClampMagnitude(targetVelocity, maxspeed); // ха лимит скорости жесть
    }

    public void OnJumpButtonDown()     // кнопка для прыжка на телефон (сука не забыдь поставить на нон чтобы срабатывало при нажатии, а не отжатии) 
    {
        if (isGrounded && Time.timeScale > 0) //если граундед и время больше 0
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse); //прыгай
        }
    }

    private void Flip()                  // собственно сам поворот
    {
        FacingRight = !FacingRight;      // Смотри направо равно несмори направо

        Vector3 theScale = transform.localScale;     // задаем вектор 3 с названием зе скейл и то, что он будет изменять фурму локальную (ток персонажа, а не всего всего на свете)
        theScale.x *= -1;                           // размер по иксу (ака ширина) умножается на -1 и поворачивается
        transform.localScale = theScale;             // 
    }
    private void CheckGround()       // собственно проверка пола
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY), checkGroundRadius);   // ебашим коллайдер

        if (colliders.Length > 1) // если коллайдер длинна больше 1
        {
            isGrounded = true;   // на земле тру
        }
        else                      // иначе
        {
            isGrounded = false;   // фолс
        }
    }


    private void OnTriggerEnter2D(Collider2D other)  // эт кастыль для респавна, наверн переделаю
    {
        if (other.tag == "Respawn")    // если дотрагивается до штуки с тегом респавн то
        {
            SceneManager.LoadScene(9);  // загружать сцену 9
            Time.timeScale = 1f;        // время на 1
        }

        if (other.tag == "Respawn1")     // тут все также, ток сцена 10
        {
            SceneManager.LoadScene(10);   // вообще я тупой и мог сделать паблик инт скене и тупо в инспекторе ставить любую сцену, а не делать по 500 одинаковых строк
            Time.timeScale = 1f;
        }


    }


}
