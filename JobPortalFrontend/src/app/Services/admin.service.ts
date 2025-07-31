import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Job } from '../Dto/job';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private apiUrl = 'https://localhost:7102/api/Job';
  private http = inject(HttpClient);

  private getHeaders(isFormData: boolean = false): HttpHeaders {
    const token = localStorage.getItem('token');
    const headersConfig: { [key: string]: string } = {
      'Authorization': `Bearer ${token}`
    };
    if (!isFormData) {
      headersConfig['Content-Type'] = 'application/json';
    }
    return new HttpHeaders(headersConfig);
  }

  addJob(formData: FormData): Observable<Job> {
    return this.http.post<Job>(this.apiUrl, formData, {
      headers: this.getHeaders(true)
    });
  }

  updateJob(id: number, formData: FormData): Observable<Job> {
    return this.http.put<Job>(`${this.apiUrl}/${id}`, formData, {
      headers: this.getHeaders(true)
    });
  }

  deleteJob(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`, {
      headers: this.getHeaders()
    });
  }
}
