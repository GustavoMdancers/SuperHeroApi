# 🦸 SuperHero API — Blazor (.NET 10)

Aplicação web desenvolvida em **C# / .NET 10** com **Blazor Web App (Interactive Server)** para consulta e visualização de super-heróis e vilões consumindo a [SuperHero API](https://superheroapi.com/).

---

## ✨ Funcionalidades

- **Listagem Inicial por Sequência de ID:** Ao abrir a aplicação, carrega automaticamente os primeiros **20 personagens em ordem de ID** (`ID 1` a `ID 20`) utilizando requisições assíncronas em paralelo (`Task.WhenAll`).
- **Lista Scrollável e Paginada (4 cards × 5 páginas):** Exibe os personagens em um container scrollável dividido em **5 páginas com 4 cards por página**, contando com controles de navegação (`Anterior`, páginas `1` a `5`, `Próxima`).
- **Busca por Nome:** Permite pesquisar qualquer personagem pelo nome (ex.: `batman`, `superman`, `spider-man`) no endpoint `/api/{access-token}/search/{name}` e retornar facilmente à listagem inicial (`IDs 1–20`).
- **Cards Resumidos & Modal de Detalhes Completos:**
  - **Cards:** Imagem, nome, nome completo, alinhamento (`good`, `bad`, `neutral`), editora e ID.
  - **Modal Interativo:** Ao clicar em qualquer card, exibe um modal com barras de progresso dos **Powerstats** (*Inteligência, Força, Velocidade, Durabilidade, Poder e Combate*), além de **Biografia**, **Aparência**, **Trabalho** e **Conexões**.
- **Carregamento Resiliente de Imagens:** Utiliza mirror via CDN (`cdn.jsdelivr.net/gh/akabab/superhero-api`) com fallback automático para a URL original (`no-referrer`) e placeholder em SVG caso a imagem original sofra bloqueio de hotlink (`403 Forbidden`).
- **Configuração Segura via `.env`:** O `access-token` da SuperHero API é lido diretamente no servidor a partir de um arquivo `.env` (ignorado pelo Git), evitando expor credenciais no código-fonte ou no navegador.

---

## 🛠️ Tecnologias Utilizadas

- **[.NET 10](https://dotnet.microsoft.com/)** (`net10.0`)
- **C#** com `Nullable` e `ImplicitUsings` habilitados
- **Blazor Web App** (`@rendermode InteractiveServer`)
- **`System.Text.Json`** (`[JsonPropertyName]`) para desserialização de propriedades com hífen da API
- **`HttpClient` / `IHttpClientFactory`** para consumo assíncrono da API REST
- **Bootstrap 5** & **Blazor CSS Isolation** (`Home.razor.css`)

---

## 📂 Estrutura do Projeto

```text
SuperHeroApi/
└── BlazorSuperHeroApi/
    ├── Layout/
    │   ├── MainLayout.razor
    │   └── NavMenu.razor
    ├── Models/
    │   ├── Appearance.cs              # gender, race, height, weight, eye-color, hair-color
    │   ├── Biography.cs               # full-name, alter-egos, aliases, place-of-birth, first-appearance, publisher, alignment
    │   ├── Connections.cs             # group-affiliation, relatives
    │   ├── HeroImage.cs               # url
    │   ├── PowerStats.cs              # intelligence, strength, speed, durability, power, combat + ParseStat()
    │   ├── SuperHero.cs               # Entidade principal do personagem
    │   ├── SuperHeroSearchResponse.cs # Envelope de resposta da busca (response, results-for, results, error)
    │   └── Work.cs                    # occupation, base
    ├── Pages/
    │   ├── Home.razor                 # Página principal com busca, paginação 4x5 e modal de detalhes
    │   └── Home.razor.css             # Estilos isolados dos cards e container scrollável
    ├── wwwroot/                       # Arquivos estáticos (Bootstrap, CSS, ícones)
    ├── .env.example                   # Exemplo de configuração da variável SUPERHERO_API_TOKEN
    ├── App.razor                      # Documento raiz do Blazor Web App
    ├── Routes.razor                   # Roteamento dos componentes Razor
    ├── Program.cs                     # Inicialização, DI e carregamento do arquivo .env
    └── BlazorSuperHeroApi.csproj
```

---

## 🚀 Como Executar o Projeto

### 1. Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) instalado
- Um **Access Token** gratuito obtido em [https://superheroapi.com/](https://superheroapi.com/)

### 2. Configurar o `.env`

Na pasta `SuperHeroApi/BlazorSuperHeroApi/`, crie um arquivo `.env` (ou copie de `.env.example`) e informe o seu token:

```env
SUPERHERO_API_TOKEN=seu_access_token_aqui
```

### 3. Executar a aplicação

No terminal, a partir da raiz do repositório:

```powershell
dotnet run --project SuperHeroApi/BlazorSuperHeroApi/BlazorSuperHeroApi.csproj
```

Acesse no navegador o endereço exibido no console (por padrão `http://localhost:5203` ou `https://localhost:7048`).

---

## 🔗 Endpoints Consumidos

| Operação | Endpoint da SuperHero API |
| :--- | :--- |
| **Busca por ID (Listagem inicial 1–20)** | `GET https://superheroapi.com/api/{access-token}/{id}` |
| **Busca por Nome** | `GET https://superheroapi.com/api/{access-token}/search/{name}` |
