import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RestConnCuisine } from '../models/RestConnCuisine';

@Injectable({
  providedIn: 'root'
})
export class RestConnCuisineService {

  private restCCUrl: string = environment.baseUrl + "/api/RestConnCuisine";

  constructor(private http: HttpClient) { }


  public getRestConnCuisines(id: number): Observable<RestConnCuisine[]> {
    return this.http.get<RestConnCuisine[]>(`${this.restCCUrl}/${id}`, { headers: environment.headers, withCredentials: environment.withCredentials }); 
  }
}
