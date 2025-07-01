using System;
using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica
    {
        private readonly decimal _diametro;

        public Circulo(decimal diametro) => _diametro = diametro;

        public override decimal CalcularArea() => (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);

        public override decimal CalcularPerimetro() => (decimal)Math.PI * _diametro;

        public override string NomeForma(SupportedLanguage idioma, int quantidade)
        {
            switch (idioma)
            {
                case SupportedLanguage.Castellano:
                    return quantidade == 1 ? "Círculo" : "Círculos";
                case SupportedLanguage.Ingles:
                    return quantidade == 1 ? "Circle" : "Circles";
                case SupportedLanguage.Italiano:
                    return quantidade == 1 ? "Cerchio" : "Cerchi";
                default:
                    return "";
            }
        }
    }
}
