# CRUD Angular & .NET 8

Este projeto é uma aplicação CRUD (Create, Read, Update, Delete) completa com um frontend em **Angular 5** e um backend em **ASP.NET Core 8.0** utilizando **MySQL**.

## 🛠️ Tecnologias e Versões

### Backend
- **Framework:** .NET 8.0
- **ORM:** Entity Framework Core 7.0.7
- **Database:** MySQL (Pomelo.EntityFrameworkCore.MySql 7.0.0)
- **API:** Web API com Controllers e Swagger para documentação.
- **CORS:** Configurado para aceitar requisições de `http://localhost:4200`.

### Frontend
- **Framework:** Angular 5.2.0
- **CLI:** Angular CLI 1.6.6
- **Styling:** Bootstrap 4.6.2
- **Scripts:** jQuery e Popper.js (dependências do Bootstrap 4).

---

## 🚀 Como Executar

### Pré-requisitos
- .NET SDK 8.0
- Node.js (compatível com Angular 5 - recomendado v8.x ou v10.x)
- MySQL Server

### Configuração do Backend (`apiDotNet/CrudComAngular`)
1.  Certifique-se de que o MySQL está rodando.
2.  Verifique a string de conexão em `appsettings.json`.
3.  Execute as migrações para criar o banco de dados:
    ```bash
    dotnet ef database update
    ```
4.  Inicie o servidor:
    ```bash
    dotnet run
    ```
    A API estará disponível em `http://localhost:5000` ou similar (verifique o console). O Swagger pode ser acessado em `/swagger`.

### Configuração do Frontend (`angular-simple-crud`)
1.  Instale as dependências:
    ```bash
    npm install
    ```
2.  Inicie o servidor de desenvolvimento:
    ```bash
    npm start
    ```
    O app estará disponível em `http://localhost:4200`.

---

## 📂 Estrutura do Projeto

- `apiDotNet/CrudComAngular/`: Código fonte do backend .NET 8.
  - `Controllers/`: Endpoints da API.
  - `Data/`: Contexto do Entity Framework (`AppDbContext`).
  - `Models/`: Classes de entidade.
  - `Migrations/`: Histórico de migrações do banco de dados.
- `angular-simple-crud/`: Código fonte do frontend Angular 5.
  - `src/app/models/`: Modelos TypeScript.
  - `src/app/services/`: Serviços para comunicação com a API.
  - `src/app/`: Componentes da aplicação.

---

## 📝 Licença

Este projeto está sob a licença [MIT](./LICENSE). sendo para fins de estudo e prática. Sinta-se à vontade para usar como referência!

---
## 👨‍💻 Autor
Desenvolvido por [David Tavares](https://github.com/davidtav) 🚀
