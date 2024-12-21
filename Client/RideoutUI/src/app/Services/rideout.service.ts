import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RideoutService {
  private readonly apiUrl = 'https://localhost:5114/rideouts';

  constructor(private http: HttpClient) { }

    // Get all rideouts (POST)
    getRideouts(): Observable<any[]> {
      return this.http.get<any[]>(`${this.apiUrl}`);
    }
  
    // Get a rideout by ID (GET)
    getRideoutById(rideoutId: string): Observable<any> {
      return this.http.get<any>(`${this.apiUrl}/${rideoutId}`);
    }
  
    // Create a new rideout (POST)
    createRideout(rideout: any): Observable<any> {
      return this.http.post<any>(`${this.apiUrl}`, rideout);
    }
  
    // Update an existing rideout (PUT)
    updateRideout(rideoutId: string, rideout: any): Observable<any> {
      return this.http.put<any>(`${this.apiUrl}/${rideoutId}`, rideout);
    }
  
    // Delete a rideout (DELETE)
    deleteRideout(rideoutId: string): Observable<any> {
      return this.http.delete<any>(`${this.apiUrl}/${rideoutId}`);
    }
}
