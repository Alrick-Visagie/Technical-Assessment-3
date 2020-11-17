import { CarsService } from './../../services/cars.service';
import { Component, OnInit } from '@angular/core';
import { CarDetailModel } from 'src/app/models/car-models';

@Component({
  selector: 'app-cars-list',
  templateUrl: './cars-list.component.html',
  styleUrls: ['./cars-list.component.scss']
})
export class CarsListComponent implements OnInit {

  cars: CarDetailModel[] = [];

  constructor(private carsService: CarsService) { }

  ngOnInit(): void {
    this.carsService.GetCars().subscribe(result => {
      this.cars = result;
    });
  }





}
