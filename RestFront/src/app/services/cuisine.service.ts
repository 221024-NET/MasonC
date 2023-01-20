import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Cuisine } from '../models/Cuisine';

@Injectable({
  providedIn: 'root'
})
export class CuisineService {
  private cuisineUrl: string = environment.baseUrl + "/api/Cuisine";

  constructor(private http: HttpClient) { }


  public getCuisine(id: number): Observable<Cuisine> {
    return this.http.get<Cuisine>(`${this.cuisineUrl}/${id}`, { headers: environment.headers, withCredentials: environment.withCredentials }); 
  }

  public getCuisines(): Observable<Cuisine[]> {
    return this.http.get<Cuisine[]>(`${this.cuisineUrl}`, { headers: environment.headers, withCredentials: environment.withCredentials }); 
  }
}
