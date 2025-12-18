using System;
using System.Collections.Generic;
using System.Text;

namespace Beyond.Shared
{
    public class DelegatesYLambdas
    {
        class DelegateTRadicional
        {
            // 1: Definimos un delegado
            public delegate void NumeroNaturalDelegate(int i);

            // 2: Creamos un método compatible con el delegado
            public void ImprimirNumero(int i)
            {
                Console.WriteLine($"El número natural es: {i}");
            }

            // 3 y 4: Método que instancia e invoca el delegado
            public void EjecutarDelegado()
            {
                // 3: Instanciamos el delegado
                NumeroNaturalDelegate numeroNaturalDelegate = ImprimirNumero;

                // 4: Invocamos el delegado
                numeroNaturalDelegate(5);
            }
        }
        // Uso:
        //var ejemplo = new DelegadoTradicional();
        //ejemplo.Ejecutar(); // Output: El número natural es: 5

        class ExpresionLambda
        {
            // 1: Definimos un delegado
            public delegate void NumeroNaturalDelegate(int i);

            // 2: Método que usa expresión lambda
            public void Ejecutar()
            {
                // Creamos una expresión lambda compatible con el delegado
                NumeroNaturalDelegate numeroNaturalDelegate = i => Console.WriteLine($"El número natural es: {i}");

                // 3: Invocamos el delegado
                numeroNaturalDelegate(10);
            }
        }

        // Uso:
        //var ejemplo = new ExpresionLambda();
        //ejemplo.Ejecutar(); // Output: El número natural es: 10

    }
}
