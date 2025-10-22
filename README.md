# LanchesMVC 🍰 | Projeto de E-commerce Básico em ASP.NET Core MVC

## 🎯 Sobre o Projeto

O **LanchesMVC** é um projeto desenvolvido com o objetivo de demonstrar minhas habilidades e proficiência no desenvolvimento de aplicações web utilizando o framework **ASP.NET Core MVC**. Ele simula um e-commerce simples focado na venda de lanches.

**Características Destacadas para Portfólio:**

* **Padrão de Design:** Implementação rigorosa do padrão **Model-View-Controller (MVC)** para garantir separação de preocupações (SoC).
* **Acesso a Dados:** Utilização do **Entity Framework Core (Code First)** para mapeamento Objeto-Relacional (ORM) e persistência de dados.
* **Injeção de Dependência (DI):** Uso do container de DI nativo do .NET Core para gerenciar serviços e dependências.
* **Design Responsivo:** Interface construída com **Bootstrap**, garantindo usabilidade em diferentes dispositivos.

## ⚙️ Arquitetura e Tecnologias

Este projeto foi construído sobre a arquitetura .NET Core, focando em práticas modernas de desenvolvimento.

### 💻 Stack Tecnológica

| Categoria | Tecnologia | Versão (Exemplo) | Objetivo no Projeto |
| :--- | :--- | :--- | :--- |
| **Backend** | **ASP.NET Core MVC** | .NET 6+ ou 7 | Core do projeto; roteamento e lógica de negócio. |
| **Linguagem** | C# | 10+ | Lógica de programação robusta e orientada a objetos. |
| **Banco de Dados** | **Entity Framework Core** | 6.0 | ORM para comunicação com o SQL Server (ou SQLite/InMemory). |
| **Frontend** | HTML5, CSS3, JS | N/A | Construção da interface do usuário. |
| **Estilização** | Bootstrap | 5.x | Framework de CSS para design responsivo. |

### 🧩 Funcionalidades Implementadas

O projeto demonstra a implementação das seguintes funcionalidades essenciais de um e-commerce:

1.  **Catálogo de Produtos:**
    * Listagem e navegação de lanches por **Categorias**.
    * Página de **Detalhes** do Produto.
2.  **Carrinho de Compras:**
    * Gerenciamento de sessão/cookie para persistência temporária do carrinho.
    * Cálculo automático de totais.
3.  **Sistema de Pedidos (Checkout):**
    * Formulário de Pedido (captura de informações do cliente).
    * Persistência do Pedido e dos Itens no banco de dados.
    * Página de Confirmação do Pedido.
4.  **Admin/Área Restrita (Opcional, mas recomendado):**
    * Módulo de **Autenticação (Identity)** para Login e Registro de usuários/admins.
    * **Autorização (Roles)** para restringir acesso ao CRUD de lanches e categorias.

## 🚀 Como Executar Localmente

Para rodar este projeto em sua máquina e inspecionar o código, siga estas instruções.

### Pré-requisitos

* [.NET SDK](https://dotnet.microsoft.com/download) (Versão compatível com o `global.json` ou `csproj`).
* Um editor de código (Visual Studio, VS Code, JetBrains Rider).

### Passos

1.  **Clonagem do Repositório:**

    ```bash
    git clone [https://github.com/ericlesbrum/LanchesMVC.git](https://github.com/ericlesbrum/LanchesMVC.git)
    cd LanchesMVC
    ```

2.  **Restauração e Construção:**

    ```bash
    dotnet restore
    dotnet build
    ```

3.  **Configuração do Banco de Dados (Entity Framework Core):**

    Execute as migrações para criar o esquema do banco de dados e inserir dados iniciais (se houver):

    ```bash
    dotnet ef database update
    ```
    *(Obs: Certifique-se de que a string de conexão em `appsettings.json` esteja configurada corretamente para sua instância de SQL Server LocalDB ou similar.)*

4.  **Início da Aplicação:**

    ```bash
    dotnet run
    ```
    A aplicação estará acessível em `http://localhost:<porta_exibida>`.

## 🤝 Contribuições e Contato

Este projeto é mantido para fins de demonstração de portfólio, mas sinta-se à vontade para inspecionar, dar sugestões ou reportar issues.

* **Autor:** Ericles Brum
* **GitHub:** [https://github.com/ericlesbrum](https://github.com/ericlesbrum)

---

> 💖 **Obrigado por visitar o projeto!**
