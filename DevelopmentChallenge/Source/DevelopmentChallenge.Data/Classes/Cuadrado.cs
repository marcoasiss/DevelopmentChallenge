using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado) => _lado = lado;
        public override decimal CalcularArea() => _lado * _lado;

        public override decimal CalcularPerimetro() => _lado * 4;

        public override string NomeForma(SupportedLanguage idioma, int quantidade)
        {

            switch (idioma)
            {
                case SupportedLanguage.Castellano:
                    return quantidade == 1 ? "Cuadrado" : "Cuadrados";
                case SupportedLanguage.Ingles:
                    return quantidade == 1 ? "Square" : "Squares";
                case SupportedLanguage.Italiano:
                    return quantidade == 1 ? "Quadrato" : "Quadrati";
                default:
                    return "";
            }
        }
    }
}
