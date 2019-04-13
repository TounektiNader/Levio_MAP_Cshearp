using Domain.Entities;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using ProjetPiMap.Models;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ProjetPiMap.Controllers
{
    public class TestController : Controller


    {
        public static string error = "";

        // GET: Test
        IServiceAnswer serviceAnswer = new ServiceAnswer();
        IServiceFolder serviceFolder = new ServiceFolder();

        IServiceTest serviceTest = new ServiceTest();
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<TestModel> list = new List<TestModel>();
            foreach (var item in serviceTest.GetAll())
            {
                TestModel fv = new TestModel();
              

                fv.testId = item.testId;
                fv.type = item.type;
                fv.question = item.question;
                fv.reponse = item.reponse;
                fv.choix1 = item.choix1;
                fv.choix2 = item.choix2;
                fv.IsCheckedR = false;
                fv.IsCheckedR1 = false;
                fv.IsCheckedR2 = false;

                list.Add(fv);
            }
           
         
            return View(list);
        }



        



        [HttpPost]
        public ActionResult Index(HttpPostedFileBase jsonFile)
        {
            
            if(!Path.GetFileName(jsonFile.FileName).EndsWith(".json"))
            { ViewBag.Error = "Invalid File Type";  }
            else {
                jsonFile.SaveAs(Server.MapPath("~/TestFiles/"+ Path.GetFileName(jsonFile.FileName)));
                StreamReader streamReader = new StreamReader(Server.MapPath("~/TestFiles/" + Path.GetFileName(jsonFile.FileName)));
                string data = streamReader.ReadToEnd();
                  List<Test> listTests = JsonConvert.DeserializeObject<List<Test>>(data);
                foreach(Test item in listTests)
                {

                    serviceTest.Add(item);
                    serviceTest.Commit();

                }

            }

            List<TestModel> list = new List<TestModel>();
            foreach (var item in serviceTest.GetAll())
            {
                TestModel fv = new TestModel();


                fv.testId = item.testId;
                fv.type = item.type;
                fv.question = item.question;
                fv.reponse = item.reponse;
                fv.choix1 = item.choix1;
                fv.choix2 = item.choix2;
                fv.IsCheckedR = false;
                fv.IsCheckedR1 = false;
                fv.IsCheckedR2 = false;

                list.Add(fv);
            }


            return View(list);
        }






        // GET: Test/Details/5
        public ActionResult Details(int id)
        {
            var test = serviceTest.GetById(id);
            TestModel ts = new TestModel();
            ts.type = test.type;
            ts.question = test.question;
            ts.reponse = test.reponse;
            ts.choix1 = test.choix1;
            ts.choix2 = test.choix2;

            return View(ts);
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            List<String> spec = (new List<String> { "Francais", "Development", "Human resource" });
            ViewBag.list = spec;
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        public ActionResult Create(TestModel testModel)
        {
            List<String> spec = (new List<String> { "French", "Development", "Human resource" });
            ViewBag.list = spec;
            Test tes = new Test();
            tes.type = testModel.type;
            tes.question = testModel.question;
            tes.reponse = testModel.reponse;
            tes.choix1 = testModel.choix1;
            tes.choix2 = testModel.choix2;

            tes.userId = User.Identity.GetUserId<int>();
            try
            {
                serviceTest.Add(tes);
                serviceTest.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int id)
        {
            var test = serviceTest.GetById(id);


            TestModel testmodel = new TestModel();
            testmodel.testId = test.testId;
            testmodel.question = test.question;
            testmodel.reponse=test.reponse ;
            testmodel.choix1 = test.choix1;
            testmodel.choix2 = test.choix2;

          
            return  View(testmodel);
        }

      
        // POST: Test/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TestModel testModel)
        {
            Test test = serviceTest.GetById(id);

            test.question = testModel.question;
            test.choix1 = testModel.choix1;
            test.choix2 = testModel.choix2;
            test.reponse = testModel.reponse;



            serviceTest.Update(test);
            serviceTest.Commit();
            return RedirectToAction("Index");

        }

        // GET: Test/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


          public ActionResult passerTest(string type )
        {

            if (Session["Rem_Time"] == null)
            {
                Session["Rem_Time"] = DateTime.Now.AddMinutes(2).ToString("dd-MM-yyyy h:mm:ss tt");
            }
            ViewBag.Rem_Time = Session["Rem_Time"];

            ViewBag.Message = "Modify this template to jump-start your MVC application.";








            Random radnom = new Random();
            List<TestModel> list = new List<TestModel>();
            List<Test> listtest = new List<Test>();
            List<Test> list2 = new List<Test>();
            listtest= serviceTest.GetAll().Where(a => a.type ==type).OrderBy(a => a.testId).ToList();
            int number = radnom.Next(listtest[0].testId, listtest[(listtest.Count()) - 1].testId);
            list2.Add(listtest.Where(a => a.testId == number).FirstOrDefault());

            do
            {
                for (int i = 1; i < 20; i++)
                {
                    number = radnom.Next(listtest[0].testId, listtest[(listtest.Count()) - 1].testId);


                    if (!list2.Contains(listtest.Where(a => a.testId == number).FirstOrDefault()))
                    {
                        list2.Add(listtest.Where(a => a.testId == number).FirstOrDefault());

                    }

                }

            }
            while (list2.Count() < 19);


                    foreach (var item in list2)
            {
           

                TestModel fv = new TestModel();


                fv.testId = item.testId;
                fv.type = item.type;
                fv.question = item.question;
                fv.reponse = item.reponse;
                fv.choix1 = item.choix1;
                fv.choix2 = item.choix2;
                fv.IsCheckedR = false;
                fv.IsCheckedR1 = false;
                fv.IsCheckedR2 = false;

                list.Add(fv);
            }
            QuestionList ql = new QuestionList();
            ql.tests = list;

            ViewBag.Error = error;
            return View(ql);
            
        }
       
        [HttpPost]
        public ActionResult passerTest(QuestionList model)
        {
         


            List<Test> lists = new List<Test>();

            try { 
            foreach (var item in model.tests)
            {

                //test.testId = item.testId;
                //int id = test.testId;
                //test.IsCheckedR = item.IsCheckedR;
                //test.IsCheckedR1 = item.IsCheckedR1;
                //test.IsCheckedR2 = item.IsCheckedR2;

                    if((item.IsCheckedR && item.IsCheckedR2)||(item.IsCheckedR&&item.IsCheckedR1)||(item.IsCheckedR1&&item.IsCheckedR2))
                    {

                        error = "vous devez cochez seul reponse";
                        return RedirectToAction("passerTest", "Test");
                    }
                    else { 

                if (item.IsCheckedR)
                {
                  //  sb.Append(item.reponse + ",");



                    item.IsCheckedR = false;
                    Test tes = new Test();
                    tes.question = item.reponse;
                    tes.type =item.type;
                    tes.testId = item.testId;
                    tes.choix2 = item.reponse;
                    lists.Add(tes);


                }
                if (item.IsCheckedR1)
                {

                 //   sb1.Append(item.choix1 + ",");


                    item.IsCheckedR1 = false;

                    Test tes = new Test();
                    tes.question = item.reponse;
                    tes.type = item.type;
                    tes.testId = item.testId;
                    tes.choix2 = item.choix1;
                    lists.Add(tes);

                }


                if (item.IsCheckedR2)
                {

 //                   sb2.Append(item.choix2 + ",");


                    item.IsCheckedR2 = false;
                    Test tes = new Test();
                    tes.question = item.reponse;
                    tes.type = item.type;
                    tes.testId = item.testId;
                    tes.choix2 = item.choix2;
                    lists.Add(tes);

                }

            }
                }
                List<Test>lists1 = lists.OrderBy(a=>a.testId).ToList();

                for (int i = 0; i <= lists1.Count()-1; i++)
            {
                Answers ans = new Answers();

                // ans.Test.testId = lists[i].testId;
                ans.answer = lists[i].choix2;
                ans.idTest = lists[i].testId;
                ans.idUser = User.Identity.GetUserId<int>();
                serviceAnswer.Add(ans);
                serviceAnswer.Commit();


          
                }

                List<Answers> listAnswers = serviceAnswer.getListAnswers(User.Identity.GetUserId<int>()).OrderBy(a => a.idTest).ToList();


            int noteTest =0;
            for (int i = 0; i <= lists1.Count() - 1; i++)
            {
                if (listAnswers[i].answer.Equals(lists1[i].question)) {

                    noteTest = noteTest + 1;
                  
                }

                serviceAnswer.Delete(listAnswers[i]);
                serviceAnswer.Commit();
                  //  listAnswers.Remove(listAnswers[i]);

            }


                Folder folder = serviceFolder.getFolderByUser(User.Identity.GetUserId<int>());
            if (noteTest < lists.Count()/2)
            {
                   folder.state = "Refused";
                    folder.testResult = noteTest;
                    serviceFolder.Update(folder);
                    serviceFolder.Commit();
                }
            else { 
            folder.testResult = noteTest;
            folder.typeTest =lists[1].type;
            folder.etape = folder.etape + 1;

            serviceFolder.Update(folder);
            serviceFolder.Commit();

                }
                ViewBag.score = folder.testResult;
            ViewBag.type = folder.typeTest;

       

            return RedirectToAction("Index", "Attachment");
            }
            catch {
              error= "vous devez remplir tous les champs";
                return RedirectToAction("passerTest", "Test");
            }
        
    }


        // POST: Test/Delete/5
  
        public ActionResult DeleteP(int id)
        {
            
            Test test = new Test();
            test = serviceTest.GetById(id);
            try
            {


                serviceTest.Delete(test);
                serviceTest.Commit();
                return RedirectToAction("Index");
              
            }
            catch
            {
                return View();
            }
        }

        public ActionResult importTest()
        { return View(); }

        [HttpPost]
        public ActionResult importTest(int id)
        { return View(); }
    }
}
