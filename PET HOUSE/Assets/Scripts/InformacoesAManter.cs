using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformacoesAManter : MonoBehaviour
{
    public List<string> produto = new List<string>();
    public List<int> estoque = new List<int>();
    public List<float> preco = new List<float>();
    public List<string> caracteristicasPricinpais = new List<string>();
    public List<string> outrasCaracteristicas = new List<string>();
    public List<string> descricao = new List<string>();

    public bool jaDeslogouUmaVez = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void salvaDados()
    {
        produto = GameObject.Find("ScriptCatalogo").GetComponent<Catalogo>().produto;
        estoque = GameObject.Find("ScriptCatalogo").GetComponent<Catalogo>().estoque;
        preco = GameObject.Find("ScriptCatalogo").GetComponent<Catalogo>().preco;
        caracteristicasPricinpais = GameObject.Find("ScriptCatalogo").GetComponent<Catalogo>().caracteristicasPricinpais;
        outrasCaracteristicas = GameObject.Find("ScriptCatalogo").GetComponent<Catalogo>().outrasCaracteristicas;
        descricao = GameObject.Find("ScriptCatalogo").GetComponent<Catalogo>().descricao;
    }
}
