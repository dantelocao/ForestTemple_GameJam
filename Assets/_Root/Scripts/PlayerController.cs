using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public GameObject pausePanel;

    public AudioSource audioSource;  // O AudioSource que voc� configurou no personagem
    public AudioClip[] footstepClips;  // Array para armazenar diferentes sons de passos

    public CharacterController controller;
    public Transform cameraTransform;
    public float speed; // Velocidade do personagem
    public float gravity = -9.81f;
    private bool isRunning = false;

    private Vector3 velocity; // Armazena a velocidade para controle da gravidade
    private bool isGrounded;

    // Altura m�nima de detec��o do ch�o (definir um raio para verificar contato)
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    // Vari�veis para controle da rota��o da c�mera com o mouse
    public float mouseSensitivity;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        PlayerController();
    }

    public void PlayerController()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Controla a rota��o vertical da c�mera (olhar para cima/baixo)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limita o olhar para n�o virar 360 graus verticalmente

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotaciona o personagem no eixo Y (esquerda/direita) com base no movimento do mouse
        transform.Rotate(Vector3.up * mouseX);

        // Verifica se o personagem est� no ch�o
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Debug.Log(isGrounded);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Manter o personagem preso ao ch�o
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        CheckIfItsRunning();

        // Dire��o do movimento baseada na orienta��o do personagem (n�o diretamente da c�mera)
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //PlayFootstepSound(move);

        // Aplica a gravidade ao personagem
        velocity.y += gravity * Time.deltaTime;

        // Aplica o movimento vertical (queda ou salto)
        controller.Move(velocity * Time.deltaTime);

    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void CheckIfItsRunning()
    {
        if (isRunning == false)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed += 2;
                isRunning = true;
            }
        }
        else
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                speed -= 2;
                isRunning = false;
            }
        }
    }

    private void PlayFootstepSound(Vector3 move)
    {
        // Toca o som apenas se o personagem estiver no ch�o e se movendo
        if (move.magnitude > 0.1f)
        {
            if (!audioSource.isPlaying)
            {
                // Seleciona um som de passo aleat�rio
                int randomIndex = UnityEngine.Random.Range(0, footstepClips.Length);
                audioSource.clip = footstepClips[randomIndex];
                audioSource.Play();
            }
        }
        else
        {
            // Para o som se o personagem parar de se mover
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

}