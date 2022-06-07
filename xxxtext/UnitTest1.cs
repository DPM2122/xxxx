using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using xxxNS;
using System.Collections.Generic;

namespace xxxtext
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PruebaPrediccionOk()
        {
            Prediccion miPrediccionPrueba = new Prediccion();

            List<double> dia1 = new List<double>(),
                         dia2 = new List<double>(),
                         dia3 = new List<double>();

            dia1.Add(12.5); dia1.Add(16.5); dia1.Add(21); dia1.Add(17); dia1.Add(15); //media1 16.4
            dia2.Add(13); dia2.Add(15); dia2.Add(19.5); dia2.Add(16.5); dia2.Add(14); //media2 15.6
            dia3.Add(14.5); dia3.Add(18.5); dia3.Add(23); dia3.Add(20); dia3.Add(17.5); //media3 18.7

            miPrediccionPrueba.PrediccionTemperatura(dia1, dia2, dia3);

            Console.WriteLine("Temperatura Celsius: " + miPrediccionPrueba.TempCelsius);
            Console.WriteLine("Temperatura Farenheit: " + miPrediccionPrueba.TempFarenheit);
            Console.WriteLine("Máxima: " + miPrediccionPrueba.TempMax);
            Console.WriteLine("Mínima: " + miPrediccionPrueba.TempMin);

            Assert.AreEqual(17.155, miPrediccionPrueba.TempCelsius, "El valor esperado no es correcto");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "No puede estar vacia la observacion del dia 1")]
        public void PruebaPrediccionErrorObservacion1()
        {

            Prediccion miPrediccionPrueba = new Prediccion();

            List<double> dia1 = new List<double>(),
                            dia2 = new List<double>(),
                            dia3 = new List<double>();


            dia2.Add(13); dia2.Add(15); dia2.Add(19.5); dia2.Add(16.5); dia2.Add(14);
            dia3.Add(14.5); dia3.Add(18.5); dia3.Add(23); dia3.Add(20); dia3.Add(17.5);

            miPrediccionPrueba.PrediccionTemperatura(dia1, dia2, dia3);


        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "No puede estar vacia la obsevacion del dia 2")]
        public void PruebaPrediccionErrorObservacion2()
        {
            Prediccion miPrediccionPrueba = new Prediccion();

            List<double> dia1 = new List<double>(),
                            dia2 = new List<double>(),
                            dia3 = new List<double>();


            dia1.Add(12.5); dia1.Add(16.5); dia1.Add(21); dia1.Add(17); dia1.Add(15);
            dia3.Add(14.5); dia3.Add(18.5); dia3.Add(23); dia3.Add(20); dia3.Add(17.5);

            miPrediccionPrueba.PrediccionTemperatura(dia1, dia2, dia3);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "No puede estar vacia la obsevacion del dia 3")]
        public void PruebaPrediccionErrorObservacion3()
        {
            Prediccion miPrediccionPrueba = new Prediccion();

            List<double> dia1 = new List<double>(),
                            dia2 = new List<double>(),
                            dia3 = new List<double>();


            dia1.Add(12.5); dia1.Add(16.5); dia1.Add(21); dia1.Add(17); dia1.Add(15);
            dia2.Add(13); dia2.Add(15); dia2.Add(19.5); dia2.Add(16.5); dia2.Add(14);


            miPrediccionPrueba.PrediccionTemperatura(dia1, dia2, dia3);
        }

    }
}

