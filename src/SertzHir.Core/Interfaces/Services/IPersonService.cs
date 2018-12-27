using System;
using System.Collections.Generic;
using System.Text;
using SertzHir.Core.Models;

namespace SertzHir.Core.Interfaces.Services
{
    public interface IPersonService
    {
        Result AddPerson(PersonModel personModel);
        Result UpdatePerson(PersonModel personModel);
        Result GetPeople(string lastname, string firstname);
        Result GetPersonById(int id);
        Result GetPeopleByState(string stateId);
        Result GetPeopleList();



    }
}
