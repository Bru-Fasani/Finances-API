# 🚧 Em testes 🚧

# Personal Expenses API
###
Finances API é uma aplicação RESTful desenvolvida com ASP.NET Core 8 e Entity Framework Core, que permite o gerenciamento de despesas pessoais por meio de operações CRUD, categorização e filtragem por data.
###
# Funcionalidades
✅ Cadastro, leitura, atualização e remoção de despesas

📅 Filtro de despesas por período (data inicial e final)

🗂️ Filtro de despesas por categoria

🧾 Cadastro de categorias com dados pré-populados

🔁 Mapeamento com AutoMapper e separação por DTOs

🛠️ Documentação interativa com Swagger

# Tecnologias Utilizadas
- .NET 8.0

- ASP.NET Core Web API

- Entity Framework Core (SQL Server)

- AutoMapper 

- Swagger / Swashbuckle 

- Docker (configurado, opcional) 

- Visual Studio 2022
  
###
# Estrutura do Projeto

Finances_API/
- ├── Controllers/
- │   └── ExpensesController.cs
- ├── Models/
- │   ├── Expense.cs
- │   └── Category.cs
- ├── DTO/
- │   ├── CreateExpenseDTO.cs
- │   ├── UpdateExpenseDTO.cs
- │   └── ExpensesDTO.cs
- ├── Profiles/
- │   └── ExpensesProfile.cs
- ├── Data/
- │   └── AppDbContext.cs
- ├── Repositories/
- │   ├── IExpenseRepository.cs
- │   └── ExpenseRepository.cs
- ├── appsettings.json
- └── Program.cs
###

### Como executar o projeto
Pré-requisitos:
- .NET 8 SDK

- SQL Server LocalDB

- (Opcional) Visual Studio 2022

Passos:
-bash
-Copiar
-Editar

# Restaure os pacotes
<pre> dotnet restore</pre>

# Crie o banco de dados com as migrations
<pre> dotnet ef database update</pre>

# Execute o projeto
<pre> dotnet run </pre>

# Acesse a documentação da API via Swagger em:

###
```
https://localhost:5001/swagger
```
###

# Endpoints principais

Verbo	Rota	Ação
<pre>GET /api/expenses	Lista todas as despesas </pre>
<pre>GET	/api/expenses/{id}	Consulta uma despesa por ID</pre>
<pre>POST	/api/expenses	Cria uma nova despesa</pre>
<pre>PUT	/api/expenses/{id}	Atualiza uma despesa existente</pre>
<pre>DELETE	/api/expenses/{id}	Remove uma despesa</pre>
<pre>GET	/api/expenses/ByDateRange?startDate=YYYY-MM-DD&endDate=YYYY-MM-DD   Filtra por período</pre>	
<pre>GET	/api/expenses/ByCategory/{categoryId}   Filtra por categoria</pre>	

# Migrations
Caso deseje criar novas migrations:

<pre>dotnet ef migrations add NomeDaMigration</pre>
<pre>dotnet ef database update</pre>
###
📌 Autor(a)
Desenvolvido por Bruna Fasani | Estudante de Engenharia de Software | Desenvolvedora .NET
