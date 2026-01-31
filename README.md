# WebApi - Gerenciamento de Autores e Livros

Esta é uma API RESTful desenvolvida em **.NET 8** para gerenciar o relacionamento entre autores e seus livros. O projeto demonstra boas práticas de desenvolvimento, como separação de responsabilidades (Service Pattern), injeção de dependência, e integração com banco de dados usando Entity Framework Core. Ideal para portfólio, mostrando habilidades em desenvolvimento backend com C#.

## 🚀 Tecnologias Utilizadas

- **C# / .NET 8**
- **Entity Framework Core**: ORM para comunicação com o banco de dados
- **SQL Server**: Banco de dados relacional
- **Docker + Docker Compose**: Containerização e orquestração
- **Swagger/OpenAPI**: Documentação interativa da API
- **AutoMapper** (se aplicável): Mapeamento de DTOs

## 📌 Funcionalidades

A API permite realizar operações CRUD completas para autores e livros:

### Autores

- Listar todos os autores cadastrados
- Buscar um autor específico pelo seu ID
- Buscar o autor associado a um determinado livro
- Criar um novo autor
- Atualizar informações de um autor
- Deletar um autor

### Livros

- Listar todos os livros cadastrados (com informações do autor)
- Buscar um livro específico pelo seu ID
- Buscar livros de um autor específico
- Criar um novo livro (associado a um autor existente)
- Atualizar informações de um livro
- Deletar um livro

## 🛠️ Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) ou Docker
- [Git](https://git-scm.com/)

## 📂 Estrutura do Projeto

```
WebApi/
├── Controllers/          # Endpoints da API
├── Models/              # Entidades do domínio
├── DTO/                 # Objetos de Transferência de Dados
├── Services/            # Lógica de negócio
├── Data/                # Contexto do Entity Framework
├── Migrations/          # Histórico de migrações do BD
├── Properties/          # Configurações do projeto
└── appsettings.json     # Configurações da aplicação
```

## 📡 Padrão de Resposta

Todas as requisições retornam um objeto padronizado para facilitar o consumo:

```json
{
  "dados": { ... },
  "mensagem": "Texto informativo sobre o resultado",
  "status": true
}
```

## 🚀 Passo a Passo para Começar o Projeto

### Opção 1: Sem Docker (Desenvolvimento Local)

1. **Clone o repositório:**

   ```bash
   git clone <url-do-repositorio>
   cd WebApi
   ```

2. **Restaure as dependências:**

   ```bash
   dotnet restore
   ```

3. **Configure o banco de dados:**
   - Instale e configure o SQL Server localmente
   - No arquivo `appsettings.json`, ajuste a string de conexão:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=WebApiDb;Trusted_Connection=True;TrustServerCertificate=True;"
     }
     ```

4. **Execute as migrações:**

   ```bash
   dotnet ef database update
   ```

5. **Execute a aplicação:**

   ```bash
   dotnet run
   ```

6. **Acesse a documentação:**
   - Abra o navegador em `https://localhost:XXXX/swagger` (porta definida no launchSettings.json)

### Opção 2: Com Docker (Ambiente Containerizado)

1. **Clone o repositório:**

   ```bash
   git clone <url-do-repositorio>
   cd WebApi
   ```

2. **Certifique-se de que o Docker está rodando:**

   ```bash
   docker --version
   docker-compose --version
   ```

3. **Execute com Docker Compose:**

   ```bash
   docker-compose up --build
   ```

4. **Acesse a aplicação:**
   - API: `http://localhost:8080`
   - Swagger: `http://localhost:8080/swagger`
   - Banco de dados: SQL Server rodando em container na porta 1433

## 🧪 Testando a API

Use o Swagger UI para testar os endpoints ou ferramentas como Postman/Insomnia:

### Exemplos de Requisições

**Criar Autor:**

```http
POST /api/autor/CriarAutor
Content-Type: application/json

{
  "nome": "João",
  "sobrenome": "Silva"
}
```

**Criar Livro:**

```http
POST /api/livro/CriarLivro
Content-Type: application/json

{
  "titulo": "Meu Primeiro Livro",
  "autorId": 1
}
```

**Listar Livros:**

```http
GET /api/livro/ListarLivros
```

## 🤝 Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.

---

**Desenvolvido por Matheus Lima** - Projeto para portfólio demonstrando habilidades em desenvolvimento de APIs RESTful com .NET.
