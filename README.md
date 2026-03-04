# Controle de Gastos

Sistema para gerenciamento de pessoas, categorias e transações financeiras.

---

## Tecnologias

**Backend:**
- C# / .NET 7
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server

**Frontend:**
- React 18
- TypeScript
- Material-UI
- React Router

---

## Funcionalidades

### Pessoas
- Listar, criar, atualizar e deletar pessoas.
- Filtrar por ID.
- Ao deletar uma pessoa, todas as suas transações são removidas automaticamente.

### Categorias
- Listar, criar e gerenciar categorias.
- Cada categoria possui finalidade (Receita ou Despesa).

### Transações
- Cadastrar transações (receitas e despesas).
- Validação: menores de 18 anos só podem lançar despesas.
- Associar transações a pessoa e categoria.
- Listar transações por pessoa ou categoria.

### Consultas
- Totais por pessoa: total de receitas, despesas e saldo individual.
- Totais por categoria: total de receitas, despesas e saldo por categoria.

---

## Estrutura do Projeto

**Backend:**
/Core → Entidades, Enums e regras de negócio
/Repository → Acesso a dados
/Controllers → Endpoints da API

**Frontend:**
/pages → Telas principais (NovaPessoa, NovaCategoria, NovaTransacao, Pessoas, Categorias)
/services → Conexão com API (pessoaService, categoriaService, transacaoService)
/types → Tipos TypeScript (Pessoa, Categoria, Transacao)
/Layouts → Layout base do sistema


---

## Como Executar

**Backend:**
1. Restaurar pacotes: `dotnet restore`
2. Atualizar banco de dados: `dotnet ef database update`
3. Executar API: `dotnet run`

**Frontend:**
1. Instalar dependências: `npm install`
2. Iniciar aplicação: `npm start`

---

## Comentários e Documentação

- Cada método importante possui **comentários explicativos**.
- No frontend, funções de submit, busca e filtros têm comentários dentro das páginas.
- No backend, endpoints e métodos do repository estão documentados usando `/// <summary>`.

---

## Observações

- A API retorna mensagens de erro detalhadas, exibidas na interface.
- A estrutura segue Clean Architecture e boas práticas de desenvolvimento.
