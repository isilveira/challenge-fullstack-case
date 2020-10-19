# FullStack Challenge
Architecture CQRS FullLIB + DDD + MediatR + ModelWrapper + FluentValidation + Specification Pattern

BackEnd: C# + WebAPI + .NET Core + EntityFrameworkCore + MSSQL

FrontEnd: Angular + Bootstrap

### Requisitos
Esse projeto requer [.NET Core SDK 3.1.403] e [Node.js v12.19.0]

### Banco de dados
Esse projeto utiliza o MSSQL e sua string de conexão está configurada para usar o (localdb)\\mssqllocaldb como servidor de banco. Caso o projeto seja executado com o Visual Studio não é necessara alteração.
Caso não exista instalação do Visual Studio na maquina pode ser necessária instalação e/ou configuração de um banco de dados (Ex: MSSQL Express) e a alteração da string de conexão para o servidor configurado.
O projeto foi feito usando Code-First e Migrations então na primeira execução a base de dados e as tabelas serão criadas caso elas não existam.

appsettings.json
```
"Server=(localdb)\\mssqllocaldb;Database=EducationDB;Trusted_Connection=True;MultipleActiveResultSets=true"
```

### Execução via VisualStudio
Para o desenvolvimento do projeto foi usado o Visual Studio Community 2019.
Basta abrir a solution com o Visual Studio restaurar os pacotes e Iniciar o Projeto.

### Execução via CMD
Abra o prompt de comando na pasta da Solution e execute os comandos abaixo.

``` cmd
C:\...\challenge-fullstack-case> dotnet build
C:\...\challenge-fullstack-case> dotnet test 
C:\...\challenge-fullstack-case> dotnet run --project src/Education.Presentations.Web.SpaAngular
```

[.NET Core SDK 3.1.403]: <https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.403-windows-x64-installer>
[Node.js v12.19.0]: <https://nodejs.org/dist/v12.19.0/node-v12.19.0-x64.msi>
