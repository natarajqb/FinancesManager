using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancesManager.Models
{
    public class Expense
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)] 
        public int ExpenseId { get; set; }
        public string Title { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}