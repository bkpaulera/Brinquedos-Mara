# Brinquedos Mara

Brinquedos Mara - Brinquedos Educativos e Pedag�gicos

## Descri��o
Brinquedos Mara � uma API desenvolvida para gerenciar um cat�logo de brinquedos educativos e pedag�gicos. O objetivo � facilitar o cadastro, consulta, atualiza��o e remo��o de produtos, promovendo o acesso a brinquedos que estimulam o desenvolvimento infantil.

## Tecnologias Utilizadas
- .NET 8
- C# 12
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- xUnit (Testes)

## Estrutura do Projeto
- **Controllers**: Camada respons�vel por expor os endpoints da API.
- **Service**: Camada de regras de neg�cio e orquestra��o das opera��es.
- **Repository**: Camada de persist�ncia e acesso ao banco de dados.
- **Models**: Entidades e objetos de dom�nio.
- **Requests/Responses**: Objetos para entrada e sa�da de dados.
- **Infra**: Configura��o do contexto de banco de dados.
- **Tests**: Testes de integra��o e unidade.

## Endpoints Principais
- `GET /api/produto` - Lista todos os produtos
- `GET /api/produto/{id}` - Consulta produto por ID
- `POST /api/produto` - Cria novo produto
- `PUT /api/produto/{id}` - Atualiza produto existente
- `DELETE /api/produto/{id}` - Remove produto

## Como Executar
1. Configure a string de conex�o no arquivo de configura��o para o SQL Server.
2. Execute as migra��es do Entity Framework para criar o banco de dados.
3. Inicie o projeto principal (BrinquedosMara).
4. Utilize ferramentas como Postman ou o arquivo BrinquedosMara.http para testar os endpoints.

## Testes
- Testes de unidade e integra��o dispon�veis no projeto `BrinquedosMara.Tests.Integration`.
- Os testes de integra��o sobem a API em mem�ria e validam todos os endpoints principais.

## Frontend
Acesse o frontend da aplica��o em: [https://brinquedos-angular.vercel.app/home](https://brinquedos-angular.vercel.app/home)

O c�digo-fonte do frontend est� dispon�vel em: [https://github.com/bkpaulera/brinquedos-angular](https://github.com/bkpaulera/brinquedos-angular)

## Objetivo
Promover o acesso a brinquedos educativos e pedag�gicos, facilitando o gerenciamento do cat�logo para escolas, pais e educadores.