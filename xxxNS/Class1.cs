using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xxxNS
{
    /// <summary>
    /// Clase que contiene un programa para predecir la temperatura
    /// </summary>
    public class Prediccion
    {
        private double tempCelsius; // temperatura en grados Celsius
        private double tempFarenheit; // temperatura en grados farenheit
        private double tempMax; // temperatura máxima
        private double tempMin; // temperatura mínima

        /// <summary>
        /// Getters y Setters de las variables principales
        /// </summary>
        public double TempCelsius
        {
            get { return tempCelsius; }
            set { this.tempCelsius = value; }
        }
        public double TempFarenheit
        {
            get { return tempFarenheit; }
            set { tempFarenheit = value; }
        }
        public double TempMax
        {
            get { return tempMax; }
            set { tempMax = value; }
        }
        public double TempMin
        {
            get { return tempMin; }
            set { tempMin = value; }
        }

        /// <summary>
        /// La siguiente función obtiene la temperatura promedio de cada uno de los días que se pasan como parámetro
        /// </summary>
        /// <param name="observacionDia1">Observación de temperatura del primer dia</param>
        /// <param name="observacionDia2">Observación de temperatura del segundo dia</param>
        /// <param name="observacionDia3">Observación de temperatura del tercer dia</param>
        /// <returns>Devuelve una estimación basada en una fórmula, además, la función retorna true si se ha podido obtener la predicción, false si ha ocurrido un error</returns>
        public bool PrediccionTemperatura(List<double> observacionDia1, List<double> observacionDia2, List<double> observacionDia3)
        {
            int i;  // contador
            double tempMedia1 = 0,
                   tempMedia2 = 0,
                   tempMedia3 = 0; // temperatura media de cada día

            TempMax = 1000; // Inicializamos los máximos y los mínimos
            TempMin = -1000;

            // Para cada día obtenemos la suma de temperaturas
            //
            if (observacionDia1.Count <= 0)
            {
                throw new Exception("No puede estar vacio la observacion del dia 1");  // Tenemos que tener al menos una observación
            }

            for (i = 0; i < observacionDia1.Count; i++)
            {
                tempMedia1 = tempMedia1 + observacionDia1[i];

                if (TempMin < observacionDia1[i])
                {
                    TempMin = observacionDia1[i];
                }

                if (TempMax > observacionDia1[i])
                {
                    TempMax = observacionDia1[i];

                }
            }

            tempMedia1 = tempMedia1 / observacionDia1.Count;

            if (observacionDia2.Count <= 0)
            {
                throw new Exception("No puede estar vacio la observacion del dia 2"); // Tenemos que tener al menos una observación
            }

            for (i = 0; i < observacionDia2.Count; i++)
            {
                tempMedia2 = tempMedia2 + observacionDia2[i];

                if (TempMin < observacionDia2[i])
                {
                    TempMin = observacionDia2[i];
                }

                if (TempMax > observacionDia2[i])
                {
                    TempMax = observacionDia2[i];

                }
            }

            tempMedia2 = tempMedia2 / observacionDia2.Count;

            if (observacionDia3.Count <= 0)
            {
                throw new Exception("No puede estar vacio la observacion del dia 3");  // Tenemos que tener al menos una observación
            }

            for (i = 0; i < observacionDia3.Count; i++)
            {
                tempMedia3 = tempMedia3 + observacionDia3[i];

                if (TempMin < observacionDia3[i])
                {
                    TempMin = observacionDia1[i];
                }

                if (TempMax > observacionDia3[i])
                {
                    TempMax = observacionDia1[i];

                }
            }

            tempMedia3 = tempMedia3 / observacionDia3.Count;

            // Finalmente calculamos la temperatura media total, dándo más peso 		
            // al último día que al primero
            //
            TempCelsius = 0.2 * tempMedia1 + 0.35 * tempMedia2 + 0.45 * tempMedia3;

            // calculamos también la temperatura en grados farenheit
            //
            TempFarenheit = (TempCelsius * 1.8) + 32;

            return true;
        }
    }
}
