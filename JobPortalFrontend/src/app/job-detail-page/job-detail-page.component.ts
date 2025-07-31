import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { JobService } from '../Services/job.service'; // adjust path
import { Job } from '../Dto/job'; // adjust path
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import {NavbarComponent} from '../navbar/navbar.component';
import { RouterModule } from '@angular/router';
@Component({
  selector: 'app-job-detail-page',
  standalone: true,
  imports: [ CommonModule,NavbarComponent,RouterModule,
    MatCardModule,
    MatButtonModule],
  templateUrl: './job-detail-page.component.html',
  styleUrl: './job-detail-page.component.css'
})



export class JobDetailPageComponent implements OnInit {

  job: Job | null = null;

  private route = inject(ActivatedRoute);
  private jobService = inject(JobService);

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (id) {
      this.getJobById(id);
    }
  }

  getJobById(id: number): void {
    this.jobService.getJobById(id).subscribe({
      next: (data: Job) => this.job = data,
      error: (err:any) => console.error('Error fetching job:', err)
    });
  }

  applyNow(): void {
    if (this.job?.applyLink) {
      window.open(this.job.applyLink, '_blank');
    }
  }
}
