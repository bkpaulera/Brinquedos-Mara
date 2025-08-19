# Brinquedos Mara

Brinquedos Mara - Brinquedos Educativos e Pedagógicos

## Descrição
Brinquedos Mara é uma API desenvolvida para gerenciar um catálogo de brinquedos educativos e pedagógicos. O objetivo é facilitar o cadastro, consulta, atualização e remoção de produtos, promovendo o acesso a brinquedos que estimulam o desenvolvimento infantil.

## Tecnologias Utilizadas
- .NET 8
- C# 12
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- xUnit (Testes)

## Estrutura do Projeto
- **Controllers**: Camada responsável por expor os endpoints da API.
- **Service**: Camada de regras de negócio e orquestração das operações.
- **Repository**: Camada de persistência e acesso ao banco de dados.
- **Models**: Entidades e objetos de domínio.
- **Requests/Responses**: Objetos para entrada e saída de dados.
- **Infra**: Configuração do contexto de banco de dados.
- **Tests**: Testes de integração e unidade.

## Endpoints Principais
- `GET /api/produto` - Lista todos os produtos
- `GET /api/produto/{id}` - Consulta produto por ID
- `POST /api/produto` - Cria novo produto
- `PUT /api/produto/{id}` - Atualiza produto existente
- `DELETE /api/produto/{id}` - Remove produto

## Como Executar
1. Configure a string de conexão no arquivo de configuração para o SQL Server.
2. Execute as migrações do Entity Framework para criar o banco de dados.
3. Inicie o projeto principal (BrinquedosMara).
4. Utilize ferramentas como Postman ou o arquivo BrinquedosMara.http para testar os endpoints.

## Testes
- Testes de unidade e integração disponíveis no projeto `BrinquedosMara.Tests.Integration`.
- Os testes de integração sobem a API em memória e validam todos os endpoints principais.

## Frontend
Acesse o frontend da aplicação em: [https://brinquedos-angular.vercel.app/home](https://brinquedos-angular.vercel.app/home)

O código-fonte do frontend está disponível em: [https://github.com/bkpaulera/brinquedos-angular](https://github.com/bkpaulera/brinquedos-angular)

## Objetivo
Promover o acesso a brinquedos educativos e pedagógicos, facilitando o gerenciamento do catálogo para escolas, pais e educadores.