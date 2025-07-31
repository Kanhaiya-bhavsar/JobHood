import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router'; // ✅ Required for routerLink

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [
    CommonModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    RouterModule // ✅ Add this so routerLink works
  ],
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  isLoggedIn = false;
  userName: string = '';
  userRole: string = '';

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.loadUserFromLocalStorage();
  }

  loadUserFromLocalStorage(): void {
    const token = localStorage.getItem('token');
    const name = localStorage.getItem('name');
    const role = localStorage.getItem('role');

    this.isLoggedIn = !!token && !!name && !!role;
    this.userName = name ?? '';
    this.userRole = role ?? '';
  }

  logout(): void {
    localStorage.clear();
    this.isLoggedIn = false;
    this.userName = '';
    this.userRole = '';
    this.router.navigate(['/login']);
  }
}
