using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
    public class DatabaseExampleController : Controller
    {
        public ApplicationDbContext dbContext;

        public DatabaseExampleController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public async Task<ViewResult> DatabaseOperations()
        public ViewResult DatabaseOperations()
        {
            // CREATE Course
            Course MyCourse1 = new Course();
            MyCourse1.Id = 6225;
            MyCourse1.Name = "ISM6225";

            Course MyCourse2 = new Course();
            MyCourse2.Id = 6226;
            MyCourse2.Name = "ISM6226";

            Course MyCourse3 = new Course();
            MyCourse3.Id = 6227;
            MyCourse3.Name = "ISM6227";

            Student MyStudent1 = new Student();
            MyStudent1.Id = 1;
            MyStudent1.Name = "Raquel Pavlik";

            Student MyStudent2 = new Student();
            MyStudent1.Id = 2;
            MyStudent1.Name = "John Snow";

            Student MyStudent3 = new Student();
            MyStudent1.Id = 3;
            MyStudent1.Name = "Frank Sinatra";

            Enrolment MyEnrolment1 = new Enrolment();
            MyEnrolment1.Id = 100;
            MyEnrolment1.course = MyCourse1;
            MyEnrolment1.student = MyStudent1;
            MyEnrolment1.grade = "A";

            Enrolment MyEnrolment2 = new Enrolment();
            MyEnrolment2.Id = 101;
            MyEnrolment2.course = MyCourse1;
            MyEnrolment2.student = MyStudent2;
            MyEnrolment2.grade = "A-";

            Enrolment MyEnrolment3 = new Enrolment();
            MyEnrolment3.Id = 102;
            MyEnrolment3.course = MyCourse1;
            MyEnrolment3.student = MyStudent3;
            MyEnrolment3.grade = "A+";

            Enrolment MyEnrolment4 = new Enrolment();
            MyEnrolment4.Id = 103;
            MyEnrolment4.course = MyCourse2;
            MyEnrolment4.student = MyStudent3;
            MyEnrolment4.grade = "B";

            Enrolment MyEnrolment5 = new Enrolment();
            MyEnrolment5.Id = 104;
            MyEnrolment5.course = MyCourse2;
            MyEnrolment5.student = MyStudent2;
            MyEnrolment5.grade = "C";

            Enrolment MyEnrolment6 = new Enrolment();
            MyEnrolment6.Id = 105;
            MyEnrolment6.course = MyCourse3;
            MyEnrolment6.student = MyStudent2;
            MyEnrolment6.grade = "A";

            dbContext.Courses.Add(MyCourse1);
            dbContext.Courses.Add(MyCourse2);
            dbContext.Courses.Add(MyCourse3);
            dbContext.Students.Add(MyStudent1);
            dbContext.Students.Add(MyStudent2);
            dbContext.Students.Add(MyStudent3);
            dbContext.Enrolments.Add(MyEnrolment1);
            dbContext.Enrolments.Add(MyEnrolment2);
            dbContext.Enrolments.Add(MyEnrolment3);
            dbContext.Enrolments.Add(MyEnrolment4);
            dbContext.Enrolments.Add(MyEnrolment5);
            dbContext.Enrolments.Add(MyEnrolment6);

            dbContext.SaveChanges();

            //  // READ operation
            //  Company CompanyRead1 = dbContext.Companies
            //                          .Where(c => c.symbol == "MCOB")
            //                          .First();

            //  Company CompanyRead2 = dbContext.Companies
            //                          .Include(c => c.Quotes)
            //                          .Where(c => c.symbol == "MCOB")
            //                          .First();

            //  // UPDATE operation
            //  CompanyRead1.iexId = "MCOB";
            //  dbContext.Companies.Update(CompanyRead1);
            //  //dbContext.SaveChanges();
            //  await dbContext.SaveChangesAsync();

            //  // DELETE operation
            //  //dbContext.Companies.Remove(CompanyRead1);
            //  //await dbContext.SaveChangesAsync();

            //  return View();
            //
        }

            public ViewResult LINQOperations()
            {
                Course CourseRead1 = dbContext.Courses
                                                .Where(c => c.Id == 6225)
                                                .First();

                Course CourseRead2 = dbContext.Courses
                                                .Include(c => c.enrolments)
                                                .Where(c => c.Id == 6225)
                                                .First();

                Enrolment Enrolment1 = dbContext.Enrolments
                                .Include(c => c.course)
                                .Include(c => c.student)
                                .Include(c => c.grade)
                                .Where(c => c.Id == 102)
                                .FirstOrDefault();

            Enrolment Enrolment2 = dbContext.Enrolments
                            .Include(c => c.course)
                            .Include(c => c.student)
                            .Include(c => c.grade)
                            .Where(c => c.Id == 101)
                            .FirstOrDefault();

            Enrolment Enrolment3 = dbContext.Enrolments
                                .Include(c => c.course)
                                .Include(c => c.student)
                                .Include(c => c.grade)
                                .Where(c => c.Id == 103)
                                .FirstOrDefault();



            return View();
        }

    }
}