# Sistema de Gerenciamento de Projetos

![Projeto](https://img.shields.io/badge/Status-Concluído-green)
![.NET](https://img.shields.io/badge/.NET-8-blue)
![Arquitetura Limpa](https://img.shields.io/badge/Arquitetura-Limpa-orange)

---

## 📋 Descrição

Sistema para gerenciamento de projetos de uma empresa, desenvolvido com base nos princípios da **Arquitetura Limpa**, exposição de uma **API RESTful**, aplicação das **regras de negócio**, e implementação de **controle de acesso** via autenticação e autorização.

---

## 🎯 Objetivo

Dar continuidade ao projeto iniciado em aula, aplicando conceitos sólidos de arquitetura e desenvolvimento para criar uma aplicação escalável, segura e de fácil manutenção.

---

## ⚙️ Funcionalidades

- **Cadastro de Projetos**  
  - Inserção  
  - Alteração  
  - Exclusão (restrita a alguns status)  
  - Consulta (listagem geral e busca por nome e status)

## 📌 Regras de Negócio

- **Exclusão restrita:**  
  Projetos com status `Iniciado`, `Planejado`, `Em andamento` ou `Encerrado` **não podem ser excluídos**.

- Operações de cadastro, alteração e exclusão restritas a usuários autenticados.

- Visualização dos projetos é restrita ao usuário autenticado, garantindo que cada usuário tenha acesso somente aos seus próprios projetos.

---

## 🏗️ Arquitetura

- Segue a **Arquitetura Limpa**, com separação clara entre as camadas:  
  - Domínio  
  - Aplicação  
  - Infraestrutura  
  - Interface/API  

- Comunicação entre camadas feita por interfaces, respeitando o princípio da inversão de dependência.

---

## 🔐 Segurança

- Autenticação com login de usuário e senha.  
- Autorização para controlar acesso às operações críticas.

---

## 🚀 API RESTful

- Endpoints para todas as operações CRUD, seguindo boas práticas REST:  
  - `GET /api/projeto` — busca todos  
  - `GET /api/projeto/buscar` — busca por nome e status  
  - `POST /api/projeto` — cria novo projeto  
  - `PUT /api/projeto` — atualiza projeto  
  - `DELETE /api/projeto/{id}` — deleta projeto (com restrições)

- Respostas com status HTTP apropriados.

---

## 📚 Documentação

- API documentada via **Swagger UI** acessível em `/swagger`.  
- Diagrama da arquitetura disponível em `docs/arquitetura.png`.  
- Documento com decisões arquiteturais e justificativas em `docs/decisoes-arquiteturais.pdf`.

---

## 🛠️ Como Executar

1. Clone o repositório:

   ```bash
   git clone <URL_DO_REPOSITORIO>
   ```

2. Pre-Requisitos:

- Ter instalado o .NET 8 SDK

- Ter um IDE compatível com .NET, como Visual Studio 2022 (versão 17.6 ou superior), Visual Studio Code com extensão C# ou JetBrains Rider

- Ter um servidor PostgreSQL disponível e configurado (local ou remoto)

- Configurar a string de conexão do banco no arquivo appsettings.json para apontar para seu servidor PostgreSQL

3. Restaure os pacotes NuGet:

```bash
dotnet restore
```

4. Aplique as migrações para criar o banco e as tabelas:
   
```bash
dotnet ef database update
```
5. Execute a API:
   
```bash
dotnet run --project Sigma.API
```

6. Acesse a documentação Swagger em `http://localhost:<porta>/swagger`.

  
   
