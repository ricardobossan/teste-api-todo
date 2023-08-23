# Kobold.TodoApp

## Documentação do Projeto

### Como rodar a aplicação

#### Passo 1. Conferir Requisitos 

Devem estar instalados:

- [Docker](https://www.docker.com/)
- [Postman](https://postman.com/)
- [Visual Studio 2019+ (Dá suporte a docker-compose)](https://visualstudio.microsoft.com/pt-br/)

#### Passo 2. Executar docker-compose

##### Opção 1: Visual Studio (Recomendada)

Esta opção é recomendada porque resolve geração de certificados.

Simplesmente abra o projeto no Visual Studio e aperte `F5`, responda que sim para as opções de gerar certificados e aguardo a janela do navegador aparecer.

##### Opção 2: Linha de comando

```bash 
cd $RAIZ_DO_PROJETO/src/Kobold.TodoApp.Api
docker-compose up
```

#### Passo 3. Faça requisições com Postman

1. Descubra o endpoint da requisição:
  - **Se executou pelo Visual Studio (opção 1)**, Copie o endereço do navegador, sem o trecho final (todoapp), e.g., `https://localhost:NUMERO_DA_PORTA/`
  - **Se executou pela linha de comando**, no terminal, digite `docker-ps` e veja o número da porta que aparece ao lado do container `teste-api-todo`, e.g.:
abaixo é `59115`:

  ```markdown
  faf7aa23c9e8   koboldtodoappapi   "dotnet Kobold.TodoA…"   13 minutes ago   Up 13 minutes   0.0.0.0:59116->80/tcp, 0.0.0.0:**59115**->443/tcp   teste-api-todo-kobold.todoapp.api-1`
  ```

2. Abra o postman;
3. Faça requisições para localhost, na porta descoberta no passo2, item 1 (anterior a este), e.g., `https://localhost:NUMERO_DA_PORTA/`, acrescentando ao final `todo`, para consultar todos sem agrupamento, ou `todo/collections`, para consultar por agrupamentos.

### Desenvolvimento

#### Análise (Capture)

#### Requisitos (Configure)

##### RNF

###### Necessários

- ORM
- API

###### Opcionais

- Repositório público no GitHub
- Banco de dados em container docker
- Interface Web

##### RF

###### Necessários

- Agrupamento em grupos/categorias;
- As categorias são `Todo` and `Done`;
- Cada tarefa só pertence a uma categoria.

###### Opcionais

- Tratamento de mensagens de erro para usuário;

#### Implementação (Control)

1. ORM
2. API agrupando por `coleções`:
  2.1. É agregado de `Todos`. Ficará no mesmo controlador.
3. Trata erros 
4. banco no docker (branch: docker)
5. teste unitário 
6. view com viewmodel

## Documentação do Desafio

### Introdução

Este repositório define uma web API para gerenciamento de tarefas. O código fonte está organizado da seguinte forma:

* Controllers:
* Models:
* Services:
* run.sh: arquivo de inicialização da aplicação.

    Para iniciar a aplicação execute o comando:

    ```
    > dotnet run -p src/Kobold.TodoApp.Api
    ```

    ### Exercício

    O exercício é composto de duas partes, a primeira obrigatória e a segunda opcional.

    #### Parte I

    Altere o código da aplicação, implementando um mecanismo de agrupamento das tarefas (definidas pela classe `Todo`) em coleções, expondo as novas funcionalidades implementadas para consumo na web API.

    #### Parte II

    A aplicação não define um mecanismo de tratamento de erros, e exceções no processamento são expostas na resposta ao usuário. Implementar mecanismo de tratamento de erros na aplicação, de forma que as respostas apresentadas ao usuário não exponham detalhes da aplicação, e apresentem mensagens claras.

    ### Avaliação

    No processo de avaliação do código, avaliaremos as seguintes características:
* Aderência da implementação ao código existente.
* Clareza do código implementado.
* Documentação das alterações efetuadas.
* Estrutura das mensagens de commit.

    A solução para o problema não é única. O candidato deve analisar o código existente, definir as funcionalidades a serem implementadas e implementa-las. A avaliação da solução apresentada será realizada em conversa com o candidato, com o objetivo de entender o processo de análise e tomada de decisões que levou àquela solução.
