using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestfultAPIProject.Models;

namespace RestfultAPIProject.Service
{
    public interface IPostService
    {
        Posts Create(Posts post);
        Posts GetPost(int id);
        List<Posts> GetAll();
        Posts DeleteProduct(int id);
        Posts Update(int id, Posts post);
    }
}