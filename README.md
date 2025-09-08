# 🏍️ MotoFacilAPI  

## 📌 Projeto  
**Disciplina:** *Advanced Business Development with .NET*  

👤 **Autores**  
- Igor Barrocal – RM555217  
- Cauan da Cruz – RM558238  

---

## 📖 Descrição  

O **MotoFacilAPI** é uma **API RESTful** construída em **.NET 8**, voltada para o gerenciamento de usuários, motos e serviços realizados nas motos.  
A arquitetura segue os princípios de **Clean Architecture**, **Domain-Driven Design (DDD)** e **Clean Code**, proporcionando:  

✅ Baixo acoplamento  
✅ Alta manutenibilidade  
✅ Escalabilidade  

---

## ⚙️ Funcionalidades  

- 👥 **Gerenciamento de Usuários** (CRUD completo, entidade rica, Value Object para e-mail)
- 🏍️ **Gerenciamento de Motos** (CRUD completo, incluindo vínculo com usuário, enum para modelo da moto)
- 🔧 **Gerenciamento de Serviços** realizados nas motos (CRUD completo, regras de reagendamento)
- 📦 **Validação de dados** via DTOs e entidades
- 📑 **Documentação interativa** com Swagger/OpenAPI
- 🗄️ **Persistência de dados** com Entity Framework Core + Migrations
- 🧩 **Paginação** nos endpoints de listagem
- 🔗 **HATEOAS** (padrão de boas práticas, retornos claros e status code apropriados)

---

## 📂 Estrutura do Projeto  
src/

┣ 📂 Api -> Controllers REST, validações de entrada  
┣ 📂 Application -> Serviços de aplicação, DTOs  
┣ 📂 Domain -> Entidades, enums, Value Objects, Interfaces de Repositório  
┗ 📂 Infrastructure -> Persistência de dados, repositórios  

---

## 🚀 Tecnologias Utilizadas  

- [.NET 8](https://dotnet.microsoft.com/)  
- **C#**  
- **Entity Framework Core**  
- **Oracle** (configurável via *appsettings.json*)  
- **Swagger/OpenAPI**  

---

## 📄 Endpoints Principais  

### 👥 Usuários  
| Método | Endpoint        | Descrição            |  
|--------|----------------|----------------------|  
| GET    | `/usuarios`    | Listar todos os usuários (com paginação) |  
| GET    | `/usuarios/{id}` | Buscar usuário por ID |  
| POST   | `/usuarios`    | Criar novo usuário |  
| PUT    | `/usuarios/{id}` | Atualizar usuário |  
| DELETE | `/usuarios/{id}` | Remover usuário |  

### 🏍️ Motos  
| Método | Endpoint     | Descrição           |  
|--------|-------------|---------------------|  
| GET    | `/motos`    | Listar todas as motos (com paginação) |  
| GET    | `/motos/{id}` | Buscar moto por ID |  
| POST   | `/motos`    | Criar nova moto (modelo, marca, vínculo ao usuário) |  
| PUT    | `/motos/{id}` | Atualizar moto |  
| DELETE | `/motos/{id}` | Remover moto |  

### 🔧 Serviços  
| Método | Endpoint        | Descrição            |  
|--------|----------------|----------------------|  
| GET    | `/servicos`    | Listar todos os serviços (com paginação) |  
| GET    | `/servicos/{id}` | Buscar serviço por ID |  
| POST   | `/servicos`    | Criar novo serviço (vinculado a uma moto e usuário) |  
| PUT    | `/servicos/{id}` | Atualizar serviço (reagendar data, etc.) |  
| DELETE | `/servicos/{id}` | Remover serviço |  

---

## 🛠️ Como Executar Localmente  

### 1️⃣ Clone o repositório  
```bash
git clone https://github.com/igorbarrocal/MotoFacilAPI.git
cd MotoFacilAPI
```

### 2️⃣ Configure o banco de dados  
A string de conexão está em `appsettings.Development.json` ou `appsettings.json`.  
Por padrão, está configurado para Oracle:

```json
"ConnectionStrings": {
  "Oracle": "Data Source=oracle.fiap.com.br:1521/orcl;User ID=RM558238;Password=111105;"
}
```
Altere conforme seu ambiente.

### 3️⃣ Execute as migrations  
```bash
dotnet ef database update
```

### 4️⃣ Rode a API  
```bash
dotnet run
```

Acesse o Swagger em:  
```
https://localhost:7150/swagger
```

---

## 📝 Modelos dos Dados (Swagger/OpenAPI)  

Os modelos e exemplos de payloads estão disponíveis na documentação interativa Swagger da API.  
Todos os endpoints têm descrições de parâmetros, exemplos e resposta.

---

## 🏆 Critérios de Projeto Atendidos

- **DDD**: Mínimo 3 entidades (Usuário, Moto, Serviço), uma entidade raiz (Usuário), Value Object (Email), entidades ricas com comportamento.
- **Clean Architecture & Clean Code**: Separação clara das camadas, SRP, DRY, KISS, YAGNI, nomeação clara, código limpo.
- **REST**: Endpoints CRUD, boas práticas, status codes, paginação, documentação.
- **Persistência**: Entity Framework Core, migrations aplicáveis, conexão via appsettings.

---

## 📬 Dúvidas?  
Abra uma issue no repositório!
