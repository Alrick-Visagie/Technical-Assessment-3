import { HttpClient } from '@angular/common/http';
import { ThrowStmt } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { CarDetailModel, LoginModel } from '../models/car-models';

@Injectable({
  providedIn: 'root'
})
export class CarsService {

  private token: string = "";
  private readonly url: string = "http://localhost:5500/api/";

  private authenticated: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public authenticatedChange$: Observable<boolean> = this.authenticated.asObservable();

  constructor(private httpClient: HttpClient) { }

  public Login(model: LoginModel) {
    this.httpClient.post<string>(`${this.url}auth`, model).subscribe(result => {
      this.token = result;
      this.authenticated.next(true);
    });
  }

  public GetCars(): Observable<CarDetailModel[]> {
    return this.httpClient.get<CarDetailModel[]>(`${this.url}cars`);
  }

  public GetCar(id: number): Observable<CarDetailModel> {
    return this.httpClient.get<CarDetailModel>(`${this.url}cars/${id}`);
  }

  public UpdateCar(model: CarDetailModel): Observable<void> {
    return this.httpClient.put<void>(`${this.url}cars/${model.Id}`, model);
  }

  public DeleteCar(id: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.url}cars/${id}`);
  }

  public GetToken() {
    return this.token;
  }



}
