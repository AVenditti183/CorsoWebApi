using System;

namespace DelegateSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var e = new Esempio();
            e.OnChange += E_OnChange;
            e.Esegui(Codice,Codice2,Codice3,Codice4);
           
        }

        private static void E_OnChange(object sender, int e)
        {
           Console.WriteLine("Qualcosa è cambiato");
            var s = (Esempio) sender;
            Console.WriteLine(s.counter);
            Console.WriteLine(e);
        }

        static void Codice()
        {
            Console.WriteLine("Code 1");
        }

        static void Codice2(int numero)
        {
            Console.WriteLine(numero);
        }

        static int Codice3()
        {
            return 5;
        }

        static int Codice4(int numero)
        {
            return numero +1;
        }
    }

    class Esempio
    {
        public int counter;
        public event EventHandler<int> OnChange;
        public void Esegui(Action del,Action<int> del2,Func<int> del3,Func<int,int> del4)
        {
            Console.WriteLine("Prima di eseguire il delegate");
            counter =del3.Invoke();
            counter = del4.Invoke(counter);
            del.Invoke();
            del2.Invoke(counter);

            OnChange?.Invoke(this,counter);
            Console.WriteLine("Dopo di esecuzione del delegate");
        }
    }
}
