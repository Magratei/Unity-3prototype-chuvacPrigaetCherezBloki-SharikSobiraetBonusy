using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explorationParticle;
    public ParticleSystem dirtyParticle;
    public AudioClip jumpSound;
    public AudioClip crushSound;

    public float jumpForce;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;
    



    void Start()
    {   //инициализируем переменную под компонент ригидбоди
        playerRb = GetComponent<Rigidbody>();
        //усиливаем гравитацию через скрипт
        Physics.gravity *= gravityModifier;


        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }
        
   
    void Update()
    {

        //когда нажат пробел мы прыгаем и показываем что оторвались от земли
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtyParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        
    }

    //делаем что то после того как коснулись чего то (встроенная функция)
    private void OnCollisionEnter(Collision collision)
    {   //если игрок коснулся обьекта с тегом земля мы меняем переменную 
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtyParticle.Play();
        }//если игрок коснулся обьекта с тегом препятствие мы меняем переменную 
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explorationParticle.Play();
            dirtyParticle.Stop();
            playerAudio.PlayOneShot(crushSound, 1.0f);
        }

    }
}
