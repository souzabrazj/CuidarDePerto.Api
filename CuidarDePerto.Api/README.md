# CuidarDePerto API (CitizenTech) — Global Solution FIAP

API RESTful desenvolvida em **ASP.NET Core 8** com **Entity Framework Core** e banco de dados **Oracle**, criada para a Global Solution da FIAP. A solução tem como objetivo monitorar a segurança e o bem-estar de idosos por meio de um sistema integrado de cadastros e registros de alertas de emergência.

---

## 🎥 Vídeo de Demonstração

* **Assista no YouTube (Não Listado):** [https://youtu.be/ap20xZTYMkY)

---

## 👥 Integrantes do Grupo
João Victor de Souza Braz - RM566862 
Felipe Cuesta Puerta de Oliveira - RM567703 
Vitor Costa de Godoi - RM568448 
Vitor Santos Domingues - RM568375 
Lucas Pompeu - RM567010 
Turma: 2TDSPR
---

## 🛠️ Tecnologias Utilizadas

* **Linguagem & Framework:** C# / .NET 8 (ASP.NET Core Web API)
* **ORM:** Entity Framework Core (`Oracle.EntityFrameworkCore`)
* **Banco de Dados:** Oracle Database (`oracle.fiap.com.br`)
* **Documentação Interativa:** Swagger / OpenAPI

---

## 🏗️ Arquitetura e Modelo de Dados

A aplicação segue o padrão arquitetural REST e implementa um relacionamento de **1 para N (1:N)** entre as entidades principais:

* **`Idoso` (`1`):** Armazena os dados cadastrais do paciente (`id`, `nome`, `idade`, `endereco`).
* **`Alerta` (`N`):** Registra ocorrências e notificações vinculadas a um idoso específico (`id`, `tipoAlerta`, `dataHora`, `idosoId`).

### Estrutura de Pastas
```text
CuidarDePerto.Api/
├── Controllers/       # Endpoints REST (IdosoController, AlertaController)
├── Data/              # Contexto do EF Core (CuidarDePertoContext)
├── Migrations/        # Scripts de versionamento e criação das tabelas no Oracle
├── Models/            # Entidades de domínio e mapeamentos (Idoso, Alerta)
├── appsettings.json   # Configurações e string de conexão (com placeholder seguro)
└── Program.cs         # Configuração de serviços, Oracle e Swagger