using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio: FormaGeometrica
    {
        private readonly decimal _baseMayor, _baseMenor, _altura, _lado1, _lado2;

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura, decimal lado1, decimal lado2)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
            _lado1 = lado1;
            _lado2 = lado2;
        }

        public override decimal CalcularArea() => ((_baseMayor + _baseMenor) * _altura) / 2;

        public override decimal CalcularPerimetro() => _baseMayor + _baseMenor + _lado1 + _lado2;

        public override string NomeForma(SupportedLanguage idioma, int quantidade)
        {
            switch (idioma)
            {
                case SupportedLanguage.Castellano:
                    return quantidade == 1 ? "Trapecio" : "Trapecios";
                case SupportedLanguage.Ingles:
                    return quantidade == 1 ? "Trapezoid" : "Trapezoids";
                case SupportedLanguage.Italiano:
                    return quantidade == 1 ? "Trapezio" : "Trapezi";
                default:
                    return "";
            }
        }
    }
}
