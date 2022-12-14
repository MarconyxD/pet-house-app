using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    bool aparece = false;
    bool esconde = false;
    bool apareceMenuCatalogo = false;
    bool escondeMenuCatalogo = false;
    public bool menuAtivo = false;

    public GameObject botaoMenu;
    public GameObject espacoVazio1;
    public GameObject espacoVazio2;
    public GameObject espacoVazio3;
    public GameObject menuCatalogo;
    public GameObject botaoMenuCatalogo;
    public GameObject scriptCatalogo;
    public GameObject botaoCatalogoCachorro;
    public GameObject botaoCatalogoGato;
    public GameObject botaoCatalogoOutros;
    public GameObject botaoCatalogoSaude;
    public GameObject botaoPromocoes1;
    public GameObject botaoPromocoes2;

    void Start()
    {
        botaoMenu.SetActive(true);
        espacoVazio1.SetActive(false);
        espacoVazio2.SetActive(false);
        espacoVazio3.SetActive(false);
        menuCatalogo.SetActive(false);
        botaoMenuCatalogo.SetActive(false);
        botaoCatalogoCachorro.SetActive(false);
        botaoCatalogoGato.SetActive(false);
        botaoCatalogoOutros.SetActive(false);
        botaoCatalogoSaude.SetActive(false);
        botaoPromocoes1.SetActive(false);
        botaoPromocoes2.SetActive(false);
    }

    void Update()
    {
        if (aparece && transform.position.x < -63.0f)
        {
            transform.position += new Vector3(Time.deltaTime * 1000.0f, 0.0f, 0.0f);
            menuAtivo = true;
        }

        if (aparece && transform.position.x > -63.0f)
        {
            aparece = false;
            botaoMenu.SetActive(false);
            espacoVazio1.SetActive(true);
            espacoVazio2.SetActive(true);
            espacoVazio3.SetActive(true);
            botaoMenuCatalogo.SetActive(true);
            botaoPromocoes1.SetActive(true);
        }

        if (esconde && transform.position.x > -708.0f)
        {
            transform.position += new Vector3(-Time.deltaTime * 1000.0f, 0.0f, 0.0f);
            botaoPromocoes1.SetActive(false);
            botaoPromocoes2.SetActive(false);
        }

        if (esconde && transform.position.x < -708.0f)
        {
            esconde = false;
            botaoMenu.SetActive(true);
            espacoVazio1.SetActive(false);
            espacoVazio2.SetActive(false);
            espacoVazio3.SetActive(false);
            botaoMenuCatalogo.SetActive(false);
            botaoPromocoes1.SetActive(false);
            menuAtivo = false;
        }

        if (apareceMenuCatalogo)
        {
            menuCatalogo.SetActive(true);
            transform.position += new Vector3(-Time.deltaTime * 1000.0f, 0.0f, 0.0f);
            apareceMenuCatalogo = false;
            botaoCatalogoCachorro.SetActive(true);
            botaoCatalogoGato.SetActive(true);
            botaoCatalogoOutros.SetActive(true);
            botaoCatalogoSaude.SetActive(true);
            botaoPromocoes1.SetActive(false);
            botaoPromocoes2.SetActive(true);
        }

        if (escondeMenuCatalogo)
        {
            menuCatalogo.SetActive(false);
            transform.position += new Vector3(Time.deltaTime * 1000.0f, 0.0f, 0.0f);
            escondeMenuCatalogo = false;
            botaoCatalogoCachorro.SetActive(false);
            botaoCatalogoGato.SetActive(false);
            botaoCatalogoOutros.SetActive(false);
            botaoCatalogoSaude.SetActive(false);
            botaoPromocoes1.SetActive(true);
            botaoPromocoes2.SetActive(false);
        }
    }

    public void ApareceMenu()
    {
        aparece = true;
    }

    public void EscondeMenu()
    {
        esconde = true;
        EscondeMenuCatalogo();
    }

    public void ApareceMenuCatalogo()
    {
        if (!menuCatalogo.activeSelf) apareceMenuCatalogo = true;
    }

    public void EscondeMenuCatalogo()
    {
        if (menuCatalogo.activeSelf) escondeMenuCatalogo = true;
    }
}
