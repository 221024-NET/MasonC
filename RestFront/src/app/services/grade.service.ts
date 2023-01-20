import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Grade } from '../models/Grade';

@Injectable({
  providedIn: 'root'
})
export class GradeService {

  private gradeUrl: string = environment.baseUrl + "/api/Grade";

  constructor(private http: HttpClient) { }


  public getGrade(id: number): Observable<Grade[]> {
    return this.http.get<Grade[]>(`${this.gradeUrl}/${id}`, { headers: environment.headers, withCredentials: environment.withCredentials }); 
  }
}
