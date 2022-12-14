using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

//-387 é a distancia em y entre os produtos no catalogo

public class Catalogo : MonoBehaviour
{
    public List<string> produto = new List<string>();
    public List<int> estoque = new List<int>();
    public List<float> preco = new List<float>();
    public List<string> caracteristicasPricinpais = new List<string>();
    public List<string> outrasCaracteristicas = new List<string>();
    public List<string> descricao = new List<string>();
    public List<string> tagProduto = new List<string>();
    public List<bool> promocao = new List<bool>();

    public List<string> carrinhoProduto = new List<string>();
    public List<int> carrinhoQuantidade = new List<int>();
    public List<float> carrinhoValor = new List<float>();
    public List<int> carrinhoIdProduto = new List<int>();

    public List<int> ocorrenciasTexto = new List<int>();

    public GameObject[] listaProdutosCarrinho;

    public GameObject produtoRotulo0;
    public GameObject produtoRotulo1;
    public GameObject produtoRotulo2;
    public GameObject produtoRotulo3;
    public GameObject produtoRotulo4;
    public GameObject produtoRotulo5;
    public GameObject produtoAberto;
    public GameObject setaDireita;
    public GameObject setaEsquerda;
    public GameObject barraDeCompra;
    public GameObject janelaCompraEfetuada;
    public GameObject janelaEstoqueVazio;
    public GameObject janelaPerfilUsuario;
    public GameObject janelaCatalogo;
    public GameObject canvasPerfilUsuario;
    public Text nomeUsuario;
    public InputField caixaBusca;
    public GameObject caixaBusca2;
    public GameObject botaoPesquisa;

    public GameObject objetoCarrinho;
    public GameObject janelaCompraFinalizada;

    private int numeroProduto = 1;
    private int numeroImagem = 1;
    public int quantidadeCompraProduto = 1;
    private int auxMenuCatalogo = 0;
    private int auxCarrinho = 0;

    private bool auxCompraFinalizada = false;
    private bool comprou = false;
    public bool cameraParada = false;

    public string textoBusca;

    // Start is called before the first frame update
    void Start()
    {
        auxMenuCatalogo = 0;

        ocorrenciasTexto.Add(99);
        ocorrenciasTexto.Add(99);
        ocorrenciasTexto.Add(99);

        produtoRotulo0.SetActive(true);
        produtoRotulo1.SetActive(true);
        produtoRotulo2.SetActive(true);
        produtoRotulo3.SetActive(true);
        produtoRotulo4.SetActive(true);
        produtoRotulo5.SetActive(true);
        produtoAberto.SetActive(false);
        setaDireita.SetActive(false);
        setaEsquerda.SetActive(false);
        barraDeCompra.SetActive(false);
        janelaCompraEfetuada.SetActive(false);
        janelaEstoqueVazio.SetActive(false);
        janelaPerfilUsuario.SetActive(false);
        janelaCatalogo.SetActive(true);
        canvasPerfilUsuario.SetActive(false);
        objetoCarrinho.SetActive(false);
        janelaCompraFinalizada.SetActive(false);
        caixaBusca2.SetActive(true);
        botaoPesquisa.SetActive(true);



            if (!GameObject.Find("ScriptMantemInfos").GetComponent<InformacoesAManter>().jaDeslogouUmaVez)
        {
            produto.Add("Casinha Pet Steel  60x63x70cm C/ almofada Para Cachorro E Gato");
            estoque.Add(3);
            preco.Add(269.90f);
            caracteristicasPricinpais.Add("Marca: Compace\nModelo: PETCS630.CL\nTamanho da raça: Médias");
            outrasCaracteristicas.Add("Comprimento x Largura x Altura: 60 cm x 63 cm x 70 cm\nMaterial: Estrutura de Aço / Caixaria\nMDP BP Acetinado / Almofada de Tecido\nÉ térmica: Não\nForma: Casinha");
            descricao.Add("Modelo: PETCS630.CL\nCor: A Definir No Ato Da Compra\n\nA Casinha Pet Steel tem seu projeto moderno e minimalista, misturando materiais como aço, tecido e tons amadeirados garantindo a beleza deste produto na decoração do seu ambiente, aliando design e estilo para o seu Pet. Sua estrutura é fabricada em aço, com soldas suavizadas e pintura texturizada epóxi-pó, conta com pés niveladores de altura e parafusos na cor preta. Para os tampos são utilizados MDP-BP At1inado comfitas de borda em pvc, dando uma maior durabilidade ao seu móvel. A Casinha Pet Steel tem uma montagem simples e acompanha manual de instruções.\n\nItens Inclusos:\n\n01 Casinha Pet Steel c/Almofada\n\nInformações Logísticas:\n\nVOL.01: Comp: 790mm / Prof: 160mm / Alt: 620mm - Peso: 10,42 Kg\n\nObservações: Não acompanha acessórios decorativos.Imagens meramente ilustrativas.\n\nInformações Técnicas\n\n• Indicação: Cachorros e Gatos\n• Material: Estrutura de Aço / Caixaria MDP BP Acetinado / Almofada de Tecido\n• Tamanho: Médio\n• Escala de Brilho: Fosco\n• Sistema de Montagem: Parafusos\n• Complexidade da Montagem: Baixa: pode ser montado por uma pessoa sozinha\n• Garantia: 06 meses contra defeito de fabricação\n\nMedidas dos Produtos:\nCasinha: Comp: 600mm / Prof: 630mm / Alt: 700mm");
            tagProduto.Add("Cachorro Gato");
            promocao.Add(false);

            produto.Add("Ração Premium Multidog 22% Proteina Saco 15kg");
            estoque.Add(20);
            preco.Add(129.90f);
            caracteristicasPricinpais.Add("Fabricante: Nutritop\nMarca: Multidog\nLinha: Premium");
            outrasCaracteristicas.Add("Animal recomendado: Cachorro\nTamanho da raça: Grande\nSabor: Carne\nEtapa de vida do animal: Adulto\nTipo de comida: Seca");
            descricao.Add("Com Ômega 3 e 6\n\nMULTIDOG PREMIUM é um alimento completo com matérias-primas rigorosamente selecionadas e produzido com carinho, em equipamentos que conferem um excelente preparo e cozimento.\nA Nutritop produz, seu pet comprova!\n\nCOMPOSIÇÃO BÁSICA: Farinha de Vísceras de Frango, Farinha de Carne e Ossos, Milho Integral Moído*, Farelo de Trigo, Gordura Animal Estabilizada, Aditivo Palatabilizante a Base de Fígado Suíno e Fígado de Frango, Cloreto de Sódio (Sal Comum), Corante (INS 102, INS 110, INS 123), Premix Mineral e Vitamínico (Vitamina A, Vitamina D3, Vitamina B2, Vitamina E, Vitamina B12, Vitamina K3, Vitamina B1, Vitamina B6, Pantotenato de Cálcio, Cloreto de Colina, Ácido Fólico, Niacina, Sulfato de Ferro, Sulfato de Manganês, Sulfato de Zinco, Sulfato de Cobre, Iodato de Cálcio, Selenito de Sódio), Conservante Sorbato de Potássio.\n\nENRIQUECIMENTO POR KG DE PRODUTO (valores mínimos): Ácido Fólico (30mg), Ácido Pantotênico (10mg), Colina (300mg), Vitamina A (10.000UI), Vitamina B1 (2mg), Vitamina B12 (15µg), Vitamina B2 (4mg), Vitamina D3 (2.000UI), Vitamina E (15UI), Vitamina K3 (2mg), Zinco (50mg), Cobre (12mg), Ferro (80mg), Iodo (5mg), Manganês (60mg), Selênio (0,015mg).");
            tagProduto.Add("Cachorro Saude");
            promocao.Add(false);

            produto.Add("Alimento/ração Whiskas 1 + para gato adulto sabor frango em saco de 3kg");
            estoque.Add(20);
            preco.Add(54.90f);
            caracteristicasPricinpais.Add("Fabricante: Mars Petcare\nMarca: Whiskas\nNome: 1 +");
            outrasCaracteristicas.Add("Animal recomendado: Gato\nTipo de comida: Seca\nEtapa de vida do animal: Adulto\nSabor: Frango\nPeso da unidade: 3 kg");
            descricao.Add("A seleção de um alimento adequado para o seu animal de estimação é muito importante para garantir o seu crescimento, o desenvolvimento e a saúde. Com esta opção da Whiskas você poderá cobrir as necessidades nutricionais e energéticas do seu gato.\n\nSeu animal de estimação sempre saudável!\nUma alimentação balanceada é essencial para que o seu fiel companheiro se mantenha saudável e forte. A dieta do seu gato é refletida na sua pelagem, por isso é de vital importância que contenha todos os nutrientes necessários para o seu crescimento. Garanta a energia e a vitalidade do seu amigo para que ele possa correr, pular e jogar o dia todo.\n\nBenefícios do alimento seco:\nA maior vantagem do alimento seco para animais de estimação é que ele pode ser armazenado por muito mais tempo sem se deteriorar e evita o aparecimento de fungos ou bactérias. Além disso, este tipo de alimento ajuda a remover o tártaro e atrasar a formação da placa dentária com o processo de mastigação e trituração.\n\nProteína para uma nutrição completa. Alimento rico em proteína animal de alto valor biológico, contém minerais como cálcio, fósforo, potássio e ferro, vitaminas A, D e E, fibras e ácidos graxos essenciais. Estes nutrientes promovem o fortalecimento do sistema imunológico do seu animal de estimação e o bom funcionamento de seus sistemas vitais. Além disso, contribuem para a saúde da sua pelagem, pele e unhas e para a manutenção de seus tendões, músculos e ossos.");
            tagProduto.Add("Gato Saude");
            promocao.Add(false);

            produto.Add("Arranhador Gangorra para Gatos");
            estoque.Add(6);
            preco.Add(44.90f);
            caracteristicasPricinpais.Add("Marca: A Kara do Gato\nModelo: Arranhador");
            outrasCaracteristicas.Add("Tipo de brinquedo: Arranhador\nComprimento x Altura x Largura: 35 cm x 32 cm x 23 cm\nPeso: 1.5 kg");
            descricao.Add("Arranhador Mini poste com gangorra, é o produto ideal para seu gatinho arranhar. Produto em madeira de compensado naval, revestido com pelúcia anti-alérgica de primeira linha , sisal e juta natural. Possui um design diferenciado, moderno e elegante. Permite ao gato brincar e arranhar com a gangorra se movendo para cima e para baixo, deixando a brincadeira ainda mais atrativa.");
            tagProduto.Add("Gato");
            promocao.Add(false);

            produto.Add("Gaiola Hamster Roedores 3 Andares Com Teto Completa");
            estoque.Add(3);
            preco.Add(185.90f);
            caracteristicasPricinpais.Add("Marca: DISTRIBUIPET\nModelo: Kit Para Gaiola Criadeira");
            outrasCaracteristicas.Add("Função: Bebedouro/Comedouro\nEspécies de aves recomendadas: Calopsita. agapornis. canários. periquitos. diamante de gould. pássaros\nMaterial: Plástico\nQuantidade de unidades: 3\nAltura x Comprimento x Largura: 5 cm x 7 cm x 7 cm\nÉ kit: Sim");
            descricao.Add("Excelente Gaiola 3 Andares Para Hamster Ornamental\n\nInformações do produto:\nGaiola para Hamster e Roedores Teto Plástico com 3 Andares.\nIndicada para hamster topolino, anão russo, chines, sírio e outros roedores.\nFabricada em material aramado com pintura epoxi de excelente acabamento e resistência.\nAcompanha 1 casinha e 2 roda de exercícios com diâmetro de 14 cm para manter a atividade física do seu pet em dia.\nTudo que seu roedor precisa está neste habitat.\n\nItens inclusos:\n01 Gaiola Aramado\n01 Gancho Teto\n01 Teto Plástico\n01 Bandeja\n02 Rodinha para exercícios com 14 cm de diâmetro\n01 Casinha\n03 Escadinhas\n03 Andares\n04 Cintas p/ fixar o teto\n\nDimensões do produto:\nAltura: 44 cm\nLargura: 23 cm\nComprimento: 30 cm\nMalha entre vão de 0,9 mm\n\nFácil Limpeza e Higienização!");
            tagProduto.Add("Outros");
            promocao.Add(false);

            produto.Add("Comedouro Agapornis Calopsita Bebedouro Banheira Passaros");
            estoque.Add(12);
            preco.Add(26.90f);
            caracteristicasPricinpais.Add("Marca: Vetnil\nLinha: Vetnil\nModelo: Gotas");
            outrasCaracteristicas.Add("Formato do suplemento: Líquido\nUnidades por kit: 1\nVolume líquido: 30 mL");
            descricao.Add("Kit Comedouro Bebedouro Banheira Passaros P/ Gaiola Viveiro Criadeira\n\nNESTE KIT:\n2 COMEDOURO ABA SBIA\n1 BEBEDOURO ITALIANO 300ML MALHA FINA OU MALHA LARGA\n1 BANHEIRA PLÁSTICA PASSAROS TAMANHO MÉDIO (A COR PODE VARIAR ENTRE CRISTAL OU BRANCO)\n\nCaracterísticas:\nComedouro Aba Sabia Para Ração e Água.\nBebedouro Italiano 300ml\nBanheira plástica média.\nUtilizar em gaiolas criadeiras e viveiros.\nFeito em plástico resistente.\nSuporte alça para pendurar no aramado da gaiola ou viveiro.\n\nDimensões:\nComprimento: 7 cm\nLargura: 7 cm\nAltura: 5 cm\n\nCapacidade de 190 ml\n\nItens inclusos:\n03 Comedouro Aba Sabia\n01 Bebedouro Italiano 300ml\n01 Banheira média\n\nOBSERVAÇÃO: Cores Sortidas");
            tagProduto.Add("Outros Saude");
            promocao.Add(false);
        }
        else
        {
            produto = GameObject.Find("ScriptMantemInfos").GetComponent<InformacoesAManter>().produto;
            estoque = GameObject.Find("ScriptMantemInfos").GetComponent<InformacoesAManter>().estoque;
            preco = GameObject.Find("ScriptMantemInfos").GetComponent<InformacoesAManter>().preco;
            caracteristicasPricinpais = GameObject.Find("ScriptMantemInfos").GetComponent<InformacoesAManter>().caracteristicasPricinpais;
            outrasCaracteristicas = GameObject.Find("ScriptMantemInfos").GetComponent<InformacoesAManter>().outrasCaracteristicas;
            descricao = GameObject.Find("ScriptMantemInfos").GetComponent<InformacoesAManter>().descricao;
        }

        produtoRotulo0.GetComponentInChildren<Text>().text = produto[0] + "\n\nEstoque: " + estoque[0] + "\n\nPreço: " + preco[0] + "0";
        produtoRotulo0.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-1", typeof(Sprite));
        numeroProduto++;

        produtoRotulo1.GetComponentInChildren<Text>().text = produto[1] + "\n\nEstoque: " + estoque[1] + "\n\nPreço: " + preco[1] + "0";
        produtoRotulo1.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-1", typeof(Sprite));
        numeroProduto++;

        produtoRotulo2.GetComponentInChildren<Text>().text = produto[2] + "\n\nEstoque: " + estoque[2] + "\n\nPreço: " + preco[2] + "0";
        produtoRotulo2.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-1", typeof(Sprite));
        numeroProduto++;

        produtoRotulo3.GetComponentInChildren<Text>().text = produto[3] + "\n\nEstoque: " + estoque[3] + "\n\nPreço: " + preco[3] + "0";
        produtoRotulo3.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-1", typeof(Sprite));
        numeroProduto++;

        produtoRotulo4.GetComponentInChildren<Text>().text = produto[4] + "\n\nEstoque: " + estoque[4] + "\n\nPreço: " + preco[4] + "0";
        produtoRotulo4.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-1", typeof(Sprite));
        numeroProduto++;

        produtoRotulo5.GetComponentInChildren<Text>().text = produto[5] + "\n\nEstoque: " + estoque[5] + "\n\nPreço: " + preco[5] + "0";
        produtoRotulo5.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-1", typeof(Sprite));

        nomeUsuario.text = GameObject.Find("Objeto para Scripts").GetComponent<Login_Transfer>().userName.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            produtoAberto.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-" + numeroImagem, typeof(Sprite));
            barraDeCompra.GetComponentInChildren<Text>().text = quantidadeCompraProduto.ToString();

            if (comprou)
            {
                produtoAberto.GetComponentInChildren<Text>().text = produto[numeroProduto - 1] + "\n\nEstoque: " + estoque[numeroProduto - 1] + "\n\nPreço: " + preco[numeroProduto - 1] + "0" + "\n\n" + caracteristicasPricinpais[numeroProduto - 1] + "\n\n" + outrasCaracteristicas[numeroProduto - 1] + "\n\n" + descricao[numeroProduto - 1];
            }
        }
    }

    public void ClicaProduto0()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo) 
        {
            produtoRotulo0.SetActive(false);
            produtoRotulo1.SetActive(false);
            produtoRotulo2.SetActive(false);
            produtoRotulo3.SetActive(false);
            produtoRotulo4.SetActive(false);
            produtoRotulo5.SetActive(false);
            produtoAberto.SetActive(true);
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(true);
            barraDeCompra.SetActive(true);
            caixaBusca2.SetActive(true);
            botaoPesquisa.SetActive(true);

            if (auxMenuCatalogo == 1) numeroProduto = 1;
            else if (auxMenuCatalogo == 2) numeroProduto = 1;
            else if (auxMenuCatalogo == 3) numeroProduto = 5;
            else if (auxMenuCatalogo == 4) numeroProduto = 2;
            else numeroProduto = 1;
            if (ocorrenciasTexto[0] == 0) numeroProduto = 1;
            else if (ocorrenciasTexto[0] == 1) numeroProduto = 2;
            else if (ocorrenciasTexto[0] == 2) numeroProduto = 3;
            else if (ocorrenciasTexto[0] == 3) numeroProduto = 4;
            else if (ocorrenciasTexto[0] == 4) numeroProduto = 5;
            else if (ocorrenciasTexto[0] == 5) numeroProduto = 6;

            produtoAberto.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-" + numeroImagem, typeof(Sprite));
            produtoAberto.GetComponentInChildren<Text>().text = produto[numeroProduto - 1] + "\n\nEstoque: " + estoque[numeroProduto - 1] + "\n\nPreço: " + preco[numeroProduto - 1] + "0" + "\n\n" + caracteristicasPricinpais[numeroProduto - 1] + "\n\n" + outrasCaracteristicas[numeroProduto - 1] + "\n\n" + descricao[numeroProduto - 1];
            barraDeCompra.GetComponentInChildren<Text>().text = quantidadeCompraProduto.ToString();

            auxMenuCatalogo = 0;
            ocorrenciasTexto.Clear();
            ocorrenciasTexto.Add(99);
            ocorrenciasTexto.Add(99);
            ocorrenciasTexto.Add(99);
        }
    }

    public void ClicaProduto1()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            produtoRotulo0.SetActive(false);
            produtoRotulo1.SetActive(false);
            produtoRotulo2.SetActive(false);
            produtoRotulo3.SetActive(false);
            produtoRotulo4.SetActive(false);
            produtoRotulo5.SetActive(false);
            produtoAberto.SetActive(true);
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(true);
            barraDeCompra.SetActive(true);
            caixaBusca2.SetActive(true);
            botaoPesquisa.SetActive(true);

            if (auxMenuCatalogo == 1) numeroProduto = 2;
            else if (auxMenuCatalogo == 2) numeroProduto = 3;
            else if (auxMenuCatalogo == 3) numeroProduto = 6;
            else if (auxMenuCatalogo == 4) numeroProduto = 3;
            else numeroProduto = 2;
            if (ocorrenciasTexto[1] == 1) numeroProduto = 2;
            else if (ocorrenciasTexto[1] == 2) numeroProduto = 3;
            else if (ocorrenciasTexto[1] == 3) numeroProduto = 4;
            else if (ocorrenciasTexto[1] == 4) numeroProduto = 5;
            else if (ocorrenciasTexto[1] == 5) numeroProduto = 6;

            produtoAberto.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-1", typeof(Sprite));
            produtoAberto.GetComponentInChildren<Text>().text = produto[numeroProduto - 1] + "\n\nEstoque: " + estoque[numeroProduto - 1] + "\n\nPreço: " + preco[numeroProduto - 1] + "0" + "\n\n" + caracteristicasPricinpais[numeroProduto - 1] + "\n\n" + outrasCaracteristicas[numeroProduto - 1] + "\n\n" + descricao[numeroProduto - 1];
            barraDeCompra.GetComponentInChildren<Text>().text = quantidadeCompraProduto.ToString();

            auxMenuCatalogo = 0;
            ocorrenciasTexto.Clear();
            ocorrenciasTexto.Add(99);
            ocorrenciasTexto.Add(99);
            ocorrenciasTexto.Add(99);
        }
    }

    public void ClicaProduto2()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            produtoRotulo0.SetActive(false);
            produtoRotulo1.SetActive(false);
            produtoRotulo2.SetActive(false);
            produtoRotulo3.SetActive(false);
            produtoRotulo4.SetActive(false);
            produtoRotulo5.SetActive(false);
            produtoAberto.SetActive(true);
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(true);
            barraDeCompra.SetActive(true);
            caixaBusca2.SetActive(true);
            botaoPesquisa.SetActive(true);

            if (auxMenuCatalogo == 2) numeroProduto = 4;
            else if (auxMenuCatalogo == 4) numeroProduto = 6;
            else numeroProduto = 3;
            if (ocorrenciasTexto[2] == 2) numeroProduto = 3;
            else if (ocorrenciasTexto[2] == 3) numeroProduto = 4;
            else if (ocorrenciasTexto[2] == 4) numeroProduto = 5;
            else if (ocorrenciasTexto[2] == 5) numeroProduto = 6;

            produtoAberto.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-1", typeof(Sprite));
            produtoAberto.GetComponentInChildren<Text>().text = produto[numeroProduto - 1] + "\n\nEstoque: " + estoque[numeroProduto - 1] + "\n\nPreço: " + preco[numeroProduto - 1] + "0" + "\n\n" + caracteristicasPricinpais[numeroProduto - 1] + "\n\n" + outrasCaracteristicas[numeroProduto - 1] + "\n\n" + descricao[numeroProduto - 1];
            barraDeCompra.GetComponentInChildren<Text>().text = quantidadeCompraProduto.ToString();

            auxMenuCatalogo = 0;
            ocorrenciasTexto.Clear();
            ocorrenciasTexto.Add(99);
            ocorrenciasTexto.Add(99);
            ocorrenciasTexto.Add(99);
        }
    }

    public void ClicaProduto3()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            produtoRotulo0.SetActive(false);
            produtoRotulo1.SetActive(false);
            produtoRotulo2.SetActive(false);
            produtoRotulo3.SetActive(false);
            produtoRotulo4.SetActive(false);
            produtoRotulo5.SetActive(false);
            produtoAberto.SetActive(true);
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(true);
            barraDeCompra.SetActive(true);
            caixaBusca2.SetActive(true);
            botaoPesquisa.SetActive(true);

            numeroProduto = 4;

            produtoAberto.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-1", typeof(Sprite));
            produtoAberto.GetComponentInChildren<Text>().text = produto[numeroProduto - 1] + "\n\nEstoque: " + estoque[numeroProduto - 1] + "\n\nPreço: " + preco[numeroProduto - 1] + "0" + "\n\n" + caracteristicasPricinpais[numeroProduto - 1] + "\n\n" + outrasCaracteristicas[numeroProduto - 1] + "\n\n" + descricao[numeroProduto - 1];
            barraDeCompra.GetComponentInChildren<Text>().text = quantidadeCompraProduto.ToString();

            ocorrenciasTexto.Clear();
            ocorrenciasTexto.Add(99);
            ocorrenciasTexto.Add(99);
            ocorrenciasTexto.Add(99);
        }
    }

    public void ClicaProduto4()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            produtoRotulo0.SetActive(false);
            produtoRotulo1.SetActive(false);
            produtoRotulo2.SetActive(false);
            produtoRotulo3.SetActive(false);
            produtoRotulo4.SetActive(false);
            produtoRotulo5.SetActive(false);
            produtoAberto.SetActive(true);
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(true);
            barraDeCompra.SetActive(true);
            caixaBusca2.SetActive(true);
            botaoPesquisa.SetActive(true);

            numeroProduto = 5;

            produtoAberto.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-1", typeof(Sprite));
            produtoAberto.GetComponentInChildren<Text>().text = produto[numeroProduto - 1] + "\n\nEstoque: " + estoque[numeroProduto - 1] + "\n\nPreço: " + preco[numeroProduto - 1] + "0" + "\n\n" + caracteristicasPricinpais[numeroProduto - 1] + "\n\n" + outrasCaracteristicas[numeroProduto - 1] + "\n\n" + descricao[numeroProduto - 1];
            barraDeCompra.GetComponentInChildren<Text>().text = quantidadeCompraProduto.ToString();

            ocorrenciasTexto.Clear();
            ocorrenciasTexto.Add(99);
            ocorrenciasTexto.Add(99);
            ocorrenciasTexto.Add(99);
        }
    }

    public void ClicaProduto5()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            produtoRotulo0.SetActive(false);
            produtoRotulo1.SetActive(false);
            produtoRotulo2.SetActive(false);
            produtoRotulo3.SetActive(false);
            produtoRotulo4.SetActive(false);
            produtoRotulo5.SetActive(false);
            produtoAberto.SetActive(true);
            setaDireita.SetActive(true);
            setaEsquerda.SetActive(true);
            barraDeCompra.SetActive(true);
            caixaBusca2.SetActive(true);
            botaoPesquisa.SetActive(true);

            numeroProduto = 6;

            produtoAberto.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-1", typeof(Sprite));
            produtoAberto.GetComponentInChildren<Text>().text = produto[numeroProduto - 1] + "\n\nEstoque: " + estoque[numeroProduto - 1] + "\n\nPreço: " + preco[numeroProduto - 1] + "0" + "\n\n" + caracteristicasPricinpais[numeroProduto - 1] + "\n\n" + outrasCaracteristicas[numeroProduto - 1] + "\n\n" + descricao[numeroProduto - 1];
            barraDeCompra.GetComponentInChildren<Text>().text = quantidadeCompraProduto.ToString();

            ocorrenciasTexto.Clear();
            ocorrenciasTexto.Add(99);
            ocorrenciasTexto.Add(99);
            ocorrenciasTexto.Add(99);
        }
    }

    public void PassarImagem()
    {
        if (numeroProduto == 1 || numeroProduto == 2)
        {
            if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
            {
                numeroImagem += 1;
                if (numeroImagem > 3) numeroImagem = 3;
            }
        }

        else if (numeroProduto == 4)
        {
            if(!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
            {
                numeroImagem += 1;
                if (numeroImagem > 2) numeroImagem = 2;
            }
        }

        else if (numeroProduto == 5)
        {
            if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
            {
                numeroImagem += 1;
                if (numeroImagem > 4) numeroImagem = 4;
            }
        }
        
    }

    public void VoltarImagem()
    {
            if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
            {
                numeroImagem -= 1;
                if (numeroImagem == 0) numeroImagem = 1;
            }
    }

    public void AdicionaProduto()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            quantidadeCompraProduto += 1;
            if (quantidadeCompraProduto > estoque[numeroProduto - 1]) quantidadeCompraProduto = estoque[numeroProduto - 1];
            if (estoque[numeroProduto - 1] == 0) quantidadeCompraProduto = 0;
        }
    }

    public void SubtraiProduto()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            quantidadeCompraProduto -= 1;
            if (quantidadeCompraProduto < 1) quantidadeCompraProduto = 1;
            if (estoque[numeroProduto - 1] == 0) quantidadeCompraProduto = 0;
        }
    }

    public void Comprar()
    {
        if (estoque[numeroProduto - 1] > 0 && quantidadeCompraProduto <= estoque[numeroProduto - 1])
        {
            estoque[numeroProduto - 1] -= quantidadeCompraProduto;
            janelaCompraEfetuada.SetActive(true);
            comprou = true;

            carrinhoProduto.Add(produto[numeroProduto - 1]);
            carrinhoQuantidade.Add(quantidadeCompraProduto);
            carrinhoValor.Add(preco[numeroProduto - 1] * quantidadeCompraProduto);
            carrinhoIdProduto.Add(numeroProduto - 1);
        }
        else
        {
            janelaEstoqueVazio.SetActive(true);
        }
    }

    public void confirmaVisualizacaoDaJanelaCompraEfetuada()
    {
        janelaCompraEfetuada.SetActive(false);
        janelaEstoqueVazio.SetActive(false);
    }

    public void AbrePerfilUsuario()
    {
        ocorrenciasTexto.Clear();
        ocorrenciasTexto.Add(99);
        ocorrenciasTexto.Add(99);
        ocorrenciasTexto.Add(99);

        janelaPerfilUsuario.SetActive(true);
        canvasPerfilUsuario.SetActive(true);
        janelaCatalogo.SetActive(false);
        produtoRotulo0.SetActive(false);
        produtoRotulo1.SetActive(false);
        produtoRotulo2.SetActive(false);
        produtoRotulo3.SetActive(false);
        produtoRotulo4.SetActive(false);
        produtoRotulo5.SetActive(false);
        setaDireita.SetActive(false);
        setaEsquerda.SetActive(false);
        barraDeCompra.SetActive(false);
        janelaCompraEfetuada.SetActive(false);
        janelaEstoqueVazio.SetActive(false);
        produtoAberto.SetActive(false);
        objetoCarrinho.SetActive(false);
        caixaBusca2.SetActive(false);
        botaoPesquisa.SetActive(false);

        cameraParada = true;
        canvasPerfilUsuario.GetComponentInChildren<Text>().text = GameObject.Find("Objeto para Scripts").GetComponent<Login_Transfer>().userName.ToString();
    }

    public void BotaoSair()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            if (carrinhoQuantidade.Count > 0)
            {
                for (int i = 0; i < carrinhoQuantidade.Count; i++)
                {
                    estoque[carrinhoIdProduto[i]] += carrinhoQuantidade[i];
                }
            }

            carrinhoProduto.Clear();
            carrinhoQuantidade.Clear();
            carrinhoValor.Clear();
            carrinhoIdProduto.Clear();

            GameObject.Find("ScriptMantemInfos").GetComponent<InformacoesAManter>().jaDeslogouUmaVez = true;
            GameObject.Find("ScriptMantemInfos").GetComponent<InformacoesAManter>().salvaDados();
            SceneManager.LoadScene("Cena Login");
        }
    }

    public void AbreCarrinho()
    {
        objetoCarrinho.SetActive(true);

        if (auxCarrinho == 0)
        {
            listaProdutosCarrinho = GameObject.FindGameObjectsWithTag("CanvasProdutoCarrinho");
            auxCarrinho = 1;
        }

        for (int i = 0; i < listaProdutosCarrinho.Length; i++)
        {
            listaProdutosCarrinho[i].SetActive(false);
        }

        if (carrinhoProduto.Count > 0)
        {
            for (int i = 0; i < carrinhoProduto.Count; i++)
            {
                listaProdutosCarrinho[i].SetActive(true);

                listaProdutosCarrinho[i].GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load((carrinhoIdProduto[i]+1) + "-1", typeof(Sprite));
                GameObject.Find("TextProduto" + i).GetComponent<Text>().text = carrinhoProduto[i];
                GameObject.Find("TextQuantidade" + i).GetComponent<Text>().text = "Qtd.: " + carrinhoQuantidade[i].ToString();
                GameObject.Find("TextValor" + i).GetComponent<Text>().text = "Valor: \n" + carrinhoValor[i].ToString();
            }  
        }
    }

    public void BotaoX0()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            listaProdutosCarrinho[0].SetActive(false);

            estoque[carrinhoIdProduto[0]] += carrinhoQuantidade[0];

            carrinhoProduto[0] = "";
            carrinhoQuantidade[0] = 0;
            carrinhoValor[0] = 0.0f;
            carrinhoIdProduto[0] = 0;
        }      
    }

    public void BotaoX1()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            listaProdutosCarrinho[1].SetActive(false);

            estoque[carrinhoIdProduto[1]] += carrinhoQuantidade[1];

            carrinhoProduto[1] = "";
            carrinhoQuantidade[1] = 0;
            carrinhoValor[1] = 0.0f;
            carrinhoIdProduto[1] = 0;
        }
    }

    public void BotaoX2()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            listaProdutosCarrinho[2].SetActive(false);

            estoque[carrinhoIdProduto[2]] += carrinhoQuantidade[2];

            carrinhoProduto[2] = "";
            carrinhoQuantidade[2] = 0;
            carrinhoValor[2] = 0.0f;
            carrinhoIdProduto[2] = 0;
        }
    }

    public void BotaoX3()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            listaProdutosCarrinho[3].SetActive(false);

            estoque[carrinhoIdProduto[3]] += carrinhoQuantidade[3];

            carrinhoProduto[3] = "";
            carrinhoQuantidade[3] = 0;
            carrinhoValor[3] = 0.0f;
            carrinhoIdProduto[3] = 0;
        }
    }

    public void BotaoX4()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            listaProdutosCarrinho[4].SetActive(false);

            estoque[carrinhoIdProduto[4]] += carrinhoQuantidade[4];

            carrinhoProduto[4] = "";
            carrinhoQuantidade[4] = 0;
            carrinhoValor[4] = 0.0f;
            carrinhoIdProduto[4] = 0;
        }
    }

    public void BotaoX5()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            listaProdutosCarrinho[5].SetActive(false);

            estoque[carrinhoIdProduto[5]] += carrinhoQuantidade[5];

            carrinhoProduto[5] = "";
            carrinhoQuantidade[5] = 0;
            carrinhoValor[5] = 0.0f;
            carrinhoIdProduto[5] = 0;
        }
    }

    public void BotaoX6()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            listaProdutosCarrinho[6].SetActive(false);

            estoque[carrinhoIdProduto[6]] += carrinhoQuantidade[6];

            carrinhoProduto[6] = "";
            carrinhoQuantidade[6] = 0;
            carrinhoValor[6] = 0.0f;
            carrinhoIdProduto[6] = 0;
        } 
    }

    public void BotaoX7()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            listaProdutosCarrinho[7].SetActive(false);

            estoque[carrinhoIdProduto[7]] += carrinhoQuantidade[7];

            carrinhoProduto[7] = "";
            carrinhoQuantidade[7] = 0;
            carrinhoValor[7] = 0.0f;
            carrinhoIdProduto[7] = 0;
        } 
    }

    public void BotaoX8()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            listaProdutosCarrinho[8].SetActive(false);

            estoque[carrinhoIdProduto[8]] += carrinhoQuantidade[8];

            carrinhoProduto[8] = "";
            carrinhoQuantidade[8] = 0;
            carrinhoValor[8] = 0.0f;
            carrinhoIdProduto[8] = 0;
        }
    }

    public void BotaoX9()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            listaProdutosCarrinho[9].SetActive(false);

            estoque[carrinhoIdProduto[9]] += carrinhoQuantidade[9];

            carrinhoProduto[9] = "";
            carrinhoQuantidade[9] = 0;
            carrinhoValor[9] = 0.0f;
            carrinhoIdProduto[9] = 0;
        } 
    }

    public void BotaoX10()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            listaProdutosCarrinho[10].SetActive(false);

            estoque[carrinhoIdProduto[10]] += carrinhoQuantidade[10];

            carrinhoProduto[10] = "";
            carrinhoQuantidade[10] = 0;
            carrinhoValor[10] = 0.0f;
            carrinhoIdProduto[10] = 0;
        } 
    }

    public void BotaoLimpar()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            for (int i = 0; i < listaProdutosCarrinho.Length; i++)
            {
                listaProdutosCarrinho[i].SetActive(false);
            }

            if (carrinhoQuantidade.Count > 0)
            {
                for (int i = 0; i < carrinhoQuantidade.Count; i++)
                {
                    estoque[carrinhoIdProduto[i]] += carrinhoQuantidade[i];
                }
            }

            carrinhoProduto.Clear();
            carrinhoQuantidade.Clear();
            carrinhoValor.Clear();
            carrinhoIdProduto.Clear();
        }
    }

    public void BotaoFinalizar()
    {
        if (!GameObject.Find("Menu aberto").GetComponent<Menu>().menuAtivo)
        {
            if (!auxCompraFinalizada)
            {
                if (carrinhoQuantidade.Count > 0)
                {
                    janelaCompraFinalizada.SetActive(true);
                    auxCompraFinalizada = true;

                    for (int i = 0; i < listaProdutosCarrinho.Length; i++)
                    {
                        listaProdutosCarrinho[i].SetActive(false);
                    }

                    carrinhoProduto.Clear();
                    carrinhoQuantidade.Clear();
                    carrinhoValor.Clear();
                    carrinhoIdProduto.Clear();
                }

                else
                {
                    janelaCompraFinalizada.GetComponentInChildren<Text>().text = "Carrinho vazio. Impossível finalizar.";
                    janelaCompraFinalizada.SetActive(true);
                    auxCompraFinalizada = true;
                }
            }
            else
            {
                janelaCompraFinalizada.SetActive(false);
                auxCompraFinalizada = false;
                janelaCompraFinalizada.GetComponentInChildren<Text>().text = "Redirecionando para a página de pagamento.";
            }
        }
    }

    public void menuCatalogoCachorro()
    {
        auxMenuCatalogo = 1;
        cameraParada = false;
        ocorrenciasTexto.Clear();
        ocorrenciasTexto.Add(99);
        ocorrenciasTexto.Add(99);
        ocorrenciasTexto.Add(99);

        janelaCatalogo.SetActive(true);
        produtoRotulo0.SetActive(true);
        produtoRotulo1.SetActive(true);
        produtoRotulo2.SetActive(false);
        produtoRotulo3.SetActive(false);
        produtoRotulo4.SetActive(false);
        produtoRotulo5.SetActive(false);
        produtoAberto.SetActive(false);
        setaDireita.SetActive(false);
        setaEsquerda.SetActive(false);
        barraDeCompra.SetActive(false);
        janelaCompraEfetuada.SetActive(false);
        janelaEstoqueVazio.SetActive(false);
        janelaPerfilUsuario.SetActive(false);
        canvasPerfilUsuario.SetActive(false);
        objetoCarrinho.SetActive(false);
        janelaCompraFinalizada.SetActive(false);
        caixaBusca2.SetActive(true);
        botaoPesquisa.SetActive(true);

        produtoRotulo0.GetComponentInChildren<Text>().text = produto[0] + "\n\nEstoque: " + estoque[0] + "\n\nPreço: " + preco[0] + "0";
        produtoRotulo0.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("1-1", typeof(Sprite));

        produtoRotulo1.GetComponentInChildren<Text>().text = produto[1] + "\n\nEstoque: " + estoque[1] + "\n\nPreço: " + preco[1] + "0";
        produtoRotulo1.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("2-1", typeof(Sprite));
    }

    public void menuCatalogoGato()
    {
        auxMenuCatalogo = 2;
        cameraParada = false;
        ocorrenciasTexto.Clear();
        ocorrenciasTexto.Add(99);
        ocorrenciasTexto.Add(99);
        ocorrenciasTexto.Add(99);

        janelaCatalogo.SetActive(true);
        produtoRotulo0.SetActive(true);
        produtoRotulo1.SetActive(true);
        produtoRotulo2.SetActive(true);
        produtoRotulo3.SetActive(false);
        produtoRotulo4.SetActive(false);
        produtoRotulo5.SetActive(false);
        produtoAberto.SetActive(false);
        setaDireita.SetActive(false);
        setaEsquerda.SetActive(false);
        barraDeCompra.SetActive(false);
        janelaCompraEfetuada.SetActive(false);
        janelaEstoqueVazio.SetActive(false);
        janelaPerfilUsuario.SetActive(false);
        canvasPerfilUsuario.SetActive(false);
        objetoCarrinho.SetActive(false);
        janelaCompraFinalizada.SetActive(false);
        caixaBusca2.SetActive(true);
        botaoPesquisa.SetActive(true);

        produtoRotulo0.GetComponentInChildren<Text>().text = produto[0] + "\n\nEstoque: " + estoque[0] + "\n\nPreço: " + preco[0] + "0";
        produtoRotulo0.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("1-1", typeof(Sprite));

        produtoRotulo1.GetComponentInChildren<Text>().text = produto[2] + "\n\nEstoque: " + estoque[2] + "\n\nPreço: " + preco[2] + "0";
        produtoRotulo1.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("3-1", typeof(Sprite));

        produtoRotulo2.GetComponentInChildren<Text>().text = produto[3] + "\n\nEstoque: " + estoque[3] + "\n\nPreço: " + preco[3] + "0";
        produtoRotulo2.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("4-1", typeof(Sprite));
    }

    public void menuCatalogoOutros()
    {
        auxMenuCatalogo = 3;
        cameraParada = false;
        ocorrenciasTexto.Clear();
        ocorrenciasTexto.Add(99);
        ocorrenciasTexto.Add(99);
        ocorrenciasTexto.Add(99);

        janelaCatalogo.SetActive(true);
        produtoRotulo0.SetActive(true);
        produtoRotulo1.SetActive(true);
        produtoRotulo2.SetActive(false);
        produtoRotulo3.SetActive(false);
        produtoRotulo4.SetActive(false);
        produtoRotulo5.SetActive(false);
        produtoAberto.SetActive(false);
        setaDireita.SetActive(false);
        setaEsquerda.SetActive(false);
        barraDeCompra.SetActive(false);
        janelaCompraEfetuada.SetActive(false);
        janelaEstoqueVazio.SetActive(false);
        janelaPerfilUsuario.SetActive(false);
        canvasPerfilUsuario.SetActive(false);
        objetoCarrinho.SetActive(false);
        janelaCompraFinalizada.SetActive(false);
        caixaBusca2.SetActive(true);
        botaoPesquisa.SetActive(true);

        produtoRotulo0.GetComponentInChildren<Text>().text = produto[4] + "\n\nEstoque: " + estoque[4] + "\n\nPreço: " + preco[4] + "0";
        produtoRotulo0.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("5-1", typeof(Sprite));

        produtoRotulo1.GetComponentInChildren<Text>().text = produto[5] + "\n\nEstoque: " + estoque[5] + "\n\nPreço: " + preco[5] + "0";
        produtoRotulo1.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("6-1", typeof(Sprite));
    }

    public void menuCatalogoSaude()
    {
        auxMenuCatalogo = 4;
        cameraParada = false;
        ocorrenciasTexto.Clear();
        ocorrenciasTexto.Add(99);
        ocorrenciasTexto.Add(99);
        ocorrenciasTexto.Add(99);

        janelaCatalogo.SetActive(true);
        produtoRotulo0.SetActive(true);
        produtoRotulo1.SetActive(true);
        produtoRotulo2.SetActive(true);
        produtoRotulo3.SetActive(false);
        produtoRotulo4.SetActive(false);
        produtoRotulo5.SetActive(false);
        produtoAberto.SetActive(false);
        setaDireita.SetActive(false);
        setaEsquerda.SetActive(false);
        barraDeCompra.SetActive(false);
        janelaCompraEfetuada.SetActive(false);
        janelaEstoqueVazio.SetActive(false);
        janelaPerfilUsuario.SetActive(false);
        canvasPerfilUsuario.SetActive(false);
        objetoCarrinho.SetActive(false);
        janelaCompraFinalizada.SetActive(false);
        caixaBusca2.SetActive(true);
        botaoPesquisa.SetActive(true);

        produtoRotulo0.GetComponentInChildren<Text>().text = produto[1] + "\n\nEstoque: " + estoque[1] + "\n\nPreço: " + preco[1] + "0";
        produtoRotulo0.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("2-1", typeof(Sprite));

        produtoRotulo1.GetComponentInChildren<Text>().text = produto[2] + "\n\nEstoque: " + estoque[2] + "\n\nPreço: " + preco[2] + "0";
        produtoRotulo1.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("3-1", typeof(Sprite));

        produtoRotulo2.GetComponentInChildren<Text>().text = produto[5] + "\n\nEstoque: " + estoque[5] + "\n\nPreço: " + preco[5] + "0";
        produtoRotulo2.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load("6-1", typeof(Sprite));
    }

    public void botaoPromocoes()
    {
        auxMenuCatalogo = 0;
        cameraParada = false;
        ocorrenciasTexto.Clear();
        ocorrenciasTexto.Add(99);
        ocorrenciasTexto.Add(99);
        ocorrenciasTexto.Add(99);

        produtoRotulo0.SetActive(true);
        produtoRotulo1.SetActive(true);
        produtoRotulo2.SetActive(true);
        produtoRotulo3.SetActive(true);
        produtoRotulo4.SetActive(true);
        produtoRotulo5.SetActive(true);
        produtoAberto.SetActive(false);
        setaDireita.SetActive(false);
        setaEsquerda.SetActive(false);
        barraDeCompra.SetActive(false);
        janelaCompraEfetuada.SetActive(false);
        janelaEstoqueVazio.SetActive(false);
        janelaPerfilUsuario.SetActive(false);
        janelaCatalogo.SetActive(true);
        canvasPerfilUsuario.SetActive(false);
        objetoCarrinho.SetActive(false);
        janelaCompraFinalizada.SetActive(false);
        caixaBusca2.SetActive(true);
        botaoPesquisa.SetActive(true);

        numeroProduto = 1;

        produtoRotulo0.GetComponentInChildren<Text>().text = produto[0] + "\n\nEstoque: " + estoque[0] + "\n\nPreço: " + preco[0] + "0";
        produtoRotulo0.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-1", typeof(Sprite));
        numeroProduto++;

        produtoRotulo1.GetComponentInChildren<Text>().text = produto[1] + "\n\nEstoque: " + estoque[1] + "\n\nPreço: " + preco[1] + "0";
        produtoRotulo1.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-1", typeof(Sprite));
        numeroProduto++;

        produtoRotulo2.GetComponentInChildren<Text>().text = produto[2] + "\n\nEstoque: " + estoque[2] + "\n\nPreço: " + preco[2] + "0";
        produtoRotulo2.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-1", typeof(Sprite));
        numeroProduto++;

        produtoRotulo3.GetComponentInChildren<Text>().text = produto[3] + "\n\nEstoque: " + estoque[3] + "\n\nPreço: " + preco[3] + "0";
        produtoRotulo3.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-1", typeof(Sprite));
        numeroProduto++;

        produtoRotulo4.GetComponentInChildren<Text>().text = produto[4] + "\n\nEstoque: " + estoque[4] + "\n\nPreço: " + preco[4] + "0";
        produtoRotulo4.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-1", typeof(Sprite));
        numeroProduto++;

        produtoRotulo5.GetComponentInChildren<Text>().text = produto[5] + "\n\nEstoque: " + estoque[5] + "\n\nPreço: " + preco[5] + "0";
        produtoRotulo5.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(numeroProduto + "-1", typeof(Sprite));

        nomeUsuario.text = GameObject.Find("Objeto para Scripts").GetComponent<Login_Transfer>().userName.ToString();
    }

    public void pesquisa()
    {
        textoBusca = caixaBusca.text;

        textoBusca = textoBusca.ToLower();

        if (textoBusca == "cachorro" || textoBusca == "cão" || textoBusca == "cao" || textoBusca == "cachorros" || textoBusca == "cães" || textoBusca == "caes") menuCatalogoCachorro();
        else if (textoBusca == "gato" || textoBusca == "gatos") menuCatalogoGato();
        else if (textoBusca == "saude" || textoBusca == "bem estar" || textoBusca == "saude e bem estar" || textoBusca == "saúde" || textoBusca == "saúde e bem estar" || textoBusca == "saude bem estar" || textoBusca == "saúde bem estar" || textoBusca == "saude estar" || textoBusca == "saúde estar") menuCatalogoSaude();
        else if (textoBusca.Length > 3)
        {
            bool verificaString = false;
            int contaOcorrencias = 0;

            ocorrenciasTexto.Clear();

            for (int i=0; i<6; i++)
            {
                string textoVerificar = produto[i];
                textoVerificar = textoVerificar.ToLower();
                verificaString = textoVerificar.Contains(textoBusca);

                if (verificaString)
                {
                    ocorrenciasTexto.Add(i);
                    verificaString = false;
                    contaOcorrencias += 1;
                }
            }

            if (contaOcorrencias == 1)
            {
                cameraParada = false;

                janelaCatalogo.SetActive(true);
                produtoRotulo0.SetActive(true);
                produtoRotulo1.SetActive(false);
                produtoRotulo2.SetActive(false);
                produtoRotulo3.SetActive(false);
                produtoRotulo4.SetActive(false);
                produtoRotulo5.SetActive(false);
                produtoAberto.SetActive(false);
                setaDireita.SetActive(false);
                setaEsquerda.SetActive(false);
                barraDeCompra.SetActive(false);
                janelaCompraEfetuada.SetActive(false);
                janelaEstoqueVazio.SetActive(false);
                janelaPerfilUsuario.SetActive(false);
                canvasPerfilUsuario.SetActive(false);
                objetoCarrinho.SetActive(false);
                janelaCompraFinalizada.SetActive(false);
                caixaBusca2.SetActive(true);
                botaoPesquisa.SetActive(true);

                produtoRotulo0.GetComponentInChildren<Text>().text = produto[ocorrenciasTexto[0]] + "\n\nEstoque: " + estoque[ocorrenciasTexto[0]] + "\n\nPreço: " + preco[ocorrenciasTexto[0]] + "0";
                produtoRotulo0.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load((ocorrenciasTexto[0]+1).ToString()+"-1", typeof(Sprite));

                contaOcorrencias = 0;
            }

            else if (contaOcorrencias == 2)
            {
                cameraParada = false;

                janelaCatalogo.SetActive(true);
                produtoRotulo0.SetActive(true);
                produtoRotulo1.SetActive(true);
                produtoRotulo2.SetActive(false);
                produtoRotulo3.SetActive(false);
                produtoRotulo4.SetActive(false);
                produtoRotulo5.SetActive(false);
                produtoAberto.SetActive(false);
                setaDireita.SetActive(false);
                setaEsquerda.SetActive(false);
                barraDeCompra.SetActive(false);
                janelaCompraEfetuada.SetActive(false);
                janelaEstoqueVazio.SetActive(false);
                janelaPerfilUsuario.SetActive(false);
                canvasPerfilUsuario.SetActive(false);
                objetoCarrinho.SetActive(false);
                janelaCompraFinalizada.SetActive(false);
                caixaBusca2.SetActive(true);
                botaoPesquisa.SetActive(true);

                produtoRotulo0.GetComponentInChildren<Text>().text = produto[ocorrenciasTexto[0]] + "\n\nEstoque: " + estoque[ocorrenciasTexto[0]] + "\n\nPreço: " + preco[ocorrenciasTexto[0]] + "0";
                produtoRotulo0.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load((ocorrenciasTexto[0] + 1).ToString() + "-1", typeof(Sprite));

                produtoRotulo1.GetComponentInChildren<Text>().text = produto[ocorrenciasTexto[1]] + "\n\nEstoque: " + estoque[ocorrenciasTexto[1]] + "\n\nPreço: " + preco[ocorrenciasTexto[1]] + "0";
                produtoRotulo1.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load((ocorrenciasTexto[1] + 1).ToString() + "-1", typeof(Sprite));

                contaOcorrencias = 0;
            }

            else if (contaOcorrencias == 3)
            {
                cameraParada = false;

                janelaCatalogo.SetActive(true);
                produtoRotulo0.SetActive(true);
                produtoRotulo1.SetActive(true);
                produtoRotulo2.SetActive(true);
                produtoRotulo3.SetActive(false);
                produtoRotulo4.SetActive(false);
                produtoRotulo5.SetActive(false);
                produtoAberto.SetActive(false);
                setaDireita.SetActive(false);
                setaEsquerda.SetActive(false);
                barraDeCompra.SetActive(false);
                janelaCompraEfetuada.SetActive(false);
                janelaEstoqueVazio.SetActive(false);
                janelaPerfilUsuario.SetActive(false);
                canvasPerfilUsuario.SetActive(false);
                objetoCarrinho.SetActive(false);
                janelaCompraFinalizada.SetActive(false);
                caixaBusca2.SetActive(true);
                botaoPesquisa.SetActive(true);

                produtoRotulo0.GetComponentInChildren<Text>().text = produto[ocorrenciasTexto[0]] + "\n\nEstoque: " + estoque[ocorrenciasTexto[0]] + "\n\nPreço: " + preco[ocorrenciasTexto[0]] + "0";
                produtoRotulo0.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load((ocorrenciasTexto[0] + 1).ToString() + "-1", typeof(Sprite));

                produtoRotulo1.GetComponentInChildren<Text>().text = produto[ocorrenciasTexto[1]] + "\n\nEstoque: " + estoque[ocorrenciasTexto[1]] + "\n\nPreço: " + preco[ocorrenciasTexto[1]] + "0";
                produtoRotulo1.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load((ocorrenciasTexto[1] + 1).ToString() + "-1", typeof(Sprite));

                produtoRotulo2.GetComponentInChildren<Text>().text = produto[ocorrenciasTexto[2]] + "\n\nEstoque: " + estoque[ocorrenciasTexto[2]] + "\n\nPreço: " + preco[ocorrenciasTexto[2]] + "0";
                produtoRotulo2.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load((ocorrenciasTexto[2] + 1).ToString() + "-1", typeof(Sprite));

                contaOcorrencias = 0;
            }

            else
            {
                cameraParada = false;

                janelaCatalogo.SetActive(true);
                produtoRotulo0.SetActive(false);
                produtoRotulo1.SetActive(false);
                produtoRotulo2.SetActive(false);
                produtoRotulo3.SetActive(false);
                produtoRotulo4.SetActive(false);
                produtoRotulo5.SetActive(false);
                produtoAberto.SetActive(false);
                setaDireita.SetActive(false);
                setaEsquerda.SetActive(false);
                barraDeCompra.SetActive(false);
                janelaCompraEfetuada.SetActive(false);
                janelaEstoqueVazio.SetActive(false);
                janelaPerfilUsuario.SetActive(false);
                canvasPerfilUsuario.SetActive(false);
                objetoCarrinho.SetActive(false);
                janelaCompraFinalizada.SetActive(false);
                caixaBusca2.SetActive(true);
                botaoPesquisa.SetActive(true);
            }

        }

        else
        {
            cameraParada = false;

            janelaCatalogo.SetActive(true);
            produtoRotulo0.SetActive(false);
            produtoRotulo1.SetActive(false);
            produtoRotulo2.SetActive(false);
            produtoRotulo3.SetActive(false);
            produtoRotulo4.SetActive(false);
            produtoRotulo5.SetActive(false);
            produtoAberto.SetActive(false);
            setaDireita.SetActive(false);
            setaEsquerda.SetActive(false);
            barraDeCompra.SetActive(false);
            janelaCompraEfetuada.SetActive(false);
            janelaEstoqueVazio.SetActive(false);
            janelaPerfilUsuario.SetActive(false);
            canvasPerfilUsuario.SetActive(false);
            objetoCarrinho.SetActive(false);
            janelaCompraFinalizada.SetActive(false);
            caixaBusca2.SetActive(true);
            botaoPesquisa.SetActive(true);
        }
    }
}
