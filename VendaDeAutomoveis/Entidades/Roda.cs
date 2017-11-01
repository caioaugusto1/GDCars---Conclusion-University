using System.Collections.Generic;
using System.Web.Mvc;
using static VendaDeAutomoveis.Enums.EnumsExtensions;

namespace VendaDeAutomoveis.Entidades
{
    public class Roda : Entity
    {
        public string Modelo { get; set; }

        public CorRoda Cor { get; set; }

        public int Aro { get; set; }
        
        public double Valor { get; set; }

        public static List<SelectListItem> GetAros()
        {
            List<SelectListItem> listAro = new List<SelectListItem>();

            for (var i = 14; i <= 20; i++)
                listAro.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });

            return listAro;
        }
    }
}