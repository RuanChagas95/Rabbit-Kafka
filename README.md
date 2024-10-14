# RabbitMQ and Kafka Learning Project

## Descrição

Este projeto tem como objetivo aprender e explorar o RabbitMQ, um sistema de mensagens amplamente utilizado para comunicação entre serviços em aplicações distribuídas.

## Testando o Projeto

1 - Execute o docker compose
```bash
docker-compose up -D --build
```
2 - Acesse a porta `3000` na rota `/swagger`: [http://localhost:3000/swagger](http://localhost:3000/swagger)

3 - Escolha a rota e clique em `Try it out` altere o body caso deseje e clique em Execute para ver o resultado

## Rotas

### 1. Enviar Mensagem

**Endpoint:** `/RabbitMQ/send`  
**Método:** `POST`

#### Descrição
Este endpoint permite enviar uma mensagem para a fila RabbitMQ.

#### Requisição

**Corpo da Requisição:**
O corpo da requisição deve conter uma string JSON representando a mensagem a ser enviada.

```json
"Sua mensagem aqui"
```
### 2. Receber Mensagem
**Endpoint**: `/RabbitMQ/receive`
**Método:** `GET`

#### Descrição
Este endpoint permite receber uma lista com até 3 mensagens da fila RabbitMQ.