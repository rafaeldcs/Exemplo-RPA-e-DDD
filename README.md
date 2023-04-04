# Variação do Ativo

## Backend
1. Foi utilizado a api https://query2.finance.yahoo.com/v8/finance/chart/PETR4.SA para consultas do ativo
2. Esta sendo armazenado ao banco, após realizar a consulta dos dados do ativo.
3. Todo o backend foi preparado utilizando metodologias de clean code e entityFramework
4. Banco de dados utilizado foi o SQL Server
5. Foi implementado o TDD simples para alguns testes em questões de consulta e campo null ou empty
6. Todo o sistema esta em .NET 7.0
7. Sistema foi criado com modelo de injeção de dependencia(Respeitando as camadas de interface e camadas de execução)

## Front-end
1. Foi utilizado javascript, jquery, html, bootstrap, ajax e CanvasJS para criação dos gráficos
2. O Ajax foi utilizado para consultas ao back-end
3. Foram utilizadas partialView para criação de grid para trazer os dados de cada dia do mês do ativo

## Como Rodar
1. É necessário o download do SQL Server, Visual Studio e o .Net 7.0 para a utilização do sistema
2. Clonar o projeto no github
3. Rodar o sql da tabela de Ativos que está na pasta sql dentro da pasta do projeto
4. Rode o sistema
5. Digite o nome do ativo e clique no botão de "Consultar"
6. Será trago o histórico dia a dia e também um gráfico mostrando a evolução do ativo no prazo de 1 mês
