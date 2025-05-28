# ConsoleFinance

ConsoleFinance é um sistema bancário simples em console, feito em C# para demonstrar conceitos de Programação Orientada a Objetos e uso de Git.

## Pré-requisitos

* .NET SDK (versão 6.0 ou superior)
* Visual Studio, VS Code ou qualquer editor de sua preferência

## Como rodar

1. Clone este repositório:

   ```bash
   git clone https://github.com/SEU_USUARIO/ConsoleFinance.git
   ```
2. Entre na pasta do projeto:

   ```bash
   cd ConsoleFinance/ConsoleFinance
   ```
3. Rode a aplicação:

   ```bash
   dotnet run
   ```

## Funcionalidades

* Cadastrar conta com número, nome do titular e CPF
* Listar todas as contas cadastradas
* Realizar depósito em contas existentes
* Realizar saque (com verificação de saldo)
* Exibir histórico de transações de cada conta

## Estrutura do projeto

* **Models/**: define as classes `Cliente` e `Conta`
* **Services/**: contém a classe `Banco`, responsável por gerenciar as contas
* **Program.cs**: menu interativo e chamada dos métodos de cadastro e operações

## Uso básico

1. Ao executar, será exibido um menu com opções numeradas.
2. Digite o número da opção desejada e siga as instruções na tela.
3. Para sair, escolha a opção `0`.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.
