namespace SimuladorApp;

public class EmprestimoService
{
    private static readonly Random _random = new();
    private static readonly Dictionary<string, decimal> _niveisEmprestimo = new()
    {
        { "Bronze", 200000 },
        { "Prata", 400000 },
        { "Ouro", 600000 },
        { "Diamante", 1000000 }
    };

    public static EmprestimoResponse SimularEmprestimo(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentNullException(nameof(nome), "O nome deve ser informado.");
        }

        bool possuiRestricao = _random.Next(2) == 0;
        var nivel = _niveisEmprestimo.Keys.ElementAt(_random.Next(_niveisEmprestimo.Count));
        var valor = _niveisEmprestimo[nivel];

        return new EmprestimoResponse
        {
            Nome = nome,
            EmprestimoAprovado = !possuiRestricao,
            Nivel = nivel,
            Valor = !possuiRestricao ? valor : 0
        };
    }
}

public class EmprestimoResponse
{
    public string Nome { get; set; }
    public bool EmprestimoAprovado { get; set; }
    public string Nivel { get; set; }
    public decimal Valor { get; set; }
}


