# WebApi - Gerenciamento de Autores e Livros

Esta é uma API simples em desenvolvimento em **.NET 8** para gerenciar o relacionamento entre autores e seus livros. O projeto foi estruturado para demonstrar o uso de boas práticas, separação de responsabilidades (Service Pattern) e integração com banco de dados usando Entity Framework Core.

## 🚀 Tecnologias Utilizadas

- **C# / .NET 8**
- **Entity Framework Core**: Para comunicação com o
- **Docker + Azure Data Studio**: Para containerização e gerenciamento do banco de dados.
- **Swagger**: Para documentação e testes rápidos dos endpoints.

## 📌 Funcionalidades

A API permite realizar operações relacionadas aos autores, como:

- Listar todos os autores cadastrados.
- Buscar um autor específico pelo seu ID.
- Buscar o autor associado a um determinado livro.

## 🛠️ Como configurar o projeto

1. **Clonar o repositório:**

   ```bash
   git clone <url-do-repositorio>
   ```

2. **Configurar o Banco de Dados:**
   No arquivo `appsettings.json`, ajuste a `DefaultConnection` para apontar para o seu servidor SQL Server:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=SEU_SERVIDOR;Database=NomeDoBanco;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

3. **Executar as Migrations:**
   Abra o terminal na pasta do projeto e execute:

   ```bash
   dotnet ef database update
   ```

4. **Rodar a aplicação:**
   ```bash
   dotnet run
   ```
   Acesse `http://localhost:XXXX/swagger` para visualizar a documentação interativa.

## 📂 Estrutura do Projeto

- **Controllers**: Portas de entrada da API.
- **Models**: Definição das entidades e de um modelo de resposta genérico.
- **Services**: Lógica de negócio e comunicação com o banco de dados.
- **Data**: Configuração do Contexto do Entity Framework (AppDbContext).
- **Migrations**: Histórico de alterações do banco de dados.

## 📡 Padrão de Resposta

Todas as requisições retornam um objeto padronizado para facilitar o consumo pelo front-end:

```json
{
  "dados": { ... },
  "mensagem": "Texto informativo",
  "status": true
}
```
