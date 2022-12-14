using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cadastro : MonoBehaviour
{
    public List<string> email = new List<string>();
    public List<string> userName = new List<string>();
    public List<string> password = new List<string>();
    public InputField inputFieldEmail;
    public InputField inputFieldUserName;
    public InputField inputFieldPassword;

    public GameObject[] cadastros;

    private void Start()
    {
        email.Add("email@teste.com.br");
        userName.Add("Marcony");
        password.Add("123456");

        if (GameObject.Find("Dados Cadastrados") != null)
        {
            email = GameObject.Find("Dados Cadastrados").GetComponent<Cadastro>().email;
            userName = GameObject.Find("Dados Cadastrados").GetComponent<Cadastro>().userName;
            password = GameObject.Find("Dados Cadastrados").GetComponent<Cadastro>().password;
        }

        cadastros = GameObject.FindGameObjectsWithTag("Cadastro");

        if (cadastros.Length > 1)
        {
            Destroy(cadastros[0]);
        }
    }

        public void StoreDatas()
    {
        email.Add(inputFieldEmail.text);
        userName.Add(inputFieldUserName.text);
        password.Add(inputFieldPassword.text);

        //textDisplay.GetComponent<Text>().text = "Usuário cadastrado.";

        SceneManager.LoadScene("Cena Login");
        DontDestroyOnLoad(this.gameObject);
    }
}
