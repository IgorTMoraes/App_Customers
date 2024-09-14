using System.Globalization;
using Repository;

namespace AppClients;

class Program
{
    static ClientRepository _clientRepository = new ClientRepository();

    static void Main(string[] args)
    {
        var cultura = new CultureInfo("pt-BR");
        Thread.CurrentThread.CurrentCulture = cultura;
        Thread.CurrentThread.CurrentUICulture = cultura;

        _clientRepository.LerDadosClients();

        while(true)
        {
            Menu();

            Console.ReadKey();
        }
    }

    static void Menu()
    {
        Console.Clear();

        Console.WriteLine("Cadastro de Clientes");
        Console.WriteLine("--------------------");
        Console.WriteLine("1 - Cadastrar Cliente");
        Console.WriteLine("2 - Exibir Cliente");
        Console.WriteLine("3 - Editor Cliente");
        Console.WriteLine("4 - Excluir Cliente");
        Console.WriteLine("5 - Sair");
        Console.WriteLine("--------------------");

        EscolherOpcao();
    }

    static void EscolherOpcao()
    {
        Console.Write("Escolha uma opção: ");

        var opcao = Console.ReadLine();

        switch (int.Parse(opcao))
        {
            case 1:
                {
                    _clientRepository.CadastarCliente();
                    Menu();
                    break;
                }
            case 2:
                {
                    _clientRepository.ExibirClientes();
                    Menu();
                    break;
                }
            case 3:
                {
                    _clientRepository.EditarClient();
                    Menu();
                    break;
                }
            case 4:
                {
                    _clientRepository.ExcluirClient();
                    Menu();
                    break;
                }
            case 5:
                {
                    _clientRepository.GravarDadosClients();
                    Environment.Exit(0);
                    break;
                }
            default:
                {
                    Console.Clear();
                    Console.WriteLine("Opção Inválida!");
                    break;
                }
        }
    }
}
