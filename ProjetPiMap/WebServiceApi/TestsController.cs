using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Data;
using Domain.Entities;
using Service;
using ProjetPiMap.Models;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace ProjetPiMap.WebServiceApi
{
    public class TestsController : ApiController
    {
        private Context db = new Context();



        public static IServiceTest cs;

        public TestsController()
        {

            cs = new ServiceTest();
        }


        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public TestsController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }



        // GET: api/Tests
        public IEnumerable<TestModel> GetTests()
        {
            var tests = cs.GetAll();
            List<TestModel> lpm = new List<TestModel>();
            foreach (var item in tests)
                lpm.Add(new TestModel
                {
                    testId = item.testId,
                    type = item.type,
                    question = item.question,
                    reponse = item.reponse,
                    choix1 = item.choix1,
                    choix2=item.choix2
                    

                });
            return lpm;

        }

        // GET: api/Tests/5
        [ResponseType(typeof(Test))]
        public IHttpActionResult GetTest(int id)
        {
            Test test = cs.GetById(id);
            TestModel testM = new TestModel();
            testM.reponse = test.reponse;
            testM.question = test.question;
            testM.choix1 = test.choix1;
            testM.choix2 = test.choix2;
            testM.type = test.type;



            if (test == null)
            {
                return NotFound();
            }

            return Ok(testM);
        }




      






        // PUT: api/Tests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTest(int id, Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != test.testId)
            {
                return BadRequest();
            }

            db.Entry(test).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tests
        [ResponseType(typeof(Test))]
        public IHttpActionResult PostTest(Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tests.Add(test);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = test.testId }, test);
        }

        // DELETE: api/Tests/5
        [ResponseType(typeof(Test))]
        public IHttpActionResult DeleteTest(int id)
        {
            Test test = cs.GetById(id);

            if (test == null)
            {
                return NotFound();
            }

            cs.Delete(test);
            cs.Commit();

            return Ok(test);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestExists(int id)
        {
            return db.Tests.Count(e => e.testId == id) > 0;
        }
    }
}