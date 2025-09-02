# 🏍️ MotoFacilAPI  

## 📌 Projeto  
**Disciplina:** *Advanced Business Development with .NET*  

👤 **Autores**  
- Igor Barrocal – RM555217  
- Cauan da Cruz – RM558238  

---

## 📖 Descrição  

O **MotoFacilAPI** é uma **API RESTful** desenvolvida em **.NET 8**, focada no gerenciamento de usuários, motos e serviços.  
Foi estruturada com **Clean Architecture**, **Domain-Driven Design (DDD)** e **Clean Code**, garantindo:  

✅ Baixo acoplamento  
✅ Alta manutenibilidade  
✅ Escalabilidade  

---

## ⚙️ Funcionalidades  

- 👥 **Gerenciamento de Usuários** (CRUD completo)  
- 🏍️ **Gerenciamento de Motos** (CRUD completo)  
- 🔧 **Gerenciamento de Serviços** realizados nas motos  
- 📦 **Validação de dados** via DTOs  
- 📑 **Documentação interativa** com Swagger  
- 🗄️ **Persistência de dados** com Entity Framework Core + Migrations  

---

## 📂 Estrutura do Projeto  
src/

┣ 📂 Api -> Controllers, validações de entrada

┣ 📂 Application -> Casos de uso (UseCases), DTOs

┣ 📂 Domain -> Entidades, Value Objects, Interfaces de Repositório

┗ 📂 Infrastructure -> Acesso a dados, repositórios, serviços externos


---

## 🚀 Tecnologias Utilizadas  

- [.NET 8](https://dotnet.microsoft.com/)  
- **C#**  
- **Entity Framework Core**  
- **SQL Server / Oracle** (configurável via *appsettings.json*)  
- **Swagger**  

---

## 📄 Endpoints Principais  

### 👥 Usuários  
| Método | Endpoint        | Descrição            |  
|--------|----------------|----------------------|  
| GET    | `/usuarios`    | Listar todos os usuários |  
| GET    | `/usuarios/{id}` | Buscar usuário por ID |  
| POST   | `/usuarios`    | Criar novo usuário |  
| PUT    | `/usuarios/{id}` | Atualizar usuário |  
| DELETE | `/usuarios/{id}` | Remover usuário |  

### 🏍️ Motos  
| Método | Endpoint     | Descrição           |  
|--------|-------------|---------------------|  
| GET    | `/motos`    | Listar todas as motos |  
| GET    | `/motos/{id}` | Buscar moto por ID |  
| POST   | `/motos`    | Criar nova moto |  
| PUT    | `/motos/{id}` | Atualizar moto |  
| DELETE | `/motos/{id}` | Remover moto |  

### 🔧 Serviços  
| Método | Endpoint        | Descrição            |  
|--------|----------------|----------------------|  
| GET    | `/servicos`    | Listar todos os serviços |  
| GET    | `/servicos/{id}` | Buscar serviço por ID |  
| POST   | `/servicos`    | Criar novo serviço |  
| PUT    | `/servicos/{id}` | Atualizar serviço |  
| DELETE | `/servicos/{id}` | Remover serviço |  

---

## 🛠️ Como Executar Localmente  

### 1️⃣ Clone o repositório  
```bash
git clone https://github.com/igorbarrocal/MotoFacilAPI.git
cd MotoFacilAPI
