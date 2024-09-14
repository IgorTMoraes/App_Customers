using Registration;

namespace Repository;

public class ClientRepository
{
    public List<Client> clients = new List<Client>();

    public void GravarDadosClients()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(clients);

        File.WriteAllText("clients.txt", json);
    }

    public void LerDadosClients()
    {
        if(File.Exists("clientes.txt"))
        {
            var dados = File.ReadAllText("clientes.txt");

            var clientsArquivo = System.Text.Json.JsonSerializer.Deserialize<List<Client>>(dados);

            clients.AddRange(clientsArquivo);
        }
    }

    public void ExcluirClient()
    {
        Console.Clear();
        Console.Write("Informe o código do cliente: ");
        var codigo = Console.ReadLine();

        var client = clients.FirstOrDefault(p => p.id == int.Parse(codigo));

        if(client == null)
        {
            Console.WriteLine("Cliente não encontrado! [Enter]");
            Console.ReadKey();
            return;
        }

        ImprimirClient(client);

        clients.Remove(client);

        Console.WriteLine("Cliente cadastro com sucesso! [ Enter]");
        
        Console.ReadKey();
    }

    public void EditarClient()
    {
        Console.Clear();
        Console.Write("Informe o código do cliente: ");
        var codigo = Console.ReadLine();

        var client = clients.FirstOrDefault(p => p.id == int.Parse(codigo));

        if(client == null)
        {
            Console.WriteLine("Cliente não encontrado! [Enter]");
            Console.ReadKey();
            return;
        }

        ImprimirClient(client);

        Console.Write("Nome do Cliente: ");
        var nome = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Data de nacimento: ");
        var dataNacimento = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        Console.Write("Desconto: ");
        var desconto = decimal.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        client.nome = nome;
        client.dataNacimento = dataNacimento;
        client.desconto = desconto;
        client.cadastradoEm = DateTime.Now;

        Console.WriteLine("Cliente cadastro com sucesso! [ Enter]");
        ImprimirClient(client);
        Console.ReadKey();
    }

    public void CadastarCliente()
    {
        Console.Clear();

        Console.Write("Nome do Cliente: ");
        var nome = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Data de nacimento: ");
        var dataNacimento = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        Console.Write("Desconto: ");
        var desconto = decimal.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        var client = new Client();
        client.id = clients.Count + 1;
        client.nome = nome;
        client.dataNacimento = dataNacimento;
        client.desconto = desconto;
        client.cadastradoEm = DateTime.Now;

        clients.Add(client);

        Console.WriteLine("Cliente cadastro com sucesso! [ Enter]");
        ImprimirClient(client);
        Console.ReadKey();
    }

    public void ImprimirClient(Client client)
    {
        Console.WriteLine("ID.............:" + client.id);
        Console.WriteLine("Nome...........:" + client.nome);
        Console.WriteLine("Desconto.......:" + client.desconto.ToString("0.00"));
        Console.WriteLine("Data Nascimento:" + client.dataNacimento);
        Console.WriteLine("Data Cadastro..:" + client.cadastradoEm);
        Console.WriteLine("-----------------------------------");
    }

    public void ExibirClientes()
    {
        Console.Clear();
        foreach (var client in clients)
        {
            ImprimirClient(client);
        }

        Console.ReadKey();
    }
}