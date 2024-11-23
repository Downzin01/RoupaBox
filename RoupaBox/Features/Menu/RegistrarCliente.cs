using RoupaBox.Features.Cadastro;
using RoupaBox.UI.Layout;
using RoupaBox.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RoupaBox.UI.Menus;

namespace RoupaBox.Features.Menu
{
    internal class RegistrarCliente
    {
        // Lista que armazena todos os clientes cadastrados
        List<CadastroCliente> listaClientes = new List<CadastroCliente>();

        // Método que realiza o cadastro de um cliente
        public CadastroCliente Registrar()
        {
            // Instanciação das classes auxiliares para cabeçalhos, validações e exibição
            Cabecalho cabecalho = new Cabecalho();
            MenuPrincipal menu = new MenuPrincipal();
            RegistarProduto variavelProduto = new RegistarProduto();
            Validador validar = new Validador();
            ExibirTabela exibirTabela = new ExibirTabela();
            Exibir exibir = new Exibir();
            LerEntrada lerEntrada = new LerEntrada();

            // Loop principal que permite registrar múltiplos clientes
            while (true)
            {
                // 1. Solicitação de dados do cliente
                // Inserir Nome Cliente
                string nomeCliente = lerEntrada.Validada<string>(
                    "\n» Digite o nome do cliente:",
                    validar.SomenteLetras,
                    "O nome não pode conter números ou caracteres especiais. Tente novamente!"
                );

                // Inserir CPF Cliente
                long cpfCliente = lerEntrada.Validada<long>(
                    "\n» Digite o CPF do cliente:",
                    validar.CPF,
                    "CPF inválido! Por favor, digite um CPF válido."
                );

                // Inserir Número de Telefone Cliente
                string telefoneCliente = lerEntrada.Validada<string>(
                    "\n» Digite o número de telefone do cliente:",
                    validar.Telefone,
                    "Telefone inválido! Por favor, digite um número válido."
                );

                // 2. Validação da Idade do Cliente
                int idadeCliente;
                do
                {
                    idadeCliente = lerEntrada.Numerica("\n» Digite a idade do cliente:", "Entrada inválida! Por favor, digite um número válido.");
                    if (idadeCliente < 0 || idadeCliente > 999)
                    {
                        exibir.Mensagem("A idade deve ser um número positivo e ter no máximo 3 dígitos.", TipoMensagem.Aviso);
                    }
                } while (idadeCliente < 0 || idadeCliente > 999);

                // Inserir Email Cliente
                string emailCliente = lerEntrada.Validada<string>(
                    "\n» Digite o e-mail do cliente:",
                    validar.Email,
                    "Email inválido! Por favor, digite um email válido"
                );

                // 3. Seleção de Sexo Cliente
                string sexoCliente = lerEntrada.SelecionarOpcao(
                    "\n» Selecione o sexo do cliente:",
                    new string[] { "Masculino", "Feminino", "Outro", "Prefiro não informar" }
                );

                // 4. Endereço e Localização do Cliente
                string enderecoCliente = lerEntrada.Validada<string>(
                    "\n» Digite o endereço do cliente:",
                    entrada => !string.IsNullOrWhiteSpace(entrada) && entrada.Any(char.IsLetter),
                    "Entrada inválida! Por favor, digite algo válido."
                );

                string complementoCliente = lerEntrada.Validada<string>(
                    "\n» Digite o complemento do endereço do cliente:",
                    entrada => !string.IsNullOrWhiteSpace(entrada) && entrada.Any(char.IsLetter),
                    "Entrada inválida! Por favor, digite algo válido."
                );

                int numeroCliente = lerEntrada.Numerica("\n» Digite o número da casa do cliente:", "Entrada inválida! Por favor, digite um número válido.");
                string bairroCliente = lerEntrada.Validada<string>(
                    "\n» Digite o bairro do cliente:",
                    entrada => !string.IsNullOrWhiteSpace(entrada) && entrada.Any(char.IsLetter),
                    "Entrada inválida! Por favor, digite algo válido."
                );

                string cidadeCliente = lerEntrada.Validada<string>(
                    "\n» Digite a cidade do cliente:",
                    entrada => !string.IsNullOrWhiteSpace(entrada) && entrada.Any(char.IsLetter),
                    "Entrada inválida! Por favor, digite algo válido."
                );

                // 5. Seleção do Estado Cliente
                string estadoClienteOpcao = lerEntrada.SelecionarOpcao(
                    "\n» Selecione o estado do cliente:",
                    new string[] {
                        "Acre", "Alagoas", "Amapá", "Amazonas", "Bahia", "Ceará", "Espírito Santo",
                        "Goiás", "Maranhão", "Mato Grosso", "Mato Grosso do Sul", "Minas Gerais",
                        "Pará", "Paraíba", "Paraná", "Pernambuco", "Piauí", "Rio de Janeiro", "Rio Grande do Norte",
                        "Rio Grande do Sul", "Rondônia", "Roraima", "Santa Catarina", "São Paulo", "Sergipe",
                        "Tocantins", "Distrito Federal"
                    }
                );

                // 6. Validação do CEP do Cliente
                Dictionary<string, string> estadosUF = new Dictionary<string, string>
                {
                    { "Acre", "AC" }, { "Alagoas", "AL" }, { "Amapá", "AP" }, { "Amazonas", "AM" }, { "Bahia", "BA" },
                    { "Ceará", "CE" }, { "Espírito Santo", "ES" }, { "Goiás", "GO" }, { "Maranhão", "MA" },
                    { "Mato Grosso", "MT" }, { "Mato Grosso do Sul", "MS" }, { "Minas Gerais", "MG" },
                    { "Pará", "PA" }, { "Paraíba", "PB" }, { "Paraná", "PR" }, { "Pernambuco", "PE" }, { "Piauí", "PI" },
                    { "Rio de Janeiro", "RJ" }, { "Rio Grande do Norte", "RN" }, { "Rio Grande do Sul", "RS" },
                    { "Rondônia", "RO" }, { "Roraima", "RR" }, { "Santa Catarina", "SC" }, { "São Paulo", "SP" },
                    { "Sergipe", "SE" }, { "Tocantins", "TO" }, { "Distrito Federal", "DF" }
                };

                // Converte o nome do estado para a UF
                string estadoCliente = estadosUF.ContainsKey(estadoClienteOpcao) ? estadosUF[estadoClienteOpcao] : "Estado Inválido";

                int cepCliente;
                do
                {
                    cepCliente = lerEntrada.Numerica("\n» Digite o CEP do endereço do cliente:", "Entrada inválida! Por favor, digite um número válido.");
                    if (cepCliente.ToString().Length != 8)
                    {
                        exibir.Mensagem("O CEP deve ser um número positivo e ter no máximo 8 dígitos", TipoMensagem.Aviso);
                    }
                } while (cepCliente.ToString().Length != 8);

                // 7. Criação do objeto Cliente com os dados coletados
                var Cliente = new CadastroCliente(cpfCliente)
                {
                    NomeCliente = nomeCliente,
                    IdadeCliente = idadeCliente,
                    SexoCliente = sexoCliente,
                    TelefoneCliente = telefoneCliente,
                    EmailCliente = emailCliente,
                    EnderecoCliente = enderecoCliente,
                    NumeroCLiente = numeroCliente,
                    ComplementoCliente = complementoCliente,
                    BairroCliente = bairroCliente,
                    CidadeCliente = cidadeCliente,
                    EstadoCliente = estadoCliente,
                    CepCliente = cepCliente
                };

                Console.Clear();

                // 8. Exibição dos dados do cliente
                exibirTabela.CadastroCliente(
                    cpfCliente, nomeCliente, idadeCliente, sexoCliente, telefoneCliente, emailCliente,
                    enderecoCliente, numeroCliente, complementoCliente, bairroCliente, cidadeCliente,
                    estadoClienteOpcao, cepCliente
                );

                // Adiciona o cliente à lista de clientes
                listaClientes.Add(Cliente);

                // 9. Pergunta ao usuário se deseja registrar outro cliente
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nDeseja registrar outro cliente? (S/N)");

                Console.ForegroundColor = ConsoleColor.White;
                string resposta = Console.ReadLine()?.Trim().ToLower();
                Console.ResetColor();

                if (resposta == "s")
                {
                    Registrar();
                    return Cliente; // Retorna o cliente registrado
                }
                else
                {
                    exibir.Mensagem("Retornando ao menu...", TipoMensagem.Sistema);
                    Thread.Sleep(2000);
                    Console.Clear();

                    cabecalho.Principal();
                    menu.ExibirMenu(variavelProduto, this);

                    return Cliente; // Retorna o cliente registrado
                }
            }
        }

        public void ExibirListaClientes()
        {
            // Instanciações de objetos auxiliares necessários para exibição
            ExibirTabela exibirTabela = new ExibirTabela();
            Exibir exibir = new Exibir();
            RegistarProduto variavelProduto = new RegistarProduto();
            Cabecalho cabecalho = new Cabecalho();
            MenuPrincipal menu = new MenuPrincipal();

            // Verifica se a lista de clientes está vazia
            if (listaClientes.Count == 0)
            {
                Console.Clear();
                exibir.Mensagem("Nenhum cliente cadastrado.", TipoMensagem.Aviso); // Mensagem de aviso
                Console.Clear();
                exibir.Mensagem("Retornando ao menu...", TipoMensagem.Sistema); // Mensagem de retorno ao menu
                Console.Clear();

                // Exibe o cabeçalho e retorna ao menu principal
                cabecalho.Principal();
                menu.ExibirMenu(variavelProduto, this);
            }
            else
            {
                // Configura as cores do console para exibição
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.Black;

                // Exibição do cabeçalho visual do sistema
                cabecalho.ListaClientes();

                // Itera sobre a lista de clientes e exibe suas informações
                foreach (var cliente in listaClientes)
                {
                    exibirTabela.ListaCliente(
                        cliente.CPFcliente,
                        cliente.NomeCliente,
                        cliente.IdadeCliente,
                        cliente.SexoCliente,
                        cliente.TelefoneCliente,
                        cliente.EmailCliente,
                        cliente.EnderecoCliente,
                        cliente.NumeroCLiente,
                        cliente.ComplementoCliente,
                        cliente.BairroCliente,
                        cliente.CidadeCliente,
                        cliente.EstadoCliente,
                        cliente.CepCliente
                    );
                }

                // Instrução ao usuário para retornar ao menu
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n» Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                Console.ResetColor();

                // Mensagem de retorno ao menu
                exibir.Mensagem("Retornando ao menu...", TipoMensagem.Sistema);
                Console.Clear();

                // Exibe o cabeçalho e retorna ao menu principal
                cabecalho.Principal();
                menu.ExibirMenu(variavelProduto, this);
            }
        }
    }
}
