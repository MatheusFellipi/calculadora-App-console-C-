using System;

namespace Calculator
{
  enum EOperacaoMatematica
  {
    Soma = 1,
    Divisão = 2,
    Subtração = 3,
    Multiplicaçao = 4,
    sair = -1
  }

  class Program
  {

    static void Main(string[] args)
    {
      Console.Clear();
      Menu();
    }
    static void Menu()
    {
      bool sair = true;
      while (sair)
      {
        Console.WriteLine("Qual e a operação de deseja??");
        Console.WriteLine("1 - Soma");
        Console.WriteLine("2 - Divisão");
        Console.WriteLine("3 - Subtração");
        Console.WriteLine("4 - Multiplicaçao");
        Console.WriteLine("-1 - Sair da aplicação");
        Console.WriteLine("---------------------");

        bool opcaoInvalida = false;
        bool menuSair = true;
        int opcao;
        Console.WriteLine("Selecione um opção:");
        opcao = int.Parse(Console.ReadLine());

        Console.WriteLine("---------------------");
        float? res = null;

        if (opcao == -1)
        {
          sair = false;
          return;

        }
        while (opcao != -1 && opcao != -2 && menuSair)
        {
          float valorN1;
          float valorN2;
          try
          {
            Console.WriteLine("Primeiro valor: ");
            valorN1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Segundo valor: ");
            valorN2 = float.Parse(Console.ReadLine());
            Console.WriteLine("---------------------");
          }
          catch
          {
            valorN1 = 0;
            valorN2 = 0;
            opcao = -2;
            menuSair = false;
            Console.WriteLine("Entre com um valor");

          }

          switch (opcao)
          {
            case (int)EOperacaoMatematica.Soma:
              res = Soma(valorN1, valorN2);
              Console.WriteLine($"Resultado da soma é: {res}");
              break;
            case (int)EOperacaoMatematica.Divisão:
              try
              {
                res = Divisao(valorN1, valorN2);
                Console.WriteLine($"Resultado da divisão é: {res}");
              }
              catch (DivideByZeroException)
              {
                Console.WriteLine("Nao e permitido divisão com 0");
              }
              break;
            case (int)EOperacaoMatematica.Subtração:
              res = Subtracao(valorN1, valorN2);
              Console.WriteLine($"Resultado da Subtracão é: {res}");
              break;
            case (int)EOperacaoMatematica.Multiplicaçao:
              res = Multiplicacao(valorN1, valorN2);
              Console.WriteLine($"Resultado da Multiplicacão é: {res}");
              break;
            case (int)EOperacaoMatematica.sair:
              sair = false;
              break;
            default:
              Console.WriteLine("selecione um opcao valida");
              opcao = -1;
              menuSair = false;
              opcaoInvalida = true;
              break;
          }

          if (!opcaoInvalida)
          {
            Console.WriteLine("---------------------");
            Console.WriteLine("Se deseja volta para o Menu - -2");
            Console.WriteLine("Se deseja sair - -1");
            opcao = int.Parse(Console.ReadLine());
            if (opcao == -1)
            {
              sair = false;
            }
          }
        }
      }

    }
    static float Soma(float valorN1, float valorN2)
    {
      return valorN1 + valorN2;
    }

    static float Subtracao(float valorN1, float valorN2)
    {
      return valorN1 - valorN2;
    }

    static float Divisao(float valorN1, float valorN2)
    {
      if (valorN2 == 0)
        throw new DivideByZeroException();

      return valorN1 / valorN2;
    }
    static float Multiplicacao(float valorN1, float valorN2)
    {
      return valorN1 * valorN2;
    }
  }
}
