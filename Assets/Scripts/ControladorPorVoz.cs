using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class ControladorPorVoz : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float fuerzaSalto = 10f;

    private CharacterController characterController;
    private Vector3 movimiento;
    private float gravedad = -9.8f;
    private bool puedeSaltar = false;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> wordToAction;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        wordToAction = new Dictionary<string, Action>();
        wordToAction.Add("derecha", Derecha);
        wordToAction.Add("izquierda", Izquierda);
        wordToAction.Add("saltar", Saltar);

        keywordRecognizer = new KeywordRecognizer(wordToAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += WordRecognized;
        keywordRecognizer.Start();
    }

    private void Update()
    {
        // Aplica gravedad
        movimiento.y += gravedad * Time.deltaTime;

        // Mueve el personaje
        characterController.Move(movimiento * Time.deltaTime);
    }

    private void WordRecognized(PhraseRecognizedEventArgs word)
    {
        Debug.Log(word.text);
        wordToAction[word.text].Invoke();
    }

    private void Derecha()
    {
        movimiento.x = velocidadMovimiento;
    }

    private void Izquierda()
    {
        movimiento.x = -velocidadMovimiento;
    }

    private void Saltar()
    {
        if (puedeSaltar)
        {
            movimiento.y = fuerzaSalto;
            puedeSaltar = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Permite saltar cuando el personaje toca el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            puedeSaltar = true;
        }
    }
}
