using System.Collections.Generic;
using System.Globalization;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Interfaces;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [SetUp]
        public void Setup()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        }

        [Test]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                ReporteFormas.Imprimir(new List<IFormaGeometrica>(), SupportedLanguage.Castellano));
        }

        [Test]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                ReporteFormas.Imprimir(new List<IFormaGeometrica>(), SupportedLanguage.Ingles));
        }

        [Test]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<IFormaGeometrica> { new Cuadrado(5) };

            var resumen = ReporteFormas.Imprimir(cuadrados, SupportedLanguage.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20<br/><br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [Test]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = ReporteFormas.Imprimir(cuadrados, SupportedLanguage.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36<br/><br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [Test]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = ReporteFormas.Imprimir(formas, SupportedLanguage.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28<br/>" +
                "2 Circles | Area 13,01 | Perimeter 18,06<br/>" +
                "3 Triangles | Area 49,64 | Perimeter 51,6<br/><br/>" +
                "TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65", resumen);
        }

        [Test]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = ReporteFormas.Imprimir(formas, SupportedLanguage.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28<br/>" +
                "2 Círculos | Area 13,01 | Perimetro 18,06<br/>" +
                "3 Triángulos | Area 49,64 | Perimetro 51,6<br/><br/>" +
                "TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65", resumen);
        }
    }
}
