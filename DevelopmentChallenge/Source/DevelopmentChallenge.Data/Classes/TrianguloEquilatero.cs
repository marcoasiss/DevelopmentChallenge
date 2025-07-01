using System;
using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero: FormaGeometrica
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado) => _lado = lado;

        public override decimal CalcularArea() => ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;

        public override decimal CalcularPerimetro() => _lado * 3;

        public override string NomeForma(SupportedLanguage idioma, int quantidade)
        {

            switch (idioma)
            {
                case SupportedLanguage.Castellano:
                    return quantidade == 1 ? "Triángulo" : "Triángulos";
                case SupportedLanguage.Ingles:
                    return quantidade == 1 ? "Triangle" : "Triangles";
                case SupportedLanguage.Italiano:
                    return quantidade == 1 ? "Triangolo" : "Triangoli";
                default:
                    return "";
            }
        }
    }
}
