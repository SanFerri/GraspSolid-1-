//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        /// <summary>
        /// Agregue el método para calcular el coste total de producción en Recipe, esto lo
        /// hice basándome en el patrón Expert. Ya que aquel que tiene los conocimientos necesarios
        /// para poder llevar a cabo la función es Recipe, porque conoce todos los steps (Y, por ende
        /// todos los costos unitarios, y el costo por hora del equipamiento).
        /// </summary>
        /// <returns></returns>
        private double GetProductionCost()
        {
            double productionCost = 0;
            foreach(Step step in this.steps)
            {
                productionCost += (step.Equipment.HourlyCost * (step.Time/3600)) + (step.Input.UnitCost * step.Quantity);
            }
            return productionCost;
        }
        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            // Aqui se imprime el costo obteniendo el double de la funcion GetProductionCost que creamos.
            Console.WriteLine($"Costo: {this.GetProductionCost()}$");
        }
    }
}