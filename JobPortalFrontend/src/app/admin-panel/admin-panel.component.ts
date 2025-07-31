import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {NavbarComponent} from '../navbar/navbar.component'
import { AdminService } from '../Services/admin.service';
import { JobService } from '../Services/job.service';
import { Job } from '../Dto/job';
import { RouterModule } from '@angular/router';
@Component({
  selector: 'app-admin-panel',
  standalone: true,
  imports: [NavbarComponent,RouterModule,
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})
export class AdminPanelComponent implements OnInit {
  jobForm!: FormGroup;
  jobId: string = '0';
  logoFile!: File;

  private fb = inject(FormBuilder);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private adminService = inject(AdminService);
  private jobService = inject(JobService);

  ngOnInit(): void {
    this.jobId = this.route.snapshot.paramMap.get('id') || '0';

    this.jobForm = this.fb.group({
      jobId: [0],
      jobTitle: ['', Validators.required],
      experience: ['', Validators.required],
      ctc: ['', Validators.required],
      applyLink: ['', Validators.required],
      applyType: ['', Validators.required],
      location: ['', Validators.required],
      domain: ['', Validators.required],
      qualification: ['', Validators.required],
      jobType: ['', Validators.required],
      jobCompanyName: ['', Validators.required],
      jobDescription: ['', Validators.required],
      companyDescription: ['', Validators.required],
      rolesAndResponsibility: ['', Validators.required],
      educationAndSkills: ['', Validators.required],
      companyLogoUrl: [null],
      addedDate: [new Date(), Validators.required],
      expireDate: [new Date(), Validators.required]
    });

    if (this.jobId !== '0') {
      this.loadJobById();
    }
  }

  loadJobById(): void {
    this.jobService.getJobById(+this.jobId).subscribe((job: Job) => {
      job.addedDate = job.addedDate ? new Date(job.addedDate) : new Date();
      job.expireDate = job.expireDate ? new Date(job.expireDate) : new Date();
      this.jobForm.patchValue(job);
    });
  }

  onFileChange(event: any): void {
    if (event.target.files.length > 0) {
      this.logoFile = event.target.files[0];
    }
  }

  onSubmit(): void {
    if (this.jobForm.invalid) {
      this.jobForm.markAllAsTouched();
      return;
    }

    const fv = this.jobForm.value;
    const formData = new FormData();
    formData.append('JobId', fv.jobId?.toString() ?? '0');

    formData.append('JobTitle', fv.jobTitle ?? '');
    formData.append('Experience', fv.experience ?? '');
    formData.append('Ctc', fv.ctc ?? '');
    formData.append('ApplyLink', fv.applyLink ?? '');
    formData.append('ApplyType', fv.applyType ?? '');
    formData.append('Location', fv.location ?? '');
    formData.append('Domain', fv.domain ?? '');
    formData.append('Qualification', fv.qualification ?? '');
    formData.append('JobType', fv.jobType ?? '');
    formData.append('JobCompanyName', fv.jobCompanyName ?? '');
    formData.append('JobDescription', fv.jobDescription ?? '');
    formData.append('CompanyDescription', fv.companyDescription ?? '');
    formData.append('RolesAndResponsibility', fv.rolesAndResponsibility ?? '');
    formData.append('EducationAndSkills', fv.educationAndSkills ?? '');
    formData.append('AddedDate', new Date(fv.addedDate).toISOString());
    formData.append('ExpireDate', new Date(fv.expireDate).toISOString());

    if (this.logoFile) {
      formData.append('CompanyLogoUrl', this.logoFile, this.logoFile.name);
    }

    const request = this.jobId === '0'
      ? this.adminService.addJob(formData)
      : this.adminService.updateJob(+this.jobId, formData);

    request.subscribe({
      next: () => {
        alert(`✅ Job ${this.jobId === '0' ? 'added' : 'updated'} successfully!`);
        this.router.navigate(['/']);
      },
      error: (err) => {
        console.error('❌ Error saving job:', err);
        alert('Something went wrong while saving the job!');
      }
    });
  }

  onDelete(): void {
   
      this.adminService.deleteJob(+this.jobId).subscribe(() => {
       
        this.router.navigate(['/']);
      });
    
  }

  get f() {
    return this.jobForm.controls;
  }
}
