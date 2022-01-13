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
    {   //�������������� ���������� ��� ��������� ���������
        playerRb = GetComponent<Rigidbody>();
        //��������� ���������� ����� ������
        Physics.gravity *= gravityModifier;


        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }
        
   
    void Update()
    {

        //����� ����� ������ �� ������� � ���������� ��� ���������� �� �����
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtyParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        
    }

    //������ ��� �� ����� ���� ��� ��������� ���� �� (���������� �������)
    private void OnCollisionEnter(Collision collision)
    {   //���� ����� �������� ������� � ����� ����� �� ������ ���������� 
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtyParticle.Play();
        }//���� ����� �������� ������� � ����� ����������� �� ������ ���������� 
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
