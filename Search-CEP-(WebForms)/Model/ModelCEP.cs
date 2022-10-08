using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    [Serializable]
    public class ModelCEP
    {
        public string CEP { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Locality { get; set; }

        public ModelCEP()
        {
        }
        public ModelCEP(string state, string district, string city, string locality)
        {
            State = state;
            District = district;
            City = city;
            Locality = locality;
        }
        public ModelCEP(string cep, string state, string district, string city, string locality)
        {
            CEP = cep;
            State = state;
            District = district;
            City = city;
            Locality = locality;
        }
    }
}