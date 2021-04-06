using System;
using System.Collections.Generic;
using gregslist2.db;
using gregslist2.Models;
using Microsoft.AspNetCore.Mvc;

namespace gregslist2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
                return Ok(FakeDB.Cars);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
                FakeDB.Cars.Add(newCar);
                return Ok(newCar);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{carId}")]
        public ActionResult<Car> GetCar(string carId)
        {
            try
            {
                Car carFound = FakeDB.Cars.Find(c => c.Id == carId);
                if (carFound == null)
                {
                    throw new System.Exception("Car does not exist");
                }
                return Ok(carFound);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteCar(string id)
        {
            try
            {
                Car carToRemove = FakeDB.Cars.Find(c => c.Id == id);
                if (FakeDB.Cars.Remove(carToRemove))
                {
                    return Ok("Car Deleted");
                }
                else
                {
                    throw new System.Exception("This car does not exist.");
                }
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<string> EditCar([FromBody] Car editedCar, string id)
        {
            try
            {
                Car carToEdit = FakeDB.Cars.Find(c => c.Id == id);
                if (carToEdit != null)
                {
                    if (editedCar.Make == null)
                    {
                        carToEdit.Make = carToEdit.Make;
                    }
                    else
                    {
                        carToEdit.Make = editedCar.Make;
                    }
                    if (editedCar.Model == null)
                    {
                        carToEdit.Model = carToEdit.Model;
                    }
                    else
                    {
                        carToEdit.Model = editedCar.Model;
                    }
                    if (editedCar.Year == null)
                    {
                        carToEdit.Year = carToEdit.Year;
                    }
                    else
                    {
                        carToEdit.Year = editedCar.Year;
                    }
                    if (editedCar.Price == null)
                    {
                        carToEdit.Price = carToEdit.Price;
                    }
                    else
                    {
                        carToEdit.Price = editedCar.Price;
                    }
                    return Ok("Car Edited");
                }
                else
                {
                    throw new System.Exception("This car does not exist.");
                }
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }


    }
}