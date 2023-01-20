import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Menu } from '../models/Menu';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  private menuUrl: string = environment.baseUrl + "/api/Menu";

  constructor(private http: HttpClient) { }

  public getMenu(id: number): Observable<Menu[]> {
    return this.http.get<Menu[]>(`${this.menuUrl}/${id}`, { headers: environment.headers, withCredentials: environment.withCredentials }); 
  }
}
