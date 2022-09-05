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

        // - Expert -
        // Creo la responsabilidad solicitada dentro de Recipe ya que es la EXPERTA en información en este caso. 

        public double GetProductionCost()
        {
            double costoInsumos = 0;
            double costoEquipamiento = 0;
            foreach (Step step in steps)
            {
                costoInsumos += step.Quantity * step.Input.UnitCost;
                costoEquipamiento += step.Time * step.Equipment.HourlyCost;
            }

            double total = costoInsumos + costoEquipamiento;
            return total;
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"\nCosto Total de Producción: {GetProductionCost().ToString()}");
        }
    }
}