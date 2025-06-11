using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Maui.Scheduler.Internal;

namespace BookStoreApp.Model;


public class Book : BindableBase
{
    public Guid id { get; set; }
  
    public string Isbn { get; set; } = null!;

    public string title;
    public string Title
    {
        get => title;
        set
        {
            title = value;
            RaisePropertyChanged();
        }
    }

    public Guid categoryId { get; set; }
   

    public Guid authorId { get; set; }
    

    public Guid publisherId { get; set; }
    public string categoryName { get; set; }
   

    public string authorName { get; set; }
    

    public string publisherName { get; set; }
   

    public int YearOfPublication { get; set; }


    public int quantity;
    public int Quantity
    {
        get => quantity;
        set
        {
            quantity = value;
            RaisePropertyChanged();
        }
    }
    public string Image { get; set; }


    public decimal Price { get; set; }
 


    public bool isDeleted { get; set; }

}
