using Domain.Entities;
using ProjetPiMap.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace ProjetPiMap.Controllers
{
    public class CustomerConsomServiceController : ApiController
    {

        IServiceClient sclient = new ServiceCustomer();
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/afficheAllClients")]
        // GET: CustomerConsomService
        //public IEnumerable<Customer> GetListClient()
        //{
        //    return sclient.GetAll();
        //}




        public IHttpActionResult afficheAllClients(System.Web.HttpPostedFileBase file)
        {
            List<ClientViewModel> list = new List<ClientViewModel>();
            foreach (var item in sclient.GetAll())
            {
                ClientViewModel client = new ClientViewModel();
                client.type = item.type;
                client.category = item.category;
                client.description = item.description;
                client.speciality = item.speciality;
                client.firstname = item.firstname;
                client.lastname = item.lastname;
                client.address = item.address;
                client.userId = item.Id;
                client.logo = item.logo;

                list.Add(client);
            }

            return Ok(list);
        }



        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            Customer cust = sclient.GetById(id);

            sclient.Delete(cust);
            sclient.Commit();
           return Ok("Index");
        }





    }
}