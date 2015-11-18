using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using FinancesManager.Models;

namespace FinancesManager.Controllers
{
    public class ExpensesController : ApiController
    {
        private FinancesManagerContext db = new FinancesManagerContext();

        // GET api/Expenses
        public IEnumerable<Expense> GetExpenses()
        {
            IEnumerable<Expense> expenses = db.Expenses.AsEnumerable();
            return expenses;
        }

        // GET api/Expenses/5
        public Expense GetExpense(int id)
        {
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return expense;
        }

        // PUT api/Expenses/5
        public HttpResponseMessage PutExpense(int id, Expense expense)
        {
            if (ModelState.IsValid && id == expense.ExpenseId)
            {
                db.Entry(expense).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Expenses
        public HttpResponseMessage PostExpense(Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Add(expense);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, expense);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = expense.ExpenseId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Expenses/5
        public HttpResponseMessage DeleteExpense(int id)
        {
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Expenses.Remove(expense);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, expense);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}