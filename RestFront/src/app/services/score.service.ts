import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Score } from '../models/Score';

@Injectable({
  providedIn: 'root'
})
export class ScoreService {

  private scoreUrl: string = environment.baseUrl + "/api/Grade";

  constructor(private http: HttpClient) { }


  public getScore(id: number): Observable<Score[]> {
    return this.http.get<Score[]>(`${this.scoreUrl}/${id}`, { headers: environment.headers, withCredentials: environment.withCredentials }); 
  }
}
