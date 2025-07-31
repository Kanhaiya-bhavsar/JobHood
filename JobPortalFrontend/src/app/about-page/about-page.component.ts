import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import {NavbarComponent} from '../navbar/navbar.component'

@Component({
  selector: 'app-about-page',
  imports: [  CommonModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
  NavbarComponent],
  templateUrl: './about-page.component.html',
  styleUrl: './about-page.component.css'
})
export class AboutPageComponent {

}
