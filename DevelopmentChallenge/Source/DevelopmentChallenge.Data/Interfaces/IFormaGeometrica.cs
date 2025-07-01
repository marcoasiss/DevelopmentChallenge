using DevelopmentChallenge.Data.Enums;

namespace DevelopmentChallenge.Data.Interfaces
{
    public interface IFormaGeometrica
    {
        decimal CalcularArea();
        decimal CalcularPerimetro();
        string NomeForma(SupportedLanguage idioma, int quantidade);
    }

}
