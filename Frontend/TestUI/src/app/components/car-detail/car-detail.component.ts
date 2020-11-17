import { CarDetailModel } from './../../models/car-models';
import { CarsService } from './../../services/cars.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.scss']
})
export class CarDetailComponent implements OnInit {

  car: CarDetailModel;
  new: boolean;

  constructor(private carService: CarsService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    var id = this.route.snapshot.paramMap.get('id');
    if (id == '0') {
      this.new = true;
      this.car = new CarDetailModel();
    } else {
      this.new = false;
    }
    this.carService.GetCar(parseInt(id));
  }

}
