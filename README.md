# Desafio .NET: sistema de estacionamento

[![Build e testes](https://github.com/erkmnasc/trilha-net-fundamentos-desafio/actions/workflows/ci.yml/badge.svg)](https://github.com/erkmnasc/trilha-net-fundamentos-desafio/actions/workflows/ci.yml)

Minha solução do desafio de projeto da trilha .NET Fundamentos da DIO, com
testes unitários em xUnit.

## O que foi feito

- Classe `Estacionamento` completa: cadastro com validação de placa (padrão
  antigo `ABC-1234` e Mercosul `ABC1D23`), remoção com cálculo do valor
  (preço inicial + preço por hora × horas) e listagem.
- Menu interativo no `Program.cs`, que também funciona com a entrada
  redirecionada (útil para rodar em script ou no CI).
- Projeto `DesafioFundamentos.Tests` com 11 testes: placas válidas e
  inválidas, cálculo do valor, horas inválidas, veículo inexistente e
  remoção da lista.

## Como rodar

Precisa do .NET 8 SDK.

```bash
dotnet run --project DesafioFundamentos   # abre o menu
dotnet test                               # roda os testes
```

## CI

O GitHub Actions compila e roda os testes a cada push na `main`, em pull
requests, manualmente e toda segunda-feira (`.github/workflows/ci.yml`).

---

## Enunciado original
### DIO - Trilha .NET - Fundamentos
www.dio.me

## Desafio de projeto
Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de fundamentos, da trilha .NET da DIO.

## Contexto
Você foi contratado para construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

## Proposta
Você precisará construir uma classe chamada "Estacionamento", conforme o diagrama abaixo:
![Diagrama de classe estacionamento](diagrama_classe_estacionamento.png)

A classe contém três variáveis, sendo:

**precoInicial**: Tipo decimal. É o preço cobrado para deixar seu veículo estacionado.

**precoPorHora**: Tipo decimal. É o preço por hora que o veículo permanecer estacionado.

**veiculos**: É uma lista de string, representando uma coleção de veículos estacionados. Contém apenas a placa do veículo.

A classe contém três métodos, sendo:

**AdicionarVeiculo**: Método responsável por receber uma placa digitada pelo usuário e guardar na variável **veiculos**.

**RemoverVeiculo**: Método responsável por verificar se um determinado veículo está estacionado, e caso positivo, irá pedir a quantidade de horas que ele permaneceu no estacionamento. Após isso, realiza o seguinte cálculo: **precoInicial** * **precoPorHora**, exibindo para o usuário.

**ListarVeiculos**: Lista todos os veículos presentes atualmente no estacionamento. Caso não haja nenhum, exibir a mensagem "Não há veículos estacionados".

Por último, deverá ser feito um menu interativo com as seguintes ações implementadas:
1. Cadastrar veículo
2. Remover veículo
3. Listar veículos
4. Encerrar


## Solução
O código está pela metade, e você deverá dar continuidade obedecendo as regras descritas acima, para que no final, tenhamos um programa funcional. Procure pela palavra comentada "TODO" no código, em seguida, implemente conforme as regras acima.
