import { Injectable } from '@angular/core';
import { environment } from '../../environments';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {
  private restUrl: string = environment.baseUrl + "/api/Restaurant";

  constructor(private http: HttpClient) { }

  public getRests(): Observable<any> {
    return this.http.get(`${this.restUrl}`, { headers: environment.headers, withCredentials: environment.withCredentials }); 
  }

  public getRest(Id: number): Observable<any> {
    return this.http.get(`${this.restUrl}/${Id}`, { headers: environment.headers, withCredentials: environment.withCredentials }); 
  }
}
