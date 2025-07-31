import { inject, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Job } from '../Dto/job'; // Adjust path as needed
import { JobService } from '../Services/job.service'; 
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import {NavbarComponent} from '../navbar/navbar.component'
@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    NavbarComponent
  ],
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'] // ✅ fixed
})
export class HomePageComponent implements OnInit { // ✅ fixed

  jobs: Job[] = [];

  // ✅ Inject services using inject()
  private jobService = inject(JobService);
  private router = inject(Router);
  userRole: string = '';

  ngOnInit(): void {
    this.getAllJobs();
    this.loadUserFromLocalStorage();
  }

  loadUserFromLocalStorage(): void {
    const role = localStorage.getItem('role');
    this.userRole = role ?? '';
  }

  getAllJobs(): void {
    this.jobService.getAllJob().subscribe({
      next: (data: Job[]) => {
        this.jobs = data;
      },
      error: (err:any) => {
        console.error('Error fetching jobs:', err);
      }
    });
  }

  goToJobDetail(jobId: number): void {
    this.router.navigate(['/Home', jobId]); // ✅ adjust route path as per your routing
  }

  goToAdmin(jobId: number): void {
    this.router.navigate(['/adminPanel', jobId]); // ✅ adjust route path as per your routing
  }
}
