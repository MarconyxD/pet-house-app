using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login_Transfer : MonoBehaviour
{
    public string email;
    public string userName;
    public string password;
    public InputField inputFieldUserName;
    public InputField inputFieldPassword;
    public GameObject textDisplay;

    string userNameTeste = "Marcony";
    string passwordTeste = "123456";

    public GameObject[] loginTransfers;

    public void Start()
    {
        loginTransfers = GameObject.FindGameObjectsWithTag("Logins");

        if (loginTransfers.Length > 1)
        {
            Destroy(loginTransfers[0]);
        }
    }

    public void GoToCadastro()
    {
        SceneManager.LoadScene("Cena Cadastro");
    }

    public void GoToApp()
    {
        userName = inputFieldUserName.text;
        password = inputFieldPassword.text;

        int aux = 0;
        GameObject dados = GameObject.Find("Dados Cadastrados");
        if (dados != null)
        {
            for (int i = 0; i < dados.GetComponent<Cadastro>().userName.Count; i++)
            {
                if (dados.GetComponent<Cadastro>().userName[i] == userName && dados.GetComponent<Cadastro>().password[i] == password)
                {
                    aux = 1;
                    email = dados.GetComponent<Cadastro>().email[i];
                    SceneManager.LoadScene("Cena Aplicacao");
                    DontDestroyOnLoad(this.gameObject);
                }
            }
            if (aux == 0)
                textDisplay.GetComponent<Text>().text = "Login ou senha incorreto.";
        }

        else
        {
            if (userNameTeste == userName && passwordTeste == password)
            {
                email = "email@teste.com.br";
                SceneManager.LoadScene("Cena Aplicacao");
                DontDestroyOnLoad(this.gameObject);
            }
            else textDisplay.GetComponent<Text>().text = "Login ou senha incorreto.";
        }
    }
}
