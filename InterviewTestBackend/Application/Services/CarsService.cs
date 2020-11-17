using Application.Models;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CarsService
    {
        private readonly CarsDbContext _db;
        private readonly IMapper _mapper;

        public CarsService(CarsDbContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        public async Task AddCar(CarDetailModel model)
        {
            var entity = _mapper.Map<CarDetail>(model);
            _db.Cars.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateCar(CarDetailModel model)
        {
            var entity = _mapper.Map<CarDetail>(model);
            _db.Cars.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<CarDetailModel> GetCar(int id)
        {
            var car = await _db.Cars
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (car == null)
            {
                throw new Exception("Invalid Car Id");
            }

            return _mapper.Map<CarDetailModel>(car);
        }

        public async Task<List<CarDetailModel>> GetCars()
        {
            var carsList = await _db.Cars
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<CarDetailModel>>(carsList);
        }

        public async Task DeleteCar(int id)
        {
            var car = await _db.Cars
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (car == null) {
                throw new Exception("Car Not Deleted: Id Invalid");
            }

            _db.Cars.Remove(car);

            await _db.SaveChangesAsync();
        }

    }
}
