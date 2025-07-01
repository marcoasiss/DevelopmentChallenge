using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangulo: FormaGeometrica
    {
        private readonly decimal _base, _altura;

        public Rectangulo(decimal b, decimal h)
        {
            _base = b;
            _altura = h;
        }

        public override decimal CalcularArea() => _base * _altura;

        public override decimal CalcularPerimetro() => 2 * (_base + _altura);

        public override string NomeForma(SupportedLanguage idioma, int quantidade)
        {

            switch (idioma)
            {
                case SupportedLanguage.Castellano:
                    return quantidade == 1 ? "Rectángulo" : "Rectángulos";
                case SupportedLanguage.Ingles:
                    return quantidade == 1 ? "Rectangle" : "Rectangles";
                case SupportedLanguage.Italiano:
                    return quantidade == 1 ? "Rettangolo" : "Rettangoli";
                default:
                    return "";
            }
        }
    }
}
