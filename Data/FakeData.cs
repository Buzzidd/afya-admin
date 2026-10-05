namespace afya_admin.Data;

public class Kpi
{
    public string Titulo { get; set; } = string.Empty;
    public string Valor { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    public double[] DadosGrafico { get; set; } = Array.Empty();
}

public class Projeto
{
    public string Nome { get; set; } = string.Empty;
    public string Responsavel { get; set; } = string.Empty;
    public int Progresso { get; set; }
    public string Status { get; set; } = string.Empty;
}

public class Atividade
{
    public string Descricao { get; set; } = string.Empty;
    public string Tempo { get; set; } = string.Empty;
}

public static class DadosFicticios
{
    public static List ObterKpis() => new()
    {
        new Kpi { Titulo = "Total de Alunos", Valor = "1.250", Cor = "mud-theme-primary", DadosGrafico = new double[] { 10, 20, 15, 30, 45 } },
        new Kpi { Titulo = "Novas Matrículas", Valor = "120", Cor = "mud-theme-success", DadosGrafico = new double[] { 5, 10, 8, 15, 20 } },
        new Kpi { Titulo = "Taxa de Evasão", Valor = "3%", Cor = "mud-theme-error", DadosGrafico = new double[] { 5, 4, 3, 3, 2 } },
        new Kpi { Titulo = "Receita", Valor = "R$ 450k", Cor = "mud-theme-warning", DadosGrafico = new double[] { 200, 250, 300, 400, 450 } }
    };

    public static List ObterProjetos() => new()
    {
        new Projeto { Nome = "Atualização do Portal", Responsavel = "Carlos", Progresso = 75, Status = "Em Andamento" },
        new Projeto { Nome = "Migração de Servidor", Responsavel = "Ana", Progresso = 100, Status = "Concluído" },
        new Projeto { Nome = "Novo App Mobile", Responsavel = "João", Progresso = 30, Status = "Em Andamento" }
    };

    public static List ObterAtividades() => new()
    {
        new Atividade { Descricao = "Carlos fez login no sistema", Tempo = "Há 5 min" },
        new Atividade { Descricao = "Relatório mensal gerado", Tempo = "Há 1 hora" },
        new Atividade { Descricao = "Nova turma adicionada", Tempo = "Há 2 horas" }
    };
}