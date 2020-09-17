using System;
using System.Collections.Generic;

namespace Parentização_Pilha
{
    class Program
    {
        static void Main(string[] args)
        {
            string aux;
            Stack<string> parents = new Stack<string>(); ;

            bool valida = true;
            bool valida2 = true;
            string x = "sim";

            while(x.ToUpper() == "SIM")
            {
                Console.Clear();
                Console.WriteLine("\tParentização");
                Console.Write("Informe a expressão aritmetica: ");
                aux = Console.ReadLine();

                for (int i = 0; i < aux.Length; i++)
                {
                    if ((aux[i] == ')'|| aux[i] == '}' || aux[i] == ']') && parents.Count == 0)
                        valida = false;
                    else
                    {
                        if (aux[i] == '{')
                        {
                            try
                            {
                                if (parents.Peek() == "(" || parents.Peek() == "[")
                                    valida2 = false;
                                else
                                    parents.Push(aux[i].ToString());
                            }
                            catch
                            {
                                parents.Push(aux[i].ToString());
                            }                         
                        }

                        if (aux[i] == '[')
                        {
                            try
                            {
                                if (parents.Peek() == "(")
                                    valida2 = false;
                                else
                                    parents.Push(aux[i].ToString());
                            }catch
                            {
                                parents.Push(aux[i].ToString());
                            }                                
                                                                                     
                        }

                        if (aux[i] == '(')
                            if (parents == null)
                            {
                                parents.Push(aux[i].ToString());
                            }else
                                parents.Push(aux[i].ToString());
                        
                        if (aux[i] == '}')
                        {
                            if (parents.Peek() == "{")
                                parents.Pop();
                            else if (parents.Count > 1)
                                valida2 = false;


                        }
                        if (aux[i] == ']')
                        {
                            if (parents.Peek() == "[")
                                parents.Pop();
                            else if(parents.Count > 1)
                                valida2 = false;
                        }
                        if (aux[i] == ')')
                        {
                            if (parents.Peek() == "(")
                                parents.Pop();
                            else if (parents.Count > 1)
                                valida2 = false;
                        }
                    }
                }
                if (parents.Count == 0)
                    valida = true;
                else
                    valida = false;

                if(valida == true && valida2 == true)
                    Console.WriteLine("Expressao valida");
                else
                    Console.WriteLine("Expressao invalida");
                parents.Clear();
                Console.WriteLine("\nDeseja verificar outra expressão?? (sim/nao)");
                x = Console.ReadLine();
                valida = true;
                valida2 = true;
            }
            
        }
    }
}
