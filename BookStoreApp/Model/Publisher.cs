using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Model;

public class Publisher
{
    public Guid id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsDeleted { get; set; } = false;
}