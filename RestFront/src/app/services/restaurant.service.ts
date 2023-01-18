import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Restaurant } from '../models/Restaurant';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {
  private restUrl: string = environment.baseUrl + "/api/Restaurant";
  private restaurant: Restaurant = new Restaurant(0, "","","","");

  constructor(private http: HttpClient) { }

  public setRest(rest: Restaurant): void{
    this.restaurant = rest;
  }

  public getStoredRest(): Restaurant{
    return this.restaurant;
  }

  public getRests(): Observable<Restaurant[]> {
    return this.http.get<Restaurant[]>(`${this.restUrl}`, { headers: environment.headers, withCredentials: environment.withCredentials }); 
  }

  public getRest(Id: number): Observable<Restaurant> {
    return this.http.get<Restaurant>(`${this.restUrl}/${Id}`, { headers: environment.headers, withCredentials: environment.withCredentials }); 
  }
}
