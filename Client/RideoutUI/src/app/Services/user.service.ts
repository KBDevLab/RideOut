import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = 'https://localhost:7026';

  constructor(private http: HttpClient) { }



  getUsers(): Observable<any[]>{
    return this.http.get<any[]>('${this.apiUrl}/users');
  }


  getUserById(userId: number): Observable<any[]>{
    return this.http.get<any[]>('${this.apiUrl}/users/${userId}');
  }

  // createUser(): Observable<any[]>{
  //   return this.http.post<any[]>();
  // }
}
