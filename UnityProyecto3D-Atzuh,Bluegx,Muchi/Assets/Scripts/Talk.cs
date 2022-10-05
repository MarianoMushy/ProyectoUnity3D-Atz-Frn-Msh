using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Talk : MonoBehaviour
{
    private bool check;
    public GameObject DialogoBox;

    public Dialogue[] dialoguito;

    public TextMeshProUGUI nombrex;

    public TextMeshProUGUI palabrasx;

    public Image carasx;

    private int linea;

    private string currentText = "";

    private bool check2 = true;

    public float delay;

    private void Start()
    {
        linea = 0;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            check = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StopCoroutine(mostrarTexto(""));
            check = false;
            DialogoBox.SetActive(false);
            nombrex.text = "";
            palabrasx.text = "";
            DialogoBox.SetActive(false);
            linea = 0;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && check && check2 && linea < dialoguito.Length)
        {

            DialogoBox.SetActive(true);
            
            nombrex.text = dialoguito[linea].nombre;

            StartCoroutine(mostrarTexto(dialoguito[linea].palabras));

            check2 = false;
            carasx.sprite = dialoguito[linea].caras;
            linea++;
        }
        else if (Input.GetKeyDown(KeyCode.E) && check && check2 && linea >= dialoguito.Length)
        {
            nombrex.text = "";
            palabrasx.text = "";
            DialogoBox.SetActive(false);
            linea = 0;
        }
    }

    IEnumerator mostrarTexto(string textos)
    {
        for (int i = 0; i <= textos.Length; i++)
        {
            currentText = textos.Substring(0, i);
            palabrasx.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        check2 = true;
    }
}
