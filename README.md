# DevelopmentChallenge







O projeto foi refatorado obedecendo os conceitos de Orientação a Objetos, bem como os 

padrões de código SOLID. A combinação dessas técnicas de programação tornaram o projeto

mais escalável, com código mais coeso e simples de entender.



Alguns pontos a serem ressaltados:





Uso de classes abstratas e de Polimorfismo



Antes o programa estava totalmente centralizado em uma classe principal,

FormaGeometrica.cs e toda a lógica concentrada na mesma classe.



Princípios SOLID



1)Para reduzir o volume de funções na mesma classe , apliquei um dos conceitos

SOLID , o Princípio de Responsabilidade Única (sigla S) , que consiste em

reduzir a complexidade de um método , dividindo as responsabilidades em diferentes classes



2)Código aberto para extensão e fechado para modificação (Princípio OCP do SOLID).

Isso pode ser notado na classe refatorada FormaGeométrica , que herda métodos genéricos

da interface IFormaGeometrica que podem ser extendidos pelos objetos Cuadrado, Triangulo, Circulo , etc.





3\) Abstração , Polimorfismo , Herança e Encapsulamento



É possível as aplicações destes conceitos em praticamente todas as classes criadas:



Ex: 



public abstract class FormaGeometrica : IFormaGeometrica

{

&nbsp;   public abstract decimal CalcularArea();

&nbsp;   public abstract decimal CalcularPerimetro();

&nbsp;   public abstract string NomeForma(SupportedLanguage idioma, int quantidade);



}



Exemplo de classe que adota o polimorfismo e herança:





public class Cuadrado : FormaGeometrica

{

&nbsp;   private readonly decimal \_lado;



&nbsp;   public Cuadrado(decimal lado) => \_lado = lado;

&nbsp;   public override decimal CalcularArea() => \_lado \* \_lado;



&nbsp;   public override decimal CalcularPerimetro() => \_lado \* 4;



&nbsp;   public override string NomeForma(SupportedLanguage idioma, int quantidade)

&nbsp;   {



&nbsp;       switch (idioma)

&nbsp;       {

&nbsp;           case SupportedLanguage.Castellano:

&nbsp;               return quantidade == 1 ? "Cuadrado" : "Cuadrados";

&nbsp;           case SupportedLanguage.Ingles:

&nbsp;               return quantidade == 1 ? "Square" : "Squares";

&nbsp;           case SupportedLanguage.Italiano:

&nbsp;               return quantidade == 1 ? "Quadrato" : "Quadrati";

&nbsp;           default:

&nbsp;               return "";

&nbsp;       }

&nbsp;   }

}







Testes Unitários



Realizei alterações nos objetos , reproduzindo uma lista polimórfica, ou seja,

uma coleção de objetos de diferentes tipos que implementam a mesma interface (IFormaGeometrica).



Antes da refatoração



var formas = new List<FormaGeometrica>

&nbsp;{

&nbsp;   new FormaGeometrica(FormaGeometrica.Cuadrado, 5),

    new FormaGeometrica(FormaGeometrica.Circulo, 3),

    new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4),

    new FormaGeometrica(FormaGeometrica.Cuadrado, 2),

    new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 9),

    new FormaGeometrica(FormaGeometrica.Circulo, 2.75m),

    new FormaGeometrica(FormaGeometrica.TrianguloEquilatero, 4.2m)            

&nbsp;};





Depois da refatoração





var formas = new List<IFormaGeometrica>

{

&nbsp;   new Cuadrado(5),

&nbsp;   new Circulo(3),

&nbsp;   new TrianguloEquilatero(4),

&nbsp;   new Cuadrado(2),

&nbsp;   new TrianguloEquilatero(9),

&nbsp;   new Circulo(2.75m),

&nbsp;   new TrianguloEquilatero(4.2m)

};

















