

import { Injectable, inject } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Job } from '../Dto/job';

@Injectable({
  providedIn: 'root'
})
export class JobService {
  private getHeaders(): HttpHeaders {
    const token = localStorage.getItem('token');  // Get token from localStorage
    return new HttpHeaders({
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
    });
  }
  private apiUrl = 'https://localhost:7102/api/Job';
  private http = inject(HttpClient);

  constructor() {}

  // ✅ Fetch all accounts
  getAllJob(): Observable<Job[]> {
    return this.http.get<Job[]>(this.apiUrl, { headers: this.getHeaders() });
  }

  // ✅ Get account by ID
  getJobById(id: number): Observable<Job> {
    return this.http.get<Job>(`${this.apiUrl}/${id}`, { headers: this.getHeaders() });
  }

  
}
