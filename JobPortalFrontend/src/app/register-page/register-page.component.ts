import { Component, OnInit, inject } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RegisterService } from '../services/register.service';
import { Register } from '../Dto/register';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

@Component({
  selector: 'app-register-page',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatCardModule,
    MatSelectModule,
    MatSnackBarModule
  ],
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css'],
})
export class RegisterPageComponent implements OnInit {
  registerService = inject(RegisterService);
  router = inject(Router);
  formBuilder = inject(FormBuilder);
  snackBar = inject(MatSnackBar);

  registerForm!: FormGroup;
  isSubmitting = false;

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      name: ['', Validators.required],
      username: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      roles: ['User']
    });
  }

  onRegister() {
    if (this.registerForm.invalid) return;

    this.isSubmitting = true;

    const formValue = this.registerForm.value;

    const requestData: Register = {
      Name: formValue.name.trim(),
      Username: formValue.username.trim(),
      Password: formValue.password,
      Roles: [formValue.roles]
    };

    console.log('Calling Register API with:', requestData);

    this.registerService.registerUser(requestData).subscribe({
      next: (res) => {
        console.log('Registration success:', res);
        this.snackBar.open('User registered successfully!', 'Close', { duration: 3000 });
        this.router.navigate(['/']);
        this.isSubmitting = false;
      },
      error: (err) => {
        console.error('Registration error:', err);
        this.snackBar.open(
          `Registration failed: ${err?.error?.message || 'Check backend or CORS settings.'}`,
          'Close',
          { duration: 4000 }
        );
        this.isSubmitting = false;
      }
    });
  }
}
