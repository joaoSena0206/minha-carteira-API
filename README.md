# minha-carteira-API
Uma API RESTful de controle financeiro, que gerencia suas finanças, podendo adicionar transações, separando as entre categorias e metas financeiras mensais.

## Funcionalidades
- ✅ Adicionar transações (crédito e débito), categorias personalizadas e metas financeiras.
- ✅ Calcular saldo atual com base nas transações do usuário.
- ✅ Classificar transações por categoria.
- ✅ Definir metas de gasto por categoria, mês e ano.
- ✅ Visualizar o status de cada meta financeira: se está dentro do limite ou foi ultrapassada.

## Tecnologias Utilizadas
- ASP.NET Core
- Entity Framework Core
- SQl Server
- JWT
- Swagger

## Endpoints Principais
### 🔐 Auth
- `POST /api/auth/register` – Registra o usuário.
- `POST /api/auth/login` – Loga o usuário, retornando o token JWT.

### 🗂️ Category
- `POST /api/category` – Cria uma categoria.
- `GET /api/category` – Lista todas as categorias.
- `PATCH /api/category/{id}` – Atualiza uma categoria existente.
- `DELETE /api/category/{id}` – Deleta uma categoria.

### 🎯 Financial Goal
- `POST /api/financial-goal` – Cria uma meta financeira.
- `GET /api/financial-goal` – Lista todas as metas financeiras com status.
- `PATCH /api/financial-goal/{id}` – Atualiza uma meta existente.
- `DELETE /api/financial-goal/{id}` – Deleta uma meta financeira.

### 💰 Transaction
- `POST /api/transaction` – Cria uma transação (crédito ou débito).
- `GET /api/transaction` – Lista e filtra todas as transações.
- `GET /api/transaction/balance` – Calcula o saldo atual.
- `PATCH /api/transaction/{id}` – Atualiza uma transação.
- `DELETE /api/transaction/{id}` – Remove uma transação.

### 👤 User
- `DELETE /api/user` – Deleta o usuário e todos os seus dados.


## Instalação
### Pré-requisitos
- .NET 9.0
- SQL Server

### Passo a Passo
1. Clone o repositório:
```bash
git clone https://github.com/joaoSena0206/minha-carteira-API.git
```

2. Entre na pasta do projeto:
```bash
cd minha-carteira-api
cd back-end
cd back-end
```

3. Restaure os pacotes:
```bash
dotnet restore
```

4. Abra o appsettings.json e configure a string de conexão ao banco

5. Execute as migrações:
```bash
dotnet ef database update
```

6. Rode o projeto:
```bash
dotnet run
```

## Licença
Esse projeto está licenciado sob a MIT License.