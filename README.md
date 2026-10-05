# Afya Admin — Dashboard com Blazor WebAssembly e MudBlazor

## Identificação

|                      |                                                       |
| -------------------- | ----------------------------------------------------- |
| **Aluno(a)**         | Carlos Vitor (COMPLETAR com nome completo)            |
| **Faculdade**        | Centro Universitário São Lucas                        |
| **Curso/Disciplina** | Ciência da Computação - Programação para sistemas web |
| **Professor(a)**     | Liluyoud Cury de Lacerda                              |
| **Semestre**         | 4º Semestre                                           |

## Objetivo do projeto

O objetivo do projeto é entender como funciona um esqueleto do dashboard, e como podemos usar o mudblazor de uma forma pratica. A ideia que o professor quis passar, foi criar uma interface parecida com um sistema administrativo do AFYA, utilizando cards, graficos, tabelas... etc.

## Tecnologias utilizadas

- .NET 10 / Blazor WebAssembly
- MudBlazor 9
- Git e GitHub para versionamento
- Visual Studio Code

## Como executar

Requisito: **.NET SDK 10**.

```bash
git clone https://github.com/Buzzidd/afya-admin.git
cd afya-admin
dotnet watch
```

A aplicação abre em `http://localhost:5137`.

## Telas

### Tema claro

![Dashboard — tema claro](docs/prints/tema-claro.png)

### Tema escuro

![Dashboard — tema escuro](docs/prints/tema-escuro.png)

### Versão mobile

![Dashboard — celular](docs/prints/mobile.png)

### HTML gerado (DevTools)

![Inspeção do HTML no DevTools](docs/prints/devtools.png)

No print eu inspecionei um dos cards de KPI do dashboard. Foi possível ver que o componente do MudBlazor gera várias tags HTML e classes próprias, como mud-paper e classes relacionadas ao espaçamento e elevação. Também foi possível perceber como uma classe que coloquei no código, como pa-4, aparece no HTML final e é usada para definir o espaçamento do componente.

## Estrutura do projeto

```
afya-admin/
├── Components/
│   ├── AtividadesRecentes.razor
│   ├── DashboardCard.razor
│   ├── KpiCard.razor
│   ├── PerformanceProjetos.razor
│   └── TabelaProjetos.razor
├── Data/
│   └── FakeData.cs
├── Layout/
│   ├── MainLayout.razor
│   └── NavMenu.razor
├── Pages/
│   ├── Dashboard.razor
│   ├── NotFound.razor
│   ├── Projetos.razor
│   └── Relatórios.razor
├── Properties/
│   └── launchSettings.json
├── docs/
│   └── prints/
├── wwwroot/
│   ├── css/app.css
│   ├── favicon.png
│   ├── icon-192.png
│   └── index.html
├── _Imports.razor
├── App.razor
├── Program.cs
└── afya-admin.csproj
```

- **`Components/`**: componentes visuais reutilizáveis que a página monta.
- **`Data/`**: dados fictícios e modelos (`Kpi`, `Projeto`, `Atividade`), separados da interface.
- **`Layout/`**: estrutura da aplicação (sidebar, barra superior, menu e tema).
- **`Pages/`**: páginas com rota (`@page`), como o Dashboard.
- **`wwwroot/`**: arquivos estáticos e o `index.html` que carrega o Blazor.

## Componentes criados

| Componente            | Responsabilidade                                          | Parâmetros que recebe                     |
| --------------------- | --------------------------------------------------------- | ----------------------------------------- |
| `DashboardCard`       | Card genérico com título que envolve qualquer conteúdo    | `Titulo`, `ChildContent` (RenderFragment) |
| `KpiCard`             | Mostra um indicador com valor e mini gráfico de tendência | `Titulo`, `Valor`, `Cor`, `DadosGrafico`  |
| `TabelaProjetos`      | Tabela de projetos recentes com status                    | `Projetos`                                |
| `PerformanceProjetos` | Lista de projetos com barras de progresso                 | `Projetos`                                |
| `AtividadesRecentes`  | Feed de atividades recentes                               | `Atividades`                              |

## O que aprendi

**1. Como uma aplicação Blazor WebAssembly inicia no navegador? Qual é o papel do `index.html`, da `<div id="app">` e do `Program.cs`?**

Eu entendi que o index.html é a página inicial que o navegador carrega. Dentro dele existe a <div id="app">, que funciona como o espaço onde o Blazor vai colocar a aplicação. Já o Program.cs é onde ficam as configurações e os serviços que a aplicação precisa para funcionar. No meu projeto, os três trabalham juntos para iniciar o dashboard no navegador.

**2. Qual é a diferença entre um Layout, uma Page e um Component neste projeto? Dê um exemplo de cada.**

Eu entendi que o Layout é a estrutura que fica em volta das páginas, como o menu lateral e a barra superior. No projeto, o MainLayout.razor é um exemplo disso. A Page é uma página que possui uma rota própria, como o Dashboard.razor. Já um Component é uma parte da interface que pode ser reutilizada, como o KpiCard.razor, que uso para mostrar os indicadores do dashboard.

**3. O que é um `RenderFragment` e como o `DashboardCard` usa esse recurso para ser reutilizado por vários cards?**
O RenderFragment permite passar um conteúdo de interface para dentro de um componente. No meu projeto, o DashboardCard recebe esse conteúdo através do ChildContent. Com isso, eu consigo criar um card padrão e colocar diferentes conteúdos dentro dele sem precisar criar um componente novo para cada tipo de card.

**4. Como funciona o `@bind-Valor` no `SeletorPeriodo`? Qual é o papel do `ValorChanged`?**
O @bind-Valor facilita a comunicação entre o componente e a página. Quando o valor do período muda no SeletorPeriodo, o ValorChanged é usado para avisar o componente que está usando ele sobre essa mudança. Assim, a página consegue receber o novo valor sem precisar fazer toda a comunicação manualmente.

**5. Por que os dados ficam na pasta `Data`, separados dos componentes? Que vantagem isso traz se, no futuro, os dados vierem de uma API?**
Os dados ficam separados para não misturar a parte visual com a parte que fornece as informações. No meu projeto eu usei dados fictícios no FakeData.cs, enquanto os componentes ficam responsáveis por mostrar esses dados. Se no futuro eu usar uma API, posso trocar a fonte dos dados sem precisar refazer toda a interface do dashboard.

**6. Como o `MudGrid` com `xs`, `sm` e `lg` faz os cards de KPI se reorganizarem em telas de tamanhos diferentes?**
O MudGrid permite definir quantas colunas os componentes ocupam dependendo do tamanho da tela. O xs é usado para telas menores, o sm para telas pequenas ou médias e o lg para telas maiores. Dessa forma, os cards conseguem se reorganizar automaticamente e o dashboard fica mais adequado para computador e celular.

**7. Como foi possível estilizar a página inteira sem escrever CSS? Explique o papel do tema (`MudTheme`) e das classes utilitárias.**
Isso foi possível porque o MudBlazor já possui vários estilos e componentes prontos. O MudTheme permite definir coisas como cores e aparência geral da aplicação. Além disso, as classes utilitárias, como pa-4, ajudam a controlar espaçamento, alinhamento e outras características sem precisar criar uma classe CSS para cada situação. Isso facilitou bastante a criação do dashboard.

**8. Por que o namespace do projeto é `afya_admin` e não `afya-admin`?**
Isso acontece porque o nome do projeto pode ter hífen, mas o hífen não pode ser usado da mesma forma em um namespace do C#. Por isso o .NET transforma o nome afya-admin em afya_admin para utilizar como namespace no código.

## Dificuldades e soluções

**Dificuldade 1:** Outra dificuldade foi ao começar a fazer o esqueleto desse codigo, não lembrava que o C# é necessário informar o tipo de dado que ela irá armazenar utilizando os sinais <>, como List<string>, List<Kpi> ou List<Projeto>. Inicialmente, utilizei apenas List, o que gerou um erro durante a compilação.

**Solução:**

**Dificuldade 2:** Outra dificuldade foi quando eu estava fazendo o esqueleto do codigo, demorei pra identificar qual versão do mudblazor eu estava usando, o que causava muitos erros ao salvar e tentar por o site no ar.

**Solução:** com auxilio do CLAUDE IA, consegui identificar através do terminal, a versão do mudblazor que eu estava utilizando, que era a mudblazor v9.

## Melhorias futuras (opcional)

Como melhoria futura, eu poderia substituir os dados fictícios por dados vindos de uma API, adicionar autenticação de usuários e criar mais páginas para o sistema. Também seria interessante deixar os gráficos realmente dinâmicos e permitir que o usuário filtre os dados por período.
