using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes
{
    public static class ReporteFormas
    {
        public static string Imprimir(List<IFormaGeometrica> formas, SupportedLanguage idioma)
        {
            var sb = new StringBuilder();

            if (formas == null || !formas.Any())
            {
                sb.Append(ObterMensagemListaVazia(idioma));
                return sb.ToString();
            }
            else
                sb.Append(ObterCabecalhoRelatorio(idioma));

            var resumen = formas.GroupBy(f => f.GetType())
                .Select(g => new
                {
                    Cantidad = g.Count(),
                    Area = g.Sum(f => f.CalcularArea()),
                    Perimetro = g.Sum(f => f.CalcularPerimetro()),
                    Nombre = g.First().NomeForma(idioma, g.Count())
                });

            foreach (var item in resumen)
            {
                sb.Append($"{item.Cantidad} {item.Nombre} | ");
                sb.Append(idioma == SupportedLanguage.Ingles ? $"Area {item.Area:#.##} | Perimeter {item.Perimetro:#.##}" :
                          idioma == SupportedLanguage.Italiano ? $"Area {item.Area:#.##} | Perimetro {item.Perimetro:#.##}" :
                          $"Area {item.Area:#.##} | Perimetro {item.Perimetro:#.##}");
                sb.Append("<br/>");
            }

            var totalFormas = formas.Count;
            var totalArea = formas.Sum(f => f.CalcularArea());
            var totalPerimetro = formas.Sum(f => f.CalcularPerimetro());

            sb.Append("<br/>TOTAL:<br/>");
            sb.Append($"{totalFormas} {(idioma == SupportedLanguage.Ingles ? "shapes" : idioma == SupportedLanguage.Italiano ? "forme" : "formas")} ");
            sb.Append($"{(idioma == SupportedLanguage.Ingles ? "Perimeter" : "Perimetro")} {totalPerimetro:#.##} ");
            sb.Append($"Area {totalArea:#.##}");

            return sb.ToString();
        }

        private static string ObterMensagemListaVazia(SupportedLanguage idioma)
        {
            switch (idioma)
            {
                case SupportedLanguage.Castellano:
                    return "<h1>Lista vacía de formas!</h1>";
                case SupportedLanguage.Ingles:
                    return "<h1>Empty list of shapes!</h1>";
                case SupportedLanguage.Italiano:
                    return "<h1>Elenco vuoto di forme!</h1>";
                default:
                    return "<h1>Lista de formas vazia!</h1>";
            }
        }

        private static string ObterCabecalhoRelatorio(SupportedLanguage idioma)
        {
            switch (idioma)
            {
                case SupportedLanguage.Castellano:
                    return "<h1>Reporte de Formas</h1>";
                case SupportedLanguage.Ingles:
                    return "<h1>Shapes report</h1>";
                case SupportedLanguage.Italiano:
                    return "<h1>Rapporto delle Forme</h1>";
                default:
                    return "<h1>Relatório de Formas</h1>";
            }
        }

    }
}
