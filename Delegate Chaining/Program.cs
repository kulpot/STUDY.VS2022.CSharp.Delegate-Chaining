using System;
using System.Collections.Generic;

//ref link:https://www.youtube.com/watch?v=UZAZAV0rV8I&list=PLAE7FECFFFCBE1A54&index=5
// Delegate chaining mostly use for events, and the observer pattern

delegate void MeDelegate();

class MainClass
{
    static void Main() // Delegate -> MulticastDelegate -> MeDelegate
    {
        MeDelegate d = Foo;
        //MeDelegate oldD = d;
        /*d();
        d = Goo
        d();*/
        /*d += Goo;
        //d += Sue;
        //d += Foo; d -= Foo
        d();*/
        /*d = (MeDelegate)Delegate.Combine(d, new MeDelegate(Goo));
        d += Sue;
        d += Foo; d -= Foo;
        d();*/
        d = (MeDelegate)Delegate.Combine(d, new MeDelegate(Goo)); //MulticastDelegate
        //Console.WriteLine(object.ReferenceEquals(d.GetInvocationList())
        d += Sue;
        d += Foo; d -= Foo;
        foreach (MeDelegate m in d.GetInvocationList())
            Console.WriteLine(m.Target + ": " + m.Method);
        

    }
    static void Foo() { Console.WriteLine("Foo()"); }
    static void Goo() { Console.WriteLine("Goo()"); }
    static void Sue() { Console.WriteLine("Sue()"); }
}