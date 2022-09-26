using EstruturaPilha.Entidades;
using System;
using System.Linq;

namespace EstruturaPilha
{
    class Program
    {
        const int tamanhoMaximoContainer = 3;
        static PilhaEstatica patioContainer1 { get; set; }
        static PilhaEstatica patioContainer2 { get; set; }
        static PilhaEstatica patioContainer3 { get; set; }
        static PilhaEstatica patioContainer4 { get; set; }

        static void Main(string[] args)
        {
            patioContainer1 = new PilhaEstatica(tamanhoMaximoContainer);
            patioContainer2 = new PilhaEstatica(tamanhoMaximoContainer);
            patioContainer3 = new PilhaEstatica(tamanhoMaximoContainer);
            patioContainer4 = new PilhaEstatica(tamanhoMaximoContainer);
            Menu();
        }

        static void PrintarMenu(){
            Console.WriteLine("**********************************");
            Console.WriteLine("* Bem vindo ao TDE de Pilhas!    *");
            Console.WriteLine("*                                *");
            Console.WriteLine("*                                *");
            Console.WriteLine("*                                *");
            Console.WriteLine("*                                *");
            Console.WriteLine("*                                *");
            Console.WriteLine("* 1 - Inserir Container          *");
            Console.WriteLine("* 2 - Remover Container          *");
            Console.WriteLine("* 3 - Listar Patios              *");
            Console.WriteLine("* 9 - Sair                       *");
            Console.WriteLine("*                                *");
            Console.WriteLine("*                                *");
            Console.WriteLine("*                                *");
            Console.WriteLine("**********************************");
        }

        static void PrintarPatios()
        {
            var containersPatio1 = patioContainer1.RetornaTodosElementos().Reverse();
            var containersPatio2 = patioContainer2.RetornaTodosElementos().Reverse();
            var containersPatio3 = patioContainer3.RetornaTodosElementos().Reverse();
            var containersPatio4 = patioContainer4.RetornaTodosElementos().Reverse();

            Console.WriteLine("**********************************");
            Console.WriteLine("Patio 1: ");
            foreach(var container in containersPatio1){
                Console.WriteLine($"{container}");
            }

            Console.WriteLine("**********************************");
            Console.WriteLine("Patio 2: ");
            foreach(var container in containersPatio2){
                Console.WriteLine($"{container}");
            }

            Console.WriteLine("**********************************");
            Console.WriteLine("Patio 3: ");
            foreach(var container in containersPatio3){
                Console.WriteLine($"{container}");
            }

            Console.WriteLine("**********************************");
            Console.WriteLine("Patio 4: ");
            foreach(var container in containersPatio4){
                Console.WriteLine($"{container}");
            }
                      
            Console.WriteLine("**********************************");
        }

        static void Menu(){
            int opcao;
            do
            {
                PrintarMenu();
                Console.Write("Digite a ação desejada: ");
                if(int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao){
                        case 1:
                            InserirContainer();
                            break;
                        case 2:
                            RemoverContainer();
                            break;
                        case 3:
                            PrintarPatios();
                            break;
                        case 9:
                            break;
                        default:
                            Console.WriteLine("Valor inválido! Digite um valor valido");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Valor inválido! Digite um valor valido");
                }

                Console.WriteLine("Digite ENTER para continuar");
                Console.ReadLine();
                Console.Clear();
            } while(opcao != 9);

            Console.WriteLine("Pressione ENTER para sair");
            Console.ReadLine();
        }

        static void InserirContainer(){
            Console.Clear();
            Console.WriteLine("Digite o codigo do container: ");
            string codigoContainer = Console.ReadLine().ToUpper();

            Console.Clear();

            if(PatiosEstaoCheios()){
                Console.WriteLine("Impossível empilhar!");
                Console.WriteLine("Pressione ENTER para continuar");
                Console.Read();
                return;
            }

            if(ExisteContainer(codigoContainer)){
                Console.WriteLine("Codigo Invalido!");
                Console.WriteLine("Pressione ENTER para continuar");
                Console.Read();
                return;
            }

            RetornarMenorPatio().Empilha(codigoContainer);
            PrintarPatios();
        }

        static void RemoverContainer(){
            Console.Clear();
            Console.WriteLine("Digite o codigo do container: ");
            string codigoContainer = Console.ReadLine().ToUpper();

            Console.Clear();

            if(!ExisteContainer(codigoContainer)){
                Console.WriteLine("Impossível desempilhar!");
                Console.WriteLine("Pressione ENTER para continuar");
                Console.Read();
                return;
            }

            if(patioContainer1.Topo() == codigoContainer){
                patioContainer1.Desempilha();
            }
            else if(patioContainer2.Topo() == codigoContainer){
                patioContainer2.Desempilha();
            }
            else if(patioContainer3.Topo() == codigoContainer){
                patioContainer3.Desempilha();
            }
            else if(patioContainer4.Topo() == codigoContainer){
                patioContainer4.Desempilha();
            }
            else{
                Console.WriteLine("Impossível Desempilhar");
                return;
            }

            PrintarPatios();
            Console.WriteLine("Pressione ENTER para continuar");
            Console.Read();
        }

        static PilhaEstatica RetornarMenorPatio(){
            var patioMaisVazio = patioContainer1;

            if(patioMaisVazio.Tamanho() > patioContainer2.Tamanho())
                patioMaisVazio = patioContainer2;

            if(patioMaisVazio.Tamanho() > patioContainer3.Tamanho())
                patioMaisVazio = patioContainer3;

            if(patioMaisVazio.Tamanho() > patioContainer4.Tamanho())
                patioMaisVazio = patioContainer4;

            return patioMaisVazio;
        }

        static bool ExisteContainer(string codigoContainer){
            var containersPatio1 = patioContainer1.RetornaTodosElementos();
            var containersPatio2 = patioContainer2.RetornaTodosElementos();
            var containersPatio3 = patioContainer3.RetornaTodosElementos();
            var containersPatio4 = patioContainer4.RetornaTodosElementos(); 

            if(containersPatio1.Contains(codigoContainer))
                return true;
            
            if(containersPatio2.Contains(codigoContainer))
                return true;

            if(containersPatio3.Contains(codigoContainer))
                return true;

            if(containersPatio4.Contains(codigoContainer))
                return true;

            return false;
        }

        static bool PatiosEstaoCheios(){
            return patioContainer1.EstaCheia() 
            && patioContainer2.EstaCheia() 
            && patioContainer3.EstaCheia() 
            && patioContainer4.EstaCheia();  
        }
    }
}
