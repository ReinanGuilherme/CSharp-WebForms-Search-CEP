using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Search_CEP__WebForms_
{
    public partial class Default : System.Web.UI.Page
    {
        //list that will be used to store the query list
        List<ModelCEP> listCeps = new List<ModelCEP>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //feeding the list after page is refreshed
            List<ModelCEP> list = (List<ModelCEP>)Session["SearchList"];

            //checks if the list is empty, if not, feeds the search list
            if (list != null)
            {
                listCeps = list;
            }
        }

        //button that calls the function
        protected async void btnSearch_Click(object sender, EventArgs e)
        {
            //clear the fields as soon as the function is called
            ClearFields();

            //checks if the input parameter is valid
            if (ValidateInputCep())
            {
                //remove (-)
                int formatTextCEP = Convert.ToInt32(tbCep.Text.Replace("-", ""));
                //function Search CEP
                ModelCEP result = await SearchCepAsync(formatTextCEP);

                //if result == null so the API didn't find a CEP
                if (result == null)
                {
                    lbMsgError.Text = "CEP not found";
                    lbMsgError.Visible = true;
                }
                //adding the values ​​returned from the query to the fields
                else if (!result.State.Equals(""))
                {
                    lbState.Text = result.State;
                    lbDistrict.Text = result.District;
                    lbCity.Text = result.City;
                    lbLocality.Text = result.Locality;
                }

                //if the field has information, add the information to the history
                if (!tbCep.Text.Equals(""))
                {
                    if (lbState.Text.Equals(""))
                    {
                        listCeps.Add(new ModelCEP(tbCep.Text, lbMsgError.Text, lbMsgError.Text, lbMsgError.Text, lbMsgError.Text));
                    } else
                    {
                        listCeps.Add(new ModelCEP(tbCep.Text, lbState.Text, lbDistrict.Text, lbCity.Text, lbLocality.Text));
                    }
                    Session["SearchList"] = listCeps;
                }

            }
        }

        private void ClearFields()
        {
            lbState.Text = "";
            lbDistrict.Text = "";
            lbCity.Text = "";
            lbLocality.Text = "";
        }

        private bool ValidateInputCep()
        {
            try
            {
                //if the CEP code is not in the valid size, it returns an error
                if (tbCep.Text.Length != 9)
                {
                    throw new Exception("Enter a valid CEP.");
                }

                return true;
            }
            catch (Exception error)
            {
                lbMsgError.Text = error.Message;
                lbMsgError.Visible = true;
                return false;
            }
        }

        private async Task<ModelCEP> SearchCepAsync(int CEP)
        {
            try
            {
                //request configuration
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync($"https://viacep.com.br/ws/{CEP}/json/");
                response.EnsureSuccessStatusCode();

                //converting the data to a more readable format
                string responseBody = await response.Content.ReadAsStringAsync();
                var convertBody = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(responseBody);

                ModelCEP address = new ModelCEP(convertBody["uf"], convertBody["bairro"], convertBody["localidade"], convertBody["logradouro"]);

                return address;
            }
            catch (Exception)
            {
                lbMsgError.Text = "An error has occurred, please check the CEP.";
                lbMsgError.Visible = true;
                return null;
            }
        }
    }
}