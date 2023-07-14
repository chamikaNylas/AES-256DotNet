using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

 public class SessionRequest
 {
   // User Email, Organization External Id, Client Id,Issued Date
    public string Email { get; set; }
    public string OfficeReferenceId { get; set; }
    public string ClientId { get; set; }
    public DateTime IssuedDate { get; set; }

 }

