import { CarsService } from './../../services/cars.service';
import { Component, OnInit } from '@angular/core';
import { LoginModel } from 'src/app/models/car-models';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginModel: LoginModel;

  constructor(private carsService: CarsService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loginModel = new LoginModel();
  }

  Login() {
    this.carsService.Login(this.loginModel);
    this.carsService.authenticatedChange$.subscribe(result => {
      this.router.navigate(['/list'], { relativeTo: this.route });
    });
  }

}
