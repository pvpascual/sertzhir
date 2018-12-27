using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SertzHir.Core;
using SertzHir.Core.Entities;
using SertzHir.Core.EntityMaps;
using SertzHir.Core.Interfaces;
using SertzHir.Core.Interfaces.Services;
using SertzHir.Core.Models;

namespace SertzHir.Services
{
    public class PersonService:IPersonService
    {
        private readonly ISertzHirDataUow _sertzHirDataUow;
        private readonly IUtility _utility;


        public PersonService(ISertzHirDataUow sertzHirDataUow, IUtility utility)
        {
            _sertzHirDataUow = sertzHirDataUow;
            _utility = utility;

        }
        /// <summary>
        /// Add a person
        /// </summary>
        /// <param name="personModel"></param>
        /// <returns></returns>
        public Result AddPerson(PersonModel personModel)
        {
            try
            {
                //Validations
               //Check if personModel is clear from SQL injection attacks
               if(!_utility.IsClearFromSqlInjection(personModel.LastName))
                   throw new Exception("Invalid lastname");

                if (!_utility.IsClearFromSqlInjection(personModel.FirstName))
                    throw new Exception("Invalid firstname");

                
                //Check if State ID is valid
                if(_sertzHirDataUow.States.GetById(personModel.StateId)==null)
                    throw new Exception("Invalid state ID");


                //Insert Person record
                using (SertzHirDataDbContext context = new SertzHirDataDbContext())
                {
                    var result = context.Database.SqlQuery<IdentityEntityMap>(
                            "EXEC uspPersonInsert @last_name={0},@first_name={1},@gender={2},@dob={3},@state_id={4};"
                            , personModel.LastName
                            , personModel.FirstName
                            , personModel.Gender
                            , personModel.DateOfBirth
                            , personModel.StateId)
                        .Select(q => new IdentityEntityMap
                        {
                            IdentityId = q.IdentityId
                        }).ToList().FirstOrDefault();

                   
                    return new Result
                    {
                        Successful = true,
                        ObjectValue = result
                    };
                }

              
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Update a person record
        /// </summary>
        /// <param name="personModel"></param>
        /// <returns></returns>
        public Result UpdatePerson(PersonModel personModel)
        {
            try
            {
                //Validations
                //Check if personModel is clear from SQL injection attacks
                if (!_utility.IsClearFromSqlInjection(personModel.LastName))
                    throw new Exception("Invalid lastname");

                if (!_utility.IsClearFromSqlInjection(personModel.FirstName))
                    throw new Exception("Invalid firstname");

               
                //Check if Person ID is valid
                if (_sertzHirDataUow.People.GetById(personModel.PersonId) == null)
                    throw new Exception("Invalid person ID");

                //Check if State ID is valid
                if (_sertzHirDataUow.States.GetById(personModel.StateId) == null)
                    throw new Exception("Invalid state ID");


                //Update a Person record
                using (SertzHirDataDbContext context = new SertzHirDataDbContext())
                {
                    var result = context.Database.SqlQuery<PersonEntityMap>(
                            "EXEC uspPersonUpdate @last_name={0},@first_name={1},@gender={2},@dob={3},@state_id={4},@person_id= {5};"
                            , personModel.LastName
                            , personModel.FirstName
                            , personModel.Gender
                            , personModel.DateOfBirth
                            , personModel.StateId
                            , personModel.PersonId)
                        .Select(q => new PersonEntityMap()
                        {
                            person_id = q.person_id,
                            last_name = q.last_name,
                            first_name = q.first_name,
                            gender = q.gender,
                            dob = q.dob,
                            state_id = q.state_id

                        }).ToList().SingleOrDefault();


                    return new Result
                    {
                        Successful = true,
                        ObjectValue = result
                    };
                }


            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Search people by firstname and lastname
        /// </summary>
        /// <param name="lastname"></param>
        /// <param name="firstname"></param>
        /// <returns></returns>
        public Result GetPeople(string lastname, string firstname)
        {
            try
            {
                //Initialize criteria
                if (String.IsNullOrEmpty(lastname))
                    lastname = "";
                if (String.IsNullOrEmpty(firstname))
                    firstname = "";

                //Validations
                //Check if personModel is clear from SQL injection attacks
                if (!_utility.IsClearFromSqlInjection(lastname))
                    throw new Exception("Invalid lastname");

                if (!_utility.IsClearFromSqlInjection(firstname))
                    throw new Exception("Invalid firstname");

                //Search for people by firstname or lastname
                using (SertzHirDataDbContext context = new SertzHirDataDbContext())
                {
                    var result = context.Database.SqlQuery<PersonEntityMap>(
                            "EXEC uspPersonSearch @last_name={0},@first_name={1};"
                            , lastname
                            , firstname)
                        .Select(q => new PersonModel()
                        {
                            PersonId = q.person_id
                            ,LastName = q.last_name
                            ,FirstName = q.first_name
                            ,Gender = q.gender
                            ,DateOfBirth = q.dob
                            ,StateId = q.state_id
                            ,StateCode = q.state_code

                        }).ToList();


                    return new Result
                    {
                        Successful = true,
                        ObjectValue = result
                    };
                }


            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Get all People List
        /// </summary>
        /// <returns></returns>
        public Result GetPeopleList()
        {
            try
            {
                var result = _sertzHirDataUow.People.GetAll().Select(p=> new PersonModel
                {
                    PersonId=p.PersonId
                    ,LastName = p.LastName
                    ,FirstName=p.FirstName
                    ,Gender = p.Gender
                    ,DateOfBirth = p.DateOfBirth
                    ,StateCode = p.State.StateCode
                });
                return new Result
                {
                    Successful = true,
                    ObjectValue = result
                };

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public Result GetPersonById(int id)
        {
            try
            {
               //Validations
                if (_sertzHirDataUow.People.GetById(id) == null)
                {
                    throw new Exception("Invalid ID");
                }
                else
                {
                    var result = _sertzHirDataUow.People.GetById(id);
                    return new Result
                    {
                        Successful = false,
                        ObjectValue = result
                    };
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Result GetPeopleByState(string stateId)
        {

            throw new NotImplementedException();

        }
    }
}
