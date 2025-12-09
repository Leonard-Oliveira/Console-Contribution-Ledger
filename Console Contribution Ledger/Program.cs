Dictionary<double, (bool anonima, char tipoDeConta)> doacoes = new Dictionary<double, (bool anonima, char tipoDeConta)>();

// MAIN
Console.Write("Informe o valor da doacao " );
double doacao = ValidaValorDoacao(Console.ReadLine()!);
Console.WriteLine("Doacao confirmada com sucesso!");
doacoes.Add(doacao, default);

Console.Write("Voce quer que esta doacao seja anonima? "); 
bool doacaoAnonima = ValidaDoacaoAnonima(Console.ReadLine()!); 

Console.Write("Conta Poupanca ou Corrente? (P/C) ");
char tipoDeConta = ValidaTipoDeConta(Console.ReadLine()!); 

doacoes[doacao] = (doacaoAnonima, tipoDeConta);
MostraInfoDoacao(doacoes, doacao);

//funcoes
void MostraInfoDoacao(Dictionary<double, (bool valor1, char valor2)> doacao, double chave)
{
    if (doacoes.TryGetValue(chave, out (bool valor1, char valor2) infoDaDoacao))
    {
        string mensagem1 = infoDaDoacao.valor1 == true ? "Sim." : "Nao.";
        string mensagem2 = infoDaDoacao.valor2 == 'P' ? "Poupanca" : "Corrente";

        Console.WriteLine($"Valor da doacao: R${chave}");
        Console.WriteLine($"Doacao anonima? {mensagem1}");
        Console.WriteLine($"Tipo de Conta: {mensagem2}");
    }
};

//FUNCOES
double ValidaValorDoacao(string valorDoacao)
{
    double doacao = double.Parse(valorDoacao); 

    Console.WriteLine($"O valor da doacao esta correto: R$ {doacao}? S/N");
    string confirmacao = Console.ReadLine()!;

    while (char.ToUpper(confirmacao[0]) != 'S')
    {
        Console.WriteLine("Doacao apagada. Informe o valor novamente");
       
        doacao = double.Parse(Console.ReadLine()!);
        
        Console.WriteLine($"O valor da doacao esta correto: R$ {doacao}? S/N");
        confirmacao = Console.ReadLine()!;
    }
    return doacao;
}
bool ValidaDoacaoAnonima(string entrada)
{
    while (entrada.Length > 1 || char.ToUpper(entrada[0]) != 'N' && char.ToUpper(entrada[0]) != 'S')
    {
        Console.WriteLine("Opcao Invalida.");
        Console.WriteLine("Insira S/N para confirmar se a Doacao e anonima ");
        entrada = Console.ReadLine()!;
    }

    return !string.IsNullOrEmpty(entrada) && char.ToUpper(entrada[0]) == 'S';
}
;
char ValidaTipoDeConta(string tipoDeConta)
{
    while (tipoDeConta.Length > 1 || char.ToUpper(tipoDeConta[0]) != 'P' && char.ToUpper(tipoDeConta[0]) != 'C')
    {
        Console.WriteLine("\nOpcao invalida. Informe Novamente.");
        Console.WriteLine("Corrente = C");
        Console.WriteLine("Poupanca = P");
        tipoDeConta = Console.ReadLine()!;
    }

    if (tipoDeConta == "C")
    {
        return 'C';
    }

    return 'P';
}