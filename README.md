🏍️ MotoFacilAPI

Projeto: MotoFacilAPI
Disciplina: Clean Code, DDD e Clean Architecture com .NET 8
Autores:
Igor Barrocal RM555217
Cauan da Cruz RM558238

📖 Descrição do Projeto

MotoFacilAPI é uma API RESTful em .NET 8 para gerenciar usuários, motos e serviços, seguindo os princípios de Clean Architecture, Domain-Driven Design (DDD) e Clean Code.
O projeto possui camadas separadas para API, Application, Domain e Infrastructure, garantindo baixo acoplamento, manutenção fácil e escalabilidade.

Principais funcionalidades:

Cadastro e gerenciamento de usuários

Cadastro e gerenciamento de motos

Cadastro e gerenciamento de serviços realizados nas motos

Validação de dados via DTOs

Documentação via Swagger

Persistência via Entity Framework Core com migrations aplicáveis

📂 Estrutura do Projeto
src/
 ┣ 📂 Api             -> Controllers, validações de entrada
 ┣ 📂 Application     -> Casos de uso (UseCases), DTOs
 ┣ 📂 Domain          -> Entidades, Value Objects, Interfaces de Repositório
 ┗ 📂 Infrastructure  -> Acesso a dados, implementação de repositórios, serviços externos

 ⚡ Tecnologias Utilizadas

.NET 8

C#

Entity Framework Core

SQL Server / Oracle (configurável via appsettings.json)

Swagger para documentação de API

📄 Endpoints Principais
Usuários

GET /usuarios – Listar todos os usuários

GET /usuarios/{id} – Buscar usuário por ID

POST /usuarios – Criar novo usuário

PUT /usuarios/{id} – Atualizar usuário

DELETE /usuarios/{id} – Remover usuário

Motos

GET /motos – Listar todas as motos

GET /motos/{id} – Buscar moto por ID

POST /motos – Criar nova moto

PUT /motos/{id} – Atualizar moto

DELETE /motos/{id} – Remover moto

Serviços

GET /servicos – Listar todos os serviços

GET /servicos/{id} – Buscar serviço por ID

POST /servicos – Criar novo serviço

PUT /servicos/{id} – Atualizar serviço

DELETE /servicos/{id} – Remover serviço

🚀 Como Executar Localmente

Clone o repositório

git clone https://github.com/igorbarrocal/MotoFacilAPI.git
cd MotoFacilAPI


Configurar string de conexão
No appsettings.json ou via variável de ambiente:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=MotoFacilDB;User Id=sa;Password=your_password;"
}


Aplicar Migrations e criar o banco de dados

dotnet ef database update --project src/Infrastructure/Infrastructure.csproj


Executar a API

dotnet run --project src/Api/Api.csproj


Acessar Swagger

Abra no navegador:

https://localhost:5106/swagger
